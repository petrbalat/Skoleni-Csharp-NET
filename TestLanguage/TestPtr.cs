using System;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace TestLanguage
{
    [TestFixture]
    public class TestPtr
    {
        [DllImport("User32.dll")]
        public static extern int MessageBox(int h, string m, string c, int type);

        [Test]
        public void PtrTest()
        {
            int b = 4;
            Assert.IsFalse(Environment.Is64BitProcess);
            unsafe //kvuli IntPtr
            {
                Assert.AreEqual(4, sizeof(int));
                Assert.AreEqual(4, sizeof(IntPtr));
                int* iPtr = &b;
                Console.WriteLine((int)iPtr); // adresa v pameti

                Assert.AreEqual(4, *iPtr);

                *iPtr = 5;
            }

            Console.WriteLine(string.Format("E1 {0} E2 {1}", sizeof(E1), sizeof(E2)));

            MessageBox(0, "Hello", "My Message Box", 0);
        }

        enum E1 : byte
        {
            PRVEK
        }

        enum E2 : long
        {
            PRVEK
        }
    }
}
