using System;
using System.Numerics;
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
        
        [Test]
        public void TestBigInteger()
        {
            BigInteger bigInteger1 = BigInteger.Parse("14574163434183438448635463483");
            BigInteger bigInteger2 = BigInteger.Parse("9486348343842341534348343843");
            BigInteger bigInteger = bigInteger1 + bigInteger2;//výhoda přetížení operátoru :-)
            Assert.AreEqual("24060511778025779982983807326", bigInteger.ToString());

            BigInteger integer = new BigInteger(5);
            int i = (int)integer;
            Assert.AreEqual(5, i);
        }
    }

    public class Tvor
    {

        #region PROPERTIES

        public Pohlavi Typ { get; set; }

        #endregion PROPERTIES

        #region OPERATORS

        public static Tvor operator +(Tvor davka1, Tvor davka2)
        {
            if (Equals(davka1.Typ, davka2.Typ))
            {
                return null;
            }

            int pohlavi = new Random().Next(1, 2);
            return new Tvor { Typ = (Pohlavi)pohlavi };
        }

        public static bool operator ==(Tvor davka1, Tvor davka2)
        {
            return Equals(davka1.Typ, davka2.Typ);
        }

        public static bool operator !=(Tvor davka1, Tvor davka2)
        {
            return !(davka1 == davka2);
        }

        public bool Equals(Tvor other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Typ, Typ);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Tvor)) return false;
            return Equals((Tvor) obj);
        }

        public override int GetHashCode()
        {
            return Typ.GetHashCode();
        }

        #endregion OPERATORS
    }

    public enum Pohlavi : int
    {
        MUZ = 1,
        ZENA = 2,
    }
}