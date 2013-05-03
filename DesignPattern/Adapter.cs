using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Banner.
/// </summary>
namespace DesignPattern.Adapter
{
	/// <summary>
	/// Adaptee
	/// </summary>
	public class Banner
	{
		/// <summary>
		/// The string.
		/// </summary>
		private String str;

		/// <summary>
		/// Initializes a new instance of the <see cref="DesignPattern.Adapter.Banner"/> class.
		/// </summary>
		/// <param name="str">String.</param>
		public Banner(String str)
		{
			this.str = str;
		}

		/// <summary>
		/// Shows the with paren.
		/// </summary>
		public void ShowWithParen()
		{
			Console.WriteLine("(" + str + ")");
		}

		/// <summary>
		/// Shows the with aster.
		/// </summary>
		public void ShowWithAster()
		{
			Console.WriteLine("*" + str + "*");
		}
	}
		
	/// <summary>
	/// Target
	/// </summary>
	public interface IPrint
	{
		/// <summary>
		/// Prints the weak.
		/// </summary>
		void PrintWeak();

		/// <summary>
		/// Prints the strong.
		/// </summary>
		void PrintStrong();
	}
		
	/// <summary>
	/// Adapter
	/// </summary>
	public class PrintBanner : IPrint
	{
		/// <summary>
		/// The banner.
		/// </summary>
		private Banner banner;

		/// <summary>
		/// Initializes a new instance of the <see cref="DesignPattern.Adapter.PrintBsnner"/> class.
		/// </summary>
		/// <param name="str">String.</param>
		public PrintBanner(String str)
		{
			this.banner = new Banner(str);
		}

		/// <summary>
		/// Prints the weak.
		/// </summary>
		public void PrintWeak()
		{
			banner.ShowWithParen();
		}

		/// <summary>
		/// Prints the strong.
		/// </summary>
		public void PrintStrong()
		{
			banner.ShowWithAster();
		}
	}

	/// <summary>
	/// Interface of file IO.
	/// </summary>
	public interface IFileIO
	{
		/// <summary>
		/// Reads from file.
		/// </summary>
		/// <param name="fileName">File name.</param>
		void ReadFromFile(string fileName);

		/// <summary>
		/// Writes to file.
		/// </summary>
		/// <param name="fileName">File name.</param>
		void WriteToFile(string fileName);

		/// <summary>
		/// Sets the value.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		void SetValue(string key,string value);

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <returns>The value.</returns>
		/// <param name="key">Key.</param>
		string GetValue(string key);
	}

	/// <summary>
	/// File properties.
	/// </summary>
	public class FileProperties : IFileIO
	{
		/// <summary>
		/// The contents.
		/// </summary>
		private Dictionary<string, string> contents;

		/// <summary>
		/// Initializes a new instance of the <see cref="DesignPattern.Adapter.FileProperties"/> class.
		/// </summary>
		public FileProperties()
		{
			this.contents = new Dictionary<string, string> ();
		}

		/// <summary>
		/// Reads from file.
		/// </summary>
		/// <param name="fileName">File name.</param>
		public void ReadFromFile(string fileName)
		{
			if (!File.Exists (fileName))
			{
				Console.WriteLine("file is not exists.");
				return;
			}

			string[] lines = File.ReadAllLines (fileName);

			foreach (var item in lines) 
			{
				int separatorIndex = item.IndexOf('=');

				if(separatorIndex > 0)
				{
					string key = item.Substring(0,separatorIndex);
					string value = item.Substring(separatorIndex+1);

					contents.Add(key,value);
				}
			}
		}

		/// <summary>
		/// Writes to file.
		/// </summary>
		/// <param name="fileName">File name.</param>
		public void WriteToFile(string fileName)
		{
			var outPutText = new List<string>();

			foreach (var item in contents) 
			{
				outPutText.Add(string.Format ("{0}={1}", item.Key,item.Value));
			}

			File.WriteAllLines (fileName, outPutText.ToArray());
		}

		/// <summary>
		/// Sets the value.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		public void SetValue(string key, string value)
		{
			this.contents.Add(key, value);
		}

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <returns>The value.</returns>
		/// <param name="key">Key.</param>
		public string GetValue(string key)
		{
			var value = string.Empty;
				
			if (contents.TryGetValue (key,out value)) 
			{
				return value;
			} 
			else
			{
				Console.WriteLine("the key does not exist");
				return "";
			}
		}
	}
}

