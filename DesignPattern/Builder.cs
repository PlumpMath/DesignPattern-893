using System;
using System.IO;
using System.Text;

namespace DesignPattern.Builder
{
	public abstract class Builder
	{
		private bool initialized = false;

		protected abstract void BuildTitle(string title);
		protected abstract void BuildString (string str);
		protected abstract void BuildItems (string[] items);
		public abstract void Close ();
		public abstract string GetResult ();

		public void MakeTitle(string title)
		{
			if (!initialized) 
			{
				BuildTitle(title);
				initialized = true;
			}
		}

		public void MakeString(string str)
		{
			if (initialized)
			{
				BuildString(str);
			}
			else 
			{
				Console.WriteLine("You have to call MakeTitle befor calling MakeString.");
			}
		}

		public void MakeItems(string[] items)
		{
			if (initialized) 
			{
				BuildItems(items);
			}
			else
			{
				Console.WriteLine("You have to call MakeTitle befor call MakeItems.");
			}
		}
	}

	public class Director
	{
		private Builder builder;
		public Director (Builder builder)
		{
			this.builder = builder;
		}

		public void Construct ()
		{
			builder.MakeTitle ("Greeting");
			builder.MakeString ("From the Morning to about Launch Time");
			builder.MakeItems (new string[]{
				"Good Morning",
				"Hello"});
			builder.MakeString ("In the Night");
			builder.MakeItems (new string[]{
				"Good Evening",
				"Good Night",
				"See you tomorrow"});
			builder.Close ();
		}
	}

	public class TextBuilder: Builder
	{
		private StringBuilder buffer = new StringBuilder ();

		protected override void BuildTitle(string title)
		{
			buffer.Append ("==========================================/n");
			buffer.Append ("[[" + title + "]]¥n");
			buffer.Append ("¥n");
		}

		protected override void BuildString(string str)
		{
			buffer.Append ("-->" + str + "¥n");
			buffer.Append ("¥n");
		}

		protected override void BuildItems(string[] items)
		{
			for (int i = 0; i < items.Length; i++) {
				buffer.Append("*" + items[i] + "/n");
			}
			buffer.Append ("¥n");
		}
		public override void Close()
		{
			buffer.Append("==========================================¥n");
		}
		public override string GetResult ()
		{
			return buffer.ToString ();
		}
	}

	public class HtmlBuilder : Builder
	{
		private string filename;
		private StringBuilder buffer = new StringBuilder();

		protected override void BuildTitle(string title)
		{
			filename = title + ".html";
			buffer.Append ("<html><head><title>" + title + "</title></head><body>");
			buffer.Append ("<h1>" + title + "</h1>");
		}
		protected override void BuildString(string str)
		{
			buffer.Append ("<p>" + str + "</p>");
		}
		protected override void BuildItems(string[] items)
		{
			buffer.Append ("<ul>");
			for (int i = 0; i < items.Length; i++) {
				buffer.Append ("<li>" + items[i] + "</li>");
			}
			buffer.Append ("</ul>");
		}
		public override void Close()
		{
			buffer.Append ("</body></html>");
			File.WriteAllText (filename, buffer.ToString ());
		}
		public override string GetResult ()
		{
			return filename;
		}
	}

	public class MarkdownBuilder : Builder
	{
		private string filename;
		private StringBuilder buffer = new StringBuilder ();

		protected override void BuildTitle(string title)
		{
			filename = title + ".md";
			buffer.Append ("#" + title);
			buffer.Append ("¥n");
		}
		protected override void BuildString(string str){
			buffer.Append ("¥n" + str + "¥n");
		}
		protected override void BuildItems(string[] items)
		{
			buffer.Append ("¥n");
			foreach (var item in items) {
				buffer.Append("* " + item);
			}

			buffer.Append ("¥n");
		}
		public override void Close()
		{
			File.WriteAllText (filename, buffer.ToString ());
		}
		public override string GetResult()
		{
			return filename;
		}
	}
}

