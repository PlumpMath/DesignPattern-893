using System;
using NUnit.Framework;
using DesignPattern.Adapter;

namespace DesignPatternTest.Adapter
{
	[TestFixture]
	public class FilePropertiesTest
	{
		[TestCase("dummy", "")]
		[TestCase("", "")]
		[TestCase("key1", "hoge")]
		public void GetValueReturnsAddedKeyValue(string key, string expected){
			var _sut = new FileProperties ();
			Assert.That (_sut.GetValue(key), Is.EqualTo (expected));
		}

		[TestCase]
		public void ReadFromFileGenerateEmptyDictionaryIfFileNotExists(){
			var _sut = new FileProperties ();
			_sut.ReadFromFile ("dummy.txt");
			Assert.That (_sut.GetValue (""), Is.EqualTo (""));
		}
	}
}

