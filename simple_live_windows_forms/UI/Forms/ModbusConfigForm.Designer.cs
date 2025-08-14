namespace simple_ids_cam_view.UI.Forms
{
    partial class ModbusConfigForm
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
            textBoxIpAddr = new TextBox();
            SaveBtn = new Button();
            CancelBtn = new Button();
            gboxIPAddr = new GroupBox();
            gboxPort = new GroupBox();
            textBoxPort = new TextBox();
            gboxIPAddr.SuspendLayout();
            gboxPort.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxIpAddr
            // 
            textBoxIpAddr.Dock = DockStyle.Fill;
            textBoxIpAddr.Font = new Font("Segoe UI", 9.5F);
            textBoxIpAddr.Location = new Point(3, 20);
            textBoxIpAddr.Multiline = true;
            textBoxIpAddr.Name = "textBoxIpAddr";
            textBoxIpAddr.Size = new Size(218, 31);
            textBoxIpAddr.TabIndex = 0;
            textBoxIpAddr.Text = "10.0.0.1";
            textBoxIpAddr.TextAlign = HorizontalAlignment.Center;
            textBoxIpAddr.TextChanged += TextBoxFields_TextChanged;
            textBoxIpAddr.KeyDown += TextBoxModbus_KeyDown;
            // 
            // SaveBtn
            // 
            SaveBtn.BackColor = Color.YellowGreen;
            SaveBtn.Location = new Point(54, 245);
            SaveBtn.Margin = new Padding(4, 3, 4, 3);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(81, 43);
            SaveBtn.TabIndex = 2;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = false;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = Color.RosyBrown;
            CancelBtn.DialogResult = DialogResult.Cancel;
            CancelBtn.Location = new Point(185, 245);
            CancelBtn.Margin = new Padding(4, 3, 4, 3);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(81, 43);
            CancelBtn.TabIndex = 3;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = false;
            // 
            // gboxIPAddr
            // 
            gboxIPAddr.Controls.Add(textBoxIpAddr);
            gboxIPAddr.Location = new Point(48, 39);
            gboxIPAddr.Name = "gboxIPAddr";
            gboxIPAddr.Size = new Size(224, 54);
            gboxIPAddr.TabIndex = 0;
            gboxIPAddr.TabStop = false;
            gboxIPAddr.Text = "IP Address";
            // 
            // gboxPort
            // 
            gboxPort.Controls.Add(textBoxPort);
            gboxPort.Location = new Point(51, 118);
            gboxPort.Name = "gboxPort";
            gboxPort.Size = new Size(218, 54);
            gboxPort.TabIndex = 1;
            gboxPort.TabStop = false;
            gboxPort.Text = "Port no.";
            // 
            // textBoxPort
            // 
            textBoxPort.Dock = DockStyle.Fill;
            textBoxPort.Font = new Font("Segoe UI", 9.5F);
            textBoxPort.Location = new Point(3, 20);
            textBoxPort.Multiline = true;
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(212, 31);
            textBoxPort.TabIndex = 0;
            textBoxPort.Text = "52";
            textBoxPort.TextAlign = HorizontalAlignment.Center;
            textBoxPort.TextChanged += TextBoxFields_TextChanged;
            textBoxPort.KeyDown += TextBoxModbus_KeyDown;
            // 
            // ModbusConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelBtn;
            ClientSize = new Size(336, 328);
            Controls.Add(gboxPort);
            Controls.Add(gboxIPAddr);
            Controls.Add(SaveBtn);
            Controls.Add(CancelBtn);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ModbusConfigForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "View or Update Modbus Settings";
            gboxIPAddr.ResumeLayout(false);
            gboxIPAddr.PerformLayout();
            gboxPort.ResumeLayout(false);
            gboxPort.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxIpAddr;
        private Button SaveBtn;
        private Button CancelBtn;
        private GroupBox gboxIPAddr;
        private GroupBox gboxPort;
        private TextBox textBoxPort;
    }
}