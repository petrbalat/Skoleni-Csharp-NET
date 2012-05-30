using System;
using NUnit.Framework;

namespace TestLanguage
{
    public interface ITestTrida
    {
        int Size { get; set; }//nelze pouzit modifikator public protoze u interface nema vyznam

        void TestVirtualMetod();
    }

    class TestTrida : ITestTrida
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

        public override string ToString()
        {
            return base.ToString();
        }
    }

    [TestFixture]
    class SubTestTrida : TestTrida
    {
        public SubTestTrida() : base(string.Empty)
        {
            string a = new string(new char[] {'a'});
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