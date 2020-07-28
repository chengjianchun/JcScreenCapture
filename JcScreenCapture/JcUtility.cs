using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace JcScreenCapture
{
	public class JcUtility
	{
		public const int ERROR_ALREADY_EXISTS = 0183;

		[StructLayout(LayoutKind.Sequential)]
		public class SECURITY_ATTRIBUTES
		{
			public int nLength;
			public int lpSecurityDescriptor;
			public int bInheritHandle;
		}

		[Flags()]
		public enum KeyModifiers
		{
			None = 0,
			Alt = 1,
			Ctrl = 2,
			Shift = 4,
			WindowsKey = 8
		}

		[DllImport("kernel32")]
		public static extern IntPtr CreateMutex(SECURITY_ATTRIBUTES lpMutexAttributes, bool bInitialOwner, string lpName);

		[DllImport("kernel32")]
		public static extern uint GetLastError();

		[DllImport("user32.dll")]
		public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

		[DllImport("user32.dll")]
		public static extern bool UnregisterHotKey(IntPtr hWnd, int id);


		public static string GetAppDir()
		{
			return Path.GetDirectoryName(Application.ExecutablePath);
		}

		public static string GetAppDataDir()
		{
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), JcConfig.Product);
			Directory.CreateDirectory(path);
			return path;
		}

		public static string GetAppDataDir(string dir)
		{
			string path = Path.Combine(GetAppDataDir(), dir);
			Directory.CreateDirectory(path);
			return path;
		}

		public static string GetLogDir()
		{
			return GetAppDataDir("log");
		}

		public static string GetScreenshotDir()
		{
			return GetAppDataDir("screenshot");
		}


		public static void Log(string content)
		{
			string path = Path.Combine(GetLogDir(), string.Format("{0}.txt", DateTime.Now.ToString("yyyy-MM-dd")));
			File.AppendAllText(path, string.Format("{0} {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), content) + Environment.NewLine);
		}

		public static void LogException(Exception ex)
		{
			Log(string.Format("{0}: {1}", ex.GetType().Name, ex.Message));
			Log(string.Format("StackTrace:{0}{1}", Environment.NewLine, ex.StackTrace));
			Log(string.Format("TargetSite:{0}{1}", Environment.NewLine, ex.TargetSite));
		}

		public static void Screenshot()
		{
			using (Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
			{
				using (Graphics g = Graphics.FromImage(bmp))
				{
					g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);

					string dir = Path.Combine(GetScreenshotDir(), DateTime.Now.ToString("yyyyMMdd"));
					Directory.CreateDirectory(dir);
					string path = Path.Combine(dir, string.Format("{0}.jpg", DateTime.Now.ToString("yyyyMMdd-HHmmss")));

					ImageCodecInfo encoder = GetEncoder(ImageFormat.Jpeg);
					EncoderParameters encoderParams = new EncoderParameters(1);
					encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 20L);
					bmp.Save(path, encoder, encoderParams);
				}
			}
		}

		private static ImageCodecInfo GetEncoder(ImageFormat format)
		{
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
			foreach (ImageCodecInfo codec in codecs)
			{
				if (codec.FormatID == format.Guid)
				{
					return codec;
				}
			}
			return null;
		}

		public static void OpenExplorer(string dir)
		{
			Process.Start(dir);
		}

		public static void SetAutoRun(bool enable)
		{
			string dest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "JcScreenCapture.lnk");
			if (enable)
			{
				string src = Path.Combine(GetAppDir(), "JcScreenCapture.lnk");
				File.Copy(src, dest, true);
			}
			else
			{
				File.Delete(dest);
			}
		}

		public static void ClearFiles(string dir, int beforeDays)
		{
			DateTime dt = DateTime.Today.AddDays(1 - beforeDays);
			foreach (FileInfo fi in new DirectoryInfo(dir).GetFiles())
			{
				if (fi.CreationTime < dt)
				{
					fi.Delete();
				}
			}
		}

		public static void ClearDirs(string dir, int beforeDays)
		{
			DateTime dt = DateTime.Today.AddDays(1 - beforeDays);
			foreach (DirectoryInfo di in new DirectoryInfo(dir).GetDirectories())
			{
				if (di.CreationTime < dt)
				{
					di.Delete(true);
				}
			}
		}

		public static void ClearLogs()
		{
			ClearFiles(GetLogDir(), 10);
		}

		public static void ClearScreenshots()
		{
			ClearDirs(GetScreenshotDir(), 10);
		}
	}
}
