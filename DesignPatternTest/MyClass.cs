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

		[TestCase("key1","hoge")]
		[TestCase("","")]
		public void WhenSetValueThenGetValueReturnsValue(string key,string value){
			var _sut = new FileProperties ();
			_sut.SetValue (key, value);
			Assert.That (_sut.GetValue (key), Is.EqualTo (value));
		}

		[TestCase]
		public void WriteFileAndGetItsValue(){
			var _sut = new FileProperties ();
			_sut.SetValue ("key1", "hoge");
			_sut.WriteToFile ("sample_actual.txt");
			FileAssert.AreEqual ("../../TestData/sample_expected.txt", "sample_actual.txt");
		}

		[TestCase]
		public void ReadFromFileGenerateEmptyDictionaryIfFileNotExists(){
			var _sut = new FileProperties ();
			_sut.ReadFromFile ("dummy.txt");
			Assert.That (_sut.GetValue (""), Is.EqualTo (""));
		}
		[Test]
		public void Tes(){

		}
	}
}

