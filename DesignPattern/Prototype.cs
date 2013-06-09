using System;
using System.Collections.Generic;
using System.Text;
using DesignPattern.Prototype.Framework;

namespace DesignPattern.Prototype
{
	namespace Framework
	{
		public interface IProduct:ICloneable
		{
			void Use (string s);
			IProduct CreateClone ();
		}

		public class Manager
		{
			private Dictionary<string, IProduct> showcase = new Dictionary<string, IProduct>();

			public Manager ()
			{
			}

			public void Register(string name, IProduct proto)
			{
				showcase.Add (name, proto);
			}

			public IProduct Create(string protoName)
			{
				IProduct p = null;
				showcase.TryGetValue(protoName, out p);
				return p.CreateClone ();
			}
		}
	}

	public class UnderLinePen:IProduct
	{
		private char ulcahr;

		public UnderLinePen(char underLineChar)
		{
			this.ulcahr = underLineChar;
		}

		public Object Clone()
		{
			return MemberwiseClone();
		}

		public void Use(string message)
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

		public IProduct CreateClone ()
		{
			IProduct p = null;
			try 
			{
				p = (IProduct)this.Clone ();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return p;
		}
	}

	public class MessageBox : IProduct
	{
		private char decoChar;

		public MessageBox(char decorationChar)
		{
			this.decoChar = decorationChar;
		}

		public Object Clone()
		{
			return this.MemberwiseClone ();
		}

		public void Use(string message)
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

		public IProduct CreateClone()
		{
			IProduct p = null;
			try 
			{
				p = (IProduct)this.Clone();
			} 
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return p;
		}
	}
}

