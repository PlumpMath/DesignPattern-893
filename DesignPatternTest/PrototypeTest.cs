using System;
using NUnit.Framework;
using DesignPattern.Prototype.Framework;

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
			manager.register ("strong message", upen);

			IProduct p1 = manager.create ("strong message");
			p1.use ("Hello World.");
		}
	}
}

