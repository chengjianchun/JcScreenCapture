using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace JcScreenCapture
{
	public partial class FormMain : Form
	{
		private const int WM_HOTKEY = 0x312;

		public FormMain()
		{
			InitializeComponent();
		}

		protected override void WndProc(ref Message msg)
		{
			base.WndProc(ref msg);
			switch (msg.Msg)
			{
				case WM_HOTKEY:
					if (Visible)
					{
						Hide();
					}
					else
					{
						Show();
						if (WindowState == FormWindowState.Minimized)
						{
							WindowState = FormWindowState.Normal;
						}
						TopMost = true;
						Invoke(new EventHandler(delegate (Object sender, EventArgs args)
						{
							TopMost = false;
						}));
					}
					break;
				default:
					break;
			}
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			IntPtr hMutex;
			hMutex = JcUtility.CreateMutex(null, false, "JcScreenCapture");
			if (JcUtility.GetLastError() == JcUtility.ERROR_ALREADY_EXISTS)
			{
				Environment.Exit(0);
			}

			if (_config.AutoHide)
			{
				this.BeginInvoke(new MethodInvoker(delegate() {
					this.Hide();
					this.Opacity = 1;
				}));
			}
			else
			{
				this.Opacity = 1;
			}

			JcUtility.RegisterHotKey(this.Handle, 101, JcUtility.KeyModifiers.Ctrl | JcUtility.KeyModifiers.Shift, Keys.J);
			JcUtility.RegisterHotKey(this.Handle, 102, JcUtility.KeyModifiers.Ctrl | JcUtility.KeyModifiers.Alt, Keys.J);

			try
			{
				JcUtility.Screenshot();
			}
			catch (Exception ex)
			{
				JcUtility.Log("Screenshot Exeption:");
				JcUtility.LogException(ex);
			}

			_tScreenshot.Start();

			cbAutoRun.Checked = _config.AutoRun;
			cbAutoHide.Checked = _config.AutoHide;
			cbAutoRun.CheckedChanged += new EventHandler(cbAutoRun_CheckedChanged);
			cbAutoHide.CheckedChanged += new EventHandler(cbAutoHide_CheckedChanged);

			JcUtility.ClearLogs();
			JcUtility.ClearScreenshots();
		}

		private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			_tScreenshot.Stop();

			JcUtility.UnregisterHotKey(this.Handle, 101);
			JcUtility.UnregisterHotKey(this.Handle, 102);
		}

		private void _tScreenshot_Tick(object sender, EventArgs e)
		{
			try
			{
				JcUtility.Screenshot();
			}
			catch (Exception ex)
			{
				JcUtility.Log("_tScreenshot_Tick Exeption:");
				JcUtility.LogException(ex);
			}
		}

		private void tsbHide_Click(object sender, EventArgs e)
		{
			Hide();
		}

		private void tsbShowScreenshot_Click(object sender, EventArgs e)
		{
			JcUtility.OpenExplorer(JcUtility.GetScreenshotDir());
		}

		private void tsbExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cbAutoRun_CheckedChanged(object sender, EventArgs e)
		{
			JcUtility.SetAutoRun(cbAutoRun.Checked);
			_config.AutoRun = cbAutoRun.Checked;
		}

		private void cbAutoHide_CheckedChanged(object sender, EventArgs e)
		{
			_config.AutoHide = cbAutoHide.Checked;
		}

		private void tsbUninstall_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to uninstall this program？", "Uninstall Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				Process.Start(Path.Combine(JcUtility.GetAppDir(), "uninst.exe"));
				Close();
			}
		}

		private void tsmiViewHelp_Click(object sender, EventArgs e)
		{
			Process.Start(JcConfig.HelpUrl);
		}

		private void tsmiAbout_Click(object sender, EventArgs e)
		{
			Process.Start(JcConfig.AboutUrl);
		}

		private void rtbInfo_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			Process.Start(e.LinkText);
		}
	}
}
