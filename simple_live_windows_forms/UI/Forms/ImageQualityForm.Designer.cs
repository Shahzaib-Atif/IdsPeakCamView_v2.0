using ImageProcessingLibrary.Helpers;

namespace TriCamPylonView.UI
{
    partial class ImageQualityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageQualityForm));
            groupBox4 = new GroupBox();
            QualityIndex = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)QualityIndex).BeginInit();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(QualityIndex);
            groupBox4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(19, 24);
            groupBox4.Margin = new Padding(8, 8, 8, 8);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(6, 9, 6, 5);
            groupBox4.Size = new Size(282, 57);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Change Image Quality (20 - 100)";
            // 
            // QualityIndex
            // 
            QualityIndex.Dock = DockStyle.Fill;
            QualityIndex.Location = new Point(5, 24);
            QualityIndex.Minimum = new decimal(new int[] { 20, 0, 0, 0 });
            QualityIndex.Name = "QualityIndex";
            QualityIndex.Size = new Size(232, 23);
            QualityIndex.TabIndex = 0;
            QualityIndex.Value = new decimal(new int[] { 73, 0, 0, 0 });
            QualityIndex.KeyDown += QualityIndex_KeyDown;
            // 
            // btnSave
            // 
            btnSave.BackColor = UIColors.ButtonSuccess;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.ForeColor = Color.White;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Location = new Point(45, 125);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 36);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = UIColors.ButtonCancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.ForeColor = UIColors.TextPrimary;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(181, 125);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 36);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // ImageQualityForm
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = UIColors.Background;
            CancelButton = btnCancel;
            ClientSize = new Size(328, 193);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(groupBox4);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "ImageQualityForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update Image Quality";
            TopMost = true;
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)QualityIndex).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown QualityIndex;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}