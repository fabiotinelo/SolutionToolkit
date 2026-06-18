namespace Transcription
{
	partial class frmAudioTranscription
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAudioTranscription));
            btnTranscribe = new Button();
            txtResult = new RichTextBox();
            cbbModel = new ComboBox();
            panel1 = new Panel();
            label2 = new Label();
            cmbLanguage = new ComboBox();
            btnCopyText = new Button();
            label1 = new Label();
            statusStrip1 = new StatusStrip();
            tslStatus = new ToolStripStatusLabel();
            tslFilePath = new ToolStripStatusLabel();
            pnlResult = new Panel();
            panel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnlResult.SuspendLayout();
            SuspendLayout();
            // 
            // btnTranscribe
            // 
            btnTranscribe.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTranscribe.ForeColor = Color.FromArgb(255, 128, 0);
            btnTranscribe.Location = new Point(534, 13);
            btnTranscribe.Name = "btnTranscribe";
            btnTranscribe.Size = new Size(147, 61);
            btnTranscribe.TabIndex = 0;
            btnTranscribe.Text = "Transcribe";
            btnTranscribe.UseVisualStyleBackColor = true;
            btnTranscribe.Click += button1_Click;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(35, 47);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(664, 250);
            txtResult.TabIndex = 2;
            txtResult.Text = "";
            // 
            // cbbModel
            // 
            cbbModel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbModel.FormattingEnabled = true;
            cbbModel.Items.AddRange(new object[] { "tiny", "tiny-q5_1", "tiny-q8_0", "tiny.en", "tiny.en-q5_1", "tiny.en-q8_0", "base", "base-q5_1", "base-q8_0", "base.en", "base.en-q5_1", "base.en-q8_0", "small", "small-q5_1", "small-q8_0", "small.en", "small.en-q5_1", "small.en-q8_0", "small.en-tdrz", "medium", "medium-q5_0", "medium-q8_0", "medium.en", "medium.en-q5_0", "medium.en-q8_0", "large-v1", "large-v2", "large-v2-q5_0", "large-v2-q8_0", "large-v3", "large-v3-q5_0", "large-v3-turbo", "large-v3-turbo-q5_0", "large-v3-turbo-q8_0" });
            cbbModel.Location = new Point(22, 45);
            cbbModel.Name = "cbbModel";
            cbbModel.Size = new Size(235, 28);
            cbbModel.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbLanguage);
            panel1.Controls.Add(btnCopyText);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cbbModel);
            panel1.Controls.Add(btnTranscribe);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1217, 93);
            panel1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(281, 13);
            label2.Name = "label2";
            label2.Size = new Size(66, 23);
            label2.TabIndex = 6;
            label2.Text = "Idioma";
            // 
            // cmbLanguage
            // 
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Items.AddRange(new object[] { "pt", "en", "es" });
            cmbLanguage.Location = new Point(281, 45);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(148, 28);
            cmbLanguage.TabIndex = 7;
            // 
            // btnCopyText
            // 
            btnCopyText.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCopyText.ForeColor = Color.Blue;
            btnCopyText.Location = new Point(703, 13);
            btnCopyText.Name = "btnCopyText";
            btnCopyText.Size = new Size(147, 61);
            btnCopyText.TabIndex = 5;
            btnCopyText.Text = "Copy Text";
            btnCopyText.UseVisualStyleBackColor = true;
            btnCopyText.Click += btnCopyText_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 13);
            label1.Name = "label1";
            label1.Size = new Size(61, 23);
            label1.TabIndex = 1;
            label1.Text = "Model";
            // 
            // statusStrip1
            // 
            statusStrip1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tslStatus, tslFilePath });
            statusStrip1.Location = new Point(0, 648);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1217, 22);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // tslStatus
            // 
            tslStatus.Name = "tslStatus";
            tslStatus.Size = new Size(0, 16);
            // 
            // tslFilePath
            // 
            tslFilePath.Name = "tslFilePath";
            tslFilePath.Size = new Size(0, 16);
            // 
            // pnlResult
            // 
            pnlResult.Controls.Add(txtResult);
            pnlResult.Location = new Point(12, 124);
            pnlResult.Name = "pnlResult";
            pnlResult.Size = new Size(838, 439);
            pnlResult.TabIndex = 7;
            // 
            // frmAudioTranscription
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 670);
            Controls.Add(pnlResult);
            Controls.Add(statusStrip1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAudioTranscription";
            Text = "Video Transcript";
            FormClosing += frmAudioTranscription_FormClosing;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            pnlResult.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTranscribe;
		private RichTextBox txtResult;
		private ComboBox cbbModel;
		private Panel panel1;
		private Label label1;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel tslStatus;
		private Panel pnlResult;
		private ToolStripStatusLabel tslFilePath;
		private Button btnCopyText;
		private Label label2;
		private ComboBox cmbLanguage;
	}
}
