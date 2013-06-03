using System;
using NUnit.Framework;
using DesignPattern.Singleton;

namespace DesignPatternTest
{
	[TestFixture]
	public class SingletonTest
	{
		[TestCase]
		public void InitializeSingletonTest ()
		{
			Console.WriteLine ("Start.");
			var obj1 = Singleton.GetInstance ();
			var obj2 = Singleton.GetInstance ();
			Assert.That (obj1, Is.EqualTo (obj2));
			Console.WriteLine ("End.");
		}
		[TestCase]
		public void CallGetInstanceThreeTimes()
		{
			Console.WriteLine ("Start.");
			var obj1 = Singleton.GetInstance ();
			var obj2 = Singleton.GetInstance ();
			var obj3 = Singleton.GetInstance ();
			Assert.That (obj1, Is.EqualTo (obj2));
			Assert.That (obj1, Is.EqualTo (obj3));
			Console.WriteLine ("End.");
		}

		[TestCase]
		public void TicketMakerIsSingleton()
		{
			Console.WriteLine ("Start");
			var obj1 = TicketMaker.GetInstance ();
			var obj2 = TicketMaker.GetInstance ();
			var obj3 = TicketMaker.GetInstance ();
			Assert.That (obj1, Is.EqualTo (obj2));
			Assert.That (obj1, Is.EqualTo (obj3));
			Console.WriteLine ("End.");
		}

		[TestCase]
		public void TicketNumberGenerateSerialNumber()
		{
			var ticketMaker = TicketMaker.GetInstance ();
			Assert.That (ticketMaker.GetNextTicketNumber (), Is.EqualTo (1001));
			Assert.That (ticketMaker.GetNextTicketNumber (), Is.EqualTo (1002));

			var ticketMakerB = TicketMaker.GetInstance ();
			Assert.That (ticketMakerB.GetNextTicketNumber (), Is.EqualTo (1003));
		}
	}
}

