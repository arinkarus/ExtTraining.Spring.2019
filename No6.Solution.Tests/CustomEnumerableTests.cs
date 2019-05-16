using NUnit.Framework;
using System.Collections.Generic;

namespace No6.Solution.Tests
{
    [TestFixture]
    public class CustomEnumerableTests
    {
        [Test]
        public void Generator_ForSequence1()
        {
            int[] expected = {1, 1, 2, 3, 5, 8, 13, 21, 34, 55};

            var generator = new SequenceGenerator<int>();
            List<int> values = new List<int>(generator.Generate(10, 1, 1, (a, b) => a + b));
            CollectionAssert.AreEqual(expected, values.ToArray());
        }

        [Test]
        public void Generator_ForSequence2()
        {
            int[] expected = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };
            var generator = new SequenceGenerator<int>();
            List<int> values = new List<int>(generator.Generate(10, 1, 2, (a, b) => 6 * b - 8 * a));
            CollectionAssert.AreEqual(expected, values.ToArray());
        }

        [TestCase(0.000001)]
        public void Generator_ForSequence3(double precision)
        {
            double[] expected = { 1, 2, 2.5, 3.3, 4.05757575757576, 4.87086926018965, 5.70389834408211, 6.55785277425587, 7.42763417076325, 8.31053343902137 };
            var generator = new SequenceGenerator<double>();
            List<double> values = new List<double>(generator.Generate(10, 1, 2, (a, b) => b + a / b));
            double[] actual = values.ToArray();
            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], precision);
            }
        }
    }
}
