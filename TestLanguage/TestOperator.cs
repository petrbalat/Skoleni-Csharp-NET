using System;
using NUnit.Framework;

namespace TestLanguage
{
    [TestFixture]
    public class TestOperator
    {
        [Test]
        public void Test()
        {
            Tvor pepa = new Tvor { Typ = Pohlavi.MUZ };
            Tvor maruska = new Tvor { Typ = Pohlavi.ZENA };
            Tvor tvor = pepa + maruska;
            Console.WriteLine(tvor);
        }
    }

    public class Tvor
    {
        public Pohlavi Typ { get; set; }

        public static Tvor operator +(Tvor davka1, Tvor davka2)
        {
            if (Equals(davka1.Typ, davka2.Typ))
            {
                return null;
            }

            int pohlavi = new Random().Next(1, 2);
            return new Tvor { Typ = (Pohlavi)pohlavi };
        }
    }

    public enum Pohlavi : int
    {
        MUZ = 1,
        ZENA = 2,
    }
}