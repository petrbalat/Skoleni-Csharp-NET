using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace TestLanguage
{
    [TestFixture]
    public class TestStaticClass
    {
        [Test]
        public void Test()
        {
            Assert.IsFalse(" ".IsNullOrEmpty());
            Assert.IsTrue(" ".IsNullOrWhiteSpace());
            string str = null;
            Assert.IsTrue(str.IsNullOrWhiteSpace());//voláno jako StringHelper.IsNullOrWhiteSpace(str) takze bez vyhozeni vyjimky NullReferenceException



            string[] coll = new[] { "aaa", "bbb" }.Prepend("ccc").ToArray();

            Console.WriteLine(coll);
        }
    }

    public static class StringHelper
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
        
        public static bool IsNullOrWhiteSpace(this string str, int asb)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }

    public static class EnumerableHelper
    {
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> str, T prvek)
        {
            yield return prvek;
            foreach (T t in str)
            {
                yield return t;
            }
        }

        public static IEnumerable<T> Append<T>(this IEnumerable<T> str, T prvek)
        {
            foreach (T t in str)
            {
                yield return t;
            }
            yield return prvek;
        }
    }
}