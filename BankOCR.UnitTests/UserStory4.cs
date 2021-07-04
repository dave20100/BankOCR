﻿using BankOCR;
using NUnit.Framework;
using System.Collections.Generic;

namespace BankOcrKata
{
    public class UserStory4
    {
        [TestCase(@"

  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |", "711111111")]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |", "777777177")]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _
 _|| || || || || || || || |
|_ |_||_||_||_||_||_||_||_|", "200800000")]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _
 _| _| _| _| _| _| _| _| _|
 _| _| _| _| _| _| _| _| _|", "333393333")]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _
|_||_||_||_||_||_||_||_||_|
|_||_||_||_||_||_||_||_||_|", "888888888 AMB ['888886888', '888888880', '888888988']")]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _
|_ |_ |_ |_ |_ |_ |_ |_ |_
 _| _| _| _| _| _| _| _| _|", "555555555 AMB ['555655555', '559555555']")]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _
|_ |_ |_ |_ |_ |_ |_ |_ |_
|_||_||_||_||_||_||_||_||_|", "666666666 AMB ['666566666', '686666666']")]
        [TestCase(@"
 _  _  _  _  _  _  _  _  _
|_||_||_||_||_||_||_||_||_|
 _| _| _| _| _| _| _| _| _|", "999999999 AMB ['899999999', '993999999', '999959999']")]
        [TestCase(@"
    _  _  _  _  _  _     _
|_||_|| || ||_   |  |  ||_
  | _||_||_||_|  |  |  | _|", "490067715 AMB ['490067115', '490067719', '490867715']")]
        [TestCase(@"
    _  _     _  _  _  _  _
 _| _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|", "123456789")]
        [TestCase(@"
 _     _  _  _  _  _  _
| || || || || || || ||_   |
|_||_||_||_||_||_||_| _|  |", "000000051")]
        [TestCase(@"
    _  _  _  _  _  _     _
|_||_|| ||_||_   |  |  | _
  | _||_||_||_|  |  |  | _|", "490867715")]
        public void Tests(string input, string expectedResult)
        {
            List<string> numbers = NumberReader.GetNumbersRepresentation(input);
            AccountNumber accountNumber = AccountNumberFactory.GetAccountNumber(numbers);
            accountNumber.FixIfOneReplacement();
            Assert.AreEqual(expectedResult, accountNumber.FullInformation());
        }
    }
}