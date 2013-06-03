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
	}
}

