namespace simple_ids_cam_view.UI.Forms
{
    partial class NewPositionForm
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
            FLP_Main = new FlowLayoutPanel();
            labelTitle = new Label();
            gbxName = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            textBoxPosId = new TextBox();
            groupBox1 = new GroupBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            textBoxCV = new TextBox();
            groupBox2 = new GroupBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            textBoxCH = new TextBox();
            gbxCountry = new GroupBox();
            comboBoxCountry = new ComboBox();
            gbxSampleSection = new GroupBox();
            comboBoxSampleSection = new ComboBox();
            panel1 = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            FLP_Main.SuspendLayout();
            gbxName.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            groupBox2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            gbxCountry.SuspendLayout();
            gbxSampleSection.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // FLP_Main
            // 
            FLP_Main.AutoSize = true;
            FLP_Main.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FLP_Main.Controls.Add(labelTitle);
            FLP_Main.Controls.Add(gbxName);
            FLP_Main.Controls.Add(groupBox1);
            FLP_Main.Controls.Add(groupBox2);
            FLP_Main.Controls.Add(gbxCountry);
            FLP_Main.Controls.Add(gbxSampleSection);
            FLP_Main.Controls.Add(panel1);
            FLP_Main.Dock = DockStyle.Fill;
            FLP_Main.FlowDirection = FlowDirection.TopDown;
            FLP_Main.Location = new Point(0, 0);
            FLP_Main.Name = "FLP_Main";
            FLP_Main.Padding = new Padding(32, 6, 20, 6);
            FLP_Main.Size = new Size(309, 544);
            FLP_Main.TabIndex = 0;
            FLP_Main.WrapContents = false;
            FLP_Main.Click += FLP_Main_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Underline);
            labelTitle.Location = new Point(37, 17);
            labelTitle.Margin = new Padding(5, 11, 10, 23);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(203, 17);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Please enter the following details:";
            // 
            // gbxName
            // 
            gbxName.AutoSize = true;
            gbxName.Controls.Add(flowLayoutPanel1);
            gbxName.Location = new Point(39, 63);
            gbxName.Margin = new Padding(7, 6, 7, 6);
            gbxName.Name = "gbxName";
            gbxName.Padding = new Padding(1, 1, 1, 2);
            gbxName.Size = new Size(202, 66);
            gbxName.TabIndex = 1;
            gbxName.TabStop = false;
            gbxName.Text = "Pos Id *";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(textBoxPosId);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(1, 18);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(6, 7, 6, 6);
            flowLayoutPanel1.Size = new Size(200, 46);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // textBoxPosId
            // 
            textBoxPosId.Location = new Point(9, 13);
            textBoxPosId.Margin = new Padding(3, 6, 3, 3);
            textBoxPosId.Name = "textBoxPosId";
            textBoxPosId.PlaceholderText = "Enter Pos Id ";
            textBoxPosId.ReadOnly = true;
            textBoxPosId.Size = new Size(182, 24);
            textBoxPosId.TabIndex = 0;
            textBoxPosId.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(flowLayoutPanel2);
            groupBox1.Location = new Point(39, 141);
            groupBox1.Margin = new Padding(7, 6, 7, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(1, 1, 1, 2);
            groupBox1.Size = new Size(202, 66);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "CV *";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(textBoxCV);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(1, 18);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(6, 7, 6, 6);
            flowLayoutPanel2.Size = new Size(200, 46);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // textBoxCV
            // 
            textBoxCV.Location = new Point(9, 13);
            textBoxCV.Margin = new Padding(3, 6, 3, 3);
            textBoxCV.Name = "textBoxCV";
            textBoxCV.PlaceholderText = "Enter vertical coordinate";
            textBoxCV.Size = new Size(182, 24);
            textBoxCV.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(flowLayoutPanel3);
            groupBox2.Location = new Point(39, 219);
            groupBox2.Margin = new Padding(7, 6, 7, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(1, 1, 1, 2);
            groupBox2.Size = new Size(202, 66);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "CH *";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel3.Controls.Add(textBoxCH);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(1, 18);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Padding = new Padding(6, 7, 6, 6);
            flowLayoutPanel3.Size = new Size(200, 46);
            flowLayoutPanel3.TabIndex = 0;
            // 
            // textBoxCH
            // 
            textBoxCH.Location = new Point(9, 13);
            textBoxCH.Margin = new Padding(3, 6, 3, 3);
            textBoxCH.Name = "textBoxCH";
            textBoxCH.PlaceholderText = "Enter horizontal coordinate";
            textBoxCH.Size = new Size(182, 24);
            textBoxCH.TabIndex = 0;
            // 
            // gbxCountry
            // 
            gbxCountry.Controls.Add(comboBoxCountry);
            gbxCountry.Location = new Point(39, 299);
            gbxCountry.Margin = new Padding(7, 8, 5, 6);
            gbxCountry.Name = "gbxCountry";
            gbxCountry.Padding = new Padding(7, 9, 7, 8);
            gbxCountry.Size = new Size(202, 61);
            gbxCountry.TabIndex = 4;
            gbxCountry.TabStop = false;
            gbxCountry.Text = "Country *";
            // 
            // comboBoxCountry
            // 
            comboBoxCountry.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxCountry.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxCountry.Dock = DockStyle.Fill;
            comboBoxCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCountry.FormattingEnabled = true;
            comboBoxCountry.Items.AddRange(new object[] { "Portugal", "Morocco" });
            comboBoxCountry.Location = new Point(7, 26);
            comboBoxCountry.Name = "comboBoxCountry";
            comboBoxCountry.Size = new Size(188, 25);
            comboBoxCountry.TabIndex = 0;
            // 
            // gbxSampleSection
            // 
            gbxSampleSection.Controls.Add(comboBoxSampleSection);
            gbxSampleSection.Location = new Point(39, 374);
            gbxSampleSection.Margin = new Padding(7, 8, 5, 6);
            gbxSampleSection.Name = "gbxSampleSection";
            gbxSampleSection.Padding = new Padding(7, 9, 7, 8);
            gbxSampleSection.Size = new Size(202, 61);
            gbxSampleSection.TabIndex = 5;
            gbxSampleSection.TabStop = false;
            gbxSampleSection.Text = "Sample Section *";
            // 
            // comboBoxSampleSection
            // 
            comboBoxSampleSection.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxSampleSection.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxSampleSection.Dock = DockStyle.Fill;
            comboBoxSampleSection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSampleSection.FormattingEnabled = true;
            comboBoxSampleSection.Items.AddRange(new object[] { "Portugal", "Morocco" });
            comboBoxSampleSection.Location = new Point(7, 26);
            comboBoxSampleSection.Name = "comboBoxSampleSection";
            comboBoxSampleSection.Size = new Size(188, 25);
            comboBoxSampleSection.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnSave);
            panel1.Location = new Point(35, 471);
            panel1.Margin = new Padding(3, 30, 3, 3);
            panel1.MinimumSize = new Size(220, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15, 6, 20, 6);
            panel1.Size = new Size(220, 50);
            panel1.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.RosyBrown;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(132, 6);
            btnCancel.Margin = new Padding(10, 11, 10, 11);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(73, 39);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.YellowGreen;
            btnSave.Location = new Point(11, 6);
            btnSave.Margin = new Padding(10, 11, 10, 11);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(74, 39);
            btnSave.TabIndex = 0;
            btnSave.Text = "OK";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_ClickAsync;
            // 
            // NewPositionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(309, 544);
            Controls.Add(FLP_Main);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "NewPositionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Enter new position coordinates";
            FLP_Main.ResumeLayout(false);
            FLP_Main.PerformLayout();
            gbxName.ResumeLayout(false);
            gbxName.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            gbxCountry.ResumeLayout(false);
            gbxSampleSection.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel FLP_Main;
        private Label labelTitle;
        private GroupBox gbxName;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox textBoxPosId;
        private Panel panel1;
        private Button btnCancel;
        private Button btnSave;
        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel2;
        private TextBox textBoxCV;
        private GroupBox groupBox2;
        private FlowLayoutPanel flowLayoutPanel3;
        private TextBox textBoxCH;
        private GroupBox gbxCountry;
        private ComboBox comboBoxCountry;
        private GroupBox gbxSampleSection;
        private ComboBox comboBoxSampleSection;
    }
}