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

		[TestCase]
		public void TripleIsSingleton()
		{
			var obj1 = Triple.GetInstance (InstanceID.ONE);
			var obj2 = Triple.GetInstance (InstanceID.TWO);
			var obj3 = Triple.GetInstance (InstanceID.THREE);
			var obj1b = Triple.GetInstance (InstanceID.ONE);
			var obj2b = Triple.GetInstance (InstanceID.TWO);
			var obj3b = Triple.GetInstance (InstanceID.THREE);

			Assert.That(obj1,Is.EqualTo(obj1b));
			Assert.That(obj2,Is.EqualTo(obj2b));
			Assert.That(obj3,Is.EqualTo(obj3b));
		}

		[TestCase]
		public void CountTripleCalled()
		{
			var obj1 = Triple.GetInstance (InstanceID.ONE);
			var obj3 = Triple.GetInstance (InstanceID.THREE);
			obj1.Call ();
			obj1.Call ();
			obj3.Call ();

			Assert.That (obj1.CallCount, Is.EqualTo (2));
			Assert.That (obj3.CallCount, Is.EqualTo (1));
		}

		[TestCase]
		public void GetInstanceOverRun()
		{
			// To prevent exception, you need value object??
			var ex = Assert.Throws<ArgumentOutOfRangeException> (
				() =>Triple.GetInstance ((InstanceID)4));
		}
	}
}

