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
		public void GetValueReturnsAddedKeyValue(string key, string expected){
			var _sut = new FileProperties ();
			Assert.That (_sut.GetValue(key), Is.EqualTo (expected));
		}

		[TestCase]
		public void WhenSetValueThenGetValueReturnsValue(){
			var _sut = new FileProperties ();
			_sut.SetValue ("key1", "hoge");
			Assert.That (_sut.GetValue ("key1"), Is.EqualTo ("hoge"));
		}

		[TestCase,Ignore]
		public void ReadFromFileGenerateEmptyDictionaryIfFileNotExists(){
			var _sut = new FileProperties ();
			_sut.ReadFromFile ("dummy.txt");
			Assert.That (_sut.GetValue (""), Is.EqualTo (""));
		}
	}
}

