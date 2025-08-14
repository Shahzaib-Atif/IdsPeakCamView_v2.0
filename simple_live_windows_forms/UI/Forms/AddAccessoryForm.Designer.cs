namespace simple_ids_cam_view.UI.Forms
{
    partial class AddAccessoryForm
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
            GbxConnName = new GroupBox();
            textBoxName = new TextBox();
            GbxType = new GroupBox();
            comboBoxTipo = new ComboBox();
            gbxCor = new GroupBox();
            textBoxReference = new TextBox();
            panel1 = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            FLP_Main.SuspendLayout();
            GbxConnName.SuspendLayout();
            GbxType.SuspendLayout();
            gbxCor.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // FLP_Main
            // 
            FLP_Main.AutoSize = true;
            FLP_Main.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FLP_Main.Controls.Add(labelTitle);
            FLP_Main.Controls.Add(GbxConnName);
            FLP_Main.Controls.Add(GbxType);
            FLP_Main.Controls.Add(gbxCor);
            FLP_Main.Controls.Add(panel1);
            FLP_Main.Dock = DockStyle.Fill;
            FLP_Main.FlowDirection = FlowDirection.TopDown;
            FLP_Main.Location = new Point(0, 0);
            FLP_Main.Name = "FLP_Main";
            FLP_Main.Padding = new Padding(20, 6, 20, 6);
            FLP_Main.Size = new Size(272, 393);
            FLP_Main.TabIndex = 1;
            FLP_Main.WrapContents = false;
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
            // GbxConnName
            // 
            GbxConnName.Controls.Add(textBoxName);
            GbxConnName.Location = new Point(27, 63);
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
            // GbxType
            // 
            GbxType.Controls.Add(comboBoxTipo);
            GbxType.Location = new Point(27, 136);
            GbxType.Margin = new Padding(7, 6, 5, 6);
            GbxType.Name = "GbxType";
            GbxType.Padding = new Padding(7, 8, 7, 8);
            GbxType.Size = new Size(189, 61);
            GbxType.TabIndex = 2;
            GbxType.TabStop = false;
            GbxType.Text = "Accessory Type *";
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
            // 
            // gbxCor
            // 
            gbxCor.Controls.Add(textBoxReference);
            gbxCor.Location = new Point(27, 209);
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
            panel1.Location = new Point(23, 316);
            panel1.Margin = new Padding(3, 40, 3, 3);
            panel1.MinimumSize = new Size(220, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(8, 6, 8, 6);
            panel1.Size = new Size(220, 50);
            panel1.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.RosyBrown;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Dock = DockStyle.Right;
            btnCancel.Location = new Point(139, 6);
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
            btnSave.Click += BtnSave_Click;
            // 
            // AddAccessoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(272, 393);
            Controls.Add(FLP_Main);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddAccessoryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Enter accessory details";
            FLP_Main.ResumeLayout(false);
            FLP_Main.PerformLayout();
            GbxConnName.ResumeLayout(false);
            GbxConnName.PerformLayout();
            GbxType.ResumeLayout(false);
            gbxCor.ResumeLayout(false);
            gbxCor.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel FLP_Main;
        private Label labelTitle;
        private GroupBox gbxName;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox textBoxConnName;
        private GroupBox GbxType;
        private ComboBox comboBoxTipo;
        private GroupBox gbxCor;
        private Panel panel1;
        private Button btnCancel;
        private Button btnSave;
        private TextBox textBoxReference;
        private GroupBox GbxConnName;
        private TextBox textBoxName;
    }
}