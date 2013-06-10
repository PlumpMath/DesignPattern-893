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

			Product p1 = manager.Create (message);
			p1.Use ("Hello World");
		}
		[TestCase('*', "warning box")]
		[TestCase('/', "slash box")]
		public void UseMessageBoxTest(char decoChar, string message)
		{
			Manager manager = new Manager ();
			MessageBox mbox = new MessageBox (decoChar);
			manager.Register (message, mbox);

			Product wbox = manager.Create (message);
			wbox.Use ("Hello World");
		}

		[TestCase]
		public void UseBothPrototype()
		{
			Manager manager = new Manager ();

			UnderLinePen upen = new UnderLinePen ('-');
			MessageBox mbox = new MessageBox ('*');
			MessageBox sbox = new MessageBox ('/');
			UnderLinePen hpen = new UnderLinePen ('~');

			manager.Register ("strong message", upen);
			manager.Register ("warning box", mbox);
			manager.Register ("slash box", sbox);
			manager.Register ("strong message2", hpen);

			Product p1 = manager.Create ("warning box");
			Product p2 = manager.Create ("strong message2");
			Product p3 = manager.Create ("slash box");
			Product p4 = manager.Create ("strong message");

			p1.Use ("Hello Warld");
			p2.Use ("Hello Warld");
			p3.Use ("Hello Warld");
			p4.Use ("Hello Warld");
		}
	}
}

