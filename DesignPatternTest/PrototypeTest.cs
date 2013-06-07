using System;
using DesignPattern.Prototype;
using DesignPattern.Prototype.Framework;
using NUnit.Framework;

namespace DesignPatternTest
{
	[TestFixture]
	public class PrototypeTest
	{
		[TestCase]
		public void UsePrototypeWithUnderLinePenTest ()
		{
			Manager manager = new Manager ();
			UnderLinePen upen = new UnderLinePen ('~');
			manager.Register ("strong message", upen);

			IProduct p1 = manager.Create ("strong message");
			p1.Use ("Hello World.");
		}
		[TestCase]
		public void UseMessageBoxTest()
		{
			Manager manager = new Manager ();
			MessageBox mbox = new MessageBox ('*');
			manager.Register ("warning box", mbox);

			IProduct wbox = manager.Create ("warning box");
			wbox.Use ("Hello World");
		}
	}
}

