using System;
using NUnit.Framework;

namespace TestLanguage
{
    [TestFixture]
    public class TestRegion
    {
        #region PROPERTIES

        public string Name { get; set; }

        public int Size { get; set; }

        #endregion PROPERTIES//uz nemusí být znova zapsán PROPERTIES ale doporucuju psát

        [Test]
        public void Test()
        {
#if DEBUG
            Console.WriteLine("Debug mod");
#endif
            int promInt = 0;

#if SILVERLIGHT // pri brouzdání knihoven se nejcasteji pouziva pro multi knihovny, .NET, micro .NET, silverlight, WinRT
            promInt = 5;
#endif
            Console.WriteLine(promInt);
        }
    }
}
