namespace simple_ids_cam_view.UI.Forms
{
    partial class DefaultFolderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultFolderForm));
            CancelBtn = new Button();
            SaveBtn = new Button();
            textBoxFolderPath = new TextBox();
            UpdateFolderBtn = new Button();
            SuspendLayout();
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = Color.RosyBrown;
            CancelBtn.DialogResult = DialogResult.Cancel;
            CancelBtn.Location = new Point(212, 151);
            CancelBtn.Margin = new Padding(4, 3, 4, 3);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(88, 43);
            CancelBtn.TabIndex = 2;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = false;
            // 
            // SaveBtn
            // 
            SaveBtn.BackColor = Color.YellowGreen;
            SaveBtn.Location = new Point(84, 151);
            SaveBtn.Margin = new Padding(4, 3, 4, 3);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(88, 43);
            SaveBtn.TabIndex = 1;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = false;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // textBoxFolderPath
            // 
            textBoxFolderPath.Location = new Point(39, 53);
            textBoxFolderPath.Multiline = true;
            textBoxFolderPath.Name = "textBoxFolderPath";
            textBoxFolderPath.Size = new Size(311, 26);
            textBoxFolderPath.TabIndex = 0;
            textBoxFolderPath.Text = "C:\\Users\\mohammad.atif\\Desktop\\temp2";
            textBoxFolderPath.TextChanged += TextBoxFolderPath_TextChanged;
            textBoxFolderPath.KeyDown += TextBoxFolderPath_KeyDown;
            // 
            // UpdateFolderBtn
            // 
            UpdateFolderBtn.BackColor = SystemColors.Window;
            UpdateFolderBtn.FlatAppearance.BorderSize = 0;
            UpdateFolderBtn.FlatStyle = FlatStyle.Flat;
            UpdateFolderBtn.Image = (Image)resources.GetObject("UpdateFolderBtn.Image");
            UpdateFolderBtn.Location = new Point(312, 56);
            UpdateFolderBtn.Name = "UpdateFolderBtn";
            UpdateFolderBtn.Size = new Size(32, 22);
            UpdateFolderBtn.TabIndex = 3;
            UpdateFolderBtn.UseVisualStyleBackColor = false;
            UpdateFolderBtn.Click += UpdateFolderBtn_Click;
            // 
            // DefaultFolderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelBtn;
            ClientSize = new Size(413, 228);
            Controls.Add(UpdateFolderBtn);
            Controls.Add(textBoxFolderPath);
            Controls.Add(SaveBtn);
            Controls.Add(CancelBtn);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "DefaultFolderForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "View or Update Default Folder";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CancelBtn;
        private Button SaveBtn;
        private TextBox textBoxFolderPath;
        private Button UpdateFolderBtn;
    }
}