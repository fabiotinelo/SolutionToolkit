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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRec));
            btnRec = new Button();
            btnStop = new Button();
            cbbWindows = new ComboBox();
            cbbMonitors = new ComboBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            statusStrip1 = new StatusStrip();
            tslStatus = new ToolStripStatusLabel();
            groupBox3 = new GroupBox();
            txtVideoFile = new TextBox();
            btnPathFile = new Button();
            sfdVideo = new SaveFileDialog();
            tableLayoutPanel1 = new TableLayoutPanel();
            splitContainer1 = new SplitContainer();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            statusStrip1.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // btnRec
            // 
            btnRec.AutoSize = true;
            btnRec.Dock = DockStyle.Fill;
            btnRec.ForeColor = Color.Red;
            btnRec.Location = new Point(0, 0);
            btnRec.Name = "btnRec";
            btnRec.Size = new Size(277, 50);
            btnRec.TabIndex = 0;
            btnRec.Text = "REC";
            btnRec.UseVisualStyleBackColor = true;
            btnRec.Click += btnRec_Click;
            // 
            // btnStop
            // 
            btnStop.AutoSize = true;
            btnStop.Dock = DockStyle.Fill;
            btnStop.Enabled = false;
            btnStop.Location = new Point(0, 0);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(284, 50);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // cbbWindows
            // 
            cbbWindows.Dock = DockStyle.Fill;
            cbbWindows.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbWindows.FormattingEnabled = true;
            cbbWindows.Location = new Point(10, 27);
            cbbWindows.Name = "cbbWindows";
            cbbWindows.Size = new Size(556, 28);
            cbbWindows.TabIndex = 3;
            // 
            // cbbMonitors
            // 
            cbbMonitors.Dock = DockStyle.Fill;
            cbbMonitors.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbMonitors.FormattingEnabled = true;
            cbbMonitors.Location = new Point(10, 27);
            cbbMonitors.Name = "cbbMonitors";
            cbbMonitors.Size = new Size(556, 28);
            cbbMonitors.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(cbbMonitors);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10, 7, 10, 7);
            groupBox1.Size = new Size(576, 61);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Monitor";
            // 
            // groupBox2
            // 
            groupBox2.AutoSize = true;
            groupBox2.Controls.Add(cbbWindows);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 137);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(10, 7, 10, 7);
            groupBox2.Size = new Size(576, 61);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Window";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tslStatus });
            statusStrip1.Location = new Point(20, 281);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(699, 24);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // tslStatus
            // 
            tslStatus.Name = "tslStatus";
            tslStatus.Size = new Size(0, 18);
            // 
            // groupBox3
            // 
            groupBox3.AutoSize = true;
            groupBox3.Controls.Add(txtVideoFile);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(10, 7, 10, 7);
            groupBox3.Size = new Size(576, 61);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Video File";
            // 
            // txtVideoFile
            // 
            txtVideoFile.Dock = DockStyle.Left;
            txtVideoFile.Location = new Point(10, 27);
            txtVideoFile.Name = "txtVideoFile";
            txtVideoFile.ReadOnly = true;
            txtVideoFile.Size = new Size(556, 27);
            txtVideoFile.TabIndex = 0;
            // 
            // btnPathFile
            // 
            btnPathFile.AutoSize = true;
            btnPathFile.Location = new Point(592, 22);
            btnPathFile.Margin = new Padding(10, 22, 3, 3);
            btnPathFile.Name = "btnPathFile";
            btnPathFile.Size = new Size(100, 37);
            btnPathFile.TabIndex = 1;
            btnPathFile.Text = "File Name";
            btnPathFile.UseVisualStyleBackColor = true;
            btnPathFile.Click += btnPathFile_Click;
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
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 83.35788F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.64212F));
            tableLayoutPanel1.Controls.Add(btnPathFile, 1, 0);
            tableLayoutPanel1.Controls.Add(groupBox3, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 2);
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(20, 10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(699, 271);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(7, 211);
            splitContainer1.Margin = new Padding(7, 10, 10, 10);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnRec);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnStop);
            splitContainer1.Size = new Size(565, 50);
            splitContainer1.SplitterDistance = 277;
            splitContainer1.TabIndex = 9;
            // 
            // FrmRec
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(739, 310);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(statusStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmRec";
            Padding = new Padding(20, 10, 20, 5);
            Text = "Capture Hub";
            FormClosing += FrmRec_FormClosing;
            Load += FrmRec_Load;
            DpiChanged += FrmRec_DpiChanged;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRec;
		private Button btnStop;
		private ComboBox cbbWindows;
		private ComboBox cbbMonitors;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel tslStatus;
		private GroupBox groupBox3;
		private Button btnPathFile;
		private SaveFileDialog sfdVideo;
        private TextBox txtVideoFile;
        private TableLayoutPanel tableLayoutPanel1;
        private SplitContainer splitContainer1;
    }
}
