using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
	using DesignPattern.Adapter;

	class DesignPatternMain
	{
		/// <summary>
		/// Client
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			IPrint printer = new PrintBsnner("Hello");
			printer.PrintWeak();
			printer.PrintStrong();
		}
	}
}

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
}