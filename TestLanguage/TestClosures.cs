using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestLanguage
{
    public delegate void Bacha(string odKoho);

    [TestFixture]
    public class TestClosures
    {
        private readonly Stresoun stresoun = new Stresoun();

        public TestClosures()
        {
            stresoun.Poslouchej += delegate(string koho)
            {
                Console.WriteLine("OldSchool");//
            };

            stresoun.Poslouchej += koho => Console.WriteLine("lambda");

            stresoun.Poslouchej += StresounOnPoslouchej;
        }

        private void StresounOnPoslouchej(string odKoho)
        {
            Console.WriteLine("metoda");
        }

        [Test]
        public void Test()
        {
            stresoun.Spust();
        }
    }


    public class Stresoun
    {
        public event Bacha Poslouchej;

        public Stresoun()
        {
        }

        public void Spust()
        {
            if (Poslouchej != null) // pokud není nikdo prihlasenej tak 
            {
                Poslouchej("baf");
            }
        }
    }
}