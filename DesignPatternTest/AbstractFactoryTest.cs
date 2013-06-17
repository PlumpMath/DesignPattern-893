using System;
using DesignPattern.AbstractFactory;
using NUnit.Framework;

namespace DesignPatternTest
{
	[TestFixture]
	public class AbstractFactoryTest
	{
		[TestCase]
		public void UseListFactoryTest ()
		{
			Factory factory = Factory.GetFactory ("hoge");

		}
	}
}

