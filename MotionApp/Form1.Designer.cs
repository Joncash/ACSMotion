namespace MotionApp
{
	partial class Form1
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
			this.YAxis_label = new System.Windows.Forms.Label();
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
			this.SuspendLayout();
			// 
			// YAxis_label
			// 
			this.YAxis_label.AutoSize = true;
			this.YAxis_label.Location = new System.Drawing.Point(35, 116);
			this.YAxis_label.Name = "YAxis_label";
			this.YAxis_label.Size = new System.Drawing.Size(13, 12);
			this.YAxis_label.TabIndex = 1;
			this.YAxis_label.Text = "Y";
			// 
			// XAxis_textBox
			// 
			this.XAxis_textBox.Font = new System.Drawing.Font("Microsoft JhengHei", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.XAxis_textBox.Location = new System.Drawing.Point(85, 47);
			this.XAxis_textBox.Name = "XAxis_textBox";
			this.XAxis_textBox.ReadOnly = true;
			this.XAxis_textBox.Size = new System.Drawing.Size(209, 50);
			this.XAxis_textBox.TabIndex = 3;
			this.XAxis_textBox.Text = "0";
			this.XAxis_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// ZAxis_textBox
			// 
			this.ZAxis_textBox.Font = new System.Drawing.Font("Microsoft JhengHei", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.ZAxis_textBox.Location = new System.Drawing.Point(85, 159);
			this.ZAxis_textBox.Name = "ZAxis_textBox";
			this.ZAxis_textBox.ReadOnly = true;
			this.ZAxis_textBox.Size = new System.Drawing.Size(209, 50);
			this.ZAxis_textBox.TabIndex = 4;
			this.ZAxis_textBox.Text = "0";
			this.ZAxis_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// YAxis_textBox
			// 
			this.YAxis_textBox.Font = new System.Drawing.Font("Microsoft JhengHei", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.YAxis_textBox.Location = new System.Drawing.Point(85, 103);
			this.YAxis_textBox.Name = "YAxis_textBox";
			this.YAxis_textBox.ReadOnly = true;
			this.YAxis_textBox.Size = new System.Drawing.Size(209, 50);
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
			this.statusStrip1.Location = new System.Drawing.Point(0, 414);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(555, 22);
			this.statusStrip1.TabIndex = 7;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(88, 17);
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
			this.xMagnificationTrackBar.Location = new System.Drawing.Point(300, 50);
			this.xMagnificationTrackBar.Name = "xMagnificationTrackBar";
			this.xMagnificationTrackBar.Size = new System.Drawing.Size(129, 45);
			this.xMagnificationTrackBar.TabIndex = 25;
			this.xMagnificationTrackBar.Value = 5;
			// 
			// yMagnificationTrackBar
			// 
			this.yMagnificationTrackBar.Location = new System.Drawing.Point(300, 105);
			this.yMagnificationTrackBar.Name = "yMagnificationTrackBar";
			this.yMagnificationTrackBar.Size = new System.Drawing.Size(129, 45);
			this.yMagnificationTrackBar.TabIndex = 26;
			this.yMagnificationTrackBar.Value = 5;
			// 
			// zMagnificationTrackBar
			// 
			this.zMagnificationTrackBar.Location = new System.Drawing.Point(300, 158);
			this.zMagnificationTrackBar.Name = "zMagnificationTrackBar";
			this.zMagnificationTrackBar.Size = new System.Drawing.Size(129, 45);
			this.zMagnificationTrackBar.TabIndex = 28;
			this.zMagnificationTrackBar.Value = 5;
			// 
			// xSpeedUnitDropDown
			// 
			this.xSpeedUnitDropDown.Increment = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.xSpeedUnitDropDown.Location = new System.Drawing.Point(452, 56);
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
			this.xSpeedUnitDropDown.Size = new System.Drawing.Size(60, 22);
			this.xSpeedUnitDropDown.TabIndex = 30;
			this.xSpeedUnitDropDown.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
			// 
			// ySpeedUnitDropDown
			// 
			this.ySpeedUnitDropDown.Increment = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.ySpeedUnitDropDown.Location = new System.Drawing.Point(452, 106);
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
			this.ySpeedUnitDropDown.Size = new System.Drawing.Size(60, 22);
			this.ySpeedUnitDropDown.TabIndex = 31;
			this.ySpeedUnitDropDown.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
			// 
			// zSpeedUnitDropDown
			// 
			this.zSpeedUnitDropDown.Increment = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.zSpeedUnitDropDown.Location = new System.Drawing.Point(452, 160);
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
			this.zSpeedUnitDropDown.Size = new System.Drawing.Size(60, 22);
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
			this.zAxisPicture.Location = new System.Drawing.Point(31, 161);
			this.zAxisPicture.Name = "zAxisPicture";
			this.zAxisPicture.Size = new System.Drawing.Size(48, 48);
			this.zAxisPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.zAxisPicture.TabIndex = 35;
			this.zAxisPicture.TabStop = false;
			// 
			// yAxisPicture
			// 
			this.yAxisPicture.Image = global::MotionApp.Properties.Resources.Letter_Y_grey_icon;
			this.yAxisPicture.Location = new System.Drawing.Point(31, 105);
			this.yAxisPicture.Name = "yAxisPicture";
			this.yAxisPicture.Size = new System.Drawing.Size(48, 48);
			this.yAxisPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.yAxisPicture.TabIndex = 34;
			this.yAxisPicture.TabStop = false;
			// 
			// xAxisPicture
			// 
			this.xAxisPicture.Image = global::MotionApp.Properties.Resources.Letter_X_grey_icon;
			this.xAxisPicture.Location = new System.Drawing.Point(31, 47);
			this.xAxisPicture.Name = "xAxisPicture";
			this.xAxisPicture.Size = new System.Drawing.Size(48, 48);
			this.xAxisPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.xAxisPicture.TabIndex = 33;
			this.xAxisPicture.TabStop = false;
			// 
			// resetPostionBtn
			// 
			this.resetPostionBtn.Image = global::MotionApp.Properties.Resources._0;
			this.resetPostionBtn.Location = new System.Drawing.Point(193, 293);
			this.resetPostionBtn.Name = "resetPostionBtn";
			this.resetPostionBtn.Size = new System.Drawing.Size(48, 48);
			this.resetPostionBtn.TabIndex = 22;
			this.resetPostionBtn.UseVisualStyleBackColor = true;
			this.resetPostionBtn.Click += new System.EventHandler(this.resetPostionBtn_Click);
			// 
			// XPYNAxis_button
			// 
			this.XPYNAxis_button.Image = global::MotionApp.Properties.Resources._2;
			this.XPYNAxis_button.Location = new System.Drawing.Point(246, 347);
			this.XPYNAxis_button.Name = "XPYNAxis_button";
			this.XPYNAxis_button.Size = new System.Drawing.Size(48, 48);
			this.XPYNAxis_button.TabIndex = 21;
			this.XPYNAxis_button.UseVisualStyleBackColor = true;
			this.XPYNAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XPYNAxis_MouseDown);
			this.XPYNAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XYAxis_button_MouseUp);
			// 
			// XNYNAxis_button
			// 
			this.XNYNAxis_button.Image = global::MotionApp.Properties.Resources._4;
			this.XNYNAxis_button.Location = new System.Drawing.Point(138, 347);
			this.XNYNAxis_button.Name = "XNYNAxis_button";
			this.XNYNAxis_button.Size = new System.Drawing.Size(48, 48);
			this.XNYNAxis_button.TabIndex = 20;
			this.XNYNAxis_button.UseVisualStyleBackColor = true;
			this.XNYNAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XNYNAxis_MouseDown);
			this.XNYNAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XYAxis_button_MouseUp);
			// 
			// XPYPAxis_button
			// 
			this.XPYPAxis_button.Image = global::MotionApp.Properties.Resources._8;
			this.XPYPAxis_button.Location = new System.Drawing.Point(246, 239);
			this.XPYPAxis_button.Name = "XPYPAxis_button";
			this.XPYPAxis_button.Size = new System.Drawing.Size(48, 48);
			this.XPYPAxis_button.TabIndex = 19;
			this.XPYPAxis_button.UseVisualStyleBackColor = true;
			this.XPYPAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XPYPAxis_MouseDown);
			this.XPYPAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XYAxis_button_MouseUp);
			// 
			// XNYPAxis_button
			// 
			this.XNYPAxis_button.Image = global::MotionApp.Properties.Resources._6;
			this.XNYPAxis_button.Location = new System.Drawing.Point(138, 239);
			this.XNYPAxis_button.Name = "XNYPAxis_button";
			this.XNYPAxis_button.Size = new System.Drawing.Size(48, 48);
			this.XNYPAxis_button.TabIndex = 18;
			this.XNYPAxis_button.UseVisualStyleBackColor = true;
			this.XNYPAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XNYPAxis_MouseDown);
			this.XNYPAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XYAxis_button_MouseUp);
			// 
			// ZNAxis_button
			// 
			this.ZNAxis_button.Image = global::MotionApp.Properties.Resources._7;
			this.ZNAxis_button.Location = new System.Drawing.Point(346, 239);
			this.ZNAxis_button.Name = "ZNAxis_button";
			this.ZNAxis_button.Size = new System.Drawing.Size(48, 48);
			this.ZNAxis_button.TabIndex = 15;
			this.ZNAxis_button.UseVisualStyleBackColor = true;
			this.ZNAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ZNAxis_MouseDown);
			this.ZNAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ZAxis_button_MouseUp);
			// 
			// YNAxis_button
			// 
			this.YNAxis_button.Image = global::MotionApp.Properties.Resources._3;
			this.YNAxis_button.Location = new System.Drawing.Point(192, 347);
			this.YNAxis_button.Name = "YNAxis_button";
			this.YNAxis_button.Size = new System.Drawing.Size(48, 48);
			this.YNAxis_button.TabIndex = 14;
			this.YNAxis_button.UseVisualStyleBackColor = true;
			this.YNAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.YNAxis_MouseDown);
			this.YNAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.YAxis_button_MouseUp);
			// 
			// XNAxis_button
			// 
			this.XNAxis_button.Image = global::MotionApp.Properties.Resources._5;
			this.XNAxis_button.Location = new System.Drawing.Point(138, 293);
			this.XNAxis_button.Name = "XNAxis_button";
			this.XNAxis_button.Size = new System.Drawing.Size(48, 48);
			this.XNAxis_button.TabIndex = 13;
			this.XNAxis_button.UseVisualStyleBackColor = true;
			this.XNAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XNAxis_MouseDown);
			this.XNAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.XAxis_button_MouseUp);
			// 
			// ServoOff_button
			// 
			this.ServoOff_button.Image = global::MotionApp.Properties.Resources.servoOff;
			this.ServoOff_button.Location = new System.Drawing.Point(29, 347);
			this.ServoOff_button.Name = "ServoOff_button";
			this.ServoOff_button.Size = new System.Drawing.Size(48, 48);
			this.ServoOff_button.TabIndex = 12;
			this.ServoOff_button.UseVisualStyleBackColor = true;
			this.ServoOff_button.Click += new System.EventHandler(this.ServoOff_button_Click);
			// 
			// Init_button
			// 
			this.Init_button.Image = global::MotionApp.Properties.Resources.init;
			this.Init_button.Location = new System.Drawing.Point(29, 239);
			this.Init_button.Name = "Init_button";
			this.Init_button.Size = new System.Drawing.Size(48, 48);
			this.Init_button.TabIndex = 11;
			this.Init_button.UseVisualStyleBackColor = true;
			this.Init_button.Click += new System.EventHandler(this.Init_button_Click);
			// 
			// ZPAxis_button
			// 
			this.ZPAxis_button.Image = global::MotionApp.Properties.Resources._3;
			this.ZPAxis_button.Location = new System.Drawing.Point(346, 347);
			this.ZPAxis_button.Name = "ZPAxis_button";
			this.ZPAxis_button.Size = new System.Drawing.Size(48, 48);
			this.ZPAxis_button.TabIndex = 10;
			this.ZPAxis_button.UseVisualStyleBackColor = true;
			this.ZPAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ZPAxis_MouseDown);
			this.ZPAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ZAxis_button_MouseUp);
			// 
			// YPAxis_button
			// 
			this.YPAxis_button.Image = global::MotionApp.Properties.Resources._7;
			this.YPAxis_button.Location = new System.Drawing.Point(192, 239);
			this.YPAxis_button.Name = "YPAxis_button";
			this.YPAxis_button.Size = new System.Drawing.Size(48, 48);
			this.YPAxis_button.TabIndex = 9;
			this.YPAxis_button.UseVisualStyleBackColor = true;
			this.YPAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.YPAxis_MouseDown);
			this.YPAxis_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.YAxis_button_MouseUp);
			// 
			// XPAxis_button
			// 
			this.XPAxis_button.Image = global::MotionApp.Properties.Resources._1;
			this.XPAxis_button.Location = new System.Drawing.Point(247, 293);
			this.XPAxis_button.Name = "XPAxis_button";
			this.XPAxis_button.Size = new System.Drawing.Size(48, 48);
			this.XPAxis_button.TabIndex = 8;
			this.XPAxis_button.UseVisualStyleBackColor = true;
			this.XPAxis_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.XPAxis_MouseDown);
			// 
			// ServoOn_button
			// 
			this.ServoOn_button.Image = global::MotionApp.Properties.Resources.servoOn;
			this.ServoOn_button.Location = new System.Drawing.Point(29, 293);
			this.ServoOn_button.Name = "ServoOn_button";
			this.ServoOn_button.Size = new System.Drawing.Size(48, 48);
			this.ServoOn_button.TabIndex = 6;
			this.ServoOn_button.UseVisualStyleBackColor = true;
			this.ServoOn_button.Click += new System.EventHandler(this.ServoOn_button_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(555, 436);
			this.Controls.Add(this.zAxisPicture);
			this.Controls.Add(this.yAxisPicture);
			this.Controls.Add(this.xAxisPicture);
			this.Controls.Add(this.zSpeedUnitDropDown);
			this.Controls.Add(this.ySpeedUnitDropDown);
			this.Controls.Add(this.xSpeedUnitDropDown);
			this.Controls.Add(this.zMagnificationTrackBar);
			this.Controls.Add(this.yMagnificationTrackBar);
			this.Controls.Add(this.xMagnificationTrackBar);
			this.Controls.Add(this.resetPostionBtn);
			this.Controls.Add(this.XPYNAxis_button);
			this.Controls.Add(this.XNYNAxis_button);
			this.Controls.Add(this.XPYPAxis_button);
			this.Controls.Add(this.XNYPAxis_button);
			this.Controls.Add(this.ZNAxis_button);
			this.Controls.Add(this.YNAxis_button);
			this.Controls.Add(this.XNAxis_button);
			this.Controls.Add(this.ServoOff_button);
			this.Controls.Add(this.Init_button);
			this.Controls.Add(this.ZPAxis_button);
			this.Controls.Add(this.YPAxis_button);
			this.Controls.Add(this.XPAxis_button);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.ServoOn_button);
			this.Controls.Add(this.YAxis_textBox);
			this.Controls.Add(this.ZAxis_textBox);
			this.Controls.Add(this.XAxis_textBox);
			this.Controls.Add(this.YAxis_label);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label YAxis_label;
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
	}
}

