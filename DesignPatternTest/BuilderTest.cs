using System;
using NUnit.Framework;
using DesignPattern.Builder;

namespace DesignPatternTest
{
	[TestFixture]
	public class BuilderTest
	{
		[TestCase(1, "")]
		public void BasicUsageOfSample (int caseNumber, string arg)
		{
			Console.WriteLine ("TestCase {0}", caseNumber);

			if (arg.Length != 1) {
				Usage ();
			}
			if (arg[0].Equals("plain")) {
				var textbuilder = new TextBuilder();
				var director = new Director(textbuilder);
				director.Construct();
				var result = textbuilder.GetResult();
				Console.WriteLine(result);
			}
			else if (arg[0].Equals("html")) {
				var htmlBuilder = new HtmlBuilder();
				var director = new Director(htmlBuilder);
				director.Construct();
				var filename = htmlBuilder.GetResult();
				Console.WriteLine("File Name: {0} have created.", filename);
			}
			else {
				Usage ();
			}
		}

		public static void Usage()
		{
			Console.WriteLine ("Argument: plain\tgenerate as plain text.");
			Console.WriteLine("Argument: html\tgenerate as HTML file.");
		}
	}
}

