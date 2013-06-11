using System;
using System.IO;
using System.Text;

namespace DesignPattern.Builder
{
	public abstract class Builder
	{
		public abstract void MakeTitle(string title);
		public abstract void MakeString (string str);
		public abstract void MakeItems (string[] items);
		public abstract void Close ();
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
			throw new NotImplementedException ();
		}
	}

	public class TextBuilder: Builder
	{
		private StringBuilder buffer = new StringBuilder ();

		public override void MakeTitle(string title)
		{
			buffer.Append ("==========================================¥n");
			buffer.Append ("[[" + title + "]]¥n");
			buffer.Append ("¥n");
		}

		public override void MakeString(string str)
		{
			buffer.Append ("-->" + str + "¥n");
			buffer.Append ("¥n");
		}

		public override void MakeItems(string[] items)
		{
			for (int i = 0; i < items.Length; i++) {
				buffer.Append("*" + items[i] + "¥n");
			}
			buffer.Append ("¥n");
		}
		public override void Close()
		{
			buffer.Append("==========================================¥n");
		}
		public string GetResult ()
		{
			return buffer.ToString ();
		}
	}

	public class HtmlBuilder : Builder
	{
		private string filename;
		private StringBuilder buffer = new StringBuilder();

		public override void MakeTitle(string title)
		{
			filename = title + ".html";
			buffer.Append ("<html><head><title>" + title + "</title></head><body>");
			buffer.Append ("<h1>" + title + "</h1>");
		}
		public override void MakeString(string str)
		{
			buffer.Append ("<p>" + str + "</p>");
		}
		public override void MakeItems(string[] items)
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
		}
		public string GetResult ()
		{
			return filename;
		}
	}
}

