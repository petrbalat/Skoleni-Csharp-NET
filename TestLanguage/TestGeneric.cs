using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace TestLanguage
{
    [TestFixture]
    public class TestGeneric
    {
        [Test]
        public void Koovariance()
        {
            IEnumerable<ITestTrida> tridy = new List<TestTrida> { new TestTrida(), new TestTrida() { Size = 2 } };
            Console.WriteLine(tridy);
        }

        [Test]
        public void KontraVariance()
        {
            SortedSet<TestTrida> testTridas = new SortedSet<TestTrida>(new TestTridaComparer())
                                                  {
                                                      new TestTrida() { Size = 5 },
                                                      new TestTrida() { Size = 2 },
                                                      new TestTrida() { Size = 8 },
                                                  };
            testTridas.Add(new TestTrida() {Size = 1} );
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