using System;
using System.IO;

namespace TryingProject
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if(!Directory.Exists("test"))
			{
				Directory.CreateDirectory("test");
			}

			for(int i = 0;i<3;i++)
			{
				string filename = string.Format("test/test{0}.txt",i);
				string contents = string.Format("This is a test file named test{0}.txt",i);
				File.WriteAllText(filename, contents);
			}
		}
	}
	public static class FileMaker
	{
		 
	}
}
