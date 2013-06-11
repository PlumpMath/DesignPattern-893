using System;

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
		public override void MakeTitle(string title)
		{
		}
		public override void MakeString(string str)
		{
		}
		public override void MakeItems(string[] items)
		{
		}
		public override void Close()
		{
		}
		public string GetResult ()
		{
			throw new NotImplementedException ();
		}
	}

	public class HtmlBuilder : Builder
	{
		public override void MakeTitle(string title)
		{
		}
		public override void MakeString(string str)
		{
		}
		public override void MakeItems(string[] items)
		{
		}
		public override void Close()
		{
		}
		public string GetResult ()
		{
			throw new NotImplementedException ();
		}
	}
}

