using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hanbo.ACS;
using NLog;
using Hanbo.Camera;
using HalconDotNet;
using Hanbo.Models;
using Hanbo.PEG.Helper;
using Hanbo.System.SingleInstance;
using Hanbo.Helper;
using System.IO;

namespace MotionApp
{
	delegate void SetTextCallback(string text);
	//PEG
	public delegate void RequestMergeImageDelegate();
	//END PEG

	public partial class MotionForm : Form
	{
		#region Delegates

		/// <summary>
		/// 合併影像 Delegate
		/// </summary>
		public RequestMergeImageDelegate RequestMergeImage;
		#endregion

		#region PEG public methods
		/// <summary>
		/// 送出要求啟動 PEG 訊號
		/// </summary>
		/// <param name="x">x way length (um)</param>
		/// <param name="y">y way length (um)</param>
		public void RequestPEGStart(int x, int y)
		{
			var width = x;
			var height = y;
			MoveViewModel = PEGCalculator.GetPEGMoveModel(width, height, CameraSpec, true);
			if (_motionAsit != null)
			{
				_motionAsit.RunPEG(MoveViewModel.YMoveLoop, MoveViewModel.XMoveLoop, MoveViewModel.YMovePixel
					, MoveViewModel.XMovePixel);
			}
		}
		#endregion

		#region PEG private methods
		private void _motionAsit_On_PEGCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (RequestMergeImage != null)
			{
				RequestMergeImage();
			}
		}
		#endregion

		#region private variables
		private static Logger _log = NLog.LogManager.GetCurrentClassLogger();
		private MotionController _motionController;
		private MotionAssistant _motionAsit;
		private LineScan _lineScan;// = new LineScan();
		#endregion

		#region 建構子
		public MotionForm()
		{
			InitializeComponent();
			TableObjectXTextBox.Enabled = false;
			//initLineScan();
			CameraSpec = ConfigurationHelper.GetCameraSpec();

			initilizeUIEnableStatus();
			initializeMotionController();
		}
		#endregion

		#region Form Events
		private void Form1_Load(object sender, EventArgs e)
		{
			XPAxis_button.MouseUp += XAxis_button_MouseUp;
			//_motionController.Initialize(false);
		}
		private void Form1_Shown(object sender, EventArgs e)
		{
			//enableAllAxis();
			enableYAxisOnly();
			BackgroundWorker worker = new BackgroundWorker();
			worker.DoWork += (caller, arg) =>
			{
				//_motionController.AllAxisBackToZero();
				//moveToMeasurePosition();
			};
			worker.RunWorkerAsync();
		}
		#endregion

		#region private methods


		private void initilizeUIEnableStatus()
		{
			XNYPAxis_button.Enabled = false;
			YPAxis_button.Enabled = false;
			XPYPAxis_button.Enabled = false;
			XPAxis_button.Enabled = false;
			XPYNAxis_button.Enabled = false;
			YNAxis_button.Enabled = false;
			XNYNAxis_button.Enabled = false;
			XNAxis_button.Enabled = false;
			resetPostionBtn.Enabled = false;
			ZPAxis_button.Enabled = false;
			ZNAxis_button.Enabled = false;
		}
		private void enableYAxisOnly()
		{
			if (!_motionController.GetAxisEnableStatus(Axis.Y))
				_motionController.EnableAxis(Axis.Y);

			toolStripStatusLabel.Text = "Done";
		}
		private void enableAllAxis()
		{
			if (!_motionController.GetAxisEnableStatus(Axis.X))
				_motionController.EnableAxis(Axis.X);

			if (!_motionController.GetAxisEnableStatus(Axis.Y))
				_motionController.EnableAxis(Axis.Y);

			if (!_motionController.GetAxisEnableStatus(Axis.Z))
				_motionController.EnableAxis(Axis.Z);
			toolStripStatusLabel.Text = "Done";
		}
		private void MultipleAxisMove(Direction xDir, Direction yDir)
		{
			yAxisPicture.Image = MotionApp.Properties.Resources.Letter_Y_lg_icon;
			xAxisPicture.Image = MotionApp.Properties.Resources.Letter_X_lg_icon;
			var xVelocity = xMagnificationTrackBar.Value * (int)xSpeedUnitDropDown.Value;
			var yVelocity = yMagnificationTrackBar.Value * (int)ySpeedUnitDropDown.Value;
			_motionController.MultipleAxisMove(new Axis[] { Axis.X, Axis.Y }, new Direction[] { xDir, yDir }, Math.Min(xVelocity, yVelocity));
		}
		#endregion

		#region MotionController methods
		private void moveToMeasurePosition()
		{
			_motionController.GoMeasurePosition();
			////X
			//_motionController.PTP_RE(0, -10000);

			////Y
			//_motionController.PTP_RE(1, -10000);
		}

		private void initializeMotionController()
		{
			_motionController = DeviceController.GetMotionControllerInstance();
			_motionController.On_AxisEnabled += _motionController_On_AxisEnabled;
			_motionController.On_XAxisMoved += _motionController_On_XAxisMoved;
			_motionController.On_YAxisMoved += _motionController_On_YAxisMoved;
			_motionController.On_ZAxisMoved += _motionController_On_ZAxisMoved;
			_motionController.On_ErrorHandler += _motionController_On_ErrorHanlder;
			_motionController.On_AllAxisDisabled += _motionController_On_AllAxisDisabled;
			_motionController.On_MotionInited += _motionController_On_MotionInited;
			_motionController.On_ResetPositioned += _motionController_On_ResetPositioned;

			_motionAsit = new MotionAssistant(_motionController);
			_motionAsit.On_PEGCompleted += _motionAsit_On_PEGCompleted;
		}

		private void _motionController_On_ErrorHanlder(object sender, System.Runtime.InteropServices.COMException exception)
		{
			string errorMessage = "Error from " + exception.Source + "\n\r";
			errorMessage = errorMessage + exception.Message + "\n\r";
			errorMessage = errorMessage + "HRESULT:" + String.Format("0x{0:X}", (exception.ErrorCode));
			_log.Error(errorMessage);
			MessageBox.Show(errorMessage);
		}

		/// <summary>
		/// 當各軸已Enabled狀態時，回應至UI
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void _motionController_On_AxisEnabled(object sender, object eventArgs)
		{
			//Thread.Sleep(1000);//why
			var vm = eventArgs as EnabledResultViewModel;
			switch (vm.Axis)
			{
				case Axis.X:
					toolStripStatusLabel1.Text = vm.Axis + " Enabled.....";
					break;
				case Axis.Y:
					toolStripStatusLabel2.Text = vm.Axis + " Enabled.....";
					YPAxis_button.Enabled = true;
					YNAxis_button.Enabled = true;
					break;
				case Axis.Z:
					toolStripStatusLabel3.Text = vm.Axis + " Enabled.....";
					break;
			}
			_motionController.StartDetection();

			/* X, Z 軸
			XNYPAxis_button.Enabled = true;
			XPYPAxis_button.Enabled = true;
			XPAxis_button.Enabled = true;
			XPYNAxis_button.Enabled = true;
			XNYNAxis_button.Enabled = true;
			XNAxis_button.Enabled = true;
			ZPAxis_button.Enabled = true;
			ZNAxis_button.Enabled = true;
			*/
			resetPostionBtn.Enabled = true;
		}

		/// <summary>
		/// 各軸歸零後之Callback
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void _motionController_On_ResetPositioned(object sender, string eventArgs)
		{
			toolStripStatusLabel1.Text = eventArgs;
		}

		/// <summary>
		/// 與機器進行連線溝通後之Callback
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void _motionController_On_MotionInited(object sender, string eventArgs)
		{
			toolStripStatusLabel.Text = eventArgs;
		}

		/// <summary>
		/// 關閉所有的軸之Callback。切斷與機器下達指令之連接之Callback。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void _motionController_On_AllAxisDisabled(object sender, string eventArgs)
		{
			toolStripStatusLabel.Text = eventArgs;
		}
		#endregion

		#region Form UI InterActive Methods

		/// <summary>
		/// Scan Button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PEGMoveButton_Click(object sender, EventArgs e)
		{
			scanWithFileProcedure();
			//scanWithMemoryProcedure();
		}
		private void scanWithMemoryProcedure()
		{
			//Stop Line Scan, then Wait for Ready Singnal
			if (_lineScan.Running)
			{
				_lineScan.StopGrab();
			}
			else
			{
				startScan();
			}
		}

		private void scanWithFileProcedure()
		{
			//Clear
			string _imageDir = @"D:\tmp\images";
			if (Directory.Exists(_imageDir))
			{
				var imageDirInfo = new DirectoryInfo(_imageDir);
				foreach (var item in imageDirInfo.EnumerateFiles())
				{
					item.Delete();
				}
			}

			var width = TableObjectXLength;
			var height = TableObjectYLength;
			MoveViewModel = PEGCalculator.GetPEGMoveModel(width, height, CameraSpec, true);
			if (_motionAsit != null)
			{
				_motionAsit.RunPEG(MoveViewModel.YMoveLoop, MoveViewModel.XMoveLoop, MoveViewModel.YMovePixel
					, MoveViewModel.XMovePixel);
			}
		}

		/// <summary>
		/// 受測物 Y 方向文字方塊
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TableObjectYTextBox_TextChanged(object sender, EventArgs e)
		{
			var txtbox = sender as TextBox;
			int length;
			if (!Int32.TryParse(txtbox.Text, out length))
			{
				//CameraSpec.VerticalResolution = 4096;
				MessageBox.Show("請輸入受測物 Y 方向大小(mm)");
			}
			else
			{
				var resolution = Math.Round((length * 1000) / CameraSpec.VerticalPixelSize);
				CameraSpec.VerticalResolution = (int)resolution;
			}
		}

		/// <summary>
		/// 受測物 X 方向文字方塊
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TableObjectXTextBox_TextChanged(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// Motion Form 位置移動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MotionForm_LocationChanged(object sender, EventArgs e)
		{
			var win = sender as MotionForm;
			/*
			LoLabel.Text = String.Format("x:{0} y:{1}", win.Location.X, win.Location.Y);
			LoLabel.Visible = true;
			 */
		}

		/// <summary>
		/// 將各軸呈顯 Enabled 狀態，與機器連線，準備下達指令。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ServoOn_button_Click(object sender, EventArgs e)
		{
			enableYAxisOnly();
			//enableAllAxis();
		}

		/// <summary>
		/// X軸正向移動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void XPAxis_MouseDown(object sender, MouseEventArgs e)
		{
			xAxisPicture.Image = MotionApp.Properties.Resources.Letter_X_lg_icon;
			_motionController.SingleAxisMove(Axis.X, Direction.POSITIVE, xMagnificationTrackBar.Value * (int)xSpeedUnitDropDown.Value);
		}

		/// <summary>
		///  X軸負向移動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void XNAxis_MouseDown(object sender, MouseEventArgs e)
		{
			xAxisPicture.Image = MotionApp.Properties.Resources.Letter_X_lg_icon;
			_motionController.SingleAxisMove(Axis.X, Direction.NEGATIVE, xMagnificationTrackBar.Value * (int)xSpeedUnitDropDown.Value);
		}

		/// <summary>
		/// 停止X軸移動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void XAxis_button_MouseUp(object sender, MouseEventArgs e)
		{
			xAxisPicture.Image = MotionApp.Properties.Resources.Letter_X_grey_icon;
			_motionController.StopPositionDetection();
			_motionController.AxisHalf(new Axis[] { Axis.X });
		}

		/// <summary>
		///  Y軸正向移動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void YPAxis_MouseDown(object sender, MouseEventArgs e)
		{
			yAxisPicture.Image = MotionApp.Properties.Resources.Letter_Y_lg_icon;
			_motionController.SingleAxisMove(Axis.Y, Direction.POSITIVE, yMagnificationTrackBar.Value * (int)ySpeedUnitDropDown.Value);
		}

		/// <summary>
		///  X軸負向移動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void YNAxis_MouseDown(object sender, MouseEventArgs e)
		{
			yAxisPicture.Image = MotionApp.Properties.Resources.Letter_Y_lg_icon;
			_motionController.SingleAxisMove(Axis.Y, Direction.NEGATIVE, yMagnificationTrackBar.Value * (int)ySpeedUnitDropDown.Value);
		}

		/// <summary>
		/// 停止Y軸移動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void YAxis_button_MouseUp(object sender, MouseEventArgs e)
		{
			yAxisPicture.Image = MotionApp.Properties.Resources.Letter_Y_grey_icon;
			_motionController.StopPositionDetection();
			_motionController.AxisHalf(new Axis[] { Axis.Y });
		}

		/// <summary>
		/// Z軸正向移動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ZPAxis_MouseDown(object sender, MouseEventArgs e)
		{
			zAxisPicture.Image = MotionApp.Properties.Resources.Letter_Z_lg_icon;
			_motionController.SingleAxisMove(Axis.Z, Direction.POSITIVE, zMagnificationTrackBar.Value * (int)zSpeedUnitDropDown.Value);

		}

		/// <summary>
		/// Z軸負向移動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ZNAxis_MouseDown(object sender, MouseEventArgs e)
		{
			zAxisPicture.Image = MotionApp.Properties.Resources.Letter_Z_lg_icon;
			_motionController.SingleAxisMove(Axis.Z, Direction.NEGATIVE, zMagnificationTrackBar.Value * (int)zSpeedUnitDropDown.Value);
		}

		/// <summary>
		/// 停止Z軸移動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ZAxis_button_MouseUp(object sender, MouseEventArgs e)
		{
			zAxisPicture.Image = MotionApp.Properties.Resources.Letter_Z_grey_icon1;
			_motionController.StopPositionDetection();
			_motionController.AxisHalf(new Axis[] { Axis.Z });
		}

		/// <summary>
		/// X軸移動後之CallBack
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="position"></param>
		public void _motionController_On_XAxisMoved(object sender, double position)
		{
			XAxis_textBox.Text = position.ToString();
		}

		/// <summary>
		/// Y軸移動後之CallBack
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="position"></param>
		public void _motionController_On_YAxisMoved(object sender, double position)
		{
			YAxis_textBox.Text = position.ToString();
		}

		/// <summary>
		/// Z軸移動後之CallBack
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="position"></param>
		public void _motionController_On_ZAxisMoved(object sender, double position)
		{
			ZAxis_textBox.Text = position.ToString();
		}

		/// <summary>
		/// 與機器進行連線溝通
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Init_button_Click(object sender, EventArgs e)
		{
			_motionController.Initialize(false);
		}


		/// <summary>
		/// 關閉所有的軸。切斷與機器下達指令之連接
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ServoOff_button_Click(object sender, EventArgs e)
		{
			_motionController.ServoOff();
		}

		private void Form1_Closing(object sender, FormClosingEventArgs e)
		{
			//_motionController.ServoOff();
			e.Cancel = false;
		}

		/// <summary>
		/// 停止X、Y軸移動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void XYAxis_button_MouseUp(object sender, MouseEventArgs e)
		{
			xAxisPicture.Image = MotionApp.Properties.Resources.Letter_X_grey_icon;
			yAxisPicture.Image = MotionApp.Properties.Resources.Letter_Y_grey_icon;
			_motionController.StopPositionDetection();
			_motionController.AxisHalf(new Axis[] { Axis.X, Axis.Y });
		}


		/// <summary>
		/// X軸正向移動 Y軸正向移動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void XPYPAxis_MouseDown(object sender, MouseEventArgs e)
		{
			MultipleAxisMove(Direction.POSITIVE, Direction.POSITIVE);
		}

		/// <summary>
		/// X軸負向移動 Y軸正向移動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void XNYPAxis_MouseDown(object sender, MouseEventArgs e)
		{
			MultipleAxisMove(Direction.NEGATIVE, Direction.POSITIVE);
		}

		/// <summary>
		/// X軸負向移動 Y軸負向移動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void XNYNAxis_MouseDown(object sender, MouseEventArgs e)
		{
			MultipleAxisMove(Direction.POSITIVE, Direction.POSITIVE);
		}

		/// <summary>
		/// X軸正向移動 Y軸負向移動
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void XPYNAxis_MouseDown(object sender, MouseEventArgs e)
		{
			MultipleAxisMove(Direction.POSITIVE, Direction.NEGATIVE);
		}



		/// <summary>
		/// 將X、Y、Z軸，歸零
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void resetPostionBtn_Click(object sender, EventArgs e)
		{
			//_motionController.AllAxisBackToZero();
			//_motionController.AxisBackToZero(1);
			_motionController.AxisBackToZero(2);
		}
		#endregion

		#region Public API
		public CameraSpecViewModel CameraSpec { get; set; }

		/// <summary>
		/// 受測物 X 方向長度 (mm)
		/// </summary>
		public int TableObjectXLength
		{
			get
			{
				double xValue;
				if (!Double.TryParse(TableObjectXTextBox.Text, out xValue))
				{
					xValue = (int)(CameraSpec.VerticalResolution * CameraSpec.VerticalPixelSize);
				}
				else
				{
					xValue = xValue * 1000;//轉為 um
				}
				return (int)xValue;
			}
		}

		/// <summary>
		/// 受測物 Y 方向長度 (mm)
		/// </summary>
		public int TableObjectYLength
		{
			get
			{
				double yValue;
				if (!Double.TryParse(TableObjectYTextBox.Text, out yValue))
				{
					yValue = (int)(CameraSpec.HorizontalResolution * CameraSpec.HorizontalPixelSize);
				}
				else
				{
					yValue = yValue * 1000; //轉為 um
				}
				return (int)yValue;
			}
		}

		public PEGMoveViewModel MoveViewModel { get; set; }

		/// <summary>
		/// 取得影像大小
		/// </summary>
		/// <returns></returns>
		public double[] GetObjectSize()
		{
			return new double[] { TableObjectXLength, TableObjectYLength };
		}


		#endregion

		#region UI Proprities
		public int XLoop
		{
			get
			{
				int x;
				if (!Int32.TryParse(textBox1.Text, out x))
					x = 1;
				return x;
			}
		}
		public int YLoop
		{
			get
			{
				int x;
				if (!Int32.TryParse(textBox2.Text, out x))
					x = 1;
				return x;
			}
		}
		#endregion


		#region 測試區
		double SS;
		private void GoButton_Click(object sender, EventArgs e)
		{
			SS = _motionController.FPOS(1);
			_motionController.PTP_RE(1, 10000);
		}

		private void BackButton_Click(object sender, EventArgs e)
		{
			double START_PEG_POS = _motionController.FPOS(1);
			_motionController.PTP_RE(1, -10000);
		}
		private void GrabImageButton_Click(object sender, EventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//Settings
			var width = TableObjectXLength;
			var height = TableObjectYLength;
			MoveViewModel = PEGCalculator.GetPEGMoveModel(width, height, CameraSpec, true);

			var _YMovePixels = 2000 * 10;

			//Move
			if (_motionAsit != null)
			{
				//=============================================variable
				int AX, AY;
				double TRIGGER_UM;
				double LINEAR_RESL;
				int MMM;
				double START_PEG_POS, END_PEG_POS;
				double PEG_DIST;
				double TRIGGER_WIDTH, TRIGGER_COUNT;
				double decreaseSpeed = 0.5;
				int direction = -1; // 方向，y軸向上為負
				//=============================================Common Settings
				AX = 0;	//machine of X
				AY = 1;// machine of Y
				MMM = 10000;//
				TRIGGER_UM = 3.5; //um, Camera pixelSize
				TRIGGER_WIDTH = 0.002; //ms, exposure time
				LINEAR_RESL = 0.1; // 不知道幹嘛用
				TRIGGER_COUNT = direction * TRIGGER_UM / LINEAR_RESL;

				//速度參數
				var _speedBaseRate = 10;
				var vel = _speedBaseRate * MMM * decreaseSpeed;
				var acc = _speedBaseRate * vel;
				var dec = acc;
				var jerk = _speedBaseRate * acc;

				//============================================== Y Axis PEG Settings

				_motionController.SETCONF(205, AY, 256.0);
				_motionController.EnableAxis(Axis.Y);
				_motionController.VEL(AY, vel);
				_motionController.ACC(AY, acc);
				_motionController.DEC(AY, dec);
				_motionController.JERK(AY, jerk);
				PEG_DIST = direction * (_YMovePixels + 1) * TRIGGER_UM / 1000 * MMM;

				double yWayMoveHalfPixels = (_YMovePixels + 1) / 2;
				double Y_DIST = yWayMoveHalfPixels * TRIGGER_UM / 1000 * MMM;//Pixel 轉換為多少 Cout, 即為移動距離

				double yMoveTotalDistance = 0.0;

				//yMove
				START_PEG_POS = _motionController.FPOS(AY);
				var moveDistance = PEG_DIST;// +(TRIGGER_UM * 10);
				END_PEG_POS = START_PEG_POS + moveDistance;
				_motionController.PEG_I_S(AY, TRIGGER_WIDTH, START_PEG_POS, TRIGGER_COUNT, END_PEG_POS);
				//

				//Back


				_motionController.PEG_GoAndBack(AY, moveDistance);
			}


		}

		#endregion

		#region GrabImage
		private List<HImage> _ImageList;
		private void initLineScan()
		{
			_lineScan = new LineScan(10000, 2000, true);
			_lineScan.On_RunningMessage += _lineScan_On_RunningMessage;
			_lineScan.On_Loaded += _lineScan_On_Loaded;
			_lineScan.On_GrabImageChanged += _lineScan_On_GrabImageChanged;
		}
		private int imageCount = 0;
		void _lineScan_On_GrabImageChanged(object sender, GrabImageEventArgs e)
		{
			var image = e.ViewModel as HImage;
			if (image != null)
			{
				_ImageList.Add(image);
				imageCount++;
				setMessage(imageCount.ToString());
			}
		}

		void _lineScan_On_Loaded(object sender, GrabImageEventArgs e)
		{
			//throw new NotImplementedException();
		}

		void _lineScan_On_RunningMessage(object sender, GrabImageEventArgs e)
		{
			var msg = e.Message;
			if (msg == "stop_Completed")
			{
				startScan();
			}
			else
			{
				setMessage(e.Message);

			}
			//throw new NotImplementedException();
		}
		private void setMessage(string msg)
		{
			//LoLabel.Text = e.Message;
			if (this.LoLabel.InvokeRequired)
			{
				SetTextCallback d = new SetTextCallback(setMessage);
				this.Invoke(d, new object[] { msg });
			}
			else
			{
				this.LoLabel.Text = msg;
			}
		}
		private void startScan()
		{
			var width = TableObjectXLength;
			var height = TableObjectYLength;
			CameraSpec.HorizontalPixelSize = 3.5;
			CameraSpec.VerticalPixelSize = 3.5;
			CameraSpec.HorizontalResolution = 2000;
			CameraSpec.VerticalResolution = 10000;
			MoveViewModel = PEGCalculator.GetPEGMoveModel(width, height, CameraSpec, true);


			_lineScan.SetPEGMode(10000, 2000);
			_lineScan.StartGrab();
			while (!_lineScan.Running)
			{
				Thread.Sleep(200);
			}

			//Do Scan

			if (_motionAsit != null)
			{
				_motionAsit.RunPEG(MoveViewModel.YMoveLoop, MoveViewModel.XMoveLoop, MoveViewModel.YMovePixel
					, MoveViewModel.XMovePixel);
			}
		}

		#endregion






	}
}

