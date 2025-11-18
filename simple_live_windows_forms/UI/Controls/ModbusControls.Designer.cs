namespace simple_ids_cam_view.UI.Controls
{
    partial class ModbusControls
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModbusControls));
            GbxLights = new GroupBox();
            BtnLightsOn = new Button();
            BtnLightsOff = new Button();
            GbxMotorPos = new GroupBox();
            textBoxCurrentPos = new TextBox();
            label8 = new Label();
            label1 = new Label();
            comboBoxMotorPos = new ComboBox();
            GbxModbusStatus = new GroupBox();
            StatusHomePosition = new Panel();
            label5 = new Label();
            StatusDoorClosed = new Panel();
            label4 = new Label();
            StatusSystemError = new Panel();
            label3 = new Label();
            StatusConnected = new Panel();
            label2 = new Label();
            label6 = new Label();
            btnClose = new Button();
            PbxRefreshModbusInfo = new PictureBox();
            toolTip1 = new ToolTip(components);
            BtnResetSystem = new Button();
            GbxUserActions = new GroupBox();
            label7 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            GbxLights.SuspendLayout();
            GbxMotorPos.SuspendLayout();
            GbxModbusStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbxRefreshModbusInfo).BeginInit();
            GbxUserActions.SuspendLayout();
            SuspendLayout();
            // 
            // GbxLights
            // 
            GbxLights.BackColor = Color.WhiteSmoke;
            GbxLights.Controls.Add(BtnLightsOn);
            GbxLights.Controls.Add(BtnLightsOff);
            GbxLights.Location = new Point(15, 78);
            GbxLights.Name = "GbxLights";
            GbxLights.Size = new Size(330, 86);
            GbxLights.TabIndex = 0;
            GbxLights.TabStop = false;
            GbxLights.Text = "Lights";
            // 
            // BtnLightsOn
            // 
            BtnLightsOn.BackColor = Color.YellowGreen;
            BtnLightsOn.Cursor = Cursors.Hand;
            BtnLightsOn.Location = new Point(46, 25);
            BtnLightsOn.Margin = new Padding(4, 3, 4, 3);
            BtnLightsOn.Name = "BtnLightsOn";
            BtnLightsOn.Size = new Size(81, 43);
            BtnLightsOn.TabIndex = 4;
            BtnLightsOn.Text = "Turn On";
            BtnLightsOn.UseVisualStyleBackColor = false;
            BtnLightsOn.Click += BtnLightsOn_Click;
            // 
            // BtnLightsOff
            // 
            BtnLightsOff.BackColor = Color.RosyBrown;
            BtnLightsOff.Cursor = Cursors.Hand;
            BtnLightsOff.DialogResult = DialogResult.Cancel;
            BtnLightsOff.Location = new Point(182, 25);
            BtnLightsOff.Margin = new Padding(4, 3, 4, 3);
            BtnLightsOff.Name = "BtnLightsOff";
            BtnLightsOff.Size = new Size(81, 43);
            BtnLightsOff.TabIndex = 5;
            BtnLightsOff.Text = "Turn Off";
            BtnLightsOff.UseVisualStyleBackColor = false;
            BtnLightsOff.Click += BtnLightsOff_Click;
            // 
            // GbxMotorPos
            // 
            GbxMotorPos.BackColor = Color.WhiteSmoke;
            GbxMotorPos.Controls.Add(textBoxCurrentPos);
            GbxMotorPos.Controls.Add(label8);
            GbxMotorPos.Controls.Add(label1);
            GbxMotorPos.Controls.Add(comboBoxMotorPos);
            GbxMotorPos.Location = new Point(15, 184);
            GbxMotorPos.Name = "GbxMotorPos";
            GbxMotorPos.Size = new Size(330, 115);
            GbxMotorPos.TabIndex = 1;
            GbxMotorPos.TabStop = false;
            GbxMotorPos.Text = "Motor Position";
            // 
            // textBoxCurrentPos
            // 
            textBoxCurrentPos.Location = new Point(156, 29);
            textBoxCurrentPos.Name = "textBoxCurrentPos";
            textBoxCurrentPos.ReadOnly = true;
            textBoxCurrentPos.Size = new Size(154, 24);
            textBoxCurrentPos.TabIndex = 4;
            textBoxCurrentPos.Text = "unknown";
            textBoxCurrentPos.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F);
            label8.Location = new Point(7, 33);
            label8.Name = "label8";
            label8.Size = new Size(132, 15);
            label8.TabIndex = 3;
            label8.Text = "Current motor position:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(7, 77);
            label1.Name = "label1";
            label1.Size = new Size(133, 15);
            label1.TabIndex = 1;
            label1.Text = "Change motor position:";
            // 
            // comboBoxMotorPos
            // 
            comboBoxMotorPos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMotorPos.Font = new Font("Segoe UI", 9F);
            comboBoxMotorPos.FormattingEnabled = true;
            comboBoxMotorPos.Items.AddRange(new object[] { "Position 1", "Position 2", "Position 3" });
            comboBoxMotorPos.Location = new Point(156, 71);
            comboBoxMotorPos.Name = "comboBoxMotorPos";
            comboBoxMotorPos.Size = new Size(154, 23);
            comboBoxMotorPos.TabIndex = 0;
            comboBoxMotorPos.SelectedIndexChanged += ComboBoxMotorPos_SelectedIndexChanged;
            // 
            // GbxModbusStatus
            // 
            GbxModbusStatus.BackColor = Color.WhiteSmoke;
            GbxModbusStatus.Controls.Add(StatusHomePosition);
            GbxModbusStatus.Controls.Add(label5);
            GbxModbusStatus.Controls.Add(StatusDoorClosed);
            GbxModbusStatus.Controls.Add(label4);
            GbxModbusStatus.Controls.Add(StatusSystemError);
            GbxModbusStatus.Controls.Add(label3);
            GbxModbusStatus.Controls.Add(StatusConnected);
            GbxModbusStatus.Controls.Add(label2);
            GbxModbusStatus.Location = new Point(15, 319);
            GbxModbusStatus.Name = "GbxModbusStatus";
            GbxModbusStatus.Size = new Size(330, 159);
            GbxModbusStatus.TabIndex = 2;
            GbxModbusStatus.TabStop = false;
            GbxModbusStatus.Text = "Machine Status";
            // 
            // StatusHomePosition
            // 
            StatusHomePosition.Location = new Point(153, 121);
            StatusHomePosition.Name = "StatusHomePosition";
            StatusHomePosition.Size = new Size(18, 16);
            StatusHomePosition.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 120);
            label5.Name = "label5";
            label5.Size = new Size(97, 17);
            label5.TabIndex = 6;
            label5.Text = "Home position:";
            // 
            // StatusDoorClosed
            // 
            StatusDoorClosed.Location = new Point(153, 91);
            StatusDoorClosed.Name = "StatusDoorClosed";
            StatusDoorClosed.Size = new Size(18, 16);
            StatusDoorClosed.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 90);
            label4.Name = "label4";
            label4.Size = new Size(83, 17);
            label4.TabIndex = 4;
            label4.Text = "Door closed:";
            // 
            // StatusSystemError
            // 
            StatusSystemError.Location = new Point(153, 61);
            StatusSystemError.Name = "StatusSystemError";
            StatusSystemError.Size = new Size(18, 16);
            StatusSystemError.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 60);
            label3.Name = "label3";
            label3.Size = new Size(86, 17);
            label3.TabIndex = 2;
            label3.Text = "System error:";
            // 
            // StatusConnected
            // 
            StatusConnected.Location = new Point(153, 31);
            StatusConnected.Name = "StatusConnected";
            StatusConnected.Size = new Size(18, 16);
            StatusConnected.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 30);
            label2.Name = "label2";
            label2.Size = new Size(91, 17);
            label2.TabIndex = 0;
            label2.Text = "Plc connected:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Underline);
            label6.Location = new Point(85, 24);
            label6.Name = "label6";
            label6.Size = new Size(125, 19);
            label6.TabIndex = 3;
            label6.Text = "Machine Controls";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnClose.BackColor = Color.YellowGreen;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Location = new Point(117, 629);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(104, 43);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // PbxRefreshModbusInfo
            // 
            PbxRefreshModbusInfo.Cursor = Cursors.Hand;
            PbxRefreshModbusInfo.Image = (Image)resources.GetObject("PbxRefreshModbusInfo.Image");
            PbxRefreshModbusInfo.Location = new Point(229, 27);
            PbxRefreshModbusInfo.Name = "PbxRefreshModbusInfo";
            PbxRefreshModbusInfo.Size = new Size(32, 18);
            PbxRefreshModbusInfo.SizeMode = PictureBoxSizeMode.Zoom;
            PbxRefreshModbusInfo.TabIndex = 9;
            PbxRefreshModbusInfo.TabStop = false;
            toolTip1.SetToolTip(PbxRefreshModbusInfo, "Refresh info");
            PbxRefreshModbusInfo.Click += PictureBoxRefreshInfo_Click;
            // 
            // BtnResetSystem
            // 
            BtnResetSystem.BackColor = Color.FromArgb(255, 192, 128);
            BtnResetSystem.Cursor = Cursors.Hand;
            BtnResetSystem.Location = new Point(137, 37);
            BtnResetSystem.Margin = new Padding(4, 3, 4, 3);
            BtnResetSystem.Name = "BtnResetSystem";
            BtnResetSystem.Size = new Size(81, 36);
            BtnResetSystem.TabIndex = 6;
            BtnResetSystem.Text = "Reset";
            toolTip1.SetToolTip(BtnResetSystem, "Go to home position");
            BtnResetSystem.UseVisualStyleBackColor = false;
            BtnResetSystem.Click += BtnResetSystem_Click;
            // 
            // GbxUserActions
            // 
            GbxUserActions.BackColor = Color.WhiteSmoke;
            GbxUserActions.Controls.Add(BtnResetSystem);
            GbxUserActions.Controls.Add(label7);
            GbxUserActions.Location = new Point(15, 500);
            GbxUserActions.Name = "GbxUserActions";
            GbxUserActions.Size = new Size(330, 103);
            GbxUserActions.TabIndex = 2;
            GbxUserActions.TabStop = false;
            GbxUserActions.Text = "User Actions";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F);
            label7.Location = new Point(29, 48);
            label7.Name = "label7";
            label7.Size = new Size(78, 15);
            label7.TabIndex = 1;
            label7.Text = "Reset system:";
            // 
            // timer1
            // 
            timer1.Interval = 3000;
            timer1.Tick += Timer1_Tick;
            // 
            // ModbusControls
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(GbxUserActions);
            Controls.Add(PbxRefreshModbusInfo);
            Controls.Add(btnClose);
            Controls.Add(label6);
            Controls.Add(GbxModbusStatus);
            Controls.Add(GbxMotorPos);
            Controls.Add(GbxLights);
            Font = new Font("Segoe UI", 9.5F);
            Name = "ModbusControls";
            Size = new Size(372, 692);
            GbxLights.ResumeLayout(false);
            GbxMotorPos.ResumeLayout(false);
            GbxMotorPos.PerformLayout();
            GbxModbusStatus.ResumeLayout(false);
            GbxModbusStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PbxRefreshModbusInfo).EndInit();
            GbxUserActions.ResumeLayout(false);
            GbxUserActions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox GbxLights;
        private Button BtnLightsOn;
        private Button BtnLightsOff;
        private GroupBox GbxMotorPos;
        private ComboBox comboBoxMotorPos;
        private Label label1;
        private GroupBox GbxModbusStatus;
        private Panel StatusSystemError;
        private Label label3;
        private Panel StatusConnected;
        private Label label2;
        private Panel StatusHomePosition;
        private Label label5;
        private Panel StatusDoorClosed;
        private Label label4;
        private Label label6;
        private Button btnClose;
        private PictureBox PbxRefreshModbusInfo;
        private ToolTip toolTip1;
        private GroupBox GbxUserActions;
        private Label label7;
        private Label label8;
        private TextBox textBoxCurrentPos;
        private Button BtnResetSystem;
        private System.Windows.Forms.Timer timer1;
    }
}
