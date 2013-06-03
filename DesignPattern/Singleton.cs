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

	public class TicketMaker
	{
		private static TicketMaker singleton = new TicketMaker ();
		private int ticket = 1000;

		private TicketMaker()
		{
			Console.WriteLine ("TicketMaker Instance Generated.");
		}

		public int GetNextTicketNumber()
		{
			ticket++;
			return ticket;
		}

		public static TicketMaker GetInstance ()
		{
			 return singleton;
		}
	}
}

