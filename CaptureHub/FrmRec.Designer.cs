namespace Rec
{
	partial class FrmRec
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRec));
            groupBox1 = new GroupBox();
            cbbWindows = new ComboBox();
            groupBox2 = new GroupBox();
            txtVideoFile = new TextBox();
            btnPathFile = new Button();
            statusStrip1 = new StatusStrip();
            tslStatus = new ToolStripStatusLabel();
            groupBox3 = new GroupBox();
            cbbMonitors = new ComboBox();
            sfdVideo = new SaveFileDialog();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox4 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnStop = new Button();
            btnRec = new Button();
            btnMicrophone = new Button();
            imageList1 = new ImageList(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            statusStrip1.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox4.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(cbbWindows);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 62);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(9, 5, 9, 5);
            groupBox1.Size = new Size(601, 56);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Window";
            // 
            // cbbWindows
            // 
            cbbWindows.Dock = DockStyle.Fill;
            cbbWindows.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbWindows.FormattingEnabled = true;
            cbbWindows.Location = new Point(9, 21);
            cbbWindows.Margin = new Padding(3, 2, 3, 2);
            cbbWindows.Name = "cbbWindows";
            cbbWindows.Size = new Size(583, 23);
            cbbWindows.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(txtVideoFile);
            groupBox2.Controls.Add(btnPathFile);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 122);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(9, 5, 9, 5);
            groupBox2.Size = new Size(601, 76);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Video File";
            // 
            // txtVideoFile
            // 
            txtVideoFile.Dock = DockStyle.Fill;
            txtVideoFile.Location = new Point(9, 21);
            txtVideoFile.Margin = new Padding(3, 2, 3, 2);
            txtVideoFile.Name = "txtVideoFile";
            txtVideoFile.ReadOnly = true;
            txtVideoFile.Size = new Size(583, 23);
            txtVideoFile.TabIndex = 1;
            // 
            // btnPathFile
            // 
            btnPathFile.AutoSize = true;
            btnPathFile.Dock = DockStyle.Bottom;
            btnPathFile.Location = new Point(9, 46);
            btnPathFile.Margin = new Padding(9, 16, 3, 2);
            btnPathFile.MaximumSize = new Size(80, 30);
            btnPathFile.Name = "btnPathFile";
            btnPathFile.Size = new Size(80, 25);
            btnPathFile.TabIndex = 1;
            btnPathFile.Text = "File Name";
            btnPathFile.UseVisualStyleBackColor = true;
            btnPathFile.Click += btnPathFile_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tslStatus });
            statusStrip1.Location = new Point(18, 285);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 12, 0);
            statusStrip1.Size = new Size(607, 22);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // tslStatus
            // 
            tslStatus.Name = "tslStatus";
            tslStatus.Size = new Size(0, 17);
            // 
            // groupBox3
            // 
            groupBox3.AutoSize = true;
            groupBox3.Controls.Add(cbbMonitors);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(3, 2);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(9, 5, 9, 5);
            groupBox3.Size = new Size(601, 56);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Monitor";
            // 
            // cbbMonitors
            // 
            cbbMonitors.Dock = DockStyle.Fill;
            cbbMonitors.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbMonitors.FormattingEnabled = true;
            cbbMonitors.Location = new Point(9, 21);
            cbbMonitors.Margin = new Padding(3, 2, 3, 2);
            cbbMonitors.Name = "cbbMonitors";
            cbbMonitors.Size = new Size(583, 23);
            cbbMonitors.TabIndex = 6;
            // 
            // sfdVideo
            // 
            sfdVideo.DefaultExt = "mp4";
            sfdVideo.Filter = "Vídeo MP4 (*.mp4)|*.mp4\"";
            sfdVideo.Title = "Video File Name";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox3, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 2);
            tableLayoutPanel1.Controls.Add(groupBox4, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(18, 8);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(607, 277);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(tableLayoutPanel2);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(3, 203);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(601, 71);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "Controls";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.Controls.Add(btnStop, 2, 0);
            tableLayoutPanel2.Controls.Add(btnRec, 1, 0);
            tableLayoutPanel2.Controls.Add(btnMicrophone, 0, 0);
            tableLayoutPanel2.Location = new Point(24, 22);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(293, 39);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // btnStop
            // 
            btnStop.AutoSize = true;
            btnStop.Enabled = false;
            btnStop.Location = new Point(178, 3);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 25);
            btnStop.TabIndex = 0;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnRec
            // 
            btnRec.AutoSize = true;
            btnRec.ForeColor = Color.Red;
            btnRec.Location = new Point(61, 3);
            btnRec.Name = "btnRec";
            btnRec.Size = new Size(75, 25);
            btnRec.TabIndex = 0;
            btnRec.Text = "REC";
            btnRec.UseVisualStyleBackColor = true;
            btnRec.Click += btnRec_Click;
            // 
            // btnMicrophone
            // 
            btnMicrophone.Dock = DockStyle.Fill;
            btnMicrophone.ImageIndex = 1;
            btnMicrophone.ImageList = imageList1;
            btnMicrophone.Location = new Point(3, 3);
            btnMicrophone.Name = "btnMicrophone";
            btnMicrophone.Size = new Size(52, 33);
            btnMicrophone.TabIndex = 0;
            btnMicrophone.UseVisualStyleBackColor = true;
            btnMicrophone.Click += btnMicrophone_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "ico-micro-open.png");
            imageList1.Images.SetKeyName(1, "ico-mute.png");
            // 
            // FrmRec
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(643, 311);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(statusStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "FrmRec";
            Padding = new Padding(18, 8, 18, 4);
            Text = "Capture Hub";
            FormClosing += FrmRec_FormClosing;
            Load += FrmRec_Load;
            DpiChanged += FrmRec_DpiChanged;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox4.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
		private GroupBox groupBox2;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel tslStatus;
		private GroupBox groupBox3;
		private Button btnPathFile;
		private SaveFileDialog sfdVideo;
        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox cbbWindows;
        private TextBox txtVideoFile;
        private ComboBox cbbMonitors;
        private Button btnRec;
        private Button btnStop;
        private GroupBox groupBox4;
        private Button btnMicrophone;
        private ImageList imageList1;
        private TableLayoutPanel tableLayoutPanel2;
    }
}
