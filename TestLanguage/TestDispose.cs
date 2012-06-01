using System;
using System.IO;
using NUnit.Framework;

namespace TestLanguage
{
    [TestFixture]
    public class TestDispose
    {
        private const string FILE = @"c:\Users\balat\Documents\Visual Studio 2010\Projects\Skoleni-Csharp-NET\.gitignore";

        [Test]
        public void TestTryFinal2()
        {
            using (var file = File.OpenRead(FILE))
            {
                string name = file.Name;
            }

        }

        [Test]
        public void TestTryFinal()
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(File.OpenRead(FILE));
                Console.WriteLine(streamReader.ReadToEnd());
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Dispose();
                }
            }
        }

        [Test]
        public void TestUsing()
        {
            using (StreamReader streamReader = new StreamReader(File.OpenRead(FILE)))
            {
                Console.WriteLine(streamReader.ReadToEnd());
            }
        }
        
        [Test]
        public void TestUsing2()
        {
            using (FileStream fileStream = File.OpenRead(FILE))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
            }
        }
    }
}