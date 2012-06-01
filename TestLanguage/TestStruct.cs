using System;
using System.Drawing;
using System.IO;
using NUnit.Framework;

namespace TestLanguage
{
    struct Point
    {
        public int x, y;
    }

    [TestFixture]
    public class TestStruct
    {
        [Test]
        public void Test()
        {
            Point? p1 = new Point { x = 100, y = 100 };

            p1 = null;
        
        }

        private static void Print(Point p2, Point p1)
        {
            Console.WriteLine("p1.x = {0}", p1.x);
            Console.WriteLine("p1.y = {0}", p1.y);
//            Console.WriteLine("p1.y = {0}", p1.person.Name);

            Console.WriteLine("p2.x = {0}", p2.x);
            Console.WriteLine("p2.y = {0}", p2.y);
//            Console.WriteLine("p2.y = {0}", p2.person.Name);
        }
    }

    enum TestEnum 
    {
        PRV1,
        PV2,
    }
}