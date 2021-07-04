using System.Collections.Generic;

namespace BankOCR
{
    public class AccountNumberFactory
    {
        public static AccountNumber GetAccountNumber(List<string> numbersStringRepresentation)
        {

            AccountNumber accountNumber = new AccountNumber();
            foreach(var number in numbersStringRepresentation)
            {
                   accountNumber.AddNumber(NumberFactory.GetNumber(number));
            }
            accountNumber.FindAndSetValidReplacements();
            accountNumber.SetStatus();
            return accountNumber;
        }
    }
}