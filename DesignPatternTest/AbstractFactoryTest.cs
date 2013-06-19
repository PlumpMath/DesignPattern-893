using System;
using DesignPattern.AbstractFactory.AbstractFactory;
using NUnit.Framework;

namespace DesignPatternTest
{
	[TestFixture]
	public class AbstractFactoryTest
	{
		[TestCase]
		public void UseListFactoryTest ()
		{
			Factory factory = Factory.GetFactory ("hoge");
			Link asahi = factory.CreateLink("AsahiShinbun", "http://www.asahi.com/");
			Link yomiuri = factory.CreateLink ("Yomiuri", ",http://www.yomiuri.co.jp/");
			Link us_Yahoo = factory.CreateLink("Yahoo!","http://www.yahoo.com/");
			Link jp_Yahoo = factory.CreateLink ("Yahoo!Japan", "http://www yahoo・co.jp/");
			Link excite = factory.CreateLink("Excite", "http://www.excite.com/");
			Link google = factory.CreateLink ("Google", "http://www.google.com/");

			Tray newsTray = factory.CreateTray ("NewsPaper");
			newsTray.Add (asahi);
			newsTray.Add (yomiuri);

			Tray yahooTray = factory.CreateTray ("Yahoo!");
			yahooTray.Add (us_Yahoo);
			yahooTray.Add (jp_Yahoo);

			Tray searchTray = factory.CreateTray ("Search Engine");
			searchTray.Add (yahooTray);
			searchTray.Add (excite);
			searchTray.Add (google);

			Page page = factory.CreatePage ("Link Page", "HiDARi");
			page.Add (newsTray);
			page.Add (searchTray);
			page.Output ();
		}

		[TestCase]
		public void DoubleQtTest()
		{

			Console.WriteLine(@"Is This ""Double Quotation"" ?");
		}
	}
}
