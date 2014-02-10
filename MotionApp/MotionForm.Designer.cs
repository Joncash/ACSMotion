namespace MotionApp
{
	partial class MotionForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.XAxis_textBox = new System.Windows.Forms.TextBox();
			this.ZAxis_textBox = new System.Windows.Forms.TextBox();
			this.YAxis_textBox = new System.Windows.Forms.TextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.xMagnificationTrackBar = new System.Windows.Forms.TrackBar();
			this.yMagnificationTrackBar = new System.Windows.Forms.TrackBar();
			this.zMagnificationTrackBar = new System.Windows.Forms.TrackBar();
			this.xSpeedUnitDropDown = new System.Windows.Forms.NumericUpDown();
			this.ySpeedUnitDropDown = new System.Windows.Forms.NumericUpDown();
			this.zSpeedUnitDropDown = new System.Windows.Forms.NumericUpDown();
			this.zAxisPicture = new System.Windows.Forms.PictureBox();
			this.yAxisPicture = new System.Windows.Forms.PictureBox();
			this.xAxisPicture = new System.Windows.Forms.PictureBox();
			this.resetPostionBtn = new System.Windows.Forms.Button();
			this.XPYNAxis_button = new System.Windows.Forms.Button();
			this.XNYNAxis_button = new System.Windows.Forms.Button();
			this.XPYPAxis_button = new System.Windows.Forms.Button();
			this.XNYPAxis_button = new System.Windows.Forms.Button();
			this.ZNAxis_button = new System.Windows.Forms.Button();
			this.YNAxis_button = new System.Windows.Forms.Button();
			this.XNAxis_button = new System.Windows.Forms.Button();
			this.ServoOff_button = new System.Windows.Forms.Button();
			this.Init_button = new System.Windows.Forms.Button();
			this.ZPAxis_button = new System.Windows.Forms.Button();
			this.YPAxis_button = new System.Windows.Forms.Button();
			this.XPAxis_button = new System.Windows.Forms.Button();
			this.ServoOn_button = new System.Windows.Forms.Button();
			this.PEGMoveButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.GoButton = new System.Windows.Forms.Button();
			this.BackButton = new System.Windows.Forms.Button();
			this.MovePanel = new System.Windows.Forms.Panel();
			this.LoLabel = new System.Windows.Forms.Label();
			this.GrabImageButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.TableObjectXTextBox = new System.Windows.Forms.TextBox();
			this.TableObjectYTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.FormToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.xMagnificationTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yMagnificationTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.zMagnificationTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xSpeedUnitDropDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ySpeedUnitDropDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.zSpeedUnitDropDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.zAxisPicture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yAxisPicture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xAxisPicture)).BeginInit();
			this.MovePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// XAxis_textBox
			// 
			this.XAxis_textBox.Font = new System.Drawing.Font("Microsoft JhengHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.XAxis_textBox.Location = new System.Drawing.Point(62, 96);
			this.XAxis_textBox.Name = "XAxis_textBox";
			this.XAxis_textBox.ReadOnly = true;
			this.XAxis_textBox.Size = new System.Drawing.Size(186, 39);
			this.XAxis_textBox.TabIndex = 3;
			this.XAxis_textBox.Text = "0";
			this.XAxis_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// ZAxis_textBox
			// 
			this.ZAxis_textBox.Font = new System.Drawing.Font("Microsoft JhengHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.ZAxis_textBox.Location = new System.Drawing.Point(62, 225);
			this.ZAxis_textBox.Name = "ZAxis_textBox";
			this.ZAxis_textBox.ReadOnly = true;
			this.ZAxis_textBox.Size = new System.Drawing.Size(186, 39);
			this.ZAxis_textBox.TabIndex = 4;
			this.ZAxis_textBox.Text = "0";
			this.ZAxis_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// YAxis_textBox
			// 
			this.YAxis_textBox.Font = new System.Drawing.Font("Microsoft JhengHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.YAxis_textBox.Location = new System.Drawing.Point(62, 158);
			this.YAxis_textBox.Name = "YAxis_textBox";
			this.YAxis_textBox.ReadOnly = true;
			this.YAxis_textBox.Size = new System.Drawing.Size(186, 39);
			this.YAxis_textBox.TabIndex = 5;
			this.YAxis_textBox.Text = "0";
			this.YAxis_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
			this.statusStrip1.Location = new System.Drawing.Point(0, 474);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(329, 22);
			this.statusStrip1.TabIndex = 7;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(87, 17);
			this.toolStripStatusLabel.Text = "Disconnection";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
			// 
			// xMagnificationTrackBar
			// 
			this.xMagnificationTrackBar.Location = new System.Drawing.Point(384, 95);
			this.xMagnificationTrackBar.Name = "xMagnificationTrackBar";
			this.xMagnificationTrackBar.Size = new System.Drawing.Size(178, 45);
			this.xMagnificationTrackBar.TabIndex = 25;
			this.xMagnificationTrackBar.Value = 5;
			// 
			// yMagnificationTrackBar
			// 
			this.yMagnificationTrackBar.Location = new System.Drawing.Point(384, 292);
			this.yMagnificationTrackBar.Name = "yMagnificationTrackBar";
			this.yMagnificationTrackBar.Size = new System.Drawing.Size(178, 45);
			this.yMagnificationTrackBar.TabIndex = 26;
			this.yMagnificationTrackBar.Value = 5;
			// 
			// zMagnificationTrackBar
			// 
			this.zMagnificationTrackBar.Location = new System.Drawing.Point(384, 186);
			this.zMagnificationTrackBar.Name = "zMagnificationTrackBar";
			this.zMagnificationTrackBar.Size = new System.Drawing.Size(178, 45);
			this.zMagnificationTrackBar.TabIndex = 28;
			this.zMagnificationTrackBar.Value = 5;
			// 
			// xSpeedUnitDropDown
			// 
			this.xSpeedUnitDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xSpeedUnitDropDown.Increment = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.xSpeedUnitDropDown.Location = new System.Drawing.Point(254, 111);
			this.xSpeedUnitDropDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.xSpeedUnitDropDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.xSpeedUnitDropDown.Name = "xSpeedUnitDropDown";
			this.xSpeedUnitDropDown.Size = new System.Drawing.Size(67, 23);
			this.xSpeedUnitDropDown.TabIndex = 30;
			this.xSpeedUnitDropDown.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
			// 
			// ySpeedUnitDropDown
			// 
			this.ySpeedUnitDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ySpeedUnitDropDown.Increment = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.ySpeedUnitDropDown.Location = new System.Drawing.Point(254, 173);
			this.ySpeedUnitDropDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.ySpeedUnitDropDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.ySpeedUnitDropDown.Name = "ySpeedUnitDropDown";
			this.ySpeedUnitDropDown.Size = new System.Drawing.Size(60, 23);
			this.ySpeedUnitDropDown.TabIndex = 31;
			this.ySpeedUnitDropDown.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
			// 
			// zSpeedUnitDropDown
			// 
			this.zSpeedUnitDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.zSpeedUnitDropDown.Increment = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.zSpeedUnitDropDown.Location = new System.Drawing.Point(254, 240);
			this.zSpeedUnitDropDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.zSpeedUnitDropDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.zSpeedUnitDropDown.Name = "zSpeedUnitDropDown";
			this.zSpeedUnitDropDown.Size = new System.Drawing.Size(60, 23);
			this.zSpeedUnitDropDown.TabIndex = 32;
			this.zSpeedUnitDropDown.Value = new decimal(new int[] {
            25000,
            0,
            0,
            0});
			// 
			// zAxisPicture
			// 
			this.zAxisPicture.Image = global::MotionApp.Properties.Resources.Letter_Z_grey_icon1;
			this.zAxisPicture.Location = new System.Drawing.Point(8, 223);
			this.zAxisPicture.Name = "zAxisPicture";
			this.zAxisPicture.Size = new System.Drawing.Size(48, 48);
			this.zAxisPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.zAxisPicture.TabIndex = 35;
			this.zAxisPicture.TabStop = false;
			// 
			// yAxisPicture
			// 
			this.yAxisPicture.Image = global::MotionApp.Properties.Resources.Letter_Y_grey_icon;
			this.yAxisPicture.Location = new System.Drawing.Point(8, 158);
			this.yAxisPicture.Name = "yAxisPicture";
			this.yAxisPicture.Size = new System.Drawing.Size(48, 48);
			this.yAxisPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.yAxisPicture.TabIndex = 34;
			this.yAxisPicture.TabStop = false;
			// 
			// xAxisPicture
			// 
			this.xAxisPicture.Image = global::MotionApp.Properties.Resources.Letter_X_grey_icon;
			this.xAxisPicture.Location = new System.Drawing.Point(8, 92);
			this.xAxisPicture.Name = "xAxisPicture";
			this.xAxisPicture.Size = new System.Drawing.Size(48, 48);
			this.xAxisPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.xAxisPicture.TabIndex = 33;
			this.xAxisPicture.TabStop = false;
			// 
			// resetPostionBtn
			// 
			this.resetPostionBtn.Image = global::MotionApp.Properties.Resources._0;
			this.resetPostionBtn.Location = new System.Drawing.Point(59, 64);
			this.resetPostionBtn.Name = "resetPostionBtn";
			this.resetPostionBtn.Size = new System.Drawing.Size(48, 52);
			this.resetPostionBtn.TabIndex = 22;
			this.resetPostionBtn.UseVisualStyleBackColor = true;
			this.resetPostionBtn.Click += new System.EventHandler(this.resetPostionBtn_Click);
			// 
			// XPYNAxis_button
			// 
			this.XPYNAxis_button.Image = global::MotionApp.Properties.Resources._2;
			this.XPYNAxis_button.Location = new System.Drawing.Point(112, 124);
			this.XPYNAxis_button.Name = "XPYNAxis_button";
			this.XPYNAxis_button.Size = new System.Drawing.Size(48, 52);
			this.XPYNAxis_button.TabIndex = 21;
			this.XPYNAxis_button.UseVisualStyleBackColor = true;
			this.XPYNAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XPYNAxis_MouseDown);
			this.XPYNAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XYAxis_button_MouseUp);
			// 
			// XNYNAxis_button
			// 
			this.XNYNAxis_button.Image = global::MotionApp.Properties.Resources._4;
			this.XNYNAxis_button.Location = new System.Drawing.Point(4, 124);
			this.XNYNAxis_button.Name = "XNYNAxis_button";
			this.XNYNAxis_button.Size = new System.Drawing.Size(48, 52);
			this.XNYNAxis_button.TabIndex = 20;
			this.XNYNAxis_button.UseVisualStyleBackColor = true;
			this.XNYNAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XNYNAxis_MouseDown);
			this.XNYNAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XYAxis_button_MouseUp);
			// 
			// XPYPAxis_button
			// 
			this.XPYPAxis_button.Image = global::MotionApp.Properties.Resources._8;
			this.XPYPAxis_button.Location = new System.Drawing.Point(112, 6);
			this.XPYPAxis_button.Name = "XPYPAxis_button";
			this.XPYPAxis_button.Size = new System.Drawing.Size(48, 52);
			this.XPYPAxis_button.TabIndex = 19;
			this.XPYPAxis_button.UseVisualStyleBackColor = true;
			this.XPYPAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XPYPAxis_MouseDown);
			this.XPYPAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XYAxis_button_MouseUp);
			// 
			// XNYPAxis_button
			// 
			this.XNYPAxis_button.Image = global::MotionApp.Properties.Resources._6;
			this.XNYPAxis_button.Location = new System.Drawing.Point(5, 7);
			this.XNYPAxis_button.Name = "XNYPAxis_button";
			this.XNYPAxis_button.Size = new System.Drawing.Size(48, 52);
			this.XNYPAxis_button.TabIndex = 18;
			this.XNYPAxis_button.UseVisualStyleBackColor = true;
			this.XNYPAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XNYPAxis_MouseDown);
			this.XNYPAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XYAxis_button_MouseUp);
			// 
			// ZNAxis_button
			// 
			this.ZNAxis_button.Image = global::MotionApp.Properties.Resources._7;
			this.ZNAxis_button.Location = new System.Drawing.Point(174, 7);
			this.ZNAxis_button.Name = "ZNAxis_button";
			this.ZNAxis_button.Size = new System.Drawing.Size(48, 52);
			this.ZNAxis_button.TabIndex = 15;
			this.ZNAxis_button.UseVisualStyleBackColor = true;
			this.ZNAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ZNAxis_MouseDown);
			this.ZNAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ZAxis_button_MouseUp);
			// 
			// YNAxis_button
			// 
			this.YNAxis_button.Image = global::MotionApp.Properties.Resources._3;
			this.YNAxis_button.Location = new System.Drawing.Point(58, 124);
			this.YNAxis_button.Name = "YNAxis_button";
			this.YNAxis_button.Size = new System.Drawing.Size(48, 52);
			this.YNAxis_button.TabIndex = 14;
			this.YNAxis_button.UseVisualStyleBackColor = true;
			this.YNAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.YNAxis_MouseDown);
			this.YNAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.YAxis_button_MouseUp);
			// 
			// XNAxis_button
			// 
			this.XNAxis_button.Image = global::MotionApp.Properties.Resources._5;
			this.XNAxis_button.Location = new System.Drawing.Point(4, 64);
			this.XNAxis_button.Name = "XNAxis_button";
			this.XNAxis_button.Size = new System.Drawing.Size(48, 52);
			this.XNAxis_button.TabIndex = 13;
			this.XNAxis_button.UseVisualStyleBackColor = true;
			this.XNAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XNAxis_MouseDown);
			this.XNAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XAxis_button_MouseUp);
			// 
			// ServoOff_button
			// 
			this.ServoOff_button.Image = global::MotionApp.Properties.Resources.servoOff;
			this.ServoOff_button.Location = new System.Drawing.Point(9, 408);
			this.ServoOff_button.Name = "ServoOff_button";
			this.ServoOff_button.Size = new System.Drawing.Size(48, 52);
			this.ServoOff_button.TabIndex = 12;
			this.FormToolTip.SetToolTip(this.ServoOff_button, "中斷各軸連線");
			this.ServoOff_button.UseVisualStyleBackColor = true;
			this.ServoOff_button.Click += new System.EventHandler(this.ServoOff_button_Click);
			// 
			// Init_button
			// 
			this.Init_button.Image = global::MotionApp.Properties.Resources.init;
			this.Init_button.Location = new System.Drawing.Point(9, 290);
			this.Init_button.Name = "Init_button";
			this.Init_button.Size = new System.Drawing.Size(48, 52);
			this.Init_button.TabIndex = 11;
			this.FormToolTip.SetToolTip(this.Init_button, "連線至控制器");
			this.Init_button.UseVisualStyleBackColor = true;
			this.Init_button.Click += new System.EventHandler(this.Init_button_Click);
			// 
			// ZPAxis_button
			// 
			this.ZPAxis_button.Image = global::MotionApp.Properties.Resources._3;
			this.ZPAxis_button.Location = new System.Drawing.Point(174, 124);
			this.ZPAxis_button.Name = "ZPAxis_button";
			this.ZPAxis_button.Size = new System.Drawing.Size(48, 52);
			this.ZPAxis_button.TabIndex = 10;
			this.ZPAxis_button.UseVisualStyleBackColor = true;
			this.ZPAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ZPAxis_MouseDown);
			this.ZPAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ZAxis_button_MouseUp);
			// 
			// YPAxis_button
			// 
			this.YPAxis_button.Image = global::MotionApp.Properties.Resources._7;
			this.YPAxis_button.Location = new System.Drawing.Point(58, 6);
			this.YPAxis_button.Name = "YPAxis_button";
			this.YPAxis_button.Size = new System.Drawing.Size(48, 52);
			this.YPAxis_button.TabIndex = 9;
			this.YPAxis_button.UseVisualStyleBackColor = true;
			this.YPAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.YPAxis_MouseDown);
			this.YPAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.YAxis_button_MouseUp);
			// 
			// XPAxis_button
			// 
			this.XPAxis_button.Image = global::MotionApp.Properties.Resources._1;
			this.XPAxis_button.Location = new System.Drawing.Point(113, 64);
			this.XPAxis_button.Name = "XPAxis_button";
			this.XPAxis_button.Size = new System.Drawing.Size(48, 52);
			this.XPAxis_button.TabIndex = 8;
			this.XPAxis_button.UseVisualStyleBackColor = true;
			this.XPAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XPAxis_MouseDown);
			// 
			// ServoOn_button
			// 
			this.ServoOn_button.Image = global::MotionApp.Properties.Resources.servoOn;
			this.ServoOn_button.Location = new System.Drawing.Point(11, 347);
			this.ServoOn_button.Name = "ServoOn_button";
			this.ServoOn_button.Size = new System.Drawing.Size(48, 52);
			this.ServoOn_button.TabIndex = 6;
			this.FormToolTip.SetToolTip(this.ServoOn_button, "啟動各軸連線");
			this.ServoOn_button.UseVisualStyleBackColor = true;
			this.ServoOn_button.Click += new System.EventHandler(this.ServoOn_button_Click);
			// 
			// PEGMoveButton
			// 
			this.PEGMoveButton.Location = new System.Drawing.Point(180, 6);
			this.PEGMoveButton.Name = "PEGMoveButton";
			this.PEGMoveButton.Size = new System.Drawing.Size(144, 67);
			this.PEGMoveButton.TabIndex = 36;
			this.PEGMoveButton.Text = "開始掃描";
			this.PEGMoveButton.UseVisualStyleBackColor = true;
			this.PEGMoveButton.Click += new System.EventHandler(this.PEGMoveButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(828, 309);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 37;
			this.label1.Text = "X-Count";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(828, 338);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 13);
			this.label2.TabIndex = 38;
			this.label2.Text = "Y-Count";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(879, 306);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(67, 20);
			this.textBox1.TabIndex = 39;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(878, 335);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(68, 20);
			this.textBox2.TabIndex = 40;
			// 
			// GoButton
			// 
			this.GoButton.Location = new System.Drawing.Point(837, 361);
			this.GoButton.Name = "GoButton";
			this.GoButton.Size = new System.Drawing.Size(51, 52);
			this.GoButton.TabIndex = 41;
			this.GoButton.Text = "Go";
			this.GoButton.UseVisualStyleBackColor = true;
			this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
			// 
			// BackButton
			// 
			this.BackButton.Location = new System.Drawing.Point(894, 361);
			this.BackButton.Name = "BackButton";
			this.BackButton.Size = new System.Drawing.Size(51, 52);
			this.BackButton.TabIndex = 42;
			this.BackButton.Text = "Back";
			this.BackButton.UseVisualStyleBackColor = true;
			this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
			// 
			// MovePanel
			// 
			this.MovePanel.Controls.Add(this.resetPostionBtn);
			this.MovePanel.Controls.Add(this.XPAxis_button);
			this.MovePanel.Controls.Add(this.YPAxis_button);
			this.MovePanel.Controls.Add(this.XNAxis_button);
			this.MovePanel.Controls.Add(this.YNAxis_button);
			this.MovePanel.Controls.Add(this.XNYPAxis_button);
			this.MovePanel.Controls.Add(this.XPYPAxis_button);
			this.MovePanel.Controls.Add(this.XNYNAxis_button);
			this.MovePanel.Controls.Add(this.XPYNAxis_button);
			this.MovePanel.Controls.Add(this.ZNAxis_button);
			this.MovePanel.Controls.Add(this.ZPAxis_button);
			this.MovePanel.Location = new System.Drawing.Point(64, 283);
			this.MovePanel.Margin = new System.Windows.Forms.Padding(2);
			this.MovePanel.Name = "MovePanel";
			this.MovePanel.Size = new System.Drawing.Size(235, 180);
			this.MovePanel.TabIndex = 44;
			// 
			// LoLabel
			// 
			this.LoLabel.AutoSize = true;
			this.LoLabel.Location = new System.Drawing.Point(834, 215);
			this.LoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.LoLabel.Name = "LoLabel";
			this.LoLabel.Size = new System.Drawing.Size(27, 13);
			this.LoLabel.TabIndex = 51;
			this.LoLabel.Text = "N/A";
			this.LoLabel.Visible = false;
			// 
			// GrabImageButton
			// 
			this.GrabImageButton.Location = new System.Drawing.Point(831, 239);
			this.GrabImageButton.Margin = new System.Windows.Forms.Padding(2);
			this.GrabImageButton.Name = "GrabImageButton";
			this.GrabImageButton.Size = new System.Drawing.Size(114, 62);
			this.GrabImageButton.TabIndex = 46;
			this.GrabImageButton.Text = " 擷取影像";
			this.GrabImageButton.UseVisualStyleBackColor = true;
			this.GrabImageButton.Click += new System.EventHandler(this.GrabImageButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 2);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(129, 13);
			this.label3.TabIndex = 47;
			this.label3.Text = "受測物 X 方向長度 (mm)";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 39);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(129, 13);
			this.label4.TabIndex = 48;
			this.label4.Text = "受測物 Y 方向長度 (mm)";
			// 
			// TableObjectXTextBox
			// 
			this.TableObjectXTextBox.Location = new System.Drawing.Point(12, 19);
			this.TableObjectXTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.TableObjectXTextBox.Name = "TableObjectXTextBox";
			this.TableObjectXTextBox.Size = new System.Drawing.Size(162, 20);
			this.TableObjectXTextBox.TabIndex = 49;
			this.TableObjectXTextBox.TextChanged += new System.EventHandler(this.TableObjectXTextBox_TextChanged);
			// 
			// TableObjectYTextBox
			// 
			this.TableObjectYTextBox.Location = new System.Drawing.Point(12, 55);
			this.TableObjectYTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.TableObjectYTextBox.Name = "TableObjectYTextBox";
			this.TableObjectYTextBox.Size = new System.Drawing.Size(162, 20);
			this.TableObjectYTextBox.TabIndex = 50;
			this.TableObjectYTextBox.TextChanged += new System.EventHandler(this.TableObjectYTextBox_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(258, 95);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 13);
			this.label5.TabIndex = 52;
			this.label5.Text = "X 速率";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(258, 158);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(41, 13);
			this.label6.TabIndex = 53;
			this.label6.Text = "Y 速率";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(258, 225);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(41, 13);
			this.label7.TabIndex = 54;
			this.label7.Text = "Z 速率";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(568, 367);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(134, 67);
			this.button1.TabIndex = 55;
			this.button1.Text = "PEGMoveAndBackTest";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MotionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(329, 496);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.LoLabel);
			this.Controls.Add(this.TableObjectYTextBox);
			this.Controls.Add(this.TableObjectXTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.GrabImageButton);
			this.Controls.Add(this.MovePanel);
			this.Controls.Add(this.BackButton);
			this.Controls.Add(this.GoButton);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.PEGMoveButton);
			this.Controls.Add(this.zAxisPicture);
			this.Controls.Add(this.yAxisPicture);
			this.Controls.Add(this.xAxisPicture);
			this.Controls.Add(this.zSpeedUnitDropDown);
			this.Controls.Add(this.ySpeedUnitDropDown);
			this.Controls.Add(this.xSpeedUnitDropDown);
			this.Controls.Add(this.zMagnificationTrackBar);
			this.Controls.Add(this.yMagnificationTrackBar);
			this.Controls.Add(this.xMagnificationTrackBar);
			this.Controls.Add(this.ServoOff_button);
			this.Controls.Add(this.Init_button);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.ServoOn_button);
			this.Controls.Add(this.YAxis_textBox);
			this.Controls.Add(this.ZAxis_textBox);
			this.Controls.Add(this.XAxis_textBox);
			this.MaximumSize = new System.Drawing.Size(345, 535);
			this.Name = "MotionForm";
			this.Text = "移動控制";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.LocationChanged += new System.EventHandler(this.MotionForm_LocationChanged);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.xMagnificationTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yMagnificationTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.zMagnificationTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xSpeedUnitDropDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ySpeedUnitDropDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.zSpeedUnitDropDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.zAxisPicture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yAxisPicture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xAxisPicture)).EndInit();
			this.MovePanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox XAxis_textBox;
		private System.Windows.Forms.TextBox ZAxis_textBox;
		private System.Windows.Forms.TextBox YAxis_textBox;
		private System.Windows.Forms.Button ServoOn_button;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.Button XPAxis_button;
		private System.Windows.Forms.Button YPAxis_button;
		private System.Windows.Forms.Button ZPAxis_button;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.Button Init_button;
		private System.Windows.Forms.Button ServoOff_button;
		private System.Windows.Forms.Button XNAxis_button;
		private System.Windows.Forms.Button YNAxis_button;
		private System.Windows.Forms.Button ZNAxis_button;
		private System.Windows.Forms.Button XNYPAxis_button;
		private System.Windows.Forms.Button XPYPAxis_button;
		private System.Windows.Forms.Button XNYNAxis_button;
		private System.Windows.Forms.Button XPYNAxis_button;
		private System.Windows.Forms.Button resetPostionBtn;
		private System.Windows.Forms.TrackBar xMagnificationTrackBar;
		private System.Windows.Forms.TrackBar yMagnificationTrackBar;
		private System.Windows.Forms.TrackBar zMagnificationTrackBar;
		private System.Windows.Forms.NumericUpDown xSpeedUnitDropDown;
		private System.Windows.Forms.NumericUpDown ySpeedUnitDropDown;
		private System.Windows.Forms.NumericUpDown zSpeedUnitDropDown;
		private System.Windows.Forms.PictureBox xAxisPicture;
		private System.Windows.Forms.PictureBox yAxisPicture;
		private System.Windows.Forms.PictureBox zAxisPicture;
		private System.Windows.Forms.Button PEGMoveButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button GoButton;
		private System.Windows.Forms.Button BackButton;
		private System.Windows.Forms.Panel MovePanel;
		private System.Windows.Forms.Button GrabImageButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox TableObjectXTextBox;
		private System.Windows.Forms.TextBox TableObjectYTextBox;
		private System.Windows.Forms.Label LoLabel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ToolTip FormToolTip;
	}
}

