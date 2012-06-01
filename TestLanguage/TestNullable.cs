using NUnit.Framework;
using System.Linq;

namespace TestLanguage
{
    [TestFixture]
    class TestNullable
    {
        [Test]
        public void Test()
        {
            string[] coll = new[] {"aaa", "bb"};
            string[] strings = coll.Where(s => s.Length == 2).ToArray();

        }
    }
}
