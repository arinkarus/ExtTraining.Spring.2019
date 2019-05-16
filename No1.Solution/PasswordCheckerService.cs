using No1.Solution.Implementation;
using No1.Solution.Interfaces;
using System;
using System.Linq;

namespace No1
{
    public class PasswordCheckerService
    {
        private readonly IRepository repository;
        private readonly IValidator validator;

        public PasswordCheckerService(IRepository repository, IValidator validator)
        {
            this.repository = repository ?? throw new ArgumentNullException("Repository can't be null");
            this.validator = validator ?? throw new ArgumentNullException("Validator can't be null");
        }

        public (bool, string) VerifyPassword(string password)
        {
            if (password == null)
                throw new ArgumentNullException($"{password} is null arg");

            var validationResult = this.validator.IsValid(password);
            if (!validationResult.Item1)
            {
                return validationResult;
            }

            repository.Create(password);

            return (true, "Password is Ok. User was created");
        }
    }
}
