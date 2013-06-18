using System;
using System.Collections.Generic;
using System.IO;

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

		public abstract class Page
		{
			protected string title;
			protected string auther;
			protected List<Item> contents = new List<Item>();

			public Page(string title, string auther)
			{
				this.title = title;
				this.auther = auther;
			}

			public void Add(Item item)
			{
				contents.Add (item);
			}

			public void Output()
			{
				var filename = this.title + ".html";
				File.WriteAllText (filename, this.MakeHtml ());
				Console.WriteLine (filename + " was created.");
			}

			public abstract string MakeHtml();
		}

		public abstract class Factory
		{
			public static Factory GetFactory()
			{
				throw new NotImplementedException ();
			}

			public abstract Link CreateLink(string caption, string url);
			public abstract Tray CreateTray(string caption);
			public abstract Page CreatePage(string title, string auther);
		}
	}

	namespace ListFactory
	{

	}
}

