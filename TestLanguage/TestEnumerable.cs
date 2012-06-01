using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using System.Linq;

namespace TestLanguage
{
    [TestFixture]
    public class TestEnumerable
    {
        [Test]
        public void Test()
        {
            IEnumerable<double> enumerable = new SumRandom().Compute();

            var doubles = enumerable.Where(d => d > 0);
            var doubles2 = enumerable.Where(d => d > 1);

            Console.WriteLine(enumerable);
        }
    }

    public class SumRandom
    {
        private double sum;

        private readonly Random random = new Random();

        public IEnumerable<double> Compute()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }
}