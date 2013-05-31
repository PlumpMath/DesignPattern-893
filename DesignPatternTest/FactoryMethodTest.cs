using System;
using NUnit.Framework;
using DesignPattern.FactoryMethod.Framework;
using DesignPattern.FactoryMethod.IdCard;

namespace DesignPatternTest
{
	[TestFixture]
	public class FactoryMethodTest
	{
		[TestCase("John Doe")]
		[TestCase("HiDARi")]
		public void CreateIDCardThenUse (string name)
		{
			var factory = new IDCardFactory ();
			var id = factory.Create (name);
			id.Use ();
		}
	}
}

