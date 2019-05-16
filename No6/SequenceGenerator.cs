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
            if (ReferenceEquals(firstItem, null))
            {
                throw new ArgumentNullException("First item can't be null");
            }

            if (ReferenceEquals(secondItem, null))
            {
                throw new ArgumentNullException("Second item can't be null");
            }

            if (rule == null)
            {
                throw new ArgumentNullException("Rule can't be null");
            }

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
