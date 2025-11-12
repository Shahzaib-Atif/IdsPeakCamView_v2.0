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
            labelTitle = new Label();
            FLP_Main = new FlowLayoutPanel();
            LabelSuggest = new LinkLabel();
            toolTip1 = new ToolTip(components);
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
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnSave);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(23, 509);
            panel1.Margin = new Padding(3, 40, 3, 3);
            panel1.MinimumSize = new Size(220, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(8, 6, 8, 6);
            panel1.Size = new Size(273, 50);
            panel1.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.RosyBrown;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Dock = DockStyle.Right;
            btnCancel.Location = new Point(192, 6);
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
            btnSave.Dock = DockStyle.Left;
            btnSave.Location = new Point(8, 6);
            btnSave.Margin = new Padding(1, 11, 10, 11);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(74, 38);
            btnSave.TabIndex = 0;
            btnSave.Text = "OK";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_ClickAsync;
            // 
            // gbxVias
            // 
            gbxVias.Controls.Add(comboBoxVias);
            gbxVias.Location = new Point(27, 402);
            gbxVias.Margin = new Padding(7, 6, 5, 6);
            gbxVias.Name = "gbxVias";
            gbxVias.Padding = new Padding(7, 8, 7, 8);
            gbxVias.Size = new Size(211, 61);
            gbxVias.TabIndex = 5;
            gbxVias.TabStop = false;
            gbxVias.Text = "Vias";
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
            gbxCor.Location = new Point(27, 329);
            gbxCor.Margin = new Padding(7, 6, 5, 6);
            gbxCor.Name = "gbxCor";
            gbxCor.Padding = new Padding(7, 8, 7, 8);
            gbxCor.Size = new Size(211, 61);
            gbxCor.TabIndex = 4;
            gbxCor.TabStop = false;
            gbxCor.Text = "Cor";
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
            gbxDiameter.Location = new Point(27, 214);
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
            gbxType.Location = new Point(27, 141);
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
            gbxName.Location = new Point(27, 63);
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
            textBoxPosId.Leave += TextBoxPosId_Leave;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Underline);
            labelTitle.Location = new Point(25, 17);
            labelTitle.Margin = new Padding(5, 11, 10, 23);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(203, 17);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Please enter the following details:";
            // 
            // FLP_Main
            // 
            FLP_Main.AutoSize = true;
            FLP_Main.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FLP_Main.Controls.Add(labelTitle);
            FLP_Main.Controls.Add(gbxName);
            FLP_Main.Controls.Add(gbxType);
            FLP_Main.Controls.Add(gbxDiameter);
            FLP_Main.Controls.Add(gbxCor);
            FLP_Main.Controls.Add(gbxVias);
            FLP_Main.Controls.Add(panel1);
            FLP_Main.Dock = DockStyle.Fill;
            FLP_Main.FlowDirection = FlowDirection.TopDown;
            FLP_Main.Location = new Point(0, 0);
            FLP_Main.Name = "FLP_Main";
            FLP_Main.Padding = new Padding(20, 6, 20, 6);
            FLP_Main.Size = new Size(319, 568);
            FLP_Main.TabIndex = 0;
            FLP_Main.WrapContents = false;
            // 
            // LabelSuggest
            // 
            LabelSuggest.ActiveLinkColor = Color.RosyBrown;
            LabelSuggest.AutoSize = true;
            LabelSuggest.Enabled = false;
            LabelSuggest.Font = new Font("Segoe UI", 9F);
            LabelSuggest.LinkColor = SystemColors.HotTrack;
            LabelSuggest.Location = new Point(248, 97);
            LabelSuggest.Name = "LabelSuggest";
            LabelSuggest.Size = new Size(48, 15);
            LabelSuggest.TabIndex = 1;
            LabelSuggest.TabStop = true;
            LabelSuggest.Text = "suggest";
            LabelSuggest.TextAlign = ContentAlignment.MiddleCenter;
            toolTip1.SetToolTip(LabelSuggest, "suggest position Id");
            LabelSuggest.LinkClicked += LabelSuggest_LinkClicked;
            // 
            // SampleDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton = btnCancel;
            ClientSize = new Size(324, 568);
            Controls.Add(LabelSuggest);
            Controls.Add(FLP_Main);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SampleDetailsForm";
            Padding = new Padding(0, 0, 5, 0);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Enter connector details";
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
        private Label labelTitle;
        private FlowLayoutPanel FLP_Main;
        private LinkLabel LabelSuggest;
        private ToolTip toolTip1;
    }
}