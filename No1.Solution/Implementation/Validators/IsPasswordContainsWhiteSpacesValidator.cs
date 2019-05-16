using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No1.Solution.Implementation
{
    public class IsPasswordContainsWhiteSpacesValidator : IValidator
    {
        public (bool, string) IsValid(string password)
        {
            if (password.Any(char.IsWhiteSpace))
            {
                return (false, $"{password} has white spaces that are not allowed!");
            }

            return (true, $"{password} doesn't contain white spaces");
        }
    }
}
