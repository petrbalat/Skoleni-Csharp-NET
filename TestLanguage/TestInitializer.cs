using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestLanguage
{
    [TestFixture]
    public class TestInitializer
    {
        [Test]
        public void Test()
        {
            var anonymniTrida = new //jiná než v javě! nelze nic implementovat ci dedit
            {
                AnonymAtrr1 = 1,
                AnonymAtrr2 = "hello"
            };

            var sstr = new List<List<string>>();

            Console.WriteLine(anonymniTrida.AnonymAtrr1);
            Console.WriteLine(anonymniTrida.AnonymAtrr2);
            TestAnonym(anonymniTrida);
        }

        private object TestAnonym(object anonymniTrida)
        {
            Console.WriteLine(anonymniTrida.GetType());
            dynamic dyn = anonymniTrida;//!!! musí být reference na assembly Microsoft.CSharp
            Console.WriteLine(dyn.AnonymAtrr1);
            Console.WriteLine(dyn.AnonymAtrr2);

            dyn = "sgrg";//lze samozřejmě použít na jakýkoliv typ nejen anonymní
            Console.WriteLine(dyn.Length);


            return new {asdf = 5};
        }
    }
}
