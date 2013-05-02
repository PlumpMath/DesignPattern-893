using System;
using System.Collections.Generic;
using System.IO;

namespace DesignPattern
{
	using DesignPattern.Adapter;

	class DesignPatternMain
	{
		/// <summary>
		/// Client
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			IPrint printer = new PrintBsnner ("Hello");
			printer.PrintWeak ();
			printer.PrintStrong ();
		}
	}
}
