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
	}
}

