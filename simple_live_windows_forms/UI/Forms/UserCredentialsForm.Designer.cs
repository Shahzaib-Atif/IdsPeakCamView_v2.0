namespace simple_ids_cam_view.UI.Forms
{
    partial class UserCredentialsForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserCredentialsForm));
            gboxUserId = new GroupBox();
            textBoxUserId = new TextBox();
            gboxPassword = new GroupBox();
            textBoxPassword = new TextBox();
            SaveBtn = new Button();
            CancelBtn = new Button();
            gbxWindowsAuth = new GroupBox();
            pictureBox1 = new PictureBox();
            checkBoxWindowsAuth = new CheckBox();
            gbxDatabaseName = new GroupBox();
            textBoxDatabaseName = new TextBox();
            gbxServerName = new GroupBox();
            textboxServerName = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            toolTip1 = new ToolTip(components);
            gboxUserId.SuspendLayout();
            gboxPassword.SuspendLayout();
            gbxWindowsAuth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            gbxDatabaseName.SuspendLayout();
            gbxServerName.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // gboxUserId
            // 
            gboxUserId.Controls.Add(textBoxUserId);
            gboxUserId.Location = new Point(33, 241);
            gboxUserId.Margin = new Padding(3, 3, 3, 11);
            gboxUserId.Name = "gboxUserId";
            gboxUserId.Size = new Size(242, 54);
            gboxUserId.TabIndex = 3;
            gboxUserId.TabStop = false;
            gboxUserId.Text = "User Id";
            // 
            // textBoxUserId
            // 
            textBoxUserId.Dock = DockStyle.Fill;
            textBoxUserId.Font = new Font("Segoe UI", 9.5F);
            textBoxUserId.Location = new Point(3, 20);
            textBoxUserId.Multiline = true;
            textBoxUserId.Name = "textBoxUserId";
            textBoxUserId.PlaceholderText = "Enter user Id";
            textBoxUserId.Size = new Size(236, 31);
            textBoxUserId.TabIndex = 0;
            textBoxUserId.TextAlign = HorizontalAlignment.Center;
            textBoxUserId.TextChanged += TextBoxDatabaseFields_TextChanged;
            textBoxUserId.KeyDown += TextBox_KeyDown;
            // 
            // gboxPassword
            // 
            gboxPassword.Controls.Add(textBoxPassword);
            gboxPassword.Location = new Point(33, 309);
            gboxPassword.Margin = new Padding(3, 3, 3, 11);
            gboxPassword.Name = "gboxPassword";
            gboxPassword.Size = new Size(242, 54);
            gboxPassword.TabIndex = 4;
            gboxPassword.TabStop = false;
            gboxPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Dock = DockStyle.Fill;
            textBoxPassword.Font = new Font("Segoe UI", 9.5F);
            textBoxPassword.Location = new Point(3, 20);
            textBoxPassword.Multiline = true;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.PlaceholderText = "Enter password";
            textBoxPassword.Size = new Size(236, 31);
            textBoxPassword.TabIndex = 0;
            textBoxPassword.TextAlign = HorizontalAlignment.Center;
            textBoxPassword.TextChanged += TextBoxDatabaseFields_TextChanged;
            textBoxPassword.KeyDown += TextBox_KeyDown;
            // 
            // SaveBtn
            // 
            SaveBtn.BackColor = Color.YellowGreen;
            SaveBtn.Location = new Point(15, 53);
            SaveBtn.Margin = new Padding(4, 3, 4, 3);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(88, 43);
            SaveBtn.TabIndex = 0;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = false;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = Color.RosyBrown;
            CancelBtn.DialogResult = DialogResult.Cancel;
            CancelBtn.Location = new Point(138, 53);
            CancelBtn.Margin = new Padding(4, 3, 4, 3);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(88, 43);
            CancelBtn.TabIndex = 1;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = false;
            // 
            // gbxWindowsAuth
            // 
            gbxWindowsAuth.Controls.Add(pictureBox1);
            gbxWindowsAuth.Controls.Add(checkBoxWindowsAuth);
            gbxWindowsAuth.Location = new Point(33, 173);
            gbxWindowsAuth.Margin = new Padding(3, 3, 3, 11);
            gbxWindowsAuth.Name = "gbxWindowsAuth";
            gbxWindowsAuth.Padding = new Padding(15, 0, 7, 8);
            gbxWindowsAuth.Size = new Size(242, 54);
            gbxWindowsAuth.TabIndex = 2;
            gbxWindowsAuth.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Help;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(222, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(13, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            toolTip1.SetToolTip(pictureBox1, "If windows authentication is selected, there is no need for user id and password");
            // 
            // checkBoxWindowsAuth
            // 
            checkBoxWindowsAuth.AutoSize = true;
            checkBoxWindowsAuth.Cursor = Cursors.Hand;
            checkBoxWindowsAuth.Dock = DockStyle.Fill;
            checkBoxWindowsAuth.Font = new Font("Segoe UI", 9.5F);
            checkBoxWindowsAuth.Location = new Point(15, 17);
            checkBoxWindowsAuth.Name = "checkBoxWindowsAuth";
            checkBoxWindowsAuth.Size = new Size(220, 29);
            checkBoxWindowsAuth.TabIndex = 0;
            checkBoxWindowsAuth.Text = "Windows authentication";
            checkBoxWindowsAuth.UseVisualStyleBackColor = true;
            checkBoxWindowsAuth.CheckedChanged += CheckBoxWindowsAuth_CheckedChanged;
            // 
            // gbxDatabaseName
            // 
            gbxDatabaseName.Controls.Add(textBoxDatabaseName);
            gbxDatabaseName.Location = new Point(33, 105);
            gbxDatabaseName.Margin = new Padding(3, 3, 3, 11);
            gbxDatabaseName.Name = "gbxDatabaseName";
            gbxDatabaseName.Size = new Size(242, 54);
            gbxDatabaseName.TabIndex = 1;
            gbxDatabaseName.TabStop = false;
            gbxDatabaseName.Text = "Database name";
            // 
            // textBoxDatabaseName
            // 
            textBoxDatabaseName.Dock = DockStyle.Fill;
            textBoxDatabaseName.Font = new Font("Segoe UI", 9.5F);
            textBoxDatabaseName.Location = new Point(3, 20);
            textBoxDatabaseName.Multiline = true;
            textBoxDatabaseName.Name = "textBoxDatabaseName";
            textBoxDatabaseName.PlaceholderText = "Enter database name";
            textBoxDatabaseName.Size = new Size(236, 31);
            textBoxDatabaseName.TabIndex = 0;
            textBoxDatabaseName.TextAlign = HorizontalAlignment.Center;
            textBoxDatabaseName.UseSystemPasswordChar = true;
            textBoxDatabaseName.TextChanged += TextBoxDatabaseFields_TextChanged;
            textBoxDatabaseName.KeyDown += TextBox_KeyDown;
            // 
            // gbxServerName
            // 
            gbxServerName.Controls.Add(textboxServerName);
            gbxServerName.Location = new Point(33, 37);
            gbxServerName.Margin = new Padding(3, 3, 3, 11);
            gbxServerName.Name = "gbxServerName";
            gbxServerName.Size = new Size(242, 54);
            gbxServerName.TabIndex = 0;
            gbxServerName.TabStop = false;
            gbxServerName.Text = "Server name";
            // 
            // textboxServerName
            // 
            textboxServerName.Dock = DockStyle.Fill;
            textboxServerName.Font = new Font("Segoe UI", 9.5F);
            textboxServerName.Location = new Point(3, 20);
            textboxServerName.Multiline = true;
            textboxServerName.Name = "textboxServerName";
            textboxServerName.PlaceholderText = "Enter server name";
            textboxServerName.Size = new Size(236, 31);
            textboxServerName.TabIndex = 0;
            textboxServerName.TextAlign = HorizontalAlignment.Center;
            textboxServerName.TextChanged += TextBoxDatabaseFields_TextChanged;
            textboxServerName.KeyDown += TextBox_KeyDown;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(gbxServerName);
            flowLayoutPanel1.Controls.Add(gbxDatabaseName);
            flowLayoutPanel1.Controls.Add(gbxWindowsAuth);
            flowLayoutPanel1.Controls.Add(gboxUserId);
            flowLayoutPanel1.Controls.Add(gboxPassword);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(30, 34, 30, 34);
            flowLayoutPanel1.Size = new Size(333, 530);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(SaveBtn);
            panel1.Controls.Add(CancelBtn);
            panel1.Location = new Point(33, 377);
            panel1.Name = "panel1";
            panel1.Size = new Size(274, 116);
            panel1.TabIndex = 5;
            // 
            // toolTip1
            // 
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            // 
            // UserCredentialsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelBtn;
            ClientSize = new Size(333, 530);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "UserCredentialsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Update User DB credentials";
            gboxUserId.ResumeLayout(false);
            gboxUserId.PerformLayout();
            gboxPassword.ResumeLayout(false);
            gboxPassword.PerformLayout();
            gbxWindowsAuth.ResumeLayout(false);
            gbxWindowsAuth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            gbxDatabaseName.ResumeLayout(false);
            gbxDatabaseName.PerformLayout();
            gbxServerName.ResumeLayout(false);
            gbxServerName.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gboxUserId;
        private TextBox textBoxUserId;
        private GroupBox gboxPassword;
        private TextBox textBoxPassword;
        private Button SaveBtn;
        private Button CancelBtn;
        private GroupBox gbxWindowsAuth;
        private CheckBox checkBoxWindowsAuth;
        private GroupBox gbxDatabaseName;
        private TextBox textBoxDatabaseName;
        private GroupBox gbxServerName;
        private TextBox textboxServerName;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private ToolTip toolTip1;
        private PictureBox pictureBox1;
    }
}