using System;

namespace DesignPattern.Singleton
{
	public class Singleton
	{
		// In C#, When create instance ?

		private static Singleton singleton = new Singleton ();

		public Singleton ()
		{
			Console.WriteLine ("¥n****** Singleton Initialized *****¥n");
		}

		public static Singleton GetInstance ()
		{
			return singleton;
		}
	}
}

