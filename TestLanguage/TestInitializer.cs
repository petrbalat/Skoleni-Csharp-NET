using System;
using NUnit.Framework;

namespace TestLanguage
{
    [TestFixture]
    public class TestInitializer
    {
        class MyClass
        {
            public string Attr1 { get; set; }
            public int Attr2 { get; set; }
        }

        [Test]
        public void Test()
        {
            MyClass myClass = new MyClass
            {
                Attr1 = String.Empty,
                Attr2 = 4
            };

            var anonymniTrida = new //jiná než v javě! nelze nic implementovat ci dedit
            {
                AnonymAtrr1 = 1,
                AnonymAtrr2 = "hello"
            };

            Console.WriteLine(anonymniTrida.AnonymAtrr1);
            Console.WriteLine(anonymniTrida.AnonymAtrr2);
            TestAnonym(anonymniTrida);
        }

        private void TestAnonym(object anonymniTrida)
        {
            Console.WriteLine(anonymniTrida.GetType());
            dynamic dyn = anonymniTrida;//!!! musí být reference na assembly Microsoft.CSharp
            Console.WriteLine(dyn.AnonymAtrr1);
            Console.WriteLine(dyn.AnonymAtrr2);

            dyn = "sgrg";//lze samozřejmě použít na jakýkoliv typ nejen anonymní
            Console.WriteLine(dyn.Length);
        }
    }
}
