using System;
using System.Globalization;
using System.Threading;

namespace TestLanguage
{
	public class TestToStringCulture
	{
		public static void Main(params string[] args)
		{
			Console.WriteLine(3.14.ToString());

			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

			Console.WriteLine(3.14.ToString());
			Console.WriteLine(3.14.ToString(new CultureInfo("cs-CZ")));

			Console.WriteLine(3.14.ToString("c"));
			Console.WriteLine(3.14.ToString("c", new CultureInfo("cs-CZ")));
			Console.WriteLine(3.14.ToString("c", new CultureInfo("sk-SK")));//workaround http://blog.aspnet.sk/mirkub/archive/2009/01/15/eur-mena-v-net-aplik-225-ciach-pre-quot-sk-sk-quot.aspx

			Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs-CZ");// napr pro 
			Console.ReadKey(true);
		}
	}
}
