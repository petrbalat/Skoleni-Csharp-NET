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
            IEnumerable<string> cisla = from i in Enumerable.Range(1, 1000)
                        let pom = i * 2
                        where pom % 3 == 0
                        orderby i descending 
                        select i.ToString();


            foreach (var i in cisla)
            {
                Console.WriteLine(i);
            }
        }
    }
}