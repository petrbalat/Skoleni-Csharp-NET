using System;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestLanguage
{
    [TestFixture]
    public class TestToStringCulture
    {
        readonly Lazy<StringBuilder> lazy = new Lazy<StringBuilder>(() => new StringBuilder());

        [Test]
        public void TestToString()
        {
            Task<int>.Factory.StartNew(() => 4).ContinueWith(task =>
                                                                 {
                                                                     var result = task.Result;

                                                                 });

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

    public static class MoneyHelper
    {
        public static string MoneyToString(this decimal dd)
        {
            return 3.14.ToString("c", new CultureInfo("cs-CZ"));
        }
    }
}
