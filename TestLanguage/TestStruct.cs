using System;
using NUnit.Framework;

namespace TestLanguage
{
    struct Point
    {
        public int x, y;

        public Person person;//typ Person je class
    }

    [TestFixture]
    public class TestStruct
    {
        [Test]
        public void Test()
        {
            var p1 = new Point { x = 100, y = 100, person = new Person {Name = "petr"} };

            Point p2 = p1;
            Print(p2, p1);

            Console.WriteLine();

            p2.x = 900;
            p2.y = 800;
            p2.person.Name = "jan";

            Print(p2, p1);
        }

        private static void Print(Point p2, Point p1)
        {
            Console.WriteLine("p1.x = {0}", p1.x);
            Console.WriteLine("p1.y = {0}", p1.y);
            Console.WriteLine("p1.y = {0}", p1.person.Name);

            Console.WriteLine("p2.x = {0}", p2.x);
            Console.WriteLine("p2.y = {0}", p2.y);
            Console.WriteLine("p2.y = {0}", p2.person.Name);
        }
    }
}