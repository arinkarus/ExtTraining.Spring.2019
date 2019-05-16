using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No6
{
    public class SequenceGenerator<T>
    {
        public IEnumerable<T> Generate(int count, T firstItem, T secondItem, Func<T, T, T> rule)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Count can't be null");
            }

            IEnumerable<T> GetValues()
            {
                T current = firstItem;
                T next = secondItem;
                for (int i = 0; i < count; i++)
                {
                    yield return current;
                    T calculatedNewValue = rule(current, next);
                    current = next;
                    next = calculatedNewValue;
                }
            }

            return GetValues();
        }
    }
}
