namespace simple_ids_cam_view
{
    partial class EditTextForm
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
            textBox = new TextBox();
            groupBox1 = new GroupBox();
            btnUpdate = new Button();
            SelectColorBtn = new Button();
            showColorPanel = new Panel();
            SelectFontBtn = new Button();
            lblSampleText = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox
            // 
            textBox.Dock = DockStyle.Fill;
            textBox.Location = new Point(8, 26);
            textBox.Margin = new Padding(4, 3, 4, 3);
            textBox.Multiline = true;
            textBox.Name = "textBox";
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.Size = new Size(357, 64);
            textBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(textBox);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(8, 9, 8, 9);
            groupBox1.Size = new Size(373, 99);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add Description";
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpdate.BackColor = Color.YellowGreen;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.Location = new Point(97, 300);
            btnUpdate.Margin = new Padding(4, 3, 4, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(190, 50);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // SelectColorBtn
            // 
            SelectColorBtn.BackColor = Color.LightGray;
            SelectColorBtn.Cursor = Cursors.Hand;
            SelectColorBtn.FlatAppearance.BorderColor = Color.Black;
            SelectColorBtn.Location = new Point(97, 153);
            SelectColorBtn.Margin = new Padding(4, 3, 4, 3);
            SelectColorBtn.Name = "SelectColorBtn";
            SelectColorBtn.Size = new Size(110, 43);
            SelectColorBtn.TabIndex = 1;
            SelectColorBtn.Text = "Select a color";
            SelectColorBtn.UseVisualStyleBackColor = false;
            SelectColorBtn.Click += SelectColorBtn_Click;
            // 
            // showColorPanel
            // 
            showColorPanel.BorderStyle = BorderStyle.FixedSingle;
            showColorPanel.Location = new Point(214, 162);
            showColorPanel.Margin = new Padding(4, 3, 4, 3);
            showColorPanel.Name = "showColorPanel";
            showColorPanel.Size = new Size(21, 22);
            showColorPanel.TabIndex = 6;
            // 
            // SelectFontBtn
            // 
            SelectFontBtn.BackColor = Color.LightGray;
            SelectFontBtn.Cursor = Cursors.Hand;
            SelectFontBtn.FlatAppearance.BorderColor = Color.Black;
            SelectFontBtn.Location = new Point(97, 204);
            SelectFontBtn.Margin = new Padding(4, 3, 4, 3);
            SelectFontBtn.Name = "SelectFontBtn";
            SelectFontBtn.Size = new Size(110, 43);
            SelectFontBtn.TabIndex = 2;
            SelectFontBtn.Text = "Pick a font";
            SelectFontBtn.UseVisualStyleBackColor = false;
            SelectFontBtn.Click += SelectFontBtn_Click;
            // 
            // lblSampleText
            // 
            lblSampleText.AutoSize = true;
            lblSampleText.Location = new Point(210, 218);
            lblSampleText.Margin = new Padding(4, 0, 4, 0);
            lblSampleText.Name = "lblSampleText";
            lblSampleText.Size = new Size(78, 17);
            lblSampleText.TabIndex = 8;
            lblSampleText.Text = "Sample Text";
            // 
            // EditTextForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(401, 378);
            Controls.Add(lblSampleText);
            Controls.Add(SelectFontBtn);
            Controls.Add(showColorPanel);
            Controls.Add(SelectColorBtn);
            Controls.Add(btnUpdate);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "EditTextForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add or Edit Description";
            KeyDown += ImageDescriptionForm_KeyDown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button SelectColorBtn;
        private System.Windows.Forms.Panel showColorPanel;
        private System.Windows.Forms.Button SelectFontBtn;
        private System.Windows.Forms.Label lblSampleText;
    }
}