using ImageProcessingLibrary.Helpers;

namespace TriCamPylonView.UI.Forms
{
    partial class ThresholdControlPanel
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
            histSimilarityTrackBar = new TrackBar();
            gbxHist = new GroupBox();
            groupBox2 = new GroupBox();
            akazeSimilarityTrackBar = new TrackBar();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox3 = new GroupBox();
            orbSimilarityTrackBar = new TrackBar();
            groupBox4 = new GroupBox();
            gfttSimilarityTrackBar = new TrackBar();
            groupBox5 = new GroupBox();
            fastFeatureSimilarityTrackBar = new TrackBar();
            groupBox6 = new GroupBox();
            imageHashSimilarityTrackBar = new TrackBar();
            panel2 = new Panel();
            ResetToZeroBtn = new Button();
            RestoreDefaultBtn = new Button();
            panel1 = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)histSimilarityTrackBar).BeginInit();
            gbxHist.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)akazeSimilarityTrackBar).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orbSimilarityTrackBar).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gfttSimilarityTrackBar).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fastFeatureSimilarityTrackBar).BeginInit();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageHashSimilarityTrackBar).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // histSimilarityTrackBar
            // 
            histSimilarityTrackBar.Dock = DockStyle.Fill;
            histSimilarityTrackBar.Location = new Point(8, 33);
            histSimilarityTrackBar.Margin = new Padding(12, 14, 12, 14);
            histSimilarityTrackBar.Maximum = 100;
            histSimilarityTrackBar.Name = "histSimilarityTrackBar";
            histSimilarityTrackBar.Size = new Size(290, 44);
            histSimilarityTrackBar.TabIndex = 0;
            histSimilarityTrackBar.Tag = "Histogram Similarity Threshold";
            histSimilarityTrackBar.TickFrequency = 10;
            histSimilarityTrackBar.ValueChanged += SimilarityTrackBar_ValueChanged;
            // 
            // gbxHist
            // 
            gbxHist.Controls.Add(histSimilarityTrackBar);
            gbxHist.Location = new Point(35, 28);
            gbxHist.Margin = new Padding(12, 14, 12, 14);
            gbxHist.Name = "gbxHist";
            gbxHist.Padding = new Padding(8, 16, 8, 9);
            gbxHist.Size = new Size(306, 86);
            gbxHist.TabIndex = 1;
            gbxHist.TabStop = false;
            gbxHist.Text = "Histogram Similarity Threshold";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(akazeSimilarityTrackBar);
            groupBox2.Location = new Point(365, 28);
            groupBox2.Margin = new Padding(12, 14, 12, 14);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(8, 16, 8, 9);
            groupBox2.Size = new Size(306, 86);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Akaze Similarity Threshold";
            // 
            // akazeSimilarityTrackBar
            // 
            akazeSimilarityTrackBar.Dock = DockStyle.Fill;
            akazeSimilarityTrackBar.Location = new Point(8, 33);
            akazeSimilarityTrackBar.Margin = new Padding(4, 3, 4, 3);
            akazeSimilarityTrackBar.Maximum = 100;
            akazeSimilarityTrackBar.Name = "akazeSimilarityTrackBar";
            akazeSimilarityTrackBar.Size = new Size(290, 44);
            akazeSimilarityTrackBar.TabIndex = 0;
            akazeSimilarityTrackBar.Tag = "Akaze Similarity Threshold";
            akazeSimilarityTrackBar.TickFrequency = 10;
            akazeSimilarityTrackBar.ValueChanged += SimilarityTrackBar_ValueChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(gbxHist);
            flowLayoutPanel1.Controls.Add(groupBox2);
            flowLayoutPanel1.Controls.Add(groupBox3);
            flowLayoutPanel1.Controls.Add(groupBox4);
            flowLayoutPanel1.Controls.Add(groupBox5);
            flowLayoutPanel1.Controls.Add(groupBox6);
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(23, 14, 12, 14);
            flowLayoutPanel1.Size = new Size(708, 567);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(orbSimilarityTrackBar);
            groupBox3.Location = new Point(35, 142);
            groupBox3.Margin = new Padding(12, 14, 12, 14);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(8, 16, 8, 9);
            groupBox3.Size = new Size(306, 86);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "ORB Similarity Threshold";
            // 
            // orbSimilarityTrackBar
            // 
            orbSimilarityTrackBar.Dock = DockStyle.Fill;
            orbSimilarityTrackBar.Location = new Point(8, 33);
            orbSimilarityTrackBar.Margin = new Padding(4, 3, 4, 3);
            orbSimilarityTrackBar.Maximum = 100;
            orbSimilarityTrackBar.Name = "orbSimilarityTrackBar";
            orbSimilarityTrackBar.Size = new Size(290, 44);
            orbSimilarityTrackBar.TabIndex = 0;
            orbSimilarityTrackBar.Tag = "ORB Similarity Threshold";
            orbSimilarityTrackBar.TickFrequency = 10;
            orbSimilarityTrackBar.ValueChanged += SimilarityTrackBar_ValueChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(gfttSimilarityTrackBar);
            groupBox4.Location = new Point(365, 142);
            groupBox4.Margin = new Padding(12, 14, 12, 14);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(8, 16, 8, 9);
            groupBox4.Size = new Size(306, 86);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "GFTT Similarity Threshold";
            // 
            // gfttSimilarityTrackBar
            // 
            gfttSimilarityTrackBar.Dock = DockStyle.Fill;
            gfttSimilarityTrackBar.Location = new Point(8, 33);
            gfttSimilarityTrackBar.Margin = new Padding(4, 3, 4, 3);
            gfttSimilarityTrackBar.Maximum = 100;
            gfttSimilarityTrackBar.Name = "gfttSimilarityTrackBar";
            gfttSimilarityTrackBar.Size = new Size(290, 44);
            gfttSimilarityTrackBar.TabIndex = 0;
            gfttSimilarityTrackBar.Tag = "GFTT Similarity Threshold";
            gfttSimilarityTrackBar.TickFrequency = 10;
            gfttSimilarityTrackBar.ValueChanged += SimilarityTrackBar_ValueChanged;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(fastFeatureSimilarityTrackBar);
            groupBox5.Location = new Point(35, 256);
            groupBox5.Margin = new Padding(12, 14, 12, 14);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(8, 16, 8, 9);
            groupBox5.Size = new Size(306, 86);
            groupBox5.TabIndex = 3;
            groupBox5.TabStop = false;
            groupBox5.Text = "Fast Feature Similarity Threshold";
            // 
            // fastFeatureSimilarityTrackBar
            // 
            fastFeatureSimilarityTrackBar.Dock = DockStyle.Fill;
            fastFeatureSimilarityTrackBar.Location = new Point(8, 33);
            fastFeatureSimilarityTrackBar.Margin = new Padding(4, 3, 4, 3);
            fastFeatureSimilarityTrackBar.Maximum = 100;
            fastFeatureSimilarityTrackBar.Name = "fastFeatureSimilarityTrackBar";
            fastFeatureSimilarityTrackBar.Size = new Size(290, 44);
            fastFeatureSimilarityTrackBar.TabIndex = 0;
            fastFeatureSimilarityTrackBar.Tag = "Fast Feature Similarity Threshold";
            fastFeatureSimilarityTrackBar.TickFrequency = 10;
            fastFeatureSimilarityTrackBar.ValueChanged += SimilarityTrackBar_ValueChanged;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(imageHashSimilarityTrackBar);
            groupBox6.Location = new Point(365, 256);
            groupBox6.Margin = new Padding(12, 14, 12, 14);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(8, 16, 8, 9);
            groupBox6.Size = new Size(306, 86);
            groupBox6.TabIndex = 4;
            groupBox6.TabStop = false;
            groupBox6.Text = "Image Hash Similarity Threshold";
            // 
            // imageHashSimilarityTrackBar
            // 
            imageHashSimilarityTrackBar.Dock = DockStyle.Fill;
            imageHashSimilarityTrackBar.Location = new Point(8, 33);
            imageHashSimilarityTrackBar.Margin = new Padding(4, 3, 4, 3);
            imageHashSimilarityTrackBar.Maximum = 100;
            imageHashSimilarityTrackBar.Name = "imageHashSimilarityTrackBar";
            imageHashSimilarityTrackBar.Size = new Size(290, 44);
            imageHashSimilarityTrackBar.TabIndex = 0;
            imageHashSimilarityTrackBar.Tag = "Image Hash Similarity Threshold";
            imageHashSimilarityTrackBar.TickFrequency = 10;
            imageHashSimilarityTrackBar.ValueChanged += SimilarityTrackBar_ValueChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(ResetToZeroBtn);
            panel2.Controls.Add(RestoreDefaultBtn);
            panel2.Location = new Point(26, 359);
            panel2.Name = "panel2";
            panel2.Size = new Size(645, 105);
            panel2.TabIndex = 5;
            // 
            // ResetToZeroBtn
            // 
            ResetToZeroBtn.BackColor = Color.LightGray;
            ResetToZeroBtn.Location = new Point(533, 62);
            ResetToZeroBtn.Name = "ResetToZeroBtn";
            ResetToZeroBtn.Size = new Size(104, 36);
            ResetToZeroBtn.TabIndex = 1;
            ResetToZeroBtn.Text = "Reset to Zero";
            ResetToZeroBtn.UseVisualStyleBackColor = false;
            ResetToZeroBtn.Click += ResetToZeroBtn_Click;
            // 
            // RestoreDefaultBtn
            // 
            RestoreDefaultBtn.BackColor = Color.LightGray;
            RestoreDefaultBtn.Location = new Point(533, 8);
            RestoreDefaultBtn.Name = "RestoreDefaultBtn";
            RestoreDefaultBtn.Size = new Size(112, 48);
            RestoreDefaultBtn.TabIndex = 0;
            RestoreDefaultBtn.Text = "Restore default settings";
            RestoreDefaultBtn.UseVisualStyleBackColor = false;
            RestoreDefaultBtn.Click += RestoreDefaultBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnCancel);
            panel1.Location = new Point(27, 470);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(643, 85);
            panel1.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.BackColor = UIColors.ButtonSuccess;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.ForeColor = Color.White;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Location = new Point(345, 25);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 43);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = UIColors.ButtonCancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.ForeColor = UIColors.TextPrimary;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(218, 25);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 43);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // ThresholdControlPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = UIColors.Background;
            CancelButton = btnCancel;
            ClientSize = new Size(708, 567);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ThresholdControlPanel";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Change Thresholds For Image Similarity";
            FormClosing += ThresholdControlPanel_FormClosing;
            Load += ThresholdControlPanel_Load;
            ((System.ComponentModel.ISupportInitialize)histSimilarityTrackBar).EndInit();
            gbxHist.ResumeLayout(false);
            gbxHist.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)akazeSimilarityTrackBar).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)orbSimilarityTrackBar).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gfttSimilarityTrackBar).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fastFeatureSimilarityTrackBar).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imageHashSimilarityTrackBar).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TrackBar histSimilarityTrackBar;
        private System.Windows.Forms.GroupBox gbxHist;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar akazeSimilarityTrackBar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar orbSimilarityTrackBar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TrackBar gfttSimilarityTrackBar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TrackBar fastFeatureSimilarityTrackBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TrackBar imageHashSimilarityTrackBar;
        private Panel panel2;
        private Button RestoreDefaultBtn;
        private Button ResetToZeroBtn;
    }
}