using System;
using System.IO;
using System.Text;

namespace DesignPattern.Builder
{
	public interface IBuilder
	{
		private bool initialized = false;

		protected abstract void BuildTitle(string title);
		public abstract void MakeString (string str);
		public abstract void MakeItems (string[] items);
		public abstract void Close ();

		public void MakeTitle(string title)
		{
			if (!initialized) 
			{
				BuildTitle(title);
				initialized = true;
			}
		}
	}

	public class Director
	{
		private IBuilder builder;
		public Director (IBuilder builder)
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

	public class TextBuilder: IBuilder
	{
		private StringBuilder buffer = new StringBuilder ();

		protected override void BuildTitle(string title)
		{
			buffer.Append ("==========================================/n");
			buffer.Append ("[[" + title + "]]¥n");
			buffer.Append ("¥n");
		}

		public void MakeString(string str)
		{
			buffer.Append ("-->" + str + "¥n");
			buffer.Append ("¥n");
		}

		public void MakeItems(string[] items)
		{
			for (int i = 0; i < items.Length; i++) {
				buffer.Append("*" + items[i] + "¥n");
			}
			buffer.Append ("¥n");
		}
		public void Close()
		{
			buffer.Append("==========================================¥n");
		}
		public string GetResult ()
		{
			return buffer.ToString ();
		}
	}

	public class HtmlBuilder : IBuilder
	{
		private string filename;
		private StringBuilder buffer = new StringBuilder();

		protected override void BuildTitle(string title)
		{
			filename = title + ".html";
			buffer.Append ("<html><head><title>" + title + "</title></head><body>");
			buffer.Append ("<h1>" + title + "</h1>");
		}
		public void MakeString(string str)
		{
			buffer.Append ("<p>" + str + "</p>");
		}
		public void MakeItems(string[] items)
		{
			buffer.Append ("<ul>");
			for (int i = 0; i < items.Length; i++) {
				buffer.Append ("<li>" + items[i] + "</li>");
			}
			buffer.Append ("</ul>");
		}
		public void Close()
		{
			buffer.Append ("</body></html>");
			File.WriteAllText (filename, buffer.ToString ());
		}
		public string GetResult ()
		{
			return filename;
		}
	}
}

