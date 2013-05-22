using System;
using System.Text;

/// <summary>
/// Abstract display.
/// </summary>
namespace DesignPattern.TemplateMethod
{
	/// <summary>
	/// Abstract display.
	/// </summary>
	public abstract class AbstractDisplay
	{
		/// <summary>
		/// Open this instance.
		/// </summary>
		protected abstract void Open();
		/// <summary>
		/// Print this instance.
		/// </summary>
		protected abstract void Print();
		/// <summary>
		/// Close this instance.
		/// </summary>
		protected abstract void Close();

		/// <summary>
		/// Display this instance.
		/// </summary>
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

	/// <summary>
	/// Char display.
	/// </summary>
	public class CharDisplay : AbstractDisplay
	{
		/// <summary>
		/// The ch.
		/// </summary>
		private char ch;

		/// <summary>
		/// Initializes a new instance of the <see cref="DesignPattern.TemplateMethod.CharDisplay"/> class.
		/// </summary>
		/// <param name="ch">Ch.</param>
		public CharDisplay(char ch)
		{
			this.ch = ch;
		}

		/// <summary>
		/// Open this instance.
		/// </summary>
		protected override void Open()
		{
			Console.Write ("<<");
		}

		/// <summary>
		/// Print this instance.
		/// </summary>
		protected override void Print()
		{
			Console.Write (this.ch);
		}

		/// <summary>
		/// Close this instance.
		/// </summary>
		protected override void Close()
		{
			Console.WriteLine (">>");
		}
	}

	/// <summary>
	/// String display.
	/// </summary>
	public class StringDisplay : AbstractDisplay
	{
		/// <summary>
		/// The string.
		/// </summary>
		private string str;
		/// <summary>
		/// The width.
		/// </summary>
		private int width;

		/// <summary>
		/// Initializes a new instance of the <see cref="DesignPattern.TemplateMethod.StringDisplay"/> class.
		/// </summary>
		/// <param name="str">String.</param>
		public StringDisplay(string str)
		{
			this.str = str;
			this.width = Encoding.GetEncoding ("Shift_JIS").GetBytes (str).Length;
		}

		/// <summary>
		/// Open this instance.
		/// </summary>
		protected override void Open()
		{
			PrintLine ();
		}

		/// <summary>
		/// Print this instance.
		/// </summary>
		protected override void Print()
		{
			Console.WriteLine ("|" + this.str + "|");
		}

		/// <summary>
		/// Close this instance.
		/// </summary>
		protected override void Close()
		{
			PrintLine ();
		}

		/// <summary>
		/// Prints the line.
		/// </summary>
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

