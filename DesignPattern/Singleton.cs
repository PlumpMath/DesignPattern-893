using System;
using System.Collections.Generic;

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

	public enum InstanceID
	{
		ONE,
		TWO,
		THREE
	}

	public class Triple
	{
		private static List<Triple> instances = new List<Triple>{
			new Triple(){CallCount=0,Id=1},
			new Triple(){CallCount=0,Id=2},
			new Triple(){CallCount=0,Id=3}
		};

		public int CallCount{ get; private set; }
		public int Id{ get; private set; }

		private Triple()
		{
			Console.WriteLine ("Start Triple");
		}

		public static Triple GetInstance(InstanceID id)
		{
			return instances[(int)id];
		}

		public void Call(){
			this.CallCount++;
		}
	}
}

