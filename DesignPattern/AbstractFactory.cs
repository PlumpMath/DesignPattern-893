using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DesignPattern.AbstractFactory.AbstractFactory;

namespace DesignPattern.AbstractFactory
{
	namespace AbstractFactory
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
			public static Factory GetFactory(string classname)
			{
				throw new NotImplementedException ();
			}

			public abstract Link CreateLink(string caption, string url);
			public abstract Tray CreateTray(string caption);
			public abstract Page CreatePage(string title, string auther);
		}
	}

	namespace ConcreteFactory
	{
		public class ListFactory : Factory
		{
			public override Link CreateLink(string caption, string url)
			{
				return new ListLink (caption, url);
			}

			public override Tray CreateTray(string caption)
			{
				return new ListTray (caption);
			}

			public override Page CreatePage(string title, string auther)
			{
				return new ListPage (title, auther);
			}
		}

		public class ListLink : Link
		{
			public ListLink (string caption, string url)
				:base(caption, url)
			{
			}

			public override string MakeHtml ()
			{
				return @"<li><a href="""" + url + @"""">" + caption + "</a></li>";
			}
		}

		public class ListTray : Tray
		{
			public ListTray(string caption)
				:base(caption)
			{
			}

			public override string MakeHtml ()
			{
				var buffer = new StringBuilder ();
				buffer.Append ("");
				return null;
			}
		}

		public class ListPage : Page
		{
			public ListPage(string title, string auther)
				:base(title, auther)
			{
			}

			public override string MakeHtml ()
			{
				throw new NotImplementedException ();
			}
		}
	}
}

