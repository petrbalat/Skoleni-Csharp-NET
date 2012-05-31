/*
 * User: Petr Balat
 * Date: 28.5.2012
 * 
 */
using System;
using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;

namespace TestLanguage
{
	class Program
	{
		public static void Main(string[] args)
		{
		    var coll = new HashSet<int> {1, 2, 5};

		    BigInteger bigInteger1 = BigInteger.Parse("14574163434183438448635463483");
		    BigInteger bigInteger2 = BigInteger.Parse("9486348343842341534348343843");
		    BigInteger bigInteger = bigInteger1 + bigInteger2;//výhoda možnosti přetížení operátoru :-)
            Console.WriteLine(bigInteger);

		    Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}