using System;
using DesignPattern.Adapter;
using NUnit.Framework;

namespace DesignPatternTest
{
	[TestFixture]
	public class AdapterTest
	{
		[TestCase]
		public void PrintBannerTest ()
		{
			IPrint printer = new PrintBanner ("Hello");
			printer.PrintWeak ();
			printer.PrintStrong ();
		}
		[TestCase,Ignore]
		public void OriginalFileIOTest()
		{
			IFileIO fileo = new FileProperties ();
			fileo.SetValue ("Year", "2013");
			fileo.SetValue ("Month", "05");
			fileo.SetValue ("Day", "02");
			fileo.WriteToFile ("FileIOExample.txt");

			IFileIO filei = new FileProperties ();
			filei.ReadFromFile("FileIOExample.txt");
			Console.WriteLine (filei.GetValue ("Year"));
			Console.WriteLine (filei.GetValue ("Month"));
			Console.WriteLine (filei.GetValue ("Day"));
		}
	}
}

