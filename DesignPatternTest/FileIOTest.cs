using System;
using System.IO;
using NUnit.Framework;
using DesignPattern.Adapter;

namespace DesignPatternTest
{
	[TestFixture, Ignore]
	public class FilePropertiesTest
	{
		[SetUp]
		public void Init()
		{
		}

		[TearDown]
		public void Destruct()
		{
			string[] files = Directory.GetFiles ("./", "*.txt");
			if (files.Length > 0) 
			{
				foreach (var item in files) 
				{
					File.Delete(item);
				}
			}
		}

		[TestCase("dummy", "")]
		[TestCase("", "")]
		public void GetValueReturnsAddedKeyValue(string key, string expected)
		{
			var _sut = new FileProperties ();
			Assert.That (_sut.GetValue(key), Is.EqualTo (expected));
		}

		[TestCase("key1","hoge")]
		[TestCase("","")]
		public void WhenSetValueThenGetValueReturnsValue(string key,string value)
		{
			var _sut = new FileProperties ();
			_sut.SetValue (key, value);
			Assert.That (_sut.GetValue (key), Is.EqualTo (value));
		}

		[TestCase]
		public void WriteFileAndGetItsValue()
		{
			var _sut = new FileProperties ();
			_sut.SetValue ("key1", "hoge");
			_sut.WriteToFile ("sample_actual.txt");
			FileAssert.AreEqual ("../../TestData/sample_expected.txt", "sample_actual.txt");
		}

		[TestCase("dummy.txt","","")]
		[TestCase("../../TestData/sample_expected.txt","key1","hoge")]
		public void ReadFromFileTests(string fileName, string key, string expected)
		{
			var _sut = new FileProperties ();
			_sut.ReadFromFile (fileName);
			Assert.That (_sut.GetValue (key), Is.EqualTo (expected));
		}

		[TestCase]
		public void SetValueCanDealMultiValue()
		{
			var _sut = new FileProperties ();
			_sut.SetValue ("key0", "value0");
			_sut.SetValue ("key1", "value1");
			_sut.WriteToFile ("actual_multi_value.txt");

			FileAssert.AreEqual("../../TestData/expected_multi_value.txt", "actual_multi_value.txt");
		}
	}
}

