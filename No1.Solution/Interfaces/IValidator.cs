using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No1.Solution.Implementation
{
    public interface IValidator
    {
        (bool, string) IsValid(string password);
    }
}
