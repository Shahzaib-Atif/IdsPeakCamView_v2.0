namespace TriCamPylonView.UI.Forms
{
    partial class ImagePreviewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImagePreviewForm));
            imageBox = new Emgu.CV.UI.ImageBox();
            imageList = new ImageList(components);
            listView = new ListView();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            labelDescription = new Label();
            toolStrip = new ToolStrip();
            BtnOpenFile = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            BtnViewInExplorer = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            BtnCopyFilePath = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            BtnShowDetails = new ToolStripButton();
            panel2 = new Panel();
            label2 = new Label();
            comboBoxSortingType = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)imageBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            toolStrip.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // imageBox
            // 
            imageBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            imageBox.BackColor = SystemColors.Control;
            imageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            imageBox.Location = new Point(4, 39);
            imageBox.Margin = new Padding(4, 3, 4, 3);
            imageBox.Name = "imageBox";
            imageBox.Size = new Size(699, 518);
            imageBox.SizeMode = PictureBoxSizeMode.Zoom;
            imageBox.TabIndex = 2;
            imageBox.TabStop = false;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth8Bit;
            imageList.ImageSize = new Size(64, 64);
            imageList.TransparentColor = Color.Transparent;
            // 
            // listView
            // 
            listView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView.LargeImageList = imageList;
            listView.Location = new Point(0, 46);
            listView.Margin = new Padding(4, 3, 4, 3);
            listView.Name = "listView";
            listView.Size = new Size(569, 515);
            listView.TabIndex = 3;
            listView.UseCompatibleStateImageBehavior = false;
            listView.SelectedIndexChanged += ListView_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Highlight;
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(43, 8);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(347, 30);
            label1.TabIndex = 35;
            label1.Text = "The following images were found in the search for similar items. \r\nSelect an image from the list to preview it.";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(7, 12);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 21);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 36;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(labelDescription);
            panel1.Controls.Add(toolStrip);
            panel1.Controls.Add(imageBox);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(612, 6);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(708, 563);
            panel1.TabIndex = 37;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(516, 59);
            labelDescription.Margin = new Padding(4, 0, 4, 0);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(112, 15);
            labelDescription.TabIndex = 4;
            labelDescription.Text = "label for description";
            labelDescription.Visible = false;
            // 
            // toolStrip
            // 
            toolStrip.AutoSize = false;
            toolStrip.BackColor = SystemColors.AppWorkspace;
            toolStrip.Items.AddRange(new ToolStripItem[] { BtnOpenFile, toolStripSeparator1, BtnViewInExplorer, toolStripSeparator2, BtnCopyFilePath, toolStripSeparator3, BtnShowDetails });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Padding = new Padding(4, 3, 4, 3);
            toolStrip.Size = new Size(706, 38);
            toolStrip.TabIndex = 3;
            toolStrip.Text = "toolStrip1";
            // 
            // BtnOpenFile
            // 
            BtnOpenFile.Image = (Image)resources.GetObject("BtnOpenFile.Image");
            BtnOpenFile.ImageTransparentColor = Color.Magenta;
            BtnOpenFile.Margin = new Padding(0, 1, 2, 2);
            BtnOpenFile.Name = "BtnOpenFile";
            BtnOpenFile.Size = new Size(77, 29);
            BtnOpenFile.Text = "Open File";
            BtnOpenFile.Click += BtnOpenFile_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 32);
            // 
            // BtnViewInExplorer
            // 
            BtnViewInExplorer.Image = (Image)resources.GetObject("BtnViewInExplorer.Image");
            BtnViewInExplorer.ImageTransparentColor = Color.Magenta;
            BtnViewInExplorer.Margin = new Padding(2, 1, 2, 2);
            BtnViewInExplorer.Name = "BtnViewInExplorer";
            BtnViewInExplorer.Size = new Size(111, 29);
            BtnViewInExplorer.Text = "View in Explorer";
            BtnViewInExplorer.Click += BtnViewInExplorer_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 32);
            // 
            // BtnCopyFilePath
            // 
            BtnCopyFilePath.Image = (Image)resources.GetObject("BtnCopyFilePath.Image");
            BtnCopyFilePath.ImageTransparentColor = Color.Magenta;
            BtnCopyFilePath.Margin = new Padding(2, 1, 2, 2);
            BtnCopyFilePath.Name = "BtnCopyFilePath";
            BtnCopyFilePath.Size = new Size(103, 29);
            BtnCopyFilePath.Text = "Copy File Path";
            BtnCopyFilePath.Click += BtnCopyFilePath_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 32);
            // 
            // BtnShowDetails
            // 
            BtnShowDetails.Image = (Image)resources.GetObject("BtnShowDetails.Image");
            BtnShowDetails.ImageTransparentColor = Color.Magenta;
            BtnShowDetails.Margin = new Padding(2, 1, 2, 2);
            BtnShowDetails.Name = "BtnShowDetails";
            BtnShowDetails.Size = new Size(123, 29);
            BtnShowDetails.Text = "Show Process Info";
            BtnShowDetails.Visible = false;
            BtnShowDetails.Click += BtnShowDetails_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(comboBoxSortingType);
            panel2.Controls.Add(listView);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(6, 6);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(571, 563);
            panel2.TabIndex = 38;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(442, 25);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 38;
            label2.Text = "sort by:";
            // 
            // comboBoxSortingType
            // 
            comboBoxSortingType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSortingType.FormattingEnabled = true;
            comboBoxSortingType.Items.AddRange(new object[] { "DinoV2", "Resnet50" });
            comboBoxSortingType.Location = new Point(489, 21);
            comboBoxSortingType.Name = "comboBoxSortingType";
            comboBoxSortingType.Size = new Size(76, 23);
            comboBoxSortingType.TabIndex = 37;
            comboBoxSortingType.SelectedIndexChanged += SortingType_SelectedIndexChanged;
            // 
            // ImagePreviewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1326, 575);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ImagePreviewForm";
            Padding = new Padding(6);
            Text = "Preview Similar Images";
            KeyDown += ImagePreviewForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)imageBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Emgu.CV.UI.ImageBox imageBox;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton BtnCopyFilePath;
        private System.Windows.Forms.ToolStripButton BtnOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnViewInExplorer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BtnShowDetails;
        private System.Windows.Forms.Label labelDescription;
        private Label label2;
        private ComboBox comboBoxSortingType;
    }
}