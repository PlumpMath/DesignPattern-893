using System;
using NUnit.Framework;
using DesignPattern.TemplateMethod;

namespace DesignPatternTest
{
	[TestFixture]
	public class TemplateMethodTest
	{
		[TestCase]
		public void InitializeWithCharacterThenDisplay ()
		{
			AbstractDisplay aDisp = new CharDisplay ('H');
			aDisp.Display ();
		}

		[TestCase]
		public void InitializeWithStringThenDisplay()
		{
			AbstractDisplay disp = new StringDisplay ("Hello World");
			disp.Display ();
		}

		[TestCase]
		public void CreateThreeInstanceThenDesplay()
		{
			AbstractDisplay aDisp1 = new CharDisplay ('H');
			AbstractDisplay aDisp2 = new StringDisplay ("Hello, CSharp!");
			AbstractDisplay aDisp3 = new StringDisplay ("Hello, Template Method.");
			aDisp1.Display ();
			aDisp2.Display ();
			aDisp3.Display ();
		}
	}
}

