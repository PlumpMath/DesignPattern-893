using System;

namespace DesignPattern.Singleton
{
	public class Singleton
	{
		// In C#, When create instance ?

		private static Singleton singleton = new Singleton ();

		private Singleton ()
		{
			Console.WriteLine ("****** Singleton Initialized ******");
		}

		public static Singleton GetInstance ()
		{
			return singleton;
		}
	}
}

