using System;
using System.Collections.Generic;

namespace DesignPattern.AbstractFactory
{
	namespace Factory
	{
		public abstract class Item
		{
			protected string caption;
			public Item (string caption)
			{
				this.caption = caption;
			}

			// return HTML string.
			public abstract string MakeHtml();
		}

		public abstract class Link:Item
		{
			protected string url;
			public Link(string caption, string url)
				: base(caption)
			{
				this.url = url;
			}
		}

		public abstract class Tray : Item
		{
			protected List<Item> tray = new List<Item> ();
			public Tray (string caption)
				:base(caption){}

			public void Add(Item item)
			{
				tray.Add (item);
			}
		}
	}
}

