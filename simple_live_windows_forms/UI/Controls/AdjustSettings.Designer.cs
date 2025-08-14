namespace simple_ids_cam_view.UI.Controls
{
    partial class AdjustSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            synchronizedExposure = new SynchronizedStepperControl();
            synchronizedGain = new SynchronizedStepperControl();
            btnClose = new Button();
            synchronizedFocus = new SynchronizedStepperControl();
            GbxWhiteBalance = new GroupBox();
            labelAuto = new Label();
            WhiteBalanceOffBtn = new RadioButton();
            WhiteBalanceOnBtn = new RadioButton();
            flowLayoutPanel = new FlowLayoutPanel();
            label6 = new Label();
            GbxWhiteBalance.SuspendLayout();
            flowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // synchronizedExposure
            // 
            synchronizedExposure.BackColor = Color.WhiteSmoke;
            synchronizedExposure.CustomName = "Exposure time [s]";
            synchronizedExposure.Font = new Font("Segoe UI", 9F);
            synchronizedExposure.Increment = 15;
            synchronizedExposure.Location = new Point(15, 176);
            synchronizedExposure.Maximum = 95000;
            synchronizedExposure.Minimum = 30;
            synchronizedExposure.Name = "synchronizedExposure";
            synchronizedExposure.Padding = new Padding(2);
            synchronizedExposure.Size = new Size(323, 164);
            synchronizedExposure.TabIndex = 1;
            // 
            // synchronizedGain
            // 
            synchronizedGain.BackColor = Color.WhiteSmoke;
            synchronizedGain.CustomName = "Gain";
            synchronizedGain.Increment = 1;
            synchronizedGain.Location = new Point(15, 346);
            synchronizedGain.Maximum = 45;
            synchronizedGain.Minimum = 1;
            synchronizedGain.Name = "synchronizedGain";
            synchronizedGain.Padding = new Padding(2);
            synchronizedGain.Size = new Size(323, 164);
            synchronizedGain.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom;
            btnClose.BackColor = Color.YellowGreen;
            btnClose.Location = new Point(112, 756);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(109, 43);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // synchronizedFocus
            // 
            synchronizedFocus.BackColor = Color.WhiteSmoke;
            synchronizedFocus.CustomName = "Focus";
            synchronizedFocus.Increment = 5;
            synchronizedFocus.Location = new Point(15, 6);
            synchronizedFocus.Maximum = 255;
            synchronizedFocus.Minimum = 0;
            synchronizedFocus.Name = "synchronizedFocus";
            synchronizedFocus.Padding = new Padding(2);
            synchronizedFocus.Size = new Size(323, 164);
            synchronizedFocus.TabIndex = 8;
            // 
            // GbxWhiteBalance
            // 
            GbxWhiteBalance.BackColor = Color.WhiteSmoke;
            GbxWhiteBalance.Controls.Add(labelAuto);
            GbxWhiteBalance.Controls.Add(WhiteBalanceOffBtn);
            GbxWhiteBalance.Controls.Add(WhiteBalanceOnBtn);
            GbxWhiteBalance.Font = new Font("Segoe UI", 9.5F);
            GbxWhiteBalance.Location = new Point(15, 516);
            GbxWhiteBalance.Name = "GbxWhiteBalance";
            GbxWhiteBalance.Size = new Size(323, 95);
            GbxWhiteBalance.TabIndex = 9;
            GbxWhiteBalance.TabStop = false;
            GbxWhiteBalance.Text = "White balance";
            // 
            // labelAuto
            // 
            labelAuto.AutoSize = true;
            labelAuto.Location = new Point(52, 34);
            labelAuto.Name = "labelAuto";
            labelAuto.Size = new Size(38, 17);
            labelAuto.TabIndex = 5;
            labelAuto.Text = "Auto:";
            // 
            // WhiteBalanceOffBtn
            // 
            WhiteBalanceOffBtn.AutoSize = true;
            WhiteBalanceOffBtn.Checked = true;
            WhiteBalanceOffBtn.Location = new Point(136, 57);
            WhiteBalanceOffBtn.Name = "WhiteBalanceOffBtn";
            WhiteBalanceOffBtn.Size = new Size(44, 21);
            WhiteBalanceOffBtn.TabIndex = 7;
            WhiteBalanceOffBtn.TabStop = true;
            WhiteBalanceOffBtn.Text = "Off";
            WhiteBalanceOffBtn.UseVisualStyleBackColor = true;
            WhiteBalanceOffBtn.CheckedChanged += WhiteBalanceOffBtn_CheckedChanged;
            // 
            // WhiteBalanceOnBtn
            // 
            WhiteBalanceOnBtn.AutoSize = true;
            WhiteBalanceOnBtn.Location = new Point(87, 57);
            WhiteBalanceOnBtn.Name = "WhiteBalanceOnBtn";
            WhiteBalanceOnBtn.Size = new Size(43, 21);
            WhiteBalanceOnBtn.TabIndex = 6;
            WhiteBalanceOnBtn.Text = "On";
            WhiteBalanceOnBtn.UseVisualStyleBackColor = true;
            WhiteBalanceOnBtn.CheckedChanged += WhiteBalanceOnBtn_CheckedChanged;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Controls.Add(synchronizedFocus);
            flowLayoutPanel.Controls.Add(synchronizedExposure);
            flowLayoutPanel.Controls.Add(synchronizedGain);
            flowLayoutPanel.Controls.Add(GbxWhiteBalance);
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Location = new Point(10, 71);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Padding = new Padding(12, 3, 3, 3);
            flowLayoutPanel.Size = new Size(350, 643);
            flowLayoutPanel.TabIndex = 10;
            flowLayoutPanel.WrapContents = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Underline);
            label6.Location = new Point(85, 24);
            label6.Name = "label6";
            label6.Size = new Size(121, 19);
            label6.TabIndex = 11;
            label6.Text = "Camera Controls";
            // 
            // AdjustSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(label6);
            Controls.Add(flowLayoutPanel);
            Controls.Add(btnClose);
            Font = new Font("Segoe UI", 9.5F);
            Name = "AdjustSettings";
            Size = new Size(372, 821);
            GbxWhiteBalance.ResumeLayout(false);
            GbxWhiteBalance.PerformLayout();
            flowLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal SynchronizedStepperControl synchronizedExposure;
        internal SynchronizedStepperControl synchronizedGain;
        internal SynchronizedStepperControl synchronizedFocus;
        private GroupBox GbxWhiteBalance;
        private Button btnClose;
        private FlowLayoutPanel flowLayoutPanel;
        private Label labelAuto;
        private RadioButton WhiteBalanceOffBtn;
        private RadioButton WhiteBalanceOnBtn;
        private Label label6;
    }
}
