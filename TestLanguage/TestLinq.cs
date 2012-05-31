using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TestLanguage
{
    [TestFixture]
    public class TestLinq
    {
        [Test]
        public void TestToObjects()
        {
            IEnumerable<string> cisla = Enumerable.Range(1, 1000).
                Select(i => new {i, pom = i*2}).Where(t => t.pom%3 == 0 ||@t.i > 100).
                    OrderByDescending(t => t.i).Select(t => t.i.ToString());


            foreach (var i in cisla)
            {
                Console.WriteLine(i);
            }
        }
    }
}