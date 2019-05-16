﻿using No3.Solution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace No3
{
    public class Calculator
    {
        public double CalculateAverage(List<double> values, IAveragingMethod averagingMethod)
        {
            if (values == null)
            {
                throw new ArgumentNullException($"Values can't be null {nameof(values)}");
            }

            if (averagingMethod == null)
            {
                throw new ArgumentNullException($"Averaging method can't be null nameof(averagingMethod)");
            }

            return averagingMethod.CalculateAverage(values);
        }

        public double CalculateAverage(List<double> values, Func<IEnumerable<double>, double> averagingMethod)
        {
            if (values == null)
            {
                throw new ArgumentNullException($"Values can't be null {nameof(values)}");
            }

            if (averagingMethod == null)
            {
                throw new ArgumentNullException($"Averaging method can't be null nameof(averagingMethod)");
            }

            return this.CalculateAverage(values, new WrapperForDelegare(averagingMethod));
        }

        internal class WrapperForDelegare : IAveragingMethod
        {
            private readonly Func<IEnumerable<double>, double> averagingMethod;

            public WrapperForDelegare(Func<IEnumerable<double>, double> averagingMethod)
            {
                this.averagingMethod = averagingMethod ?? throw new ArgumentNullException("AveragingMethod can't be null");
            }

            public double CalculateAverage(IEnumerable<double> values)
            {
                return this.averagingMethod(values);
            }
        }
    }
}
