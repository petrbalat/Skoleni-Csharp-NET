using System;
using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace TestLanguage
{
    [TestFixture]
	public class TestToStringCulture
	{
        [Test]
		public void TestToString()
		{
			Console.WriteLine(3.14.ToString());
            Console.WriteLine(3.14.ToString(CultureInfo.InvariantCulture));

			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

			Console.WriteLine(3.14.ToString());
			Console.WriteLine(3.14.ToString(new CultureInfo("cs-CZ")));

			Console.WriteLine(3.14.ToString("c"));
			Console.WriteLine(3.14.ToString("c", new CultureInfo("cs-CZ")));
			Console.WriteLine(3.14.ToString("c", new CultureInfo("sk-SK")));

			Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs-CZ");// napr pro WPF nebo WinForms
		}
	}
}
