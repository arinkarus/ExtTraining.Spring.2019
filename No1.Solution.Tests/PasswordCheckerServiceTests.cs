using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No1.Solution.Implementation;
using NUnit.Framework;

namespace No1.Solution.Tests
{
    public class PasswordCheckerServiceTests
    {
        [TestCase("", " is empty", false)]
        [TestCase("123", "123 length too short", false)]
        [TestCase("12345612346565565646464656545", "12345612346565565646464656545 length too long", false)]
        [TestCase("hellohello", "hellohello hasn't digits", false)]
        [TestCase("64310362", "64310362 hasn't alphanumerical chars", false)]
        [TestCase("Some123Pass", "Password is Ok. User was created", true)]
        [TestCase("Some123 h", "Password is Ok. User was created", true)]
        public void VerifyPassword_SqlRepositoryAndStandartValidator_ReturnValidationResult(string password, string expectedMessage, bool isValid)
        {
            var passwordCheckerService = new PasswordCheckerService(new SqlRepository(), new StandartPasswordValidator());
            var validationResult = passwordCheckerService.VerifyPassword(password);
            var messageActual = validationResult.Item2;
            bool isValidActual = validationResult.Item1;
            Assert.AreEqual(expectedMessage, messageActual);
            Assert.AreEqual(isValid, isValidActual);
        }

        [TestCase("", " is empty", false)]
        [TestCase("123", "123 length too short", false)]
        [TestCase("12345612346565565646464656545", "12345612346565565646464656545 length too long", false)]
        [TestCase("hellohello", "hellohello hasn't digits", false)]
        [TestCase("64310362", "64310362 hasn't alphanumerical chars", false)]
        [TestCase("Some123 h", "Some123 h has white spaces that are not allowed!", false)]
        [TestCase(" Some123Pass ", " Some123Pass  has untrimmed white spaces", false)]
        [TestCase("Some123Pass", "Password is Ok. User was created", true)]
        public void VerifyPassword_FileRepositoryAndComplexValidator_ReturnValidationeResult(string password, string expectedMessage, bool isValid)
        {
            List<IValidator> validatorsList = new List<IValidator>()
            { new StandartPasswordValidator(), new IsPasswordHasUntrimmedWhiteSpaces(), new IsPasswordContainsWhiteSpacesValidator() };
            var complexValidator = new 
                ComplexPasswordValidator(validatorsList);
            var passwordCheckerService = new PasswordCheckerService(new SqlRepository(), complexValidator);
            var validationResult = passwordCheckerService.VerifyPassword(password);
            var messageActual = validationResult.Item2;
            bool isValidActual = validationResult.Item1;
            Assert.AreEqual(expectedMessage, messageActual);
            Assert.AreEqual(isValid, isValidActual);
        }
    }
}
