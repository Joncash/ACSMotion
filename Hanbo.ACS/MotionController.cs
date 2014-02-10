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
		private string _motionControllerIP = "10.0.0.100";
		//private BackgroundWorker _bgworker = new BackgroundWorker();
		private BackgroundWorker _bgworkerForDetectAxisPostion = new BackgroundWorker();
		private SPIIPLUSCOM660Lib.Channel _ch;
		private const double m_VelocityUnit = 50000;
		private int _waitTimeout = 40000;
		private int _positionDetectionSleepTime = 500;

		private int _axisEnabledCode = 536870929;

		public event AxisEnableEventHandler On_AxisEnabled;
		public event XAxisMoveEventHandler On_XAxisMoved;
		public event YAxisMoveEventHandler On_YAxisMoved;
		public event ZAxisMoveEventHandler On_ZAxisMoved;
		public event AxisHaltEventHandler On_AxisHalted;

		public event ErrorEventHandler On_ErrorHandler;
		public event InitMotionEventHandler On_MotionInited;
		public event DisableAxisAllMotionEventHandler On_AllAxisDisabled;
		public event ResetEventHandler On_ResetPositioned;
		private bool _simulate = false;


		/// <summary>
		/// initialize, 預設為直接連線至控制器, Motion Controller IP, 預設為 10.0.0.100
		/// </summary>
		public MotionController()
		{
			//init backgroundworker
			init();
		}

		/// <summary>
		/// MotionController
		/// </summary>
		/// <param name="motionControllerIP">Motion Controller IP, 預設為 10.0.0.100</param>
		public MotionController(string motionControllerIP)
		{
			_motionControllerIP = motionControllerIP;
			init();
		}

		public MotionController(bool _simulate)
		{
			// TODO: Complete member initialization
			this._simulate = _simulate;
			init();
		}

		private void init()
		{
			//_bgworker.WorkerReportsProgress = true;
			//_bgworker.WorkerSupportsCancellation = true;
			//_bgworker.DoWork += _bgworker_DoWork;
			//_bgworker.ProgressChanged += _bgworker_ProgressChanged;
			//_bgworker.RunWorkerCompleted += _bgworker_RunWorkerCompleted;

			//偵測移動
			_bgworkerForDetectAxisPostion.WorkerReportsProgress = true;
			_bgworkerForDetectAxisPostion.WorkerSupportsCancellation = true;
			_bgworkerForDetectAxisPostion.DoWork += _bgworkerForAxis_DoWork;
			_bgworkerForDetectAxisPostion.ProgressChanged += _bgworkerForAxis_ProgressChanged;
			_bgworkerForDetectAxisPostion.RunWorkerCompleted += _bgworkerForAxis_RunWorkerCompleted;
		}

		#region Background Methods, for 偵測位置
		void _bgworkerForAxis_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//ToDO
			//throw new NotImplementedException();
		}
		void _bgworkerForAxis_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			var axis = e.ProgressPercentage;
			var position = (double)e.UserState;
			switch (axis)
			{
				case (int)Axis.X:
					if (On_XAxisMoved != null)
					{
						On_XAxisMoved(null, position);
					}
					break;
				case (int)Axis.Y:
					if (On_YAxisMoved != null)
					{
						On_YAxisMoved(null, position);
					}
					break;
				case (int)Axis.Z:
					if (On_ZAxisMoved != null)
					{
						On_ZAxisMoved(null, position);
					}
					break;
			}
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

					try
					{
						var yPosition = _ch.GetFPosition((int)Axis.Y);
						worker.ReportProgress((int)Axis.Y, yPosition);
						//var xPosition = _ch.GetFPosition((int)Axis.X);
						//worker.ReportProgress((int)Axis.X, xPosition);
						//var zPosition = _ch.GetFPosition((int)Axis.Z);
						//worker.ReportProgress(1);
					}
					catch (Exception ex)
					{
					}
					finally
					{
						Thread.Sleep(_positionDetectionSleepTime);
					}
				}
			}
		}
		#endregion

		/// <summary>
		/// 不斷的與機器取得目前各軸的Position之背景處理
		/// </summary>
		public void StartDetection()
		{
			if (!_bgworkerForDetectAxisPostion.IsBusy)
				_bgworkerForDetectAxisPostion.RunWorkerAsync();
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
					_ch.OpenCommEthernet(_motionControllerIP, protocol);
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
			Initialize(_simulate);
		}

		//void _bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		//{
		//	if (e.Cancelled)
		//	{

		//	}
		//	else
		//	{

		//	}
		//	//throw new NotImplementedException();
		//}

		/// <summary>
		/// 當軸在移動時，不斷取得正在移動的軸之Position
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//void _bgworker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		//{
		//	//Axis[] axisList = (Axis[])e.UserState;
		//	//foreach (var axis in axisList)
		//	//{
		//	//	switch (axis)
		//	//	{
		//	//		case Axis.X:
		//	//			if (On_XAxisMoved != null)
		//	//			{
		//	//				On_XAxisMoved(null, _ch.GetFPosition((int)axis));
		//	//			}
		//	//			break;
		//	//		case Axis.Y:
		//	//			if (On_YAxisMoved != null)
		//	//			{
		//	//				On_YAxisMoved(null, _ch.GetFPosition((int)axis));
		//	//			}
		//	//			break;
		//	//		case Axis.Z:
		//	//			if (On_ZAxisMoved != null)
		//	//			{
		//	//				On_ZAxisMoved(null, _ch.GetFPosition((int)axis));
		//	//			}
		//	//			break;

		//	//		default:
		//	//			break;
		//	//	}
		//	//}


		//}

		//void _bgworker_DoWork(object sender, DoWorkEventArgs e)
		//{
		//	var worker = sender as BackgroundWorker;
		//	int index = 10;

		//	while (true)
		//	{
		//		if (worker.CancellationPending)
		//		{
		//			e.Cancel = true;
		//			break;
		//		}
		//		else
		//		{
		//			index++;
		//			worker.ReportProgress(index, e.Argument);
		//			Thread.Sleep(200);
		//		}
		//	}

		//}

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
					if (_ch.GetMotorState(axisInt) == _axisEnabledCode)
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
		public bool GetAxisEnableStatus(Axis axis)
		{
			int axisInt = (int)axis;
			var enabled = _ch.GetMotorState(axisInt) == _axisEnabledCode;
			var msg = (enabled) ? "Success" : "Fail";
			if (On_AxisEnabled != null)
			{
				On_AxisEnabled(null, new EnabledResultViewModel() { Axis = axis, Message = msg });
			}
			return enabled;
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
				//_bgworker.CancelAsync();
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
				_ch.WaitProgramEnd(3, _waitTimeout);
				_ch.WaitProgramEnd(2, _waitTimeout);
				_ch.WaitProgramEnd(1, _waitTimeout);

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
		public void GoMeasurePosition()
		{
			_ch.RunBuffer(8);
			_ch.WaitProgramEnd(8, _waitTimeout);
		}

		/// <summary>
		/// Axis X = 1, Axis Y =2, Axis Z = 3
		/// </summary>
		/// <param name="axis"></param>
		public void AxisBackToZero(int axis)
		{
			try
			{
				_ch.RunBuffer(axis);
				_ch.WaitProgramEnd(axis, _waitTimeout);
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

		/// <summary>
		/// GetFPosition
		/// </summary>
		/// <param name="axis">軸</param>
		/// <returns></returns>
		public double FPOS(int axis)
		{
			return _ch.GetFPosition(axis);
		}

		/// <summary>
		/// SETCONF
		/// </summary>
		/// <param name="key"></param>
		/// <param name="index"></param>
		/// <param name="value"></param>
		public void SETCONF(int key, int index, double value)
		{
			_ch.SetConf(key, index, value);
		}

		/// <summary>
		/// VEL (Velocity)
		/// </summary>
		/// <param name="axis"></param>
		/// <param name="value"></param>
		public void VEL(int axis, double value)
		{
			_ch.SetVelocity(axis, value);
		}

		/// <summary>
		/// ACC, Acceleration
		/// </summary>
		/// <param name="axis"></param>
		/// <param name="value"></param>
		public void ACC(int axis, double value)
		{
			_ch.SetAcceleration(axis, value);
		}

		/// <summary>
		/// DEC, DeAcceleration
		/// </summary>
		/// <param name="axis"></param>
		/// <param name="value"></param>
		public void DEC(int axis, double value)
		{
			_ch.SetDeceleration(axis, value);
		}

		/// <summary>
		/// JERK
		/// </summary>
		/// <param name="axis"></param>
		/// <param name="value"></param>
		public void JERK(int axis, double value)
		{
			_ch.SetJerk(axis, value);
		}

		public void PEG_I_S(int axis, double width, double firstPoint, double interval, double lastPoint)
		{
			var flags = _ch.ACSC_AMF_SYNCHRONOUS;
			PEG_I(flags, axis, width, firstPoint, interval, lastPoint);
		}
		public void PEG_I(int flags, int axis, double width, double firstPoint, double interval, double lastPoint)
		{
			_ch.PegInc(flags, axis, width, firstPoint, interval, lastPoint, _ch.ACSC_NONE, _ch.ACSC_NONE);
			_ch.EndSequence(axis);
		}

		/// <summary>
		/// Point To Point With Parameter R , E
		/// R means the Point value is relative to the end point of the previous motion.
		/// E means Wait for motion termination before executing next command
		/// In this function, wait for motion termination with 2000ms timeout
		/// </summary>
		/// <param name="axis"></param>
		/// <param name="point"></param>
		public void PTP_RE(int axis, double point)
		{
			int flags = _ch.ACSC_AMF_RELATIVE;
			try
			{
				_ch.ToPoint(flags, axis, point);
				//_ch.WaitMotionEnd(axis, 200000);
				_ch.EndSequence(axis);
				_ch.WaitMotionEnd(axis, 20000);
			}
			catch (Exception ex)
			{
				//ToDo
			}
		}
		public void PEG_GoAndBack(int axis, double point)
		{
			/* 不工作*/
			var MMM = 10000;//
			var decreaseSpeed = 1;
			var _speedBaseRate = 100;
			var vel = _speedBaseRate * MMM * decreaseSpeed;
			var acc = _speedBaseRate * vel;
			var dec = acc;
			var jerk = _speedBaseRate * acc;

			int flags = _ch.ACSC_AMF_RELATIVE;
			_ch.ToPoint(flags, axis, point);
			//_ch.WaitMotionEnd(axis, 200000);
			ACC(axis, acc);
			DEC(axis, dec);
			JERK(axis, jerk);
			_ch.ExtToPoint(_ch.ACSC_AMF_VELOCITY | _ch.ACSC_AMF_RELATIVE, axis, -point, vel, vel);
			//_ch.ToPoint(flags, axis, -point);
			//_ch.WaitMotionEnd(axis, 200000);
			_ch.EndSequence(axis);
			_ch.WaitMotionEnd(axis, 200000);

		}

		public void PTP_E(int axis, double point)
		{
			int flags = _ch.ACSC_NONE;
			flags = _ch.ACSC_AMF_RELATIVE;
			_ch.ToPoint(flags, axis, point);
			//_ch.WaitMotionEnd(axis, 200000);
			_ch.EndSequence(axis);
			_ch.WaitMotionEnd(axis, 200000);
		}



		public void RemoveAllRegisterEvent()
		{
			On_AxisEnabled = null;
			On_XAxisMoved = null;
			On_YAxisMoved = null;
			On_ZAxisMoved = null;
			On_ErrorHandler = null;
			On_AllAxisDisabled = null;
			On_MotionInited = null;
			On_ResetPositioned = null;
		}
	}
}
