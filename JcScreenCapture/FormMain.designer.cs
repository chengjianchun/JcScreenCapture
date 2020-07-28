namespace JcScreenCapture
{
	partial class FormMain
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this._tScreenshot = new System.Windows.Forms.Timer(this.components);
			this._ts = new System.Windows.Forms.ToolStrip();
			this.tsbHide = new System.Windows.Forms.ToolStripButton();
			this.tsbShowScreenshot = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbUninstall = new System.Windows.Forms.ToolStripButton();
			this.tsbExit = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbHelp = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsmiViewHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.cbAutoRun = new System.Windows.Forms.CheckBox();
			this.cbAutoHide = new System.Windows.Forms.CheckBox();
			this.rtbInfo = new System.Windows.Forms.RichTextBox();
			this._config = new JcScreenCapture.JcConfig(this.components);
			this._ts.SuspendLayout();
			this.SuspendLayout();
			// 
			// _tScreenshot
			// 
			this._tScreenshot.Interval = 60000;
			this._tScreenshot.Tick += new System.EventHandler(this._tScreenshot_Tick);
			// 
			// _ts
			// 
			this._ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHide,
            this.tsbShowScreenshot,
            this.toolStripSeparator1,
            this.tsbUninstall,
            this.tsbExit,
            this.toolStripSeparator2,
            this.tsbHelp});
			this._ts.Location = new System.Drawing.Point(0, 0);
			this._ts.Name = "_ts";
			this._ts.Size = new System.Drawing.Size(584, 25);
			this._ts.TabIndex = 0;
			this._ts.Text = "toolStrip1";
			// 
			// tsbHide
			// 
			this.tsbHide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbHide.ForeColor = System.Drawing.Color.Green;
			this.tsbHide.Image = ((System.Drawing.Image)(resources.GetObject("tsbHide.Image")));
			this.tsbHide.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbHide.Name = "tsbHide";
			this.tsbHide.Size = new System.Drawing.Size(39, 22);
			this.tsbHide.Text = "Hide";
			this.tsbHide.Click += new System.EventHandler(this.tsbHide_Click);
			// 
			// tsbShowScreenshot
			// 
			this.tsbShowScreenshot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbShowScreenshot.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowScreenshot.Image")));
			this.tsbShowScreenshot.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbShowScreenshot.Name = "tsbShowScreenshot";
			this.tsbShowScreenshot.Size = new System.Drawing.Size(39, 22);
			this.tsbShowScreenshot.Text = "View";
			this.tsbShowScreenshot.Click += new System.EventHandler(this.tsbShowScreenshot_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbUninstall
			// 
			this.tsbUninstall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbUninstall.Image = ((System.Drawing.Image)(resources.GetObject("tsbUninstall.Image")));
			this.tsbUninstall.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbUninstall.Name = "tsbUninstall";
			this.tsbUninstall.Size = new System.Drawing.Size(61, 22);
			this.tsbUninstall.Text = "Uninstall";
			this.tsbUninstall.Click += new System.EventHandler(this.tsbUninstall_Click);
			// 
			// tsbExit
			// 
			this.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
			this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbExit.Name = "tsbExit";
			this.tsbExit.Size = new System.Drawing.Size(32, 22);
			this.tsbExit.Text = "Exit";
			this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbHelp
			// 
			this.tsbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewHelp,
            this.tsmiAbout});
			this.tsbHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsbHelp.Image")));
			this.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbHelp.Name = "tsbHelp";
			this.tsbHelp.Size = new System.Drawing.Size(48, 22);
			this.tsbHelp.Text = "Help";
			// 
			// tsmiViewHelp
			// 
			this.tsmiViewHelp.Name = "tsmiViewHelp";
			this.tsmiViewHelp.Size = new System.Drawing.Size(180, 22);
			this.tsmiViewHelp.Text = "View Help";
			this.tsmiViewHelp.Click += new System.EventHandler(this.tsmiViewHelp_Click);
			// 
			// tsmiAbout
			// 
			this.tsmiAbout.Name = "tsmiAbout";
			this.tsmiAbout.Size = new System.Drawing.Size(180, 22);
			this.tsmiAbout.Text = "About";
			this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
			// 
			// cbAutoRun
			// 
			this.cbAutoRun.AutoSize = true;
			this.cbAutoRun.Location = new System.Drawing.Point(12, 28);
			this.cbAutoRun.Name = "cbAutoRun";
			this.cbAutoRun.Size = new System.Drawing.Size(84, 16);
			this.cbAutoRun.TabIndex = 1;
			this.cbAutoRun.Text = "Auto Start";
			this.cbAutoRun.UseVisualStyleBackColor = true;
			// 
			// cbAutoHide
			// 
			this.cbAutoHide.AutoSize = true;
			this.cbAutoHide.Location = new System.Drawing.Point(111, 28);
			this.cbAutoHide.Name = "cbAutoHide";
			this.cbAutoHide.Size = new System.Drawing.Size(78, 16);
			this.cbAutoHide.TabIndex = 2;
			this.cbAutoHide.Text = "Auto Hide";
			this.cbAutoHide.UseVisualStyleBackColor = true;
			// 
			// rtbInfo
			// 
			this.rtbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbInfo.Location = new System.Drawing.Point(12, 50);
			this.rtbInfo.Name = "rtbInfo";
			this.rtbInfo.ReadOnly = true;
			this.rtbInfo.Size = new System.Drawing.Size(560, 299);
			this.rtbInfo.TabIndex = 3;
			this.rtbInfo.Text = "After the window is hidden, press Ctrl + Shift + J or Ctrl + Alt + J to display t" +
    "he window.";
			this.rtbInfo.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbInfo_LinkClicked);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 361);
			this.ControlBox = false;
			this.Controls.Add(this.rtbInfo);
			this.Controls.Add(this.cbAutoHide);
			this.Controls.Add(this.cbAutoRun);
			this.Controls.Add(this._ts);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormMain";
			this.Opacity = 0D;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "JcScreenCapture";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
			this.Load += new System.EventHandler(this.FormMain_Load);
			this._ts.ResumeLayout(false);
			this._ts.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer _tScreenshot;
		private System.Windows.Forms.ToolStrip _ts;
		private System.Windows.Forms.ToolStripButton tsbHide;
		private System.Windows.Forms.ToolStripButton tsbShowScreenshot;
		private System.Windows.Forms.ToolStripButton tsbExit;
		private System.Windows.Forms.CheckBox cbAutoRun;
		private System.Windows.Forms.CheckBox cbAutoHide;
		private System.Windows.Forms.RichTextBox rtbInfo;
		private JcConfig _config;
		private System.Windows.Forms.ToolStripButton tsbUninstall;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripDropDownButton tsbHelp;
		private System.Windows.Forms.ToolStripMenuItem tsmiViewHelp;
		private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
	}
}

