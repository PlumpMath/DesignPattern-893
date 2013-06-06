using System;
using System.Collections.Generic;
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

		public UnderLinePen(char ulchar)
		{
			this.ulcahr = ulcahr;
		}

		public Object Clone()
		{
			return null;
		}

		public void Use(string message)
		{
		}

		public Framework.IProduct CreateClone ()
		{
			IProduct p = null;
			p = (IProduct)this.MemberwiseClone ();
			return p;
		}
	}
}

