namespace simple_ids_cam_view.UI.Controls
{
    partial class SynchronizedStepperControl
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
            groupBox = new GroupBox();
            FlpValue = new FlowLayoutPanel();
            LabelDecrement = new Label();
            textBoxValue = new TextBox();
            LabelIncrement = new Label();
            labelAuto = new Label();
            RadioButtonOff = new RadioButton();
            RadioButtonOn = new RadioButton();
            trackBar = new TrackBar();
            groupBox.SuspendLayout();
            FlpValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit();
            SuspendLayout();
            // 
            // groupBox
            // 
            groupBox.BackColor = SystemColors.Control;
            groupBox.Controls.Add(FlpValue);
            groupBox.Controls.Add(labelAuto);
            groupBox.Controls.Add(RadioButtonOff);
            groupBox.Controls.Add(RadioButtonOn);
            groupBox.Controls.Add(trackBar);
            groupBox.Dock = DockStyle.Fill;
            groupBox.Font = new Font("Segoe UI", 9.5F);
            groupBox.Location = new Point(4, 6);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(332, 155);
            groupBox.TabIndex = 0;
            groupBox.TabStop = false;
            groupBox.Text = "Exposure time [ms]";
            // 
            // FlpValue
            // 
            FlpValue.AutoSize = true;
            FlpValue.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FlpValue.BackColor = Color.White;
            FlpValue.BorderStyle = BorderStyle.FixedSingle;
            FlpValue.Controls.Add(LabelDecrement);
            FlpValue.Controls.Add(textBoxValue);
            FlpValue.Controls.Add(LabelIncrement);
            FlpValue.Location = new Point(206, 39);
            FlpValue.Name = "FlpValue";
            FlpValue.Size = new Size(84, 30);
            FlpValue.TabIndex = 5;
            // 
            // LabelDecrement
            // 
            LabelDecrement.BackColor = Color.LightGray;
            LabelDecrement.Cursor = Cursors.Hand;
            LabelDecrement.Dock = DockStyle.Left;
            LabelDecrement.Font = new Font("Segoe UI", 9.5F);
            LabelDecrement.ForeColor = SystemColors.ControlDarkDark;
            LabelDecrement.Location = new Point(0, 1);
            LabelDecrement.Margin = new Padding(0, 1, 0, 1);
            LabelDecrement.Name = "LabelDecrement";
            LabelDecrement.Size = new Size(17, 26);
            LabelDecrement.TabIndex = 3;
            LabelDecrement.Text = "◀";
            LabelDecrement.TextAlign = ContentAlignment.MiddleRight;
            LabelDecrement.MouseDown += LabelDecrement_MouseDown;
            // 
            // textBoxValue
            // 
            textBoxValue.BackColor = Color.White;
            textBoxValue.BorderStyle = BorderStyle.None;
            textBoxValue.Font = new Font("Segoe UI Light", 12F, FontStyle.Bold);
            textBoxValue.ForeColor = Color.Black;
            textBoxValue.Location = new Point(18, 3);
            textBoxValue.Margin = new Padding(1, 3, 1, 3);
            textBoxValue.Name = "textBoxValue";
            textBoxValue.Size = new Size(46, 22);
            textBoxValue.TabIndex = 2;
            textBoxValue.Text = "0";
            textBoxValue.TextAlign = HorizontalAlignment.Center;
            textBoxValue.KeyDown += TextBoxValue_KeyDown;
            // 
            // LabelIncrement
            // 
            LabelIncrement.BackColor = Color.LightGray;
            LabelIncrement.Cursor = Cursors.Hand;
            LabelIncrement.Dock = DockStyle.Right;
            LabelIncrement.Font = new Font("Segoe UI", 9.5F);
            LabelIncrement.ForeColor = SystemColors.ControlDarkDark;
            LabelIncrement.Location = new Point(65, 1);
            LabelIncrement.Margin = new Padding(0, 1, 0, 1);
            LabelIncrement.Name = "LabelIncrement";
            LabelIncrement.Size = new Size(17, 26);
            LabelIncrement.TabIndex = 4;
            LabelIncrement.Text = "▶";
            LabelIncrement.TextAlign = ContentAlignment.MiddleLeft;
            LabelIncrement.MouseDown += LabelIncrement_MouseDown;
            // 
            // labelAuto
            // 
            labelAuto.AutoSize = true;
            labelAuto.Location = new Point(31, 96);
            labelAuto.Name = "labelAuto";
            labelAuto.Size = new Size(38, 17);
            labelAuto.TabIndex = 2;
            labelAuto.Text = "Auto:";
            // 
            // RadioButtonOff
            // 
            RadioButtonOff.AutoSize = true;
            RadioButtonOff.Location = new Point(112, 116);
            RadioButtonOff.Name = "RadioButtonOff";
            RadioButtonOff.Size = new Size(44, 21);
            RadioButtonOff.TabIndex = 4;
            RadioButtonOff.Text = "Off";
            RadioButtonOff.UseVisualStyleBackColor = true;
            RadioButtonOff.CheckedChanged += RadioButtonOff_CheckedChanged;
            // 
            // RadioButtonOn
            // 
            RadioButtonOn.AutoSize = true;
            RadioButtonOn.Checked = true;
            RadioButtonOn.Location = new Point(63, 116);
            RadioButtonOn.Name = "RadioButtonOn";
            RadioButtonOn.Size = new Size(43, 21);
            RadioButtonOn.TabIndex = 3;
            RadioButtonOn.TabStop = true;
            RadioButtonOn.Text = "On";
            RadioButtonOn.UseVisualStyleBackColor = true;
            RadioButtonOn.CheckedChanged += RadioButtonOn_CheckedChanged;
            // 
            // trackBar
            // 
            trackBar.Cursor = Cursors.SizeAll;
            trackBar.Location = new Point(11, 33);
            trackBar.Maximum = 4200;
            trackBar.Name = "trackBar";
            trackBar.Size = new Size(174, 45);
            trackBar.TabIndex = 0;
            trackBar.TickStyle = TickStyle.Both;
            trackBar.ValueChanged += TrackBar_ValueChanged;
            // 
            // SynchronizedStepperControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(groupBox);
            Name = "SynchronizedStepperControl";
            Padding = new Padding(4, 6, 4, 4);
            Size = new Size(340, 165);
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            FlpValue.ResumeLayout(false);
            FlpValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox;
        private TrackBar trackBar;
        private RadioButton RadioButtonOn;
        private RadioButton RadioButtonOff;
        private Label labelAuto;
        private FlowLayoutPanel FlpValue;
        private TextBox textBoxValue;
        private Label LabelDecrement;
        private Label LabelIncrement;
    }
}
