using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.Xml;
using System.IO;

namespace JcScreenCapture
{
	public partial class JcConfig : Component
	{
		public const string Product = "JcScreenCapture";
		public const string HelpUrl = "https://github.com/chengjianchun/JcScreenCapture";
		public const string AboutUrl = "https://github.com/chengjianchun/JcScreenCapture";

		public static JcConfig Instance;

		private string _configPath;
		private XmlDocument _doc;

		public JcConfig()
		{
			InitializeComponent();

			Instance = this;
		}

		public JcConfig(IContainer container)
		{
			container.Add(this);

			InitializeComponent();

			Instance = this;
		}

		[Browsable(false)]
		public string ConfigPath
		{
			get
			{
				if (_configPath == null)
				{
					_configPath = Path.Combine(JcUtility.GetAppDataDir(), "config.xml");
				}
				return _configPath;
			}
		}

		[Browsable(false)]
		public XmlDocument Doc
		{
			get
			{
				if (_doc == null)
				{
					_doc = new XmlDocument();
					if (File.Exists(ConfigPath))
					{
						_doc.Load(ConfigPath);
					}
					else
					{
						_doc.AppendChild(_doc.CreateXmlDeclaration("1.0", "UTF-8", null));
						_doc.AppendChild(_doc.CreateElement("configs"));
					}
				}
				return _doc;
			}
		}

		[Browsable(false)]
		public string Version
		{
			get { return new AssemblyName(Assembly.GetEntryAssembly().FullName).Version.ToString(3); }
		}

		public bool ReadBool(string key, bool defaultValue)
		{
			XmlElement ele = Doc.DocumentElement.SelectSingleNode(string.Format("config[@key=\"{0}\"]", key)) as XmlElement;
			if (ele != null)
			{
				string str = ele.GetAttribute("value");
				if (!string.IsNullOrEmpty(str))
				{
					bool b;
					if (bool.TryParse(str, out b)) return b;
				}
			}
			return defaultValue;
		}

		public int ReadInt(string key, int defaultValue)
		{
			XmlElement ele = Doc.DocumentElement.SelectSingleNode(string.Format("config[@key=\"{0}\"]", key)) as XmlElement;
			if (ele != null)
			{
				string str = ele.GetAttribute("value");
				if (!string.IsNullOrEmpty(str))
				{
					int i;
					if (int.TryParse(str, out i)) return i;
				}
			}
			return defaultValue;
		}

		public long ReadLong(string key, long defaultValue)
		{
			XmlElement ele = Doc.DocumentElement.SelectSingleNode(string.Format("config[@key=\"{0}\"]", key)) as XmlElement;
			if (ele != null)
			{
				string str = ele.GetAttribute("value");
				if (!string.IsNullOrEmpty(str))
				{
					long i;
					if (long.TryParse(str, out i)) return i;
				}
			}
			return defaultValue;
		}

		public double ReadDouble(string key, double defaultValue)
		{
			XmlElement ele = Doc.DocumentElement.SelectSingleNode(string.Format("config[@key=\"{0}\"]", key)) as XmlElement;
			if (ele != null)
			{
				string str = ele.GetAttribute("value");
				if (!string.IsNullOrEmpty(str))
				{
					double d;
					if (double.TryParse(str, out d)) return d;
				}
			}
			return defaultValue;
		}

		public DateTime ReadDateTime(string key, DateTime defaultValue)
		{
			XmlElement ele = Doc.DocumentElement.SelectSingleNode(string.Format("config[@key=\"{0}\"]", key)) as XmlElement;
			if (ele != null)
			{
				string str = ele.GetAttribute("value");
				if (!string.IsNullOrEmpty(str))
				{
					DateTime dt;
					if (DateTime.TryParse(str, out dt)) return dt;
				}
			}
			return defaultValue;
		}

		public T ReadEnum<T>(string key, T defaultValue)
		{
			XmlElement ele = Doc.DocumentElement.SelectSingleNode(string.Format("config[@key=\"{0}\"]", key)) as XmlElement;
			if (ele != null)
			{
				string str = ele.GetAttribute("value");
				if (!string.IsNullOrEmpty(str))
				{
					try
					{
						return (T)Enum.Parse(typeof(T), str);
					}
					catch
					{
					}
				}
			}
			return defaultValue;
		}

		public string ReadString(string key, string defaultValue)
		{
			XmlElement ele = Doc.DocumentElement.SelectSingleNode(string.Format("config[@key=\"{0}\"]", key)) as XmlElement;
			if (ele != null)
			{
				string str = ele.GetAttribute("value");
				if (!string.IsNullOrEmpty(str))
				{
					return str;
				}
			}
			return defaultValue;
		}

		public void WriteBool(string key, bool value)
		{
			XmlElement ele = Doc.DocumentElement.SelectSingleNode(string.Format("config[@key=\"{0}\"]", key)) as XmlElement;
			if (ele == null)
			{
				ele = Doc.CreateElement("config");
				Doc.DocumentElement.AppendChild(ele);
				ele.SetAttribute("key", key);
			}
			ele.SetAttribute("value", value.ToString());
			Doc.Save(ConfigPath);
		}

		public void WriteInt(string key, int value)
		{
			XmlElement ele = Doc.DocumentElement.SelectSingleNode(string.Format("config[@key=\"{0}\"]", key)) as XmlElement;
			if (ele == null)
			{
				ele = Doc.CreateElement("config");
				Doc.DocumentElement.AppendChild(ele);
				ele.SetAttribute("key", key);
			}
			ele.SetAttribute("value", value.ToString());
			Doc.Save(ConfigPath);
		}

		public void WriteLong(string key, long value)
		{
			XmlElement ele = Doc.DocumentElement.SelectSingleNode(string.Format("config[@key=\"{0}\"]", key)) as XmlElement;
			if (ele == null)
			{
				ele = Doc.CreateElement("config");
				Doc.DocumentElement.AppendChild(ele);
				ele.SetAttribute("key", key);
			}
			ele.SetAttribute("value", value.ToString());
			Doc.Save(ConfigPath);
		}

		public void WriteDouble(string key, double value)
		{
			XmlElement ele = Doc.DocumentElement.SelectSingleNode(string.Format("config[@key=\"{0}\"]", key)) as XmlElement;
			if (ele == null)
			{
				ele = Doc.CreateElement("config");
				Doc.DocumentElement.AppendChild(ele);
				ele.SetAttribute("key", key);
			}
			ele.SetAttribute("value", value.ToString());
			Doc.Save(ConfigPath);
		}

		public void WriteDateTime(string key, DateTime value)
		{
			XmlElement ele = Doc.DocumentElement.SelectSingleNode(string.Format("config[@key=\"{0}\"]", key)) as XmlElement;
			if (ele == null)
			{
				ele = Doc.CreateElement("config");
				Doc.DocumentElement.AppendChild(ele);
				ele.SetAttribute("key", key);
			}
			ele.SetAttribute("value", value.ToString());
			Doc.Save(ConfigPath);
		}

		public void WriteEnum<T>(string key, T value)
		{
			XmlElement ele = Doc.DocumentElement.SelectSingleNode(string.Format("config[@key=\"{0}\"]", key)) as XmlElement;
			if (ele == null)
			{
				ele = Doc.CreateElement("config");
				Doc.DocumentElement.AppendChild(ele);
				ele.SetAttribute("key", key);
			}
			ele.SetAttribute("value", value.ToString());
			Doc.Save(ConfigPath);
		}

		public void WriteString(string key, string value)
		{
			XmlElement ele = Doc.DocumentElement.SelectSingleNode(string.Format("config[@key=\"{0}\"]", key)) as XmlElement;
			if (ele == null)
			{
				ele = Doc.CreateElement("config");
				Doc.DocumentElement.AppendChild(ele);
				ele.SetAttribute("key", key);
			}
			ele.SetAttribute("value", value);
			Doc.Save(ConfigPath);
		}


		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool AutoRun
		{
			get { return ReadBool("AutoRun", false); }
			set { WriteBool("AutoRun", value); }
		}

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool AutoHide
		{
			get { return ReadBool("AutoHide", false); }
			set { WriteBool("AutoHide", value); }
		}
	}
}
