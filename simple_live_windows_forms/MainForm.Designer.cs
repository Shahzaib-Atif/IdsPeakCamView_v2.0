using simple_ids_cam_view.UI.Controls;

namespace simple_ids_cam_view
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            counterLabel = new Label();
            toolStrip1 = new ToolStrip();
            StartAcquisitionBtn = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            StopAcquisitionBtn = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            LightsBtn = new ToolStripButton();
            toolStripSeparator9 = new ToolStripSeparator();
            MotorPositionBtn = new ToolStripDropDownButton();
            position1ToolStripMenuItem = new ToolStripMenuItem();
            position2ToolStripMenuItem = new ToolStripMenuItem();
            position3ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            SingleAcquisitionBtn = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            ToolsBtn = new ToolStripDropDownButton();
            ImageQualityMenuItem = new ToolStripMenuItem();
            ImageSizeMenuItem = new ToolStripMenuItem();
            ImageSimilarityMenuItem = new ToolStripMenuItem();
            DefaultFolderMenuItem = new ToolStripMenuItem();
            AddImagesToDBMenuItem = new ToolStripMenuItem();
            DeleteImagepMenuItem = new ToolStripMenuItem();
            ModbusConfigMenuItem = new ToolStripMenuItem();
            changeDatabaseSettingsToolStripMenuItem = new ToolStripMenuItem();
            CameraSettingsMenuItem = new ToolStripMenuItem();
            hardwareSettingsMenuItem = new ToolStripMenuItem();
            EditTextMenuItem = new ToolStripMenuItem();
            toolStripSeparator14 = new ToolStripSeparator();
            gbxProgress = new GroupBox();
            progressBar = new ProgressBar();
            customPictureBox = new SimplePictureBox();
            toolStrip2 = new ToolStrip();
            CropBtn = new ToolStripButton();
            toolStripSeparator11 = new ToolStripSeparator();
            CrosshairBtn = new ToolStripButton();
            SaveFinalImageBtn = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            SaveToDbBtn = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            AddAccessoryBtn = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            SaveExtraImgBtn = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            FindSimilarImgsBtn = new ToolStripDropDownButton();
            DisplayPanel = new Panel();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            GbxShowLoading = new GroupBox();
            pictureBox1 = new PictureBox();
            UseCurrentImageCheckbox = new CheckBox();
            Flp_Main = new FlowLayoutPanel();
            CameraSettingsPanel = new AdjustSettings();
            ModbusControlsPanel = new ModbusControls();
            toolTip1 = new ToolTip(components);
            toolStrip1.SuspendLayout();
            gbxProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customPictureBox).BeginInit();
            toolStrip2.SuspendLayout();
            DisplayPanel.SuspendLayout();
            statusStrip1.SuspendLayout();
            GbxShowLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            Flp_Main.SuspendLayout();
            SuspendLayout();
            // 
            // counterLabel
            // 
            counterLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            counterLabel.AutoSize = true;
            counterLabel.Location = new Point(322, 700);
            counterLabel.MinimumSize = new Size(10, 10);
            counterLabel.Name = "counterLabel";
            counterLabel.Size = new Size(10, 15);
            counterLabel.TabIndex = 2;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ControlLight;
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.Font = new Font("Segoe UI", 10.5F);
            toolStrip1.Items.AddRange(new ToolStripItem[] { StartAcquisitionBtn, toolStripSeparator1, StopAcquisitionBtn, toolStripSeparator2, LightsBtn, toolStripSeparator9, MotorPositionBtn, toolStripSeparator8, SingleAcquisitionBtn, toolStripSeparator3, ToolsBtn, toolStripSeparator14 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(4, 4, 0, 4);
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(433, 34);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // StartAcquisitionBtn
            // 
            StartAcquisitionBtn.Enabled = false;
            StartAcquisitionBtn.Image = (Image)resources.GetObject("StartAcquisitionBtn.Image");
            StartAcquisitionBtn.ImageTransparentColor = Color.Magenta;
            StartAcquisitionBtn.Margin = new Padding(1, 1, 0, 2);
            StartAcquisitionBtn.Name = "StartAcquisitionBtn";
            StartAcquisitionBtn.Size = new Size(58, 23);
            StartAcquisitionBtn.Text = "Start";
            StartAcquisitionBtn.ToolTipText = "Start continuous acquisition";
            StartAcquisitionBtn.Click += StartAcquisitionBtn_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 26);
            // 
            // StopAcquisitionBtn
            // 
            StopAcquisitionBtn.Font = new Font("Segoe UI", 10F);
            StopAcquisitionBtn.Image = (Image)resources.GetObject("StopAcquisitionBtn.Image");
            StopAcquisitionBtn.ImageTransparentColor = Color.Magenta;
            StopAcquisitionBtn.Name = "StopAcquisitionBtn";
            StopAcquisitionBtn.Size = new Size(57, 23);
            StopAcquisitionBtn.Text = "Stop";
            StopAcquisitionBtn.ToolTipText = "Stop continuous acquisition";
            StopAcquisitionBtn.Click += StopAcquisitionBtn_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 26);
            // 
            // LightsBtn
            // 
            LightsBtn.Image = Properties.Resources.icons8_light_off_18;
            LightsBtn.ImageTransparentColor = Color.Magenta;
            LightsBtn.Name = "LightsBtn";
            LightsBtn.Size = new Size(66, 23);
            LightsBtn.Text = "Lights";
            LightsBtn.Click += LightsBtn_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(6, 26);
            // 
            // MotorPositionBtn
            // 
            MotorPositionBtn.DropDownItems.AddRange(new ToolStripItem[] { position1ToolStripMenuItem, position2ToolStripMenuItem, position3ToolStripMenuItem });
            MotorPositionBtn.Image = (Image)resources.GetObject("MotorPositionBtn.Image");
            MotorPositionBtn.ImageTransparentColor = Color.Magenta;
            MotorPositionBtn.Name = "MotorPositionBtn";
            MotorPositionBtn.Size = new Size(137, 23);
            MotorPositionBtn.Text = "Camera Position";
            MotorPositionBtn.DropDownItemClicked += MotorPositionBtn_DropDownItemClicked;
            // 
            // position1ToolStripMenuItem
            // 
            position1ToolStripMenuItem.Name = "position1ToolStripMenuItem";
            position1ToolStripMenuItem.Size = new Size(190, 24);
            position1ToolStripMenuItem.Text = "Position 1 - far";
            // 
            // position2ToolStripMenuItem
            // 
            position2ToolStripMenuItem.Name = "position2ToolStripMenuItem";
            position2ToolStripMenuItem.Size = new Size(190, 24);
            position2ToolStripMenuItem.Text = "Position 2 - center";
            // 
            // position3ToolStripMenuItem
            // 
            position3ToolStripMenuItem.Name = "position3ToolStripMenuItem";
            position3ToolStripMenuItem.Size = new Size(190, 24);
            position3ToolStripMenuItem.Text = "Position 3 - close";
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(6, 26);
            // 
            // SingleAcquisitionBtn
            // 
            SingleAcquisitionBtn.Enabled = false;
            SingleAcquisitionBtn.Image = (Image)resources.GetObject("SingleAcquisitionBtn.Image");
            SingleAcquisitionBtn.ImageTransparentColor = Color.Magenta;
            SingleAcquisitionBtn.Name = "SingleAcquisitionBtn";
            SingleAcquisitionBtn.Size = new Size(65, 23);
            SingleAcquisitionBtn.Text = "Single";
            SingleAcquisitionBtn.Visible = false;
            SingleAcquisitionBtn.Click += SingleAcquisitionBtn_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 26);
            toolStripSeparator3.Visible = false;
            // 
            // ToolsBtn
            // 
            ToolsBtn.DropDownItems.AddRange(new ToolStripItem[] { ImageQualityMenuItem, ImageSizeMenuItem, ImageSimilarityMenuItem, DefaultFolderMenuItem, AddImagesToDBMenuItem, DeleteImagepMenuItem, ModbusConfigMenuItem, changeDatabaseSettingsToolStripMenuItem, CameraSettingsMenuItem, hardwareSettingsMenuItem, EditTextMenuItem });
            ToolsBtn.Image = (Image)resources.GetObject("ToolsBtn.Image");
            ToolsBtn.ImageTransparentColor = Color.Magenta;
            ToolsBtn.Name = "ToolsBtn";
            ToolsBtn.Size = new Size(69, 23);
            ToolsBtn.Text = "Tools";
            ToolsBtn.ToolTipText = "Tools";
            // 
            // ImageQualityMenuItem
            // 
            ImageQualityMenuItem.Image = (Image)resources.GetObject("ImageQualityMenuItem.Image");
            ImageQualityMenuItem.Name = "ImageQualityMenuItem";
            ImageQualityMenuItem.Size = new Size(287, 24);
            ImageQualityMenuItem.Text = "Image quality";
            ImageQualityMenuItem.ToolTipText = "Change image quality";
            ImageQualityMenuItem.Visible = false;
            ImageQualityMenuItem.Click += ImageQualityMenuItem_Click;
            // 
            // ImageSizeMenuItem
            // 
            ImageSizeMenuItem.Image = (Image)resources.GetObject("ImageSizeMenuItem.Image");
            ImageSizeMenuItem.Name = "ImageSizeMenuItem";
            ImageSizeMenuItem.Size = new Size(287, 24);
            ImageSizeMenuItem.Text = "Image size";
            ImageSizeMenuItem.ToolTipText = "Change image size";
            ImageSizeMenuItem.Visible = false;
            ImageSizeMenuItem.Click += ImageSizeMenuItem_Click;
            // 
            // ImageSimilarityMenuItem
            // 
            ImageSimilarityMenuItem.Image = (Image)resources.GetObject("ImageSimilarityMenuItem.Image");
            ImageSimilarityMenuItem.Name = "ImageSimilarityMenuItem";
            ImageSimilarityMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            ImageSimilarityMenuItem.Size = new Size(287, 24);
            ImageSimilarityMenuItem.Text = "Image similarity settings";
            ImageSimilarityMenuItem.ToolTipText = "Update image similarity thresholds values";
            ImageSimilarityMenuItem.Visible = false;
            ImageSimilarityMenuItem.Click += ImageSimilarityMenuItem_Click;
            // 
            // DefaultFolderMenuItem
            // 
            DefaultFolderMenuItem.Image = (Image)resources.GetObject("DefaultFolderMenuItem.Image");
            DefaultFolderMenuItem.Name = "DefaultFolderMenuItem";
            DefaultFolderMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            DefaultFolderMenuItem.Size = new Size(287, 24);
            DefaultFolderMenuItem.Text = "Change default folder";
            DefaultFolderMenuItem.Visible = false;
            DefaultFolderMenuItem.Click += DefaultFolderMenuItem_Click;
            // 
            // AddImagesToDBMenuItem
            // 
            AddImagesToDBMenuItem.Image = (Image)resources.GetObject("AddImagesToDBMenuItem.Image");
            AddImagesToDBMenuItem.Name = "AddImagesToDBMenuItem";
            AddImagesToDBMenuItem.Size = new Size(287, 24);
            AddImagesToDBMenuItem.Text = "Add images to DB";
            AddImagesToDBMenuItem.Visible = false;
            AddImagesToDBMenuItem.Click += AddImagesToDBMenuItem_Click;
            // 
            // DeleteImagepMenuItem
            // 
            DeleteImagepMenuItem.Image = (Image)resources.GetObject("DeleteImagepMenuItem.Image");
            DeleteImagepMenuItem.Name = "DeleteImagepMenuItem";
            DeleteImagepMenuItem.Size = new Size(287, 24);
            DeleteImagepMenuItem.Text = "Delete an image";
            DeleteImagepMenuItem.ToolTipText = "Delete from local folder & DB";
            DeleteImagepMenuItem.Visible = false;
            DeleteImagepMenuItem.Click += DeleteImageMenuItem_Click;
            // 
            // ModbusConfigMenuItem
            // 
            ModbusConfigMenuItem.Image = (Image)resources.GetObject("ModbusConfigMenuItem.Image");
            ModbusConfigMenuItem.Name = "ModbusConfigMenuItem";
            ModbusConfigMenuItem.ShortcutKeys = Keys.Control | Keys.M;
            ModbusConfigMenuItem.Size = new Size(287, 24);
            ModbusConfigMenuItem.Text = "Change modbus settings";
            ModbusConfigMenuItem.Visible = false;
            ModbusConfigMenuItem.Click += ModbusConfigMenuItem_Click;
            // 
            // changeDatabaseSettingsToolStripMenuItem
            // 
            changeDatabaseSettingsToolStripMenuItem.Image = (Image)resources.GetObject("changeDatabaseSettingsToolStripMenuItem.Image");
            changeDatabaseSettingsToolStripMenuItem.Name = "changeDatabaseSettingsToolStripMenuItem";
            changeDatabaseSettingsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
            changeDatabaseSettingsToolStripMenuItem.Size = new Size(287, 24);
            changeDatabaseSettingsToolStripMenuItem.Text = "Change database settings";
            changeDatabaseSettingsToolStripMenuItem.Visible = false;
            changeDatabaseSettingsToolStripMenuItem.Click += ChangeDatabaseSettingsMenuItem_Click;
            // 
            // CameraSettingsMenuItem
            // 
            CameraSettingsMenuItem.Image = (Image)resources.GetObject("CameraSettingsMenuItem.Image");
            CameraSettingsMenuItem.Name = "CameraSettingsMenuItem";
            CameraSettingsMenuItem.Size = new Size(287, 24);
            CameraSettingsMenuItem.Text = "Camera Settings";
            CameraSettingsMenuItem.Click += AdjustSettingsBtn_Click;
            // 
            // hardwareSettingsMenuItem
            // 
            hardwareSettingsMenuItem.Image = (Image)resources.GetObject("hardwareSettingsMenuItem.Image");
            hardwareSettingsMenuItem.Name = "hardwareSettingsMenuItem";
            hardwareSettingsMenuItem.Size = new Size(287, 24);
            hardwareSettingsMenuItem.Text = "Hardware Settings";
            hardwareSettingsMenuItem.Click += ModbusControlsBtn_Click;
            // 
            // EditTextMenuItem
            // 
            EditTextMenuItem.Image = (Image)resources.GetObject("EditTextMenuItem.Image");
            EditTextMenuItem.Name = "EditTextMenuItem";
            EditTextMenuItem.Size = new Size(287, 24);
            EditTextMenuItem.Text = "Edit Text";
            EditTextMenuItem.Click += EditTextBtn_Click;
            // 
            // toolStripSeparator14
            // 
            toolStripSeparator14.Name = "toolStripSeparator14";
            toolStripSeparator14.Size = new Size(6, 26);
            // 
            // gbxProgress
            // 
            gbxProgress.Controls.Add(progressBar);
            gbxProgress.Location = new Point(287, 243);
            gbxProgress.Name = "gbxProgress";
            gbxProgress.Padding = new Padding(7);
            gbxProgress.Size = new Size(294, 52);
            gbxProgress.TabIndex = 3;
            gbxProgress.TabStop = false;
            gbxProgress.Text = "Searching for similar images ... ";
            gbxProgress.Visible = false;
            // 
            // progressBar
            // 
            progressBar.Dock = DockStyle.Fill;
            progressBar.Location = new Point(7, 23);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(280, 22);
            progressBar.TabIndex = 0;
            // 
            // customPictureBox
            // 
            customPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            customPictureBox.BackColor = SystemColors.ControlLight;
            customPictureBox.BorderStyle = BorderStyle.FixedSingle;
            customPictureBox.CroppingRectangle = new Rectangle(0, 0, 0, 0);
            customPictureBox.Image = null;
            customPictureBox.IsSelecting = false;
            customPictureBox.Location = new Point(0, 35);
            customPictureBox.Name = "customPictureBox";
            customPictureBox.Size = new Size(856, 663);
            customPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            customPictureBox.TabIndex = 5;
            customPictureBox.TabStop = false;
            // 
            // toolStrip2
            // 
            toolStrip2.AutoSize = false;
            toolStrip2.BackColor = SystemColors.ControlLight;
            toolStrip2.Font = new Font("Segoe UI", 9.5F);
            toolStrip2.Items.AddRange(new ToolStripItem[] { CropBtn, toolStripSeparator11, CrosshairBtn, SaveFinalImageBtn, toolStripSeparator4, SaveToDbBtn, toolStripSeparator7, AddAccessoryBtn, toolStripSeparator6, SaveExtraImgBtn, toolStripSeparator5, FindSimilarImgsBtn });
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Margin = new Padding(0, 2, 0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Padding = new Padding(3);
            toolStrip2.RenderMode = ToolStripRenderMode.System;
            toolStrip2.Size = new Size(856, 35);
            toolStrip2.TabIndex = 6;
            toolStrip2.Text = "toolStrip1";
            // 
            // CropBtn
            // 
            CropBtn.BackColor = SystemColors.ControlLight;
            CropBtn.Enabled = false;
            CropBtn.Image = Properties.Resources.icons8_crop_20;
            CropBtn.ImageTransparentColor = Color.Magenta;
            CropBtn.Margin = new Padding(3, 1, 0, 2);
            CropBtn.Name = "CropBtn";
            CropBtn.Size = new Size(97, 26);
            CropBtn.Text = "Crop Image";
            CropBtn.Click += UpdateRoiBtn_Click;
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new Size(6, 29);
            // 
            // CrosshairBtn
            // 
            CrosshairBtn.BackColor = SystemColors.ControlLight;
            CrosshairBtn.ForeColor = SystemColors.ControlText;
            CrosshairBtn.Image = (Image)resources.GetObject("CrosshairBtn.Image");
            CrosshairBtn.ImageTransparentColor = Color.Magenta;
            CrosshairBtn.Name = "CrosshairBtn";
            CrosshairBtn.Size = new Size(83, 26);
            CrosshairBtn.Text = "Crosshair";
            CrosshairBtn.Click += CrosshairBtn_Click;
            // 
            // SaveFinalImageBtn
            // 
            SaveFinalImageBtn.Enabled = false;
            SaveFinalImageBtn.Image = (Image)resources.GetObject("SaveFinalImageBtn.Image");
            SaveFinalImageBtn.ImageTransparentColor = Color.Magenta;
            SaveFinalImageBtn.Name = "SaveFinalImageBtn";
            SaveFinalImageBtn.Size = new Size(108, 26);
            SaveFinalImageBtn.Text = "Save in folder";
            SaveFinalImageBtn.ToolTipText = "Save final image";
            SaveFinalImageBtn.Visible = false;
            SaveFinalImageBtn.Click += SaveFinalImageBtn_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 29);
            // 
            // SaveToDbBtn
            // 
            SaveToDbBtn.Enabled = false;
            SaveToDbBtn.Image = (Image)resources.GetObject("SaveToDbBtn.Image");
            SaveToDbBtn.ImageTransparentColor = Color.Magenta;
            SaveToDbBtn.Name = "SaveToDbBtn";
            SaveToDbBtn.Size = new Size(117, 26);
            SaveToDbBtn.Text = "Save connector";
            SaveToDbBtn.Click += SaveToDbBtn_ClickAsync;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 29);
            // 
            // AddAccessoryBtn
            // 
            AddAccessoryBtn.Enabled = false;
            AddAccessoryBtn.Image = (Image)resources.GetObject("AddAccessoryBtn.Image");
            AddAccessoryBtn.ImageTransparentColor = Color.Magenta;
            AddAccessoryBtn.Name = "AddAccessoryBtn";
            AddAccessoryBtn.Size = new Size(113, 26);
            AddAccessoryBtn.Text = "Add accessory";
            AddAccessoryBtn.Click += AddAccessoryBtn_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 29);
            // 
            // SaveExtraImgBtn
            // 
            SaveExtraImgBtn.Enabled = false;
            SaveExtraImgBtn.Image = (Image)resources.GetObject("SaveExtraImgBtn.Image");
            SaveExtraImgBtn.ImageTransparentColor = Color.Magenta;
            SaveExtraImgBtn.Name = "SaveExtraImgBtn";
            SaveExtraImgBtn.Size = new Size(97, 26);
            SaveExtraImgBtn.Text = "Extra Image";
            SaveExtraImgBtn.ToolTipText = "Extra Image";
            SaveExtraImgBtn.Click += SaveExtraImgBtn_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 29);
            // 
            // FindSimilarImgsBtn
            // 
            FindSimilarImgsBtn.Enabled = false;
            FindSimilarImgsBtn.Font = new Font("Segoe UI", 9.5F);
            FindSimilarImgsBtn.Image = (Image)resources.GetObject("FindSimilarImgsBtn.Image");
            FindSimilarImgsBtn.ImageTransparentColor = Color.Magenta;
            FindSimilarImgsBtn.Name = "FindSimilarImgsBtn";
            FindSimilarImgsBtn.RightToLeft = RightToLeft.Yes;
            FindSimilarImgsBtn.ShowDropDownArrow = false;
            FindSimilarImgsBtn.Size = new Size(67, 26);
            FindSimilarImgsBtn.Text = "Search";
            FindSimilarImgsBtn.ToolTipText = "Search for similar images";
            FindSimilarImgsBtn.Click += FindImagesBtn_Click;
            // 
            // DisplayPanel
            // 
            DisplayPanel.Controls.Add(statusStrip1);
            DisplayPanel.Controls.Add(GbxShowLoading);
            DisplayPanel.Controls.Add(UseCurrentImageCheckbox);
            DisplayPanel.Controls.Add(gbxProgress);
            DisplayPanel.Controls.Add(counterLabel);
            DisplayPanel.Controls.Add(customPictureBox);
            DisplayPanel.Controls.Add(toolStrip2);
            DisplayPanel.Location = new Point(772, 7);
            DisplayPanel.Margin = new Padding(0, 2, 0, 0);
            DisplayPanel.MinimumSize = new Size(0, 50);
            DisplayPanel.Name = "DisplayPanel";
            DisplayPanel.Size = new Size(856, 714);
            DisplayPanel.TabIndex = 7;
            // 
            // statusStrip1
            // 
            statusStrip1.Font = new Font("Segoe UI", 9.5F);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(8, 697);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RenderMode = ToolStripRenderMode.Professional;
            statusStrip1.Size = new Size(90, 22);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.UseWaitCursor = true;
            statusStrip1.Visible = false;
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(42, 17);
            statusLabel.Text = "status";
            statusLabel.Visible = false;
            // 
            // GbxShowLoading
            // 
            GbxShowLoading.BackColor = Color.White;
            GbxShowLoading.Controls.Add(pictureBox1);
            GbxShowLoading.Location = new Point(287, 237);
            GbxShowLoading.Name = "GbxShowLoading";
            GbxShowLoading.Padding = new Padding(0);
            GbxShowLoading.Size = new Size(239, 61);
            GbxShowLoading.TabIndex = 9;
            GbxShowLoading.TabStop = false;
            GbxShowLoading.Text = "Please wait ... ";
            GbxShowLoading.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(239, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // UseCurrentImageCheckbox
            // 
            UseCurrentImageCheckbox.BackColor = SystemColors.ControlLight;
            UseCurrentImageCheckbox.Checked = true;
            UseCurrentImageCheckbox.CheckState = CheckState.Checked;
            UseCurrentImageCheckbox.Cursor = Cursors.Hand;
            UseCurrentImageCheckbox.Enabled = false;
            UseCurrentImageCheckbox.Font = new Font("Segoe UI", 8.5F);
            UseCurrentImageCheckbox.Location = new Point(718, 1);
            UseCurrentImageCheckbox.Name = "UseCurrentImageCheckbox";
            UseCurrentImageCheckbox.Padding = new Padding(7, 4, 4, 4);
            UseCurrentImageCheckbox.Size = new Size(137, 27);
            UseCurrentImageCheckbox.TabIndex = 8;
            UseCurrentImageCheckbox.Text = "Use Current Image";
            toolTip1.SetToolTip(UseCurrentImageCheckbox, "Uncheck to use a local image for comparison; otherwise, the camera image will be used.");
            UseCurrentImageCheckbox.UseVisualStyleBackColor = false;
            UseCurrentImageCheckbox.CheckedChanged += UseCurrentImage_CheckedChanged;
            // 
            // Flp_Main
            // 
            Flp_Main.AutoSize = true;
            Flp_Main.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Flp_Main.Controls.Add(CameraSettingsPanel);
            Flp_Main.Controls.Add(ModbusControlsPanel);
            Flp_Main.Controls.Add(DisplayPanel);
            Flp_Main.Location = new Point(0, 37);
            Flp_Main.Name = "Flp_Main";
            Flp_Main.Padding = new Padding(5, 5, 2, 5);
            Flp_Main.Size = new Size(1630, 726);
            Flp_Main.TabIndex = 8;
            // 
            // CameraSettingsPanel
            // 
            CameraSettingsPanel.AutoSize = true;
            CameraSettingsPanel.BorderStyle = BorderStyle.Fixed3D;
            CameraSettingsPanel.Font = new Font("Segoe UI", 9.5F);
            CameraSettingsPanel.Location = new Point(8, 7);
            CameraSettingsPanel.Margin = new Padding(3, 2, 15, 3);
            CameraSettingsPanel.Name = "CameraSettingsPanel";
            CameraSettingsPanel.Padding = new Padding(0, 1, 0, 0);
            CameraSettingsPanel.Size = new Size(367, 657);
            CameraSettingsPanel.TabIndex = 8;
            CameraSettingsPanel.Visible = false;
            // 
            // ModbusControlsPanel
            // 
            ModbusControlsPanel.BackColor = SystemColors.Control;
            ModbusControlsPanel.BorderStyle = BorderStyle.Fixed3D;
            ModbusControlsPanel.Font = new Font("Segoe UI", 9.5F);
            ModbusControlsPanel.Location = new Point(393, 7);
            ModbusControlsPanel.Margin = new Padding(3, 2, 15, 3);
            ModbusControlsPanel.Name = "ModbusControlsPanel";
            ModbusControlsPanel.Padding = new Padding(0, 1, 0, 0);
            ModbusControlsPanel.Size = new Size(364, 697);
            ModbusControlsPanel.TabIndex = 9;
            ModbusControlsPanel.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1262, 757);
            Controls.Add(Flp_Main);
            Controls.Add(toolStrip1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Image Processing Tool";
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            gbxProgress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)customPictureBox).EndInit();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            DisplayPanel.ResumeLayout(false);
            DisplayPanel.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            GbxShowLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            Flp_Main.ResumeLayout(false);
            Flp_Main.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label counterLabel;
        private ToolStrip toolStrip1;
        private ToolStripButton StartAcquisitionBtn;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton StopAcquisitionBtn;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton SingleAcquisitionBtn;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripDropDownButton ToolsBtn;
        private ToolStripMenuItem ImageQualityMenuItem;
        private ToolStripMenuItem ImageSizeMenuItem;
        private ToolStripMenuItem ImageSimilarityMenuItem;
        private GroupBox gbxProgress;
        private ProgressBar progressBar;
        private ToolStripSeparator toolStripSeparator9;
        private SimplePictureBox customPictureBox;
        private ToolStrip toolStrip2;
        private ToolStripButton CropBtn;
        private Panel DisplayPanel;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripButton SaveFinalImageBtn;
        private ToolStripSeparator toolStripSeparator4;
        //private ToolStripButton FindSimilarImgsBtn;
        private ToolStripDropDownButton FindSimilarImgsBtn;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton SaveToDbBtn;
        private ToolStripMenuItem DefaultFolderMenuItem;
        private CheckBox UseCurrentImageCheckbox;
        private ToolStripMenuItem AddImagesToDBMenuItem;
        private FlowLayoutPanel Flp_Main;
        private AdjustSettings CameraSettingsPanel;
        private ToolStripMenuItem DeleteImagepMenuItem;
        private ToolStripMenuItem ModbusConfigMenuItem;
        private ToolStripMenuItem changeDatabaseSettingsToolStripMenuItem;
        private ModbusControls ModbusControlsPanel;
        private ToolStripButton CrosshairBtn;
        private ToolStripButton LightsBtn;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripDropDownButton MotorPositionBtn;
        private ToolStripMenuItem position1ToolStripMenuItem;
        private ToolStripMenuItem position2ToolStripMenuItem;
        private ToolStripMenuItem position3ToolStripMenuItem;
        private ToolTip toolTip1;
        private ToolStripSeparator toolStripSeparator14;
        private GroupBox GbxShowLoading;
        private PictureBox pictureBox1;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton AddAccessoryBtn;
        private ToolStripMenuItem CameraSettingsMenuItem;
        private ToolStripMenuItem hardwareSettingsMenuItem;
        private ToolStripMenuItem EditTextMenuItem;
        private ToolStripButton SaveExtraImgBtn;
        private ToolStripSeparator toolStripSeparator6;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
    }
}