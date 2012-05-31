using System;
using NUnit.Framework;

namespace TestLanguage
{
    struct Point { public int x, y;}

    [TestFixture]
    public class StructTest
    {
        [Test]
        public void Test()
        {
            var p1 = new Point { x = 100, y = 100 };

            Console.WriteLine("priradim p1 do p2");
            Point p2 = p1;

            Console.WriteLine("p1.x = {0}", p1.x);
            Console.WriteLine("p1.y = {0}", p1.y);

            Console.WriteLine("p2.x = {0}", p2.x);
            Console.WriteLine("p2.y = {0}", p2.y);

            Console.WriteLine(">Zmenim p2.x na 900");

            p2.x = 900;
            p2.y = 800;
            Console.WriteLine("p1.x = {0}", p1.x);
            Console.WriteLine("p1.y = {0}", p1.y);

            Console.WriteLine("p2.x = {0}", p2.x);
            Console.WriteLine("p2.y = {0}", p2.y);
        }
    }
}