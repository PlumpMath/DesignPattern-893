using System;
using DesignPattern.FactoryMethod.Framework;
using DesignPattern.FactoryMethod.IdCard;

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
			#region Adapter Pattern
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
			#endregion 

			#region Template Method Pattern
			AbstractDisplay aDisp1 = new CharDisplay ('H');
			AbstractDisplay aDisp2 = new StringDisplay ("Hello, CSharp!");
			AbstractDisplay aDisp3 = new StringDisplay ("Hello, Template Method.");
			aDisp1.Display ();
			aDisp2.Display ();
			aDisp3.Display ();
			#endregion

			#region  Factory Method Pattern ***/
			Factory factory = new IDCardFactory ();
			Product card1 = factory.Create ("Ikawa");
			Product card2 = factory.Create ("Sho");
			Product card3 = factory.Create ("John Doe");

			card1.Use ();
			card2.Use ();
			card3.Use ();
			#endregion
		}
	}
}
