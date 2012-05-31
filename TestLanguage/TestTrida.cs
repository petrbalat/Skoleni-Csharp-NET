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
        public TestTrida(string par)
        {
        }

        private int size;
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public virtual void TestVirtualMetod()
        {
            Console.WriteLine("TestTrida");
        }
    }

    [TestFixture]
    public sealed class SubTestTrida : TestTrida, ITestTrida
    {
        public SubTestTrida() : base("construktor predka")
        {
        }

        public new void TestVirtualMetod()
        {
            Console.WriteLine("SubTestTrida");
        }

        [Test]
        public void TestVirtual()
        {
            ITestTrida itestTrida = new SubTestTrida();
            itestTrida.TestVirtualMetod();
            var testTrida = new TestTrida("");
            testTrida.TestVirtualMetod();
        }
    }
}