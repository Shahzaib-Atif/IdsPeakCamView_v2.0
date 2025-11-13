namespace simple_ids_cam_view.UI.Forms
{
    partial class SampleDetailsView
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
            panel1 = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            gbxVias = new GroupBox();
            comboBoxVias = new ComboBox();
            gbxCor = new GroupBox();
            comboBoxCor = new ComboBox();
            gbxDiameter = new GroupBox();
            FLP_Diameters = new FlowLayoutPanel();
            groupBox2 = new GroupBox();
            numericIntDia = new NumericUpDown();
            gbxExt = new GroupBox();
            numericExtDia = new NumericUpDown();
            groupBox4 = new GroupBox();
            numericThickness = new NumericUpDown();
            gbxType = new GroupBox();
            comboBoxTipo = new ComboBox();
            gbxName = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            textBoxPosId = new TextBox();
            FLP_Main = new FlowLayoutPanel();
            groupBox3 = new GroupBox();
            comboBoxManufact = new ComboBox();
            groupBox5 = new GroupBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            textBoxRefManufact = new TextBox();
            groupBox6 = new GroupBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            textBoxDesignation = new TextBox();
            toolTip1 = new ToolTip(components);
            groupBox1 = new GroupBox();
            label1 = new Label();
            groupBox7 = new GroupBox();
            label2 = new Label();
            flowLayoutPanel4 = new FlowLayoutPanel();
            groupBox8 = new GroupBox();
            flowLayoutPanel5 = new FlowLayoutPanel();
            textBoxOBS = new RichTextBox();
            flowLayoutPanel6 = new FlowLayoutPanel();
            groupBox9 = new GroupBox();
            label3 = new Label();
            flowLayoutPanel7 = new FlowLayoutPanel();
            checkBoxClip = new CheckBox();
            checkBoxSpacer = new CheckBox();
            checkBoxCapot = new CheckBox();
            checkBoxVedante = new CheckBox();
            checkBoxMola = new CheckBox();
            checkBoxMoldagem = new CheckBox();
            checkBoxTravao = new CheckBox();
            checkBoxAbracadeira = new CheckBox();
            checkBoxLinguetes = new CheckBox();
            checkBoxOutros = new CheckBox();
            checkBoxSamplePanel = new CheckBox();
            checkBoxOlhal = new CheckBox();
            panel1.SuspendLayout();
            gbxVias.SuspendLayout();
            gbxCor.SuspendLayout();
            gbxDiameter.SuspendLayout();
            FLP_Diameters.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericIntDia).BeginInit();
            gbxExt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericExtDia).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericThickness).BeginInit();
            gbxType.SuspendLayout();
            gbxName.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            FLP_Main.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            groupBox6.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox7.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            groupBox8.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            groupBox9.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnSave);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 495);
            panel1.Margin = new Padding(3, 60, 3, 3);
            panel1.MinimumSize = new Size(220, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(8, 6, 8, 6);
            panel1.Size = new Size(1035, 50);
            panel1.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.RosyBrown;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(497, 4);
            btnCancel.Margin = new Padding(1, 11, 10, 11);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(79, 39);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.YellowGreen;
            btnSave.Location = new Point(350, 4);
            btnSave.Margin = new Padding(1, 11, 10, 11);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 39);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // gbxVias
            // 
            gbxVias.Controls.Add(comboBoxVias);
            gbxVias.Location = new Point(10, 348);
            gbxVias.Margin = new Padding(7, 6, 5, 6);
            gbxVias.Name = "gbxVias";
            gbxVias.Padding = new Padding(7, 8, 7, 8);
            gbxVias.Size = new Size(211, 61);
            gbxVias.TabIndex = 5;
            gbxVias.TabStop = false;
            gbxVias.Text = "Vias *";
            // 
            // comboBoxVias
            // 
            comboBoxVias.Dock = DockStyle.Fill;
            comboBoxVias.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVias.FormattingEnabled = true;
            comboBoxVias.Location = new Point(7, 25);
            comboBoxVias.Name = "comboBoxVias";
            comboBoxVias.Size = new Size(197, 25);
            comboBoxVias.TabIndex = 0;
            // 
            // gbxCor
            // 
            gbxCor.Controls.Add(comboBoxCor);
            gbxCor.Location = new Point(10, 275);
            gbxCor.Margin = new Padding(7, 6, 5, 6);
            gbxCor.Name = "gbxCor";
            gbxCor.Padding = new Padding(7, 8, 7, 8);
            gbxCor.Size = new Size(211, 61);
            gbxCor.TabIndex = 4;
            gbxCor.TabStop = false;
            gbxCor.Text = "Cor *";
            // 
            // comboBoxCor
            // 
            comboBoxCor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxCor.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxCor.Dock = DockStyle.Fill;
            comboBoxCor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCor.FormattingEnabled = true;
            comboBoxCor.Location = new Point(7, 25);
            comboBoxCor.Name = "comboBoxCor";
            comboBoxCor.Size = new Size(197, 25);
            comboBoxCor.TabIndex = 0;
            // 
            // gbxDiameter
            // 
            gbxDiameter.Controls.Add(FLP_Diameters);
            gbxDiameter.Location = new Point(10, 160);
            gbxDiameter.Margin = new Padding(7, 6, 5, 6);
            gbxDiameter.Name = "gbxDiameter";
            gbxDiameter.Size = new Size(267, 103);
            gbxDiameter.TabIndex = 3;
            gbxDiameter.TabStop = false;
            gbxDiameter.Text = "Diameter";
            gbxDiameter.Visible = false;
            // 
            // FLP_Diameters
            // 
            FLP_Diameters.Controls.Add(groupBox2);
            FLP_Diameters.Controls.Add(gbxExt);
            FLP_Diameters.Controls.Add(groupBox4);
            FLP_Diameters.Dock = DockStyle.Fill;
            FLP_Diameters.Location = new Point(3, 20);
            FLP_Diameters.Margin = new Padding(5, 6, 5, 6);
            FLP_Diameters.Name = "FLP_Diameters";
            FLP_Diameters.Size = new Size(261, 80);
            FLP_Diameters.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(numericIntDia);
            groupBox2.Location = new Point(5, 6);
            groupBox2.Margin = new Padding(5, 6, 5, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5, 8, 5, 6);
            groupBox2.Size = new Size(72, 66);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Int.";
            // 
            // numericIntDia
            // 
            numericIntDia.DecimalPlaces = 2;
            numericIntDia.Dock = DockStyle.Fill;
            numericIntDia.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericIntDia.Location = new Point(5, 25);
            numericIntDia.Name = "numericIntDia";
            numericIntDia.Size = new Size(62, 24);
            numericIntDia.TabIndex = 0;
            numericIntDia.KeyDown += NumericDimensionBox_KeyDown;
            // 
            // gbxExt
            // 
            gbxExt.Controls.Add(numericExtDia);
            gbxExt.Location = new Point(87, 6);
            gbxExt.Margin = new Padding(5, 6, 5, 6);
            gbxExt.Name = "gbxExt";
            gbxExt.Padding = new Padding(5, 8, 5, 6);
            gbxExt.Size = new Size(72, 66);
            gbxExt.TabIndex = 1;
            gbxExt.TabStop = false;
            gbxExt.Text = "Ext.";
            // 
            // numericExtDia
            // 
            numericExtDia.DecimalPlaces = 2;
            numericExtDia.Dock = DockStyle.Fill;
            numericExtDia.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericExtDia.Location = new Point(5, 25);
            numericExtDia.Name = "numericExtDia";
            numericExtDia.Size = new Size(62, 24);
            numericExtDia.TabIndex = 0;
            numericExtDia.KeyDown += NumericDimensionBox_KeyDown;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(numericThickness);
            groupBox4.Location = new Point(169, 6);
            groupBox4.Margin = new Padding(5, 6, 5, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(5, 8, 5, 6);
            groupBox4.Size = new Size(72, 66);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Esp.";
            // 
            // numericThickness
            // 
            numericThickness.DecimalPlaces = 2;
            numericThickness.Dock = DockStyle.Fill;
            numericThickness.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericThickness.Location = new Point(5, 25);
            numericThickness.Name = "numericThickness";
            numericThickness.Size = new Size(62, 24);
            numericThickness.TabIndex = 0;
            numericThickness.KeyDown += NumericDimensionBox_KeyDown;
            // 
            // gbxType
            // 
            gbxType.Controls.Add(comboBoxTipo);
            gbxType.Location = new Point(10, 87);
            gbxType.Margin = new Padding(7, 6, 5, 6);
            gbxType.Name = "gbxType";
            gbxType.Padding = new Padding(7, 8, 7, 8);
            gbxType.Size = new Size(211, 61);
            gbxType.TabIndex = 2;
            gbxType.TabStop = false;
            gbxType.Text = "Tipo *";
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
            comboBoxTipo.Size = new Size(197, 25);
            comboBoxTipo.TabIndex = 0;
            comboBoxTipo.SelectedIndexChanged += ComboBoxTipo_SelectedIndexChanged;
            // 
            // gbxName
            // 
            gbxName.AutoSize = true;
            gbxName.Controls.Add(flowLayoutPanel1);
            gbxName.Location = new Point(10, 9);
            gbxName.Margin = new Padding(7, 6, 7, 6);
            gbxName.Name = "gbxName";
            gbxName.Padding = new Padding(1, 1, 1, 2);
            gbxName.Size = new Size(214, 66);
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
            flowLayoutPanel1.Size = new Size(212, 46);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // textBoxPosId
            // 
            textBoxPosId.Location = new Point(9, 13);
            textBoxPosId.Margin = new Padding(3, 6, 3, 3);
            textBoxPosId.Name = "textBoxPosId";
            textBoxPosId.PlaceholderText = "Enter Pos Id ";
            textBoxPosId.Size = new Size(194, 24);
            textBoxPosId.TabIndex = 0;
            textBoxPosId.KeyDown += TextBoxPosId_KeyDown;
            // 
            // FLP_Main
            // 
            FLP_Main.AutoSize = true;
            FLP_Main.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FLP_Main.BackColor = SystemColors.Control;
            FLP_Main.BorderStyle = BorderStyle.Fixed3D;
            FLP_Main.Controls.Add(gbxName);
            FLP_Main.Controls.Add(gbxType);
            FLP_Main.Controls.Add(gbxDiameter);
            FLP_Main.Controls.Add(gbxCor);
            FLP_Main.Controls.Add(gbxVias);
            FLP_Main.FlowDirection = FlowDirection.TopDown;
            FLP_Main.Location = new Point(3, 42);
            FLP_Main.MinimumSize = new Size(200, 0);
            FLP_Main.Name = "FLP_Main";
            FLP_Main.Padding = new Padding(3);
            FLP_Main.Size = new Size(289, 422);
            FLP_Main.TabIndex = 0;
            FLP_Main.WrapContents = false;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.None;
            groupBox3.Controls.Add(comboBoxManufact);
            groupBox3.Location = new Point(29, 12);
            groupBox3.Margin = new Padding(7, 6, 5, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(7, 8, 7, 8);
            groupBox3.Size = new Size(246, 61);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Manufacturer";
            // 
            // comboBoxManufact
            // 
            comboBoxManufact.Dock = DockStyle.Fill;
            comboBoxManufact.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxManufact.FormattingEnabled = true;
            comboBoxManufact.Location = new Point(7, 25);
            comboBoxManufact.Name = "comboBoxManufact";
            comboBoxManufact.Size = new Size(232, 25);
            comboBoxManufact.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.AutoSize = true;
            groupBox5.Controls.Add(flowLayoutPanel2);
            groupBox5.Location = new Point(27, 85);
            groupBox5.Margin = new Padding(7, 6, 7, 6);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(1, 1, 1, 2);
            groupBox5.Size = new Size(249, 66);
            groupBox5.TabIndex = 7;
            groupBox5.TabStop = false;
            groupBox5.Text = "Ref. Manufacturer";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(textBoxRefManufact);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(1, 18);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(6, 7, 6, 6);
            flowLayoutPanel2.Size = new Size(247, 46);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // textBoxRefManufact
            // 
            textBoxRefManufact.Location = new Point(9, 13);
            textBoxRefManufact.Margin = new Padding(3, 6, 3, 3);
            textBoxRefManufact.Name = "textBoxRefManufact";
            textBoxRefManufact.PlaceholderText = "Enter Pos Id ";
            textBoxRefManufact.Size = new Size(229, 24);
            textBoxRefManufact.TabIndex = 0;
            // 
            // groupBox6
            // 
            groupBox6.AutoSize = true;
            groupBox6.Controls.Add(flowLayoutPanel3);
            groupBox6.Location = new Point(27, 163);
            groupBox6.Margin = new Padding(7, 6, 7, 6);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(1, 1, 1, 2);
            groupBox6.Size = new Size(249, 66);
            groupBox6.TabIndex = 8;
            groupBox6.TabStop = false;
            groupBox6.Text = "Designation";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel3.Controls.Add(textBoxDesignation);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(1, 18);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Padding = new Padding(6, 7, 6, 6);
            flowLayoutPanel3.Size = new Size(247, 46);
            flowLayoutPanel3.TabIndex = 0;
            // 
            // textBoxDesignation
            // 
            textBoxDesignation.Location = new Point(9, 13);
            textBoxDesignation.Margin = new Padding(3, 6, 3, 3);
            textBoxDesignation.Name = "textBoxDesignation";
            textBoxDesignation.PlaceholderText = "Enter Pos Id ";
            textBoxDesignation.Size = new Size(229, 24);
            textBoxDesignation.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(FLP_Main);
            groupBox1.FlatStyle = FlatStyle.System;
            groupBox1.Location = new Point(25, 13);
            groupBox1.Margin = new Padding(15, 3, 15, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.RightToLeft = RightToLeft.No;
            groupBox1.Size = new Size(298, 487);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Underline);
            label1.Location = new Point(3, 20);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 0, 5, 5);
            label1.Size = new Size(292, 22);
            label1.TabIndex = 1;
            label1.Text = "Connector Details";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox7
            // 
            groupBox7.AutoSize = true;
            groupBox7.BackColor = SystemColors.Control;
            groupBox7.Controls.Add(label2);
            groupBox7.Controls.Add(flowLayoutPanel4);
            groupBox7.FlatStyle = FlatStyle.System;
            groupBox7.Location = new Point(353, 13);
            groupBox7.Margin = new Padding(15, 3, 15, 3);
            groupBox7.Name = "groupBox7";
            groupBox7.RightToLeft = RightToLeft.No;
            groupBox7.Size = new Size(313, 457);
            groupBox7.TabIndex = 2;
            groupBox7.TabStop = false;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.Control;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Underline);
            label2.Location = new Point(3, 20);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 0, 5, 5);
            label2.Size = new Size(307, 22);
            label2.TabIndex = 1;
            label2.Text = "Properties";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel4.AutoSize = true;
            flowLayoutPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel4.BackColor = SystemColors.Control;
            flowLayoutPanel4.BorderStyle = BorderStyle.Fixed3D;
            flowLayoutPanel4.Controls.Add(groupBox3);
            flowLayoutPanel4.Controls.Add(groupBox5);
            flowLayoutPanel4.Controls.Add(groupBox6);
            flowLayoutPanel4.Controls.Add(groupBox8);
            flowLayoutPanel4.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel4.Location = new Point(3, 42);
            flowLayoutPanel4.MinimumSize = new Size(200, 0);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Padding = new Padding(20, 6, 20, 6);
            flowLayoutPanel4.Size = new Size(307, 392);
            flowLayoutPanel4.TabIndex = 0;
            flowLayoutPanel4.WrapContents = false;
            // 
            // groupBox8
            // 
            groupBox8.AutoSize = true;
            groupBox8.Controls.Add(flowLayoutPanel5);
            groupBox8.Location = new Point(27, 241);
            groupBox8.Margin = new Padding(7, 6, 7, 6);
            groupBox8.Name = "groupBox8";
            groupBox8.Padding = new Padding(1, 1, 1, 2);
            groupBox8.Size = new Size(249, 135);
            groupBox8.TabIndex = 9;
            groupBox8.TabStop = false;
            groupBox8.Text = "Observation";
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.AutoSize = true;
            flowLayoutPanel5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel5.Controls.Add(textBoxOBS);
            flowLayoutPanel5.Dock = DockStyle.Fill;
            flowLayoutPanel5.Location = new Point(1, 18);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Padding = new Padding(6, 7, 6, 6);
            flowLayoutPanel5.Size = new Size(247, 115);
            flowLayoutPanel5.TabIndex = 0;
            // 
            // textBoxOBS
            // 
            textBoxOBS.BorderStyle = BorderStyle.FixedSingle;
            textBoxOBS.Location = new Point(9, 10);
            textBoxOBS.Name = "textBoxOBS";
            textBoxOBS.Size = new Size(229, 96);
            textBoxOBS.TabIndex = 1;
            textBoxOBS.Text = "";
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.AutoSize = true;
            flowLayoutPanel6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel6.BackColor = SystemColors.Control;
            flowLayoutPanel6.Controls.Add(groupBox1);
            flowLayoutPanel6.Controls.Add(groupBox7);
            flowLayoutPanel6.Controls.Add(groupBox9);
            flowLayoutPanel6.Dock = DockStyle.Fill;
            flowLayoutPanel6.Location = new Point(0, 0);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Padding = new Padding(10);
            flowLayoutPanel6.Size = new Size(1035, 495);
            flowLayoutPanel6.TabIndex = 7;
            // 
            // groupBox9
            // 
            groupBox9.AutoSize = true;
            groupBox9.BackColor = SystemColors.ButtonFace;
            groupBox9.Controls.Add(label3);
            groupBox9.Controls.Add(flowLayoutPanel7);
            groupBox9.FlatStyle = FlatStyle.System;
            groupBox9.Location = new Point(696, 13);
            groupBox9.Margin = new Padding(15, 3, 15, 3);
            groupBox9.Name = "groupBox9";
            groupBox9.RightToLeft = RightToLeft.No;
            groupBox9.Size = new Size(206, 405);
            groupBox9.TabIndex = 3;
            groupBox9.TabStop = false;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Underline);
            label3.Location = new Point(3, 20);
            label3.Margin = new Padding(30, 0, 3, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 0, 5, 5);
            label3.Size = new Size(200, 22);
            label3.TabIndex = 1;
            label3.Text = "Components";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel7.AutoSize = true;
            flowLayoutPanel7.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel7.BackColor = SystemColors.Control;
            flowLayoutPanel7.BorderStyle = BorderStyle.Fixed3D;
            flowLayoutPanel7.Controls.Add(checkBoxClip);
            flowLayoutPanel7.Controls.Add(checkBoxSpacer);
            flowLayoutPanel7.Controls.Add(checkBoxCapot);
            flowLayoutPanel7.Controls.Add(checkBoxVedante);
            flowLayoutPanel7.Controls.Add(checkBoxMola);
            flowLayoutPanel7.Controls.Add(checkBoxMoldagem);
            flowLayoutPanel7.Controls.Add(checkBoxTravao);
            flowLayoutPanel7.Controls.Add(checkBoxAbracadeira);
            flowLayoutPanel7.Controls.Add(checkBoxLinguetes);
            flowLayoutPanel7.Controls.Add(checkBoxOutros);
            flowLayoutPanel7.Controls.Add(checkBoxSamplePanel);
            flowLayoutPanel7.Controls.Add(checkBoxOlhal);
            flowLayoutPanel7.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel7.Location = new Point(3, 42);
            flowLayoutPanel7.MinimumSize = new Size(200, 0);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Padding = new Padding(20, 6, 20, 6);
            flowLayoutPanel7.Size = new Size(200, 340);
            flowLayoutPanel7.TabIndex = 0;
            flowLayoutPanel7.WrapContents = false;
            // 
            // checkBoxClip
            // 
            checkBoxClip.AutoSize = true;
            checkBoxClip.Location = new Point(23, 9);
            checkBoxClip.Name = "checkBoxClip";
            checkBoxClip.Size = new Size(49, 21);
            checkBoxClip.TabIndex = 7;
            checkBoxClip.Text = "Clip";
            checkBoxClip.UseVisualStyleBackColor = true;
            // 
            // checkBoxSpacer
            // 
            checkBoxSpacer.AutoSize = true;
            checkBoxSpacer.Location = new Point(23, 36);
            checkBoxSpacer.Name = "checkBoxSpacer";
            checkBoxSpacer.Size = new Size(67, 21);
            checkBoxSpacer.TabIndex = 8;
            checkBoxSpacer.Text = "Spacer";
            checkBoxSpacer.UseVisualStyleBackColor = true;
            // 
            // checkBoxCapot
            // 
            checkBoxCapot.AutoSize = true;
            checkBoxCapot.Location = new Point(23, 63);
            checkBoxCapot.Name = "checkBoxCapot";
            checkBoxCapot.Size = new Size(62, 21);
            checkBoxCapot.TabIndex = 9;
            checkBoxCapot.Text = "Capot";
            checkBoxCapot.UseVisualStyleBackColor = true;
            // 
            // checkBoxVedante
            // 
            checkBoxVedante.AutoSize = true;
            checkBoxVedante.Location = new Point(23, 90);
            checkBoxVedante.Name = "checkBoxVedante";
            checkBoxVedante.Size = new Size(74, 21);
            checkBoxVedante.TabIndex = 10;
            checkBoxVedante.Text = "Vedante";
            checkBoxVedante.UseVisualStyleBackColor = true;
            // 
            // checkBoxMola
            // 
            checkBoxMola.AutoSize = true;
            checkBoxMola.Location = new Point(23, 117);
            checkBoxMola.Name = "checkBoxMola";
            checkBoxMola.Size = new Size(57, 21);
            checkBoxMola.TabIndex = 11;
            checkBoxMola.Text = "Mola";
            checkBoxMola.UseVisualStyleBackColor = true;
            // 
            // checkBoxMoldagem
            // 
            checkBoxMoldagem.AutoSize = true;
            checkBoxMoldagem.Location = new Point(23, 144);
            checkBoxMoldagem.Name = "checkBoxMoldagem";
            checkBoxMoldagem.Size = new Size(91, 21);
            checkBoxMoldagem.TabIndex = 12;
            checkBoxMoldagem.Text = "Moldagem";
            checkBoxMoldagem.UseVisualStyleBackColor = true;
            // 
            // checkBoxTravao
            // 
            checkBoxTravao.AutoSize = true;
            checkBoxTravao.Location = new Point(23, 171);
            checkBoxTravao.Name = "checkBoxTravao";
            checkBoxTravao.Size = new Size(66, 21);
            checkBoxTravao.TabIndex = 13;
            checkBoxTravao.Text = "Travao";
            checkBoxTravao.UseVisualStyleBackColor = true;
            // 
            // checkBoxAbracadeira
            // 
            checkBoxAbracadeira.AutoSize = true;
            checkBoxAbracadeira.Location = new Point(23, 198);
            checkBoxAbracadeira.Name = "checkBoxAbracadeira";
            checkBoxAbracadeira.Size = new Size(98, 21);
            checkBoxAbracadeira.TabIndex = 14;
            checkBoxAbracadeira.Text = "Abracadeira";
            checkBoxAbracadeira.UseVisualStyleBackColor = true;
            // 
            // checkBoxLinguetes
            // 
            checkBoxLinguetes.AutoSize = true;
            checkBoxLinguetes.Location = new Point(23, 225);
            checkBoxLinguetes.Name = "checkBoxLinguetes";
            checkBoxLinguetes.Size = new Size(82, 21);
            checkBoxLinguetes.TabIndex = 15;
            checkBoxLinguetes.Text = "Linguetes";
            checkBoxLinguetes.UseVisualStyleBackColor = true;
            // 
            // checkBoxOutros
            // 
            checkBoxOutros.AutoSize = true;
            checkBoxOutros.Location = new Point(23, 252);
            checkBoxOutros.Name = "checkBoxOutros";
            checkBoxOutros.Size = new Size(67, 21);
            checkBoxOutros.TabIndex = 16;
            checkBoxOutros.Text = "Outros";
            checkBoxOutros.UseVisualStyleBackColor = true;
            // 
            // checkBoxSamplePanel
            // 
            checkBoxSamplePanel.AutoSize = true;
            checkBoxSamplePanel.Location = new Point(23, 279);
            checkBoxSamplePanel.Name = "checkBoxSamplePanel";
            checkBoxSamplePanel.Size = new Size(105, 21);
            checkBoxSamplePanel.TabIndex = 17;
            checkBoxSamplePanel.Text = "Sample Panel";
            checkBoxSamplePanel.UseVisualStyleBackColor = true;
            // 
            // checkBoxOlhal
            // 
            checkBoxOlhal.AutoSize = true;
            checkBoxOlhal.Location = new Point(23, 306);
            checkBoxOlhal.Name = "checkBoxOlhal";
            checkBoxOlhal.Size = new Size(66, 21);
            checkBoxOlhal.TabIndex = 18;
            checkBoxOlhal.Text = "OLHAL";
            checkBoxOlhal.UseVisualStyleBackColor = true;
            // 
            // SampleDetailsView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Control;
            CancelButton = btnCancel;
            ClientSize = new Size(1040, 545);
            Controls.Add(flowLayoutPanel6);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SampleDetailsView";
            Padding = new Padding(0, 0, 5, 0);
            StartPosition = FormStartPosition.CenterParent;
            Text = "New connector";
            panel1.ResumeLayout(false);
            gbxVias.ResumeLayout(false);
            gbxCor.ResumeLayout(false);
            gbxDiameter.ResumeLayout(false);
            FLP_Diameters.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericIntDia).EndInit();
            gbxExt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericExtDia).EndInit();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericThickness).EndInit();
            gbxType.ResumeLayout(false);
            gbxName.ResumeLayout(false);
            gbxName.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            FLP_Main.ResumeLayout(false);
            FLP_Main.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel7.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnCancel;
        private Button btnSave;
        private GroupBox gbxVias;
        private ComboBox comboBoxVias;
        private GroupBox gbxCor;
        private ComboBox comboBoxCor;
        private GroupBox gbxDiameter;
        private FlowLayoutPanel FLP_Diameters;
        private GroupBox groupBox2;
        private NumericUpDown numericIntDia;
        private GroupBox gbxExt;
        private NumericUpDown numericExtDia;
        private GroupBox groupBox4;
        private NumericUpDown numericThickness;
        private GroupBox gbxType;
        private ComboBox comboBoxTipo;
        private GroupBox gbxName;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox textBoxPosId;
        private FlowLayoutPanel FLP_Main;
        private ToolTip toolTip1;
        private GroupBox groupBox1;
        private Label label1;
        private GroupBox groupBox3;
        private ComboBox comboBoxManufact;
        private GroupBox groupBox5;
        private TextBox textBoxRefManufact;
        private FlowLayoutPanel flowLayoutPanel2;
        private GroupBox groupBox6;
        private FlowLayoutPanel flowLayoutPanel3;
        private TextBox textBoxDesignation;
        private GroupBox groupBox7;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel4;
        private GroupBox groupBox8;
        private FlowLayoutPanel flowLayoutPanel5;
        private RichTextBox textBoxOBS;
        private FlowLayoutPanel flowLayoutPanel6;
        private GroupBox groupBox9;
        private Label label3;
        private FlowLayoutPanel flowLayoutPanel7;
        private CheckBox checkBoxClip;
        private CheckBox checkBoxSpacer;
        private CheckBox checkBoxCapot;
        private CheckBox checkBoxVedante;
        private CheckBox checkBoxMola;
        private CheckBox checkBoxMoldagem;
        private CheckBox checkBoxTravao;
        private CheckBox checkBoxAbracadeira;
        private CheckBox checkBoxLinguetes;
        private CheckBox checkBoxOutros;
        private CheckBox checkBoxSamplePanel;
        private CheckBox checkBoxOlhal;
    }
}