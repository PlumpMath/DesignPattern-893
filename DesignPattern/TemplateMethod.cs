using System;
using System.Text;

namespace DesignPattern.TemplateMethod
{
	public abstract class AbstracDisplay
	{
		public AbstracDisplay ()
		{
		}
		
		public abstract void Open();
		public abstract void Print();
		public abstract void Close();

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

	public class CharDisplay : AbstracDisplay
	{
		private char ch;

		public CharDisplay(char ch)
		{
			this.ch = ch;
		}

		public override void Open()
		{
			Console.Write ("<<");
		}

		public override void Print()
		{
			Console.Write (this.ch);
		}

		public override void Close()
		{
			Console.WriteLine (">>");
		}
	}

	public class StringDisplay : AbstracDisplay
	{
		private string str;
		private int width;

		public StringDisplay(string str)
		{
			this.str = str;
			this.width = Encoding.GetEncoding ("Shift_JIS").GetBytes (str).Length;
		}
		
		public override void Open()
		{
			PrintLine ();
		}
		public override void Print()
		{
			Console.WriteLine ("|" + this.str + "|");
		}
		public override void Close()
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

