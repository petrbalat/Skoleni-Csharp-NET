using System;
using NUnit.Framework;

namespace TestLanguage
{
    public interface ITestTrida
    {
        int Size { get; set; }//nelze pouzit modifikator public protoze u interface nema vyznam

        void TestVirtualMetod();
    }

    public class TestTrida : ITestTrida
    {
        public int Size { get; set; }

        public void TestVirtualMetod()
        {
            Console.WriteLine("TestTrida");
        }
    }

    [TestFixture]
    public sealed class SubTestTrida : TestTrida
    {
        public new void TestVirtualMetod()
        {
            Console.WriteLine("SubTestTrida");
        }

        [Test]
        public void TestVirtual()
        {
            TestTrida itestTrida = new SubTestTrida();
            itestTrida.TestVirtualMetod();
        }
    }
}