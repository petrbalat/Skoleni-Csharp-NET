﻿using System;
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
            int actual = 4;
            Assert.IsTrue(Environment.Is64BitProcess);
            unsafe //kvuli IntPtr
            {
                Assert.AreEqual(4, sizeof(int));
                Assert.AreEqual(8, sizeof(IntPtr));
                int* iPtr = &actual;
                Console.WriteLine((int)iPtr); // adresa v pameti

                Assert.AreEqual(4, *iPtr);

                *iPtr = 5;
            }
            Assert.AreEqual(5, actual);



            Console.WriteLine(string.Format("E1 {0} E2 {1}", sizeof(E1), sizeof(E2)));
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
