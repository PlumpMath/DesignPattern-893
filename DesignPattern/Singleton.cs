using System;

namespace DesignPattern.Singleton
{
	public class Singleton
	{
		// below instance create when GetInstance() to be called.
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

