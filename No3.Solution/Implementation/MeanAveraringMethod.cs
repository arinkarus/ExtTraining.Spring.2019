using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No3.Solution.Implementation
{
    public class MeanAveraringMethod : IAveragingMethod
    {
        public double CalculateAverage(IEnumerable<double> values)
        {
            return values.Sum() / values.Count();
        }
    }
}
