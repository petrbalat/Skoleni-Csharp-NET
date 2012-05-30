using System;

namespace TestLanguage
{
	public class TestPtr
	{
		public static void Main(string[] args)
		{
			int b = 4;
			Console.WriteLine(string.Format("64bit runtime {0}", Environment.Is64BitProcess));
			unsafe //kvuli IntPtr
			{
				Console.WriteLine(string.Format("int {0} IntPtr {1}", sizeof(int), sizeof(IntPtr)));
				int *iPtr = &b;
				Console.WriteLine((int)iPtr); // adresa v pameti
				Console.WriteLine(*iPtr); // hodnota kam ukazue
				*iPtr = 5;
			}
			
			Console.WriteLine(string.Format("E1 {0} E2 {1}", sizeof(E1), sizeof(E2)));
			
			
			Console.ReadKey(true);
		}
		
		enum E1 : byte
		{
			PRVEK
		}
		
		enum E2 : long
		{
			PRVEK
		}
	}
}
