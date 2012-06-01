using System;
using NUnit.Framework;

namespace TestLanguage
{
    public delegate void Bacha(string odKoho);//muze byt definovaný i mimo třídu

    [TestFixture]
    public class TestClosures
    {
        public event Bacha Poslouchej;

        public TestClosures()
        {
            //            Poslouchej += koho => Console.WriteLine("lambda");
            //            Poslouchej += StresounOnPoslouchej;
        }

        private void StresounOnPoslouchej(string odKoho)
        {
            Console.WriteLine("metoda");
        }

        [Test]
        public void Test()
        {
            Poslouchej("baf");
        }
    }
}