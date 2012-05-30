using System;
using NUnit.Framework;

namespace TestLanguage
{
    [TestFixture]
    class TestNullable
    {
        [Test]
        public void Test()
        {
            Nullable<int> inta = new Nullable<int>();
            Nullable<int> inta2 = null;
            int? intb = null;//preferovaný zápis

            Assert.IsTrue(inta == intb);
            Assert.IsTrue(inta == null);
            Assert.IsFalse(inta.HasValue);
            Assert.IsFalse(intb.HasValue);
            Assert.IsFalse(inta2.HasValue);

            try
            {
                Console.WriteLine(string.Format("inta.HasValue {0}", intb.Value));//!!! InvalidOperationException
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }

            try
            {
                Console.WriteLine(string.Format("inta.Value {0}", inta.Value));//!!! InvalidOperationException
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
            }

            int intc = inta ?? 0;
            Assert.AreEqual(0, intc);
        }
    }
}
