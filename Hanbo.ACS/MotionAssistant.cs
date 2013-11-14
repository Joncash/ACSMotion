using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hanbo.ACS
{
	public delegate void RunPEGCompletedDelegate(object sender, RunWorkerCompletedEventArgs e);
	public class MotionAssistant
	{
		public event RunPEGCompletedDelegate On_PEGCompleted;
		private MotionController _motionController;
		private BackgroundWorker _bgWorker;
		public MotionAssistant(MotionController motionController)
		{
			_motionController = motionController;
			_bgWorker = new BackgroundWorker();
			_bgWorker.WorkerSupportsCancellation = true;
			_bgWorker.WorkerReportsProgress = true;
			_bgWorker.DoWork += _bgWorker_DoWork;
			_bgWorker.ProgressChanged += _bgWorker_ProgressChanged;
			_bgWorker.RunWorkerCompleted += _bgWorker_RunWorkerCompleted;
		}

		void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (On_PEGCompleted != null)
			{
				On_PEGCompleted(sender, e);
			}
			//throw new NotImplementedException();
		}

		void _bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			//throw new NotImplementedException();
		}

		void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			var worker = sender as BackgroundWorker;
			while (true)
			{
				if (worker.CancellationPending)
				{
					e.Cancel = true;
					break;
				}
				else
				{
					//ToRunSomeThing
					run();
					break;
				}
			}
		}
		private void run()
		{
			//=============================================variable
			int AX, AY;
			double TRIGGER_UM;
			double LINEAR_RESL;
			int MMM;
			double START_PEG_POS, END_PEG_POS;
			double PEG_DIST;
			double TRIGGER_WIDTH, TRIGGER_COUNT;

			//=============================================Common Settings
			AX = 0;	//machine of X
			AY = 1;// machine of Y
			MMM = 10000;//
			TRIGGER_UM = 7; //um, Camera pixelSize
			TRIGGER_WIDTH = 0.002; //ms, exposure time
			LINEAR_RESL = 0.1; // 不知道幹嘛用
			TRIGGER_COUNT = TRIGGER_UM / LINEAR_RESL;

			//============================================== X Axis Settings
			double START_X_POS, X_DIST;
			double xWayMoveHalfPixels = XMovePixels / 2;
			X_DIST = xWayMoveHalfPixels * TRIGGER_UM / 1000 * MMM;//Pixel 轉換為多少 Cout, 即為移動距離

			START_X_POS = _motionController.FPOS(AX);// X 的起始位置
			_motionController.SETCONF(205, AX, 256.0);
			_motionController.EnableAxis(Axis.X);
			var vel = 10 * MMM;
			var acc = 10 * vel;
			var dec = acc;
			var jerk = 10 * acc;
			_motionController.VEL(AX, vel);
			_motionController.ACC(AX, acc);
			_motionController.DEC(AX, dec);
			_motionController.JERK(AX, jerk);

			//============================================== Y Axis PEG Settings
			_motionController.SETCONF(205, AY, 256.0);
			_motionController.EnableAxis(Axis.Y);
			_motionController.VEL(AY, vel);
			_motionController.ACC(AY, acc);
			_motionController.DEC(AY, dec);
			_motionController.JERK(AY, jerk);
			PEG_DIST = YMovePixels * TRIGGER_UM / 1000 * MMM;

			double yWayMoveHalfPixels = YMovePixels / 2;
			double Y_DIST = yWayMoveHalfPixels * TRIGGER_UM / 1000 * MMM;//Pixel 轉換為多少 Cout, 即為移動距離

			double yMoveTotalDistance = 0.0;
			for (int y = 0; y < YLoop; y++)
			{
				if (y > 0)
				{
					yMoveTotalDistance += Y_DIST;

					// Y Move Half
					_motionController.PTP_RE(AY, Y_DIST);
					Thread.Sleep(200);
				}
				yMoveAndBack(AY, TRIGGER_UM, PEG_DIST, TRIGGER_WIDTH, TRIGGER_COUNT, out START_PEG_POS, out END_PEG_POS);
				double xMoveTotalDistance = 0.0;
				for (int x = 0; x < XLoop; x++)
				{
					//X Move Half
					_motionController.PTP_RE(AX, X_DIST);
					xMoveTotalDistance += X_DIST;
					yMoveAndBack(AY, TRIGGER_UM, PEG_DIST, TRIGGER_WIDTH, TRIGGER_COUNT, out START_PEG_POS, out END_PEG_POS);

				}
				//X back to original
				_motionController.PTP_RE(AX, -xMoveTotalDistance);
			}
			//Y back to original
			_motionController.PTP_RE(AY, -yMoveTotalDistance);
		}
		private int YLoop;
		private int XLoop;
		private double YMovePixels;
		private double XMovePixels;
		public void RunPEG(int yWayLoop, int xWayLoop, double yWayMovePixel, double xWayMovePixel)
		{
			YLoop = yWayLoop;
			XLoop = xWayLoop;
			YMovePixels = yWayMovePixel;
			XMovePixels = xWayMovePixel;
			if (!_bgWorker.IsBusy)
			{
				_bgWorker.RunWorkerAsync();
			}

		}
		private void yMoveAndBack(int AY, double TRIGGER_UM, double PEG_DIST, double TRIGGER_WIDTH, double TRIGGER_COUNT, out double START_PEG_POS, out double END_PEG_POS)
		{
			//yMove
			START_PEG_POS = _motionController.FPOS(AY);
			END_PEG_POS = START_PEG_POS + PEG_DIST;
			_motionController.PEG_I_S(AY, TRIGGER_WIDTH, START_PEG_POS, TRIGGER_COUNT, END_PEG_POS);

			_motionController.PEG_GoAndBack(AY, PEG_DIST);
		}
	}
}
