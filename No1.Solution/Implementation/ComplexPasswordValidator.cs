using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No1.Solution.Implementation
{
    public class ComplexPasswordValidator: IValidator
    {
        private readonly List<IValidator> validators;

        public ComplexPasswordValidator(IEnumerable<IValidator> validators)
        {
            if (validators == null)
            {
                throw new ArgumentNullException("Validators can't be null");
            }

            this.validators = new List<IValidator>(validators);
        }
        
        public (bool, string) IsValid(string password)
        {
            (bool, string) result;
            foreach (var validator in validators)
            {
                result = validator.IsValid(password);
                if (!result.Item1)
                {
                    return result;
                }
            }

            return (true, "Password is valid");
        }
    }
}
