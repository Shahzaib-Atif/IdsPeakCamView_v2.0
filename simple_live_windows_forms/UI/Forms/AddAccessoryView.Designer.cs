namespace simple_ids_cam_view.UI.Forms
{
    partial class AddAccessoryView
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
            GbxConnName = new GroupBox();
            textBoxName = new TextBox();
            groupBox1 = new GroupBox();
            textBoxRefDV = new TextBox();
            checkBoxColorAssociated = new CheckBox();
            groupBox2 = new GroupBox();
            numUpDownQty = new NumericUpDown();
            gbxCor = new GroupBox();
            textBoxReference = new TextBox();
            panel1 = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox4 = new GroupBox();
            comboBoxTipo = new ComboBox();
            gbxCapotAngle = new GroupBox();
            comboBoxCapotAngle = new ComboBox();
            gbxClipColor = new GroupBox();
            comboBoxClipColor = new ComboBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            FLP_Main.SuspendLayout();
            GbxConnName.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numUpDownQty).BeginInit();
            gbxCor.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox4.SuspendLayout();
            gbxCapotAngle.SuspendLayout();
            gbxClipColor.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // FLP_Main
            // 
            FLP_Main.AutoSize = true;
            FLP_Main.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FLP_Main.Controls.Add(GbxConnName);
            FLP_Main.Controls.Add(gbxCor);
            FLP_Main.Controls.Add(groupBox1);
            FLP_Main.Controls.Add(checkBoxColorAssociated);
            FLP_Main.FlowDirection = FlowDirection.TopDown;
            FLP_Main.Location = new Point(13, 13);
            FLP_Main.MinimumSize = new Size(200, 0);
            FLP_Main.Name = "FLP_Main";
            FLP_Main.Padding = new Padding(20, 6, 20, 6);
            FLP_Main.Size = new Size(241, 278);
            FLP_Main.TabIndex = 1;
            FLP_Main.WrapContents = false;
            // 
            // GbxConnName
            // 
            GbxConnName.Controls.Add(textBoxName);
            GbxConnName.Location = new Point(27, 12);
            GbxConnName.Margin = new Padding(7, 6, 5, 6);
            GbxConnName.Name = "GbxConnName";
            GbxConnName.Padding = new Padding(7, 8, 7, 8);
            GbxConnName.Size = new Size(189, 61);
            GbxConnName.TabIndex = 7;
            GbxConnName.TabStop = false;
            GbxConnName.Text = "Connector Name *";
            // 
            // textBoxName
            // 
            textBoxName.Dock = DockStyle.Fill;
            textBoxName.Location = new Point(7, 25);
            textBoxName.Margin = new Padding(3, 6, 3, 3);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Add connector name";
            textBoxName.Size = new Size(175, 24);
            textBoxName.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxRefDV);
            groupBox1.Location = new Point(27, 158);
            groupBox1.Margin = new Padding(7, 6, 5, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(7, 8, 7, 8);
            groupBox1.Size = new Size(189, 61);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ref DV";
            // 
            // textBoxRefDV
            // 
            textBoxRefDV.Dock = DockStyle.Fill;
            textBoxRefDV.Location = new Point(7, 25);
            textBoxRefDV.Margin = new Padding(3, 6, 3, 3);
            textBoxRefDV.Name = "textBoxRefDV";
            textBoxRefDV.PlaceholderText = "Add some reference";
            textBoxRefDV.Size = new Size(175, 24);
            textBoxRefDV.TabIndex = 1;
            // 
            // checkBoxColorAssociated
            // 
            checkBoxColorAssociated.AutoSize = true;
            checkBoxColorAssociated.Location = new Point(23, 228);
            checkBoxColorAssociated.Name = "checkBoxColorAssociated";
            checkBoxColorAssociated.Padding = new Padding(10);
            checkBoxColorAssociated.Size = new Size(146, 41);
            checkBoxColorAssociated.TabIndex = 0;
            checkBoxColorAssociated.Text = "Color Associated";
            checkBoxColorAssociated.UseVisualStyleBackColor = true;
            checkBoxColorAssociated.CheckedChanged += checkBoxColorAssociated_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(numUpDownQty);
            groupBox2.Location = new Point(27, 231);
            groupBox2.Margin = new Padding(7, 6, 5, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(7, 8, 7, 8);
            groupBox2.Size = new Size(105, 61);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Quantity";
            // 
            // numUpDownQty
            // 
            numUpDownQty.Dock = DockStyle.Fill;
            numUpDownQty.Font = new Font("Segoe UI", 10F);
            numUpDownQty.Location = new Point(7, 25);
            numUpDownQty.Name = "numUpDownQty";
            numUpDownQty.Size = new Size(91, 25);
            numUpDownQty.TabIndex = 0;
            numUpDownQty.TextAlign = HorizontalAlignment.Center;
            // 
            // gbxCor
            // 
            gbxCor.Controls.Add(textBoxReference);
            gbxCor.Location = new Point(27, 85);
            gbxCor.Margin = new Padding(7, 6, 5, 6);
            gbxCor.Name = "gbxCor";
            gbxCor.Padding = new Padding(7, 8, 7, 8);
            gbxCor.Size = new Size(189, 61);
            gbxCor.TabIndex = 4;
            gbxCor.TabStop = false;
            gbxCor.Text = "Reference *";
            // 
            // textBoxReference
            // 
            textBoxReference.Dock = DockStyle.Fill;
            textBoxReference.Location = new Point(7, 25);
            textBoxReference.Margin = new Padding(3, 6, 3, 3);
            textBoxReference.Name = "textBoxReference";
            textBoxReference.PlaceholderText = "Add some reference";
            textBoxReference.Size = new Size(175, 24);
            textBoxReference.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnSave);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 317);
            panel1.Margin = new Padding(3, 40, 3, 3);
            panel1.MinimumSize = new Size(220, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(8, 6, 8, 6);
            panel1.Size = new Size(536, 50);
            panel1.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.RosyBrown;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(281, 5);
            btnCancel.Margin = new Padding(1, 11, 10, 11);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(73, 38);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.YellowGreen;
            btnSave.Location = new Point(160, 5);
            btnSave.Margin = new Padding(1, 11, 10, 11);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(74, 38);
            btnSave.TabIndex = 0;
            btnSave.Text = "OK";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(groupBox4);
            flowLayoutPanel1.Controls.Add(gbxCapotAngle);
            flowLayoutPanel1.Controls.Add(gbxClipColor);
            flowLayoutPanel1.Controls.Add(groupBox2);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(260, 13);
            flowLayoutPanel1.MinimumSize = new Size(200, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(20, 6, 20, 6);
            flowLayoutPanel1.Size = new Size(241, 304);
            flowLayoutPanel1.TabIndex = 10;
            flowLayoutPanel1.WrapContents = false;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(comboBoxTipo);
            groupBox4.Location = new Point(27, 12);
            groupBox4.Margin = new Padding(7, 6, 5, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(7, 8, 7, 8);
            groupBox4.Size = new Size(189, 61);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Accessory Type *";
            // 
            // comboBoxTipo
            // 
            comboBoxTipo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxTipo.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxTipo.Dock = DockStyle.Fill;
            comboBoxTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipo.FormattingEnabled = true;
            comboBoxTipo.Items.AddRange(new object[] { "conector", "clip", "olhal", "grommet" });
            comboBoxTipo.Location = new Point(7, 25);
            comboBoxTipo.Name = "comboBoxTipo";
            comboBoxTipo.Size = new Size(175, 25);
            comboBoxTipo.TabIndex = 0;
            comboBoxTipo.SelectedIndexChanged += ComboBoxTipo_SelectedIndexChanged;
            // 
            // gbxCapotAngle
            // 
            gbxCapotAngle.Controls.Add(comboBoxCapotAngle);
            gbxCapotAngle.Location = new Point(27, 85);
            gbxCapotAngle.Margin = new Padding(7, 6, 5, 6);
            gbxCapotAngle.Name = "gbxCapotAngle";
            gbxCapotAngle.Padding = new Padding(7, 8, 7, 8);
            gbxCapotAngle.Size = new Size(189, 61);
            gbxCapotAngle.TabIndex = 5;
            gbxCapotAngle.TabStop = false;
            gbxCapotAngle.Text = "Capot Angle";
            gbxCapotAngle.Visible = false;
            // 
            // comboBoxCapotAngle
            // 
            comboBoxCapotAngle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxCapotAngle.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxCapotAngle.Dock = DockStyle.Fill;
            comboBoxCapotAngle.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCapotAngle.FormattingEnabled = true;
            comboBoxCapotAngle.Items.AddRange(new object[] { "conector", "clip", "olhal", "grommet" });
            comboBoxCapotAngle.Location = new Point(7, 25);
            comboBoxCapotAngle.Name = "comboBoxCapotAngle";
            comboBoxCapotAngle.Size = new Size(175, 25);
            comboBoxCapotAngle.TabIndex = 0;
            // 
            // gbxClipColor
            // 
            gbxClipColor.Controls.Add(comboBoxClipColor);
            gbxClipColor.Location = new Point(27, 158);
            gbxClipColor.Margin = new Padding(7, 6, 5, 6);
            gbxClipColor.Name = "gbxClipColor";
            gbxClipColor.Padding = new Padding(7, 8, 7, 8);
            gbxClipColor.Size = new Size(189, 61);
            gbxClipColor.TabIndex = 6;
            gbxClipColor.TabStop = false;
            gbxClipColor.Text = "Clip Color";
            gbxClipColor.Visible = false;
            // 
            // comboBoxClipColor
            // 
            comboBoxClipColor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxClipColor.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxClipColor.Dock = DockStyle.Fill;
            comboBoxClipColor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClipColor.FormattingEnabled = true;
            comboBoxClipColor.Items.AddRange(new object[] { "conector", "clip", "olhal", "grommet" });
            comboBoxClipColor.Location = new Point(7, 25);
            comboBoxClipColor.Name = "comboBoxClipColor";
            comboBoxClipColor.Size = new Size(175, 25);
            comboBoxClipColor.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(FLP_Main);
            flowLayoutPanel2.Controls.Add(flowLayoutPanel1);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(10);
            flowLayoutPanel2.Size = new Size(536, 317);
            flowLayoutPanel2.TabIndex = 11;
            // 
            // AddAccessoryView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton = btnCancel;
            ClientSize = new Size(536, 367);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddAccessoryView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Enter accessory details";
            FLP_Main.ResumeLayout(false);
            FLP_Main.PerformLayout();
            GbxConnName.ResumeLayout(false);
            GbxConnName.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numUpDownQty).EndInit();
            gbxCor.ResumeLayout(false);
            gbxCor.PerformLayout();
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            gbxCapotAngle.ResumeLayout(false);
            gbxClipColor.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel FLP_Main;
        private GroupBox gbxName;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox textBoxConnName;
        private GroupBox gbxCor;
        private Panel panel1;
        private Button btnCancel;
        private Button btnSave;
        private TextBox textBoxReference;
        private GroupBox GbxConnName;
        private TextBox textBoxName;
        private GroupBox groupBox1;
        private TextBox textBoxRefDV;
        private GroupBox groupBox4;
        private ComboBox comboBoxTipo;
        private FlowLayoutPanel flowLayoutPanel2;
        private CheckBox checkBoxColorAssociated;
        private GroupBox groupBox2;
        private NumericUpDown numUpDownQty;
        private GroupBox gbxCapotAngle;
        private ComboBox comboBoxCapotAngle;
        private GroupBox gbxClipColor;
        private ComboBox comboBoxClipColor;
    }
}