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
			btnPathFile = new Button();
			lblVideoFile = new Label();
			sfdVideo = new SaveFileDialog();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			statusStrip1.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			// 
			// btnRec
			// 
			btnRec.ForeColor = Color.Red;
			btnRec.Location = new Point(1074, 138);
			btnRec.Name = "btnRec";
			btnRec.Size = new Size(105, 71);
			btnRec.TabIndex = 0;
			btnRec.Text = "REC";
			btnRec.UseVisualStyleBackColor = true;
			btnRec.Click += btnRec_Click;
			// 
			// btnStop
			// 
			btnStop.Enabled = false;
			btnStop.Location = new Point(1199, 138);
			btnStop.Name = "btnStop";
			btnStop.Size = new Size(105, 71);
			btnStop.TabIndex = 2;
			btnStop.Text = "Stop";
			btnStop.UseVisualStyleBackColor = true;
			btnStop.Click += btnStop_Click;
			// 
			// cbbWindows
			// 
			cbbWindows.DropDownStyle = ComboBoxStyle.DropDownList;
			cbbWindows.FormattingEnabled = true;
			cbbWindows.Location = new Point(15, 33);
			cbbWindows.Name = "cbbWindows";
			cbbWindows.Size = new Size(979, 28);
			cbbWindows.TabIndex = 3;
			// 
			// cbbMonitors
			// 
			cbbMonitors.DropDownStyle = ComboBoxStyle.DropDownList;
			cbbMonitors.FormattingEnabled = true;
			cbbMonitors.Location = new Point(19, 42);
			cbbMonitors.Name = "cbbMonitors";
			cbbMonitors.Size = new Size(240, 28);
			cbbMonitors.TabIndex = 5;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(cbbMonitors);
			groupBox1.Location = new Point(27, 23);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(285, 89);
			groupBox1.TabIndex = 6;
			groupBox1.TabStop = false;
			groupBox1.Text = "Monitor";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(cbbWindows);
			groupBox2.Location = new Point(27, 129);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(1018, 80);
			groupBox2.TabIndex = 7;
			groupBox2.TabStop = false;
			groupBox2.Text = "Window";
			// 
			// statusStrip1
			// 
			statusStrip1.ImageScalingSize = new Size(20, 20);
			statusStrip1.Items.AddRange(new ToolStripItem[] { tslStatus });
			statusStrip1.Location = new Point(0, 235);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new Size(1331, 22);
			statusStrip1.TabIndex = 8;
			statusStrip1.Text = "statusStrip1";
			// 
			// tslStatus
			// 
			tslStatus.Name = "tslStatus";
			tslStatus.Size = new Size(0, 16);
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(btnPathFile);
			groupBox3.Controls.Add(lblVideoFile);
			groupBox3.Location = new Point(343, 23);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(961, 89);
			groupBox3.TabIndex = 8;
			groupBox3.TabStop = false;
			groupBox3.Text = "Video File";
			// 
			// btnPathFile
			// 
			btnPathFile.Location = new Point(840, 34);
			btnPathFile.Name = "btnPathFile";
			btnPathFile.Size = new Size(103, 37);
			btnPathFile.TabIndex = 1;
			btnPathFile.Text = "File Name";
			btnPathFile.UseVisualStyleBackColor = true;
			btnPathFile.Click += btnPathFile_Click;
			// 
			// lblVideoFile
			// 
			lblVideoFile.Location = new Point(22, 42);
			lblVideoFile.MaximumSize = new Size(803, 0);
			lblVideoFile.Name = "lblVideoFile";
			lblVideoFile.Size = new Size(803, 28);
			lblVideoFile.TabIndex = 0;
			lblVideoFile.Text = "          ";
			// 
			// sfdVideo
			// 
			sfdVideo.DefaultExt = "mp4";
			sfdVideo.Filter = "Vídeo MP4 (*.mp4)|*.mp4\"";
			sfdVideo.Title = "Video File Name";
			// 
			// FrmRec
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1331, 257);
			Controls.Add(groupBox3);
			Controls.Add(statusStrip1);
			Controls.Add(btnRec);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(btnStop);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "FrmRec";
			Text = "Capture Hub";
			FormClosing += FrmRec_FormClosing;
			Load += FrmRec_Load;
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			groupBox3.ResumeLayout(false);
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
		private Label lblVideoFile;
		private SaveFileDialog sfdVideo;
	}
}
