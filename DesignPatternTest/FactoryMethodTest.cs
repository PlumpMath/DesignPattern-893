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

		[TestCase]
		public void CreateTwoCardAndGetSerialNumberTest()
		{
			var factory = new IDCardFactory ();
			var idCard1 = factory.Create ("John Doe");
			var idCard2 = factory.Create ("iKW HiDARi");
			var idCard3 = factory.Create ("HogeHoge");

			var ownerList = factory.GetOwners ();
			foreach (var item in ownerList)
			{
				Console.WriteLine("No.{0}: {1}",item.Key,item.Value);
			}

			idCard1.Use ();
			idCard2.Use ();
			idCard3.Use ();
		}
	}
}

