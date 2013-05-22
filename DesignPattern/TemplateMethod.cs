using System;
using System.Text;

namespace DesignPattern.TemplateMethod
{
	public abstract class AbstractDisplay
	{
		public AbstractDisplay ()
		{
		}
		
		protected abstract void Open();
		protected abstract void Print();
		protected abstract void Close();

		public void Display()
		{
			Open ();
			for (int i = 0; i < 5; i++) 
			{
				Print();
			}

			Close ();
		}
	}

	public class CharDisplay : AbstractDisplay
	{
		private char ch;

		public CharDisplay(char ch)
		{
			this.ch = ch;
		}

		protected override void Open()
		{
			Console.Write ("<<");
		}

		protected override void Print()
		{
			Console.Write (this.ch);
		}

		protected override void Close()
		{
			Console.WriteLine (">>");
		}
	}

	public class StringDisplay : AbstractDisplay
	{
		private string str;
		private int width;

		public StringDisplay(string str)
		{
			this.str = str;
			this.width = Encoding.GetEncoding ("Shift_JIS").GetBytes (str).Length;
		}
		
		protected override void Open()
		{
			PrintLine ();
		}
		protected override void Print()
		{
			Console.WriteLine ("|" + this.str + "|");
		}
		protected override void Close()
		{
			PrintLine ();
		}

		private void PrintLine()
		{
			Console.Write ("+");
			for (int i = 0; i < this.width; i++) {
				Console.Write("-");
			}
			Console.WriteLine ("+");
		}
	}
}

