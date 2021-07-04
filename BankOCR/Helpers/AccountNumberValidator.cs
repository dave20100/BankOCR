using System;

namespace BankOCR
{
    public static class AccountNumberValidator
    {
        public static bool IsAccountNumberValid(string accountNumber)
        {
            if (accountNumber.Contains('?'))
            {
                return false;
            }
            int checksum = 0;
            for (int index = 1; index <= accountNumber.Length; index++)
            {
                int currentNumber = accountNumber[accountNumber.Length - index] - '0';
                if(currentNumber < 0 || currentNumber > 9) {
                    throw new ArgumentException();
                }
                checksum += currentNumber * index;
            }
            checksum = checksum % 11;
            return checksum == 0;
        }
    }
}