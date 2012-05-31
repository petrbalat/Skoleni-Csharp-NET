/*
 * User: Petr Balat
 * Date: 28.5.2012
 * 
 */
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestLanguage
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

		    var coll = new HashSet<int> {1, 2, 5};
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}