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

namespace MotionApp
{
	public partial class Form1 : Form
	{
		private static Logger _log = NLog.LogManager.GetCurrentClassLogger();
		private MotionController _motionController;
		public Form1()
		{
			_motionController = new MotionController();
			_motionController.On_AxisEnabled += _motionController_On_AxisEnabled;
			_motionController.On_XAxisMoved += _motionController_On_XAxisMoved;
			_motionController.On_YAxisMoved += _motionController_On_YAxisMoved;
			_motionController.On_ZAxisMoved += _motionController_On_ZAxisMoved;
			_motionController.On_ErrorHandler += _motionController_On_ErrorHanlder;
			_motionController.On_AllAxisDisabled += _motionController_On_AllAxisDisabled;
			_motionController.On_MotionInited += _motionController_On_MotionInited;
			_motionController.On_ResetPositioned += _motionController_On_ResetPositioned;
			InitializeComponent();
			XPAxis_button.MouseUp += XAxis_button_MouseUp;

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

	

		void _motionController_On_ErrorHanlder(object sender, System.Runtime.InteropServices.COMException exception)
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
			Thread.Sleep(1000);
			var vm = eventArgs as EnabledResultViewModel;
			switch (vm.Axis)
			{
				case Axis.X:
					toolStripStatusLabel1.Text = vm.Axis + " Enabled.....";
					break;
				case Axis.Y:
					toolStripStatusLabel2.Text = vm.Axis + " Enabled.....";
					break;
				case Axis.Z:
					toolStripStatusLabel3.Text = vm.Axis + " Enabled.....";
					break;
			}
			_motionController.StartDetection();
			XNYPAxis_button.Enabled = true;
			YPAxis_button.Enabled = true;
			XPYPAxis_button.Enabled = true;
			XPAxis_button.Enabled = true;
			XPYNAxis_button.Enabled = true;
			YNAxis_button.Enabled = true;
			XNYNAxis_button.Enabled = true;
			XNAxis_button.Enabled = true;
			resetPostionBtn.Enabled = true;
			ZPAxis_button.Enabled = true;
			ZNAxis_button.Enabled = true;
		}

		/// <summary>
		/// 將各軸呈顯 Enabled 狀態，與機器連線，準備下達指令。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ServoOn_button_Click(object sender, EventArgs e)
		{
			_motionController.EnableAxis(Axis.X);
			_motionController.EnableAxis(Axis.Y);
			_motionController.EnableAxis(Axis.Z);
			toolStripStatusLabel.Text = "Done";
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
			_motionController.SingleAxisMove(Axis.X, Direction.NEGATIVE,  xMagnificationTrackBar.Value * (int)xSpeedUnitDropDown.Value);
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

		private void MultipleAxisMove(Direction xDir, Direction yDir)
		{
			yAxisPicture.Image = MotionApp.Properties.Resources.Letter_Y_lg_icon;
			xAxisPicture.Image = MotionApp.Properties.Resources.Letter_X_lg_icon;
			var xVelocity = xMagnificationTrackBar.Value * (int)xSpeedUnitDropDown.Value;
			var yVelocity = yMagnificationTrackBar.Value * (int)ySpeedUnitDropDown.Value;
			_motionController.MultipleAxisMove(new Axis[] { Axis.X, Axis.Y }, new Direction[] { xDir, yDir }, Math.Min(xVelocity, yVelocity));
		}

		/// <summary>
		/// 將X、Y、Z軸，歸零
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void resetPostionBtn_Click(object sender, EventArgs e)
		{
			_motionController.AllAxisBackToZero();
		}

		/// <summary>
		/// 各軸歸零後之Callback
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		void _motionController_On_ResetPositioned(object sender, string eventArgs)
		{
			toolStripStatusLabel1.Text = eventArgs;
		}

		/// <summary>
		/// 與機器進行連線溝通後之Callback
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		void _motionController_On_MotionInited(object sender, string eventArgs)
		{
			toolStripStatusLabel.Text = eventArgs;
		}


		/// <summary>
		/// 關閉所有的軸之Callback。切斷與機器下達指令之連接之Callback。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		void _motionController_On_AllAxisDisabled(object sender, string eventArgs)
		{
			toolStripStatusLabel.Text = eventArgs;

		}


		

		

		



		

	}
}

