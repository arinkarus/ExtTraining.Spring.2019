using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No1.Solution.Implementation
{
    public class IsPasswordHasUntrimmedWhiteSpaces : IValidator
    {
        public (bool, string) IsValid(string password)
        {
            if (password.Trim().Length != password.Length)
            {
                return (false, $"{password} has untrimmed white spaces");
            }

            return (true, $"{password} doesn't have untrimmed white spaces");
        }
    }
}
