using System;
using System.Collections.Generic;
using System.Text;
using DesignPattern.Prototype.Framework;

namespace DesignPattern.Prototype
{
	namespace Framework
	{
		public abstract class Product : ICloneable
		{
			public abstract void Use (string s);
			public object Clone()
			{
				return MemberwiseClone ();
			}
			public Product CreateClone ()
			{
				Product p = null;
				try 
				{
					p = (Product)this.Clone ();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				
				return p;
			}
		}

		public class Manager
		{
			private Dictionary<string, Product> showcase = new Dictionary<string, Product>();

			public Manager ()
			{
			}

			public void Register(string name, Product proto)
			{
				showcase.Add (name, proto);
			}

			public Product Create(string protoName)
			{
				Product p = null;
				showcase.TryGetValue(protoName, out p);
				return p.CreateClone ();
			}
		}
	}

	public class UnderLinePen:Product
	{
		private char ulcahr;

		public UnderLinePen(char underLineChar)
		{
			this.ulcahr = underLineChar;
		}

		public override void Use(string message)
		{
			int length = Encoding.GetEncoding ("Shift_JIS").GetByteCount (message);
			Console.WriteLine(@"""" + message + @"""");
			Console.Write (" ");
			for (int i = 0; i < length; i++)
			{
				Console.Write(this.ulcahr);
			}

			Console.WriteLine (" ");
		}
	}

	public class MessageBox : Product
	{
		private char decoChar;

		public MessageBox(char decorationChar)
		{
			this.decoChar = decorationChar;
		}

		public override void Use(string message)
		{
			int length = Encoding.GetEncoding ("Shift_JIS").GetByteCount (message) + 4;

			for (int i = 0; i < length; i++) 
			{
				Console.Write (string.Format ("{0}", decoChar));
			}
			Console.WriteLine ("");

			Console.WriteLine (string.Format("{0} {1} {0}",decoChar,message));

			for (int i = 0; i < length; i++) 
			{
				Console.Write (string.Format ("{0}", decoChar));
			}
			Console.WriteLine ("");
		}
	}
}

