namespace TriCamPylonView.UI.Forms
{
    partial class ImageResizerForm
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
            btnSave = new Button();
            btnCancel = new Button();
            groupBox4 = new GroupBox();
            ResizeFactor = new NumericUpDown();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ResizeFactor).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.YellowGreen;
            btnSave.Location = new Point(51, 146);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 38);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.RosyBrown;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(188, 146);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 38);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(ResizeFactor);
            groupBox4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(19, 32);
            groupBox4.Margin = new Padding(8);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(6, 9, 6, 6);
            groupBox4.Size = new Size(296, 61);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Image Resize Factor (0,1 - 1)";
            groupBox4.UseCompatibleTextRendering = true;
            // 
            // ResizeFactor
            // 
            ResizeFactor.DecimalPlaces = 1;
            ResizeFactor.Dock = DockStyle.Fill;
            ResizeFactor.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            ResizeFactor.Location = new Point(6, 25);
            ResizeFactor.Margin = new Padding(4, 3, 4, 3);
            ResizeFactor.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            ResizeFactor.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            ResizeFactor.Name = "ResizeFactor";
            ResizeFactor.Size = new Size(284, 23);
            ResizeFactor.TabIndex = 0;
            ResizeFactor.Value = new decimal(new int[] { 1, 0, 0, 0 });
            ResizeFactor.KeyDown += ResizeFactor_KeyDown;
            // 
            // ImageResizerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(355, 214);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(groupBox4);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ImageResizerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Resize Image";
            TopMost = true;
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ResizeFactor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown ResizeFactor;
    }
}