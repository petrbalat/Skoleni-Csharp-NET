using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestLanguage
{
    [TestFixture]
    public class TestEnumerable
    {
        [Test]
        public void Test()
        {
            foreach (double cislo in new SumRandom().Compute())
            {
                Console.WriteLine(cislo);
            }
        }
    }

    public class SumRandom
    {
        private double sum;

        private readonly Random random = new Random();

        public IEnumerable<double> Compute()
        {
            while (sum < 10000)
            {
                int next = random.Next(100);
                sum += next;
                yield return sum;


                if (sum % 1000 == 0)
                {
                    yield break;
                }
            }
        }
    }
}