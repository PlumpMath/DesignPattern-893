using System;
using DesignPattern.Prototype;
using DesignPattern.Prototype.Framework;
using NUnit.Framework;

namespace DesignPatternTest
{
	[TestFixture]
	public class PrototypeTest
	{
		[TestCase('~', "strog message")]
		public void UsePrototypeWithUnderLinePenTest (char ulchar, string message)
		{
			Manager manager = new Manager ();
			UnderLinePen upen = new UnderLinePen (ulchar);
			manager.Register (message, upen);

			IProduct p1 = manager.Create (message);
			p1.Use ("Hello World");
		}
		[TestCase('*', "warning box")]
		[TestCase('/', "slash box")]
		public void UseMessageBoxTest(char decoChar, string message)
		{
			Manager manager = new Manager ();
			MessageBox mbox = new MessageBox (decoChar);
			manager.Register (message, mbox);

			IProduct wbox = manager.Create (message);
			wbox.Use ("Hello World");
		}

		// TODO: add test case to assert to use multi prototype.
	}
}

