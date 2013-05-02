using System;
using System.Collections.Generic;
using System.IO;

namespace DesignPattern.Adapter
{
	/// <summary>
	/// Adaptee
	/// </summary>
	public class Banner
	{
		private String str;

		public Banner(String str)
		{
			this.str = str;
		}

		public void ShowWithParen()
		{
			Console.WriteLine("(" + str + ")");
		}

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
		void PrintWeak();
		void PrintStrong();
	}
		
	/// <summary>
	/// Adapter
	/// </summary>
	public class PrintBsnner : IPrint
	{
		private Banner banner;
			
		public PrintBsnner(String str)
		{
			this.banner = new Banner(str);
		}
		public void PrintWeak()
		{
			banner.ShowWithParen();
		}
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
		void ReadFromFile(string fileName);
		void WriteToFile(string fileName);
		void SetValue(string key,string value);
		string GetValue(string key);
	}
		
	public class FileProperties : IFileIO
	{
		private Dictionary<string, string> contents;

		public FileProperties(){
			this.contents = new Dictionary<string, string> ();
		}

		public void ReadFromFile(string fileName)
		{
			if (!File.Exists (fileName))
			{
				Console.WriteLine("file is not exists.");
				return;
			}

			string[] lines = File.ReadAllLines (fileName);

			foreach (var item in lines) {
				int separatorIndex = item.IndexOf('=');
				if(separatorIndex > 0){
					string key = item.Substring(0,separatorIndex);
					string value = item.Substring(separatorIndex+1);
					contents.Add(key,value);
				}
			}
		}

		public void WriteToFile(string fileName)
		{
			var outPutText = new List<string>();

			foreach (var item in contents) {
				outPutText.Add(string.Format ("{0}={1}", item.Key,item.Value));
			}
			File.WriteAllLines (fileName, outPutText.ToArray());
		}

		public void SetValue(string key, string value)
		{
			this.contents.Add(key, value);
		}

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

