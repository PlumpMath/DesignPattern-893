using System;
using System.Collections.Generic;
using NUnit.Framework;
using DesignPattern.Builder;

namespace DesignPatternTest
{
	[TestFixture]
	public class BuilderTest
	{
		[TestCase]
		public void TextBuilderTest ()
		{
			IBuilder textbuilder = new TextBuilder();
			var director = new Director(textbuilder);
			director.Construct();
			var result = textbuilder.GetResult();
			Console.WriteLine(result);

		}

		[TestCase]
		public void HtmlBuilderTest()
		{
			IBuilder htmlBuilder = new HtmlBuilder();
			var director = new Director(htmlBuilder);
			director.Construct();
			var filename = htmlBuilder.GetResult();
			Console.WriteLine("File Name: {0} have created.", filename);
		}
	}
}

