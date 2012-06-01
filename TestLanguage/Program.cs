/*
 * User: Petr Balat
 * Date: 28.5.2012
 * 
 */

using NUnit.Framework;

namespace TestLanguage
{
    [TestFixture]
    class Program
    {
        [Test]
        public void Main()
        {
            int iii = int.MaxValue;
            int b = iii += 1;
        }
    }
}
