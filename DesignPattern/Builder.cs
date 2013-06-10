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
	}
}

