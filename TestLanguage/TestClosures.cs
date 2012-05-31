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
            Poslouchej += delegate(string koho)
            {
                Console.WriteLine("OldSchool");//
            };

            Poslouchej += koho => Console.WriteLine("lambda");

            Poslouchej += StresounOnPoslouchej;
            Poslouchej += new Bacha(StresounOnPoslouchej);//grand school :-)
        }

        private void StresounOnPoslouchej(string odKoho)
        {
            Console.WriteLine("metoda");
        }

        [Test]
        public void Test()
        {
            if (Poslouchej != null) // pokud není nikdo prihlasenej tak 
            {
                Poslouchej("baf");
            }
        }
    }
}