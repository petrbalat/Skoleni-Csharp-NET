using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestLanguage
{
    [TestFixture]
    public class TestGeneric
    {
        [Test]
        public void Koovariance()
        {
            IEnumerable<ITestTrida> tridy = new List<ITestTrida> { new TestTrida("a"), new TestTrida("b") { Size = 2 } };
            Console.WriteLine(tridy);
        }

        [Test]
        public void KontraVariance()
        {
            SortedSet<TestTrida> testTridas = new SortedSet<TestTrida>(new TestTridaComparer())
                                                  {
                                                      new TestTrida("d") { Size = 5 },
                                                      new TestTrida("e") { Size = 2 },
                                                      new TestTrida("f") { Size = 8 },
                                                  };
            Console.WriteLine(testTridas);
        }

        [Test]
        public void TestToString()
        {
            Console.WriteLine(typeof(IList<>));
            Console.WriteLine(typeof(IList<string>));
            Console.WriteLine(typeof(IDictionary<,>));
            Console.WriteLine(typeof(IDictionary<int, string>));
        }

        public class TestTridaComparer : IComparer<ITestTrida>
        {
            public int Compare(ITestTrida x, ITestTrida y)
            {
                return x.Size.CompareTo(y.Size);
            }
        }
    }
}