using System;

namespace DesignPattern
{
	using Adapter;
	using TemplateMethod;

	class DesignPatternMain
	{
		/// <summary>
		/// Client
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			/*** Adapter Pattern ***/
			IPrint printer = new PrintBanner ("Hello");
			printer.PrintWeak ();
			printer.PrintStrong ();

/*
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
*/

			/*** Template Method Pattern ***/
			AbstracDisplay aDisp1 = new CharDisplay ('H');
			AbstracDisplay aDisp2 = new StringDisplay ("Hello, CSharp!");
			AbstracDisplay aDisp3 = new StringDisplay ("Hello, Template Method.");
			aDisp1.Display ();
			aDisp2.Display ();
			aDisp3.Display ();
		}
	}
}
