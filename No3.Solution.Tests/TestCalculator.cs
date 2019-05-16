using System.Collections.Generic;
using No3.Solution.Implementation;
using NUnit.Framework;
using System.Linq;

namespace No3.Solution.Tests
{
    [TestFixture]
    public class TestCalculator
    {
        private readonly List<double> values = new List<double> { 10, 5, 7, 15, 13, 12, 8, 7, 4, 2, 9 };

        [Test]
        public void Test_AverageByMean()
        {
            Calculator calculator = new Calculator();

            double expected = 8.3636363;

            double actual = calculator.CalculateAverage(values, new MeanAveraringMethod());

            Assert.AreEqual(expected, actual, 0.000001);
        }

        [Test]
        public void Test_AverageByMedian()
        {
            Calculator calculator = new Calculator();

            double expected = 8.0;

            double actual = calculator.CalculateAverage(values, new MedianAveragingMethod());

            Assert.AreEqual(expected, actual, 0.000001);
        }

        [TestCase(new double[] { 5, 5, 33, 10 })]
        public void Test_AverageDelegateMean(double[] values)
        {
            Calculator calculator = new Calculator();
            
            double expected = 45.5;

            double actual = calculator.CalculateAverage(values.ToList(), (val) => val.Sum() / val.Count());

            Assert.AreEqual(expected, actual, 0.000001);
        }
    }
}