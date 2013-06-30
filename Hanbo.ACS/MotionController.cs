using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace Hanbo.ACS
{
	public class MotionController
	{
		private static Logger _log = NLog.LogManager.GetCurrentClassLogger();
		private BackgroundWorker _bgworker = new BackgroundWorker();
		private BackgroundWorker _bgworkerForAllAxis = new BackgroundWorker();
		private SPIIPLUSCOM660Lib.Channel _ch;
		public event AxisEnableEventHandler On_AxisEnabled;
		public event XAxisMoveEventHandler On_XAxisMoved;
		public event YAxisMoveEventHandler On_YAxisMoved;
		public event ZAxisMoveEventHandler On_ZAxisMoved;
		public event AxisHaltEventHandler On_AxisHalted;

		public event ErrorEventHandler On_ErrorHandler;
		public event InitMotionEventHandler On_MotionInited;
		public event DisableAxisAllMotionEventHandler On_AllAxisDisabled;
		public event ResetEventHandler On_ResetPositioned;
		private const double m_VelocityUnit = 50000;

		/// <summary>
		/// initialize
		/// </summary>
		public MotionController()
		{
			//init backgroundworker
			_bgworker.WorkerReportsProgress = true;
			_bgworker.WorkerSupportsCancellation = true;
			_bgworker.DoWork += _bgworker_DoWork;
			_bgworker.ProgressChanged += _bgworker_ProgressChanged;
			_bgworker.RunWorkerCompleted += _bgworker_RunWorkerCompleted;

			_bgworkerForAllAxis.WorkerReportsProgress = true;
			_bgworkerForAllAxis.WorkerSupportsCancellation = true;
			_bgworkerForAllAxis.DoWork += _bgworkerForAxis_DoWork;
			_bgworkerForAllAxis.ProgressChanged += _bgworkerForAxis_ProgressChanged;
			_bgworkerForAllAxis.RunWorkerCompleted += _bgworkerForAxis_RunWorkerCompleted;
		}
		
		void _bgworkerForAxis_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			throw new NotImplementedException();
		}
		void _bgworkerForAxis_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (On_XAxisMoved != null)
			{
				On_XAxisMoved(null, _ch.GetFPosition((int)Axis.X));
			}

			if (On_YAxisMoved != null)
			{
				On_YAxisMoved(null, _ch.GetFPosition((int)Axis.Y));
			}

			if (On_ZAxisMoved != null)
			{
				On_ZAxisMoved(null, _ch.GetFPosition((int)Axis.Z));
			}


		}

		/// <summary>
		/// 不斷的與機器取得目前各軸的Position之背景處理
		/// </summary>
		public void StartDetection()
		{
			if (!_bgworkerForAllAxis.IsBusy)
				_bgworkerForAllAxis.RunWorkerAsync();
		}
		void _bgworkerForAxis_DoWork(object sender, DoWorkEventArgs e)
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
					worker.ReportProgress(1);
					Thread.Sleep(500);
				}
			}
		}

		/// <summary>
		/// 與機器進行連線溝通
		/// </summary>
		/// <param name="isSimulator">是否啟動模擬器，若非啟用模擬器，則依乙太網路與實體機器進行連線。</param>
		public void Initialize(bool isSimulator)
		{
			try
			{
				_ch = new SPIIPLUSCOM660Lib.Channel();
				if (isSimulator)
				{
					_ch.OpenCommDirect();
				}
				else
				{
					var protocol = _ch.ACSC_SOCKET_DGRAM_PORT;
					_ch.OpenCommEthernet("10.0.0.100", protocol);
				}

				_ch.RegisterEmergencyStop();
				if (On_MotionInited != null)
				{
					On_MotionInited(null, "Initialize Complete...");
				}


			}
			catch (COMException ex)
			{
				On_ErrorHandler(null, ex);
				_log.Error("Initialize, Error={0}", ex.StackTrace);
			}
		}

		public void Initialize()
		{
			Initialize(false);
		}

		void _bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled)
			{

			}
			else
			{

			}
			//throw new NotImplementedException();
		}

		/// <summary>
		/// 當軸在移動時，不斷取得正在移動的軸之Position
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void _bgworker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			Axis[] axisList = (Axis[])e.UserState;
			foreach (var axis in axisList)
			{
				switch (axis)
				{
					case Axis.X:
						if (On_XAxisMoved != null)
						{
							On_XAxisMoved(null, _ch.GetFPosition((int)axis));
						}
						break;
					case Axis.Y:
						if (On_YAxisMoved != null)
						{
							On_YAxisMoved(null, _ch.GetFPosition((int)axis));
						}
						break;
					case Axis.Z:
						if (On_ZAxisMoved != null)
						{
							On_ZAxisMoved(null, _ch.GetFPosition((int)axis));
						}
						break;

					default:
						break;
				}
			}


		}

		void _bgworker_DoWork(object sender, DoWorkEventArgs e)
		{
			var worker = sender as BackgroundWorker;
			int index = 10;

			while (true)
			{
				if (worker.CancellationPending)
				{
					e.Cancel = true;
					break;
				}
				else
				{
					index++;
					worker.ReportProgress(index, e.Argument);
					Thread.Sleep(200);
				}
			}

		}
		
		/// <summary>
		/// 指定某一軸，呈顯激活狀態，並等待電機指令的狀態
		/// </summary>
		/// <param name="axis">指定某一軸</param>
		public void EnableAxis(Axis axis)
		{
			try
			{
				int axisInt = (int)axis;
				_ch.Enable(axisInt);
				_ch.WaitMotorEnabled(axisInt, 1, 5000);

				while (true)
				{
					if (_ch.GetMotorState(axisInt) == 536870929)
						break;
				}

				if (On_AxisEnabled != null)
				{
					On_AxisEnabled(null, new EnabledResultViewModel() { Axis = axis, Message = "Success" });
				}
			}
			catch (COMException ex)
			{
				On_ErrorHandler(null, ex);
				_log.Error("EnableAxis, Error={0}", ex.StackTrace);
			}
		}

		/// <summary>
		/// 單軸移動
		/// </summary>
		/// <param name="axis">移動哪軸</param>
		/// <param name="dir">移動方向(正向移動或負向移動)</param>
		/// <param name="velocity">移動速度</param>
		public void SingleAxisMove(Axis axis, Direction dir, int velocity)
		{
			try
			{
				_ch.Jog(_ch.ACSC_AMF_VELOCITY, (int)axis, (int)dir * velocity);
			}
			catch (COMException ex)
			{
				On_ErrorHandler(null, ex);
				_log.Error("SingleAxisMove, Error={0}", ex.StackTrace);
			}
		}

		/// <summary>
		/// 多軸移動
		/// </summary>
		/// <param name="axiss">移動若干軸，依陣列表示</param>
		/// <param name="dirs">表明若干軸，各自移動的方向(正向移動或負向移動)，依陣列表示</param>
		/// <param name="velocity">移動若干軸之速度</param>
		public void MultipleAxisMove(Axis[] axiss, Direction[] dirs, int velocity)
		{
			try
			{
				int[] axisList = new int[axiss.Length + 1];
				for (int i = 0; i < axiss.Length; i++)
				{
					axisList[i] = (int)axiss[i];
				}
				axisList[axiss.Length] = -1;
				var dirList = dirs.Select(s => (int)s).ToArray();
				_ch.JogM(_ch.ACSC_AMF_VELOCITY, axisList, dirList, velocity);
			
			}
			catch (COMException ex)
			{
				On_ErrorHandler(null, ex);
				_log.Error("MultipleAxisMove, Error={0}", ex.StackTrace);
			}
		}

		/// <summary>
		/// 停止若干軸之移動
		/// </summary>
		/// <param name="axisList">表明要停止移動的若干軸，依陣列表示</param>
		public void AxisHalf(Axis[] axisList)
		{
			try
			{				
				if (axisList.Length == 1)
				{
					_ch.Halt((int)axisList[0]);
				}
				else
				{
					int[] axisArray = new int[axisList.Length + 1];
					for (int i = 0; i < axisList.Length; i++)
					{
						axisArray[i] = (int)axisList[i];
					}
					axisArray[axisList.Length] = -1;
					_ch.HaltM(axisArray);
				}

				if (On_AxisHalted != null)
				{
					On_AxisHalted(null, new HaltedResultViewModel() { AxisList = axisList, Message = "Success" });
				}
				
			}
			catch (COMException ex)
			{
				On_ErrorHandler(null, ex);
				_log.Error("AxisHalf, Error={0}", ex.StackTrace);
			}
		}

		/// <summary>
		/// 取消軸正在移動時，不斷取得目前的Position
		/// </summary>
		public void StopPositionDetection()
		{
			try
			{
				_bgworker.CancelAsync();
			}
			catch (Exception ex)
			{
				_log.Error("CancelSigleDisplayPositionBackgroupWork, Error={0}", ex.StackTrace);
			}
			
		}

		/// <summary>
		/// 關閉所有的軸。切斷與機器下達指令之連接
		/// </summary>
		public void ServoOff()
		{
			try
			{
				_ch.DisableAll();

				if (On_AllAxisDisabled != null)
				{
					On_AllAxisDisabled(null, "Servo Off Complete...");
				}
			}
			catch (COMException ex)
			{
				On_ErrorHandler(null, ex);
				_log.Error("ServoOff, Error={0}", ex.StackTrace);
			}
		}

		/// <summary>
		/// 歸零。將各軸，移至「0」之位置
		/// </summary>
		public void AllAxisBackToZero()
		{
			try
			{
				_ch.RunBuffer(3);  //'3:      A()
				_ch.RunBuffer(2);  //'2:      Y()
				_ch.RunBuffer(1); //'1:      X() 
				_ch.WaitProgramEnd(3, 40000);
				_ch.WaitProgramEnd(2, 40000);
				_ch.WaitProgramEnd(1, 40000);

				if (On_ResetPositioned != null)
				{
					On_ResetPositioned(null, "Reset Complete...");
				}
			}
			catch (COMException ex)
			{
				On_ErrorHandler(null, ex);
				_log.Error("Reset, Error={0}", ex.StackTrace);
			}
		}
	}
}
