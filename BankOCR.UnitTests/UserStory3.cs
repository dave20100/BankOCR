using System.Collections.Generic;
using BankOCR;
using NUnit.Framework;

namespace BankOcrKata
{
    public class UserStory3
    {
        [TestCase(@"
 _  _  _  _  _  _  _  _
| || || || || || || ||_   |
|_||_||_||_||_||_||_| _|  |", "000000051")]
        [TestCase(@"
    _  _  _  _  _  _     _
|_||_|| || ||_   |  |  | _
  | _||_||_||_|  |  |  | _|", "49006771? ILL")]
        [TestCase(@"
    _  _     _  _  _  _  _
  | _| _||_| _ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _ ", "1234?678? ILL")]
        public void Tests(string input, string expectedResult)
        {
            List<string> numbers = NumberReader.GetNumbersRepresentation(input);
            AccountNumber accountNumber = AccountNumberFactory.GetAccountNumber(numbers);
            Assert.AreEqual(expectedResult, accountNumber.NumberAndStatus());
        }
    }
}