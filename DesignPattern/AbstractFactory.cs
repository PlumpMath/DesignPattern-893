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
			public static Factory GetFactory(string className)
			{
				Factory factory = null;
				try
				{
					Type type = Type.GetType (className);
					factory = (Factory)Activator.CreateInstance(type);
				}
				catch(Exception e)
				{
					Console.WriteLine(e.Message);
				}

				return factory;
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
			public ListFactory()
			{
			}

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
				return @"<li><a href="" " + url + @""" >" + caption + "</a></li>";
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
				buffer.Append ("<li>");
				buffer.Append (caption);
				buffer.Append ("<ul>");
				foreach (var item in tray) 
				{
					buffer.Append(item.MakeHtml());
				}

				buffer.Append ("</ul></li>");
				return buffer.ToString();
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
				var buffer = new StringBuilder ();
				buffer.Append ("<html><head><title>" + title + "</title></head>");
				buffer.Append ("<body>");
				buffer.Append ("<h1>" + title + "</h1>");
				buffer.Append ("<ul>");
				foreach (var item in contents) 
				{
					buffer.Append(item.MakeHtml());
				}

				buffer.Append ("</ul>");
				buffer.Append ("<hr><address>" + auther + "</address>");
				buffer.Append ("</body></html>");

				return buffer.ToString ();
			}
		}

		public class TableFactory : Factory
		{
			public TableFactory()
			{
			}

			public override Link CreateLink(string caption, string url)
			{
				return new TableLink (caption, url);
			}

			public override Tray CreateTray(string caption)
			{
				return new TableTray (caption);
			}

			public override Page CreatePage (string title, string auther)
			{
				return new TableLink (title, auther);
			}
		}

		public class TableLink : Link
		{ 
			TableLink(string caption, string url)
				:base(caption, url)
			{
			}
		}

		public class TableTray :Tray
		{
			
		}
	}
}

