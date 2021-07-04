using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace BankOCR
{
    public class AccountNumber
    {
        public AccountNumber()
        {
            this.Numbers = new List<Number>();
            this.ValidReplacements = new List<string>();
        }

        public List<Number> Numbers { get; set; }
        public string Status { get; set; }
        public List<string> ValidReplacements { get; set; }

        public string AccountNumberValue
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (var number in this.Numbers)
                {
                    builder.Append(number.Value);
                }
                return builder.ToString();
            }
            set
            {
                for (int index = 0; index < value.Length; index++)
                {
                    if (this.Numbers[index].Value != value[index] && this.Numbers[index].ReplacementValues.Contains(value[index]))
                    {
                        this.Numbers[index].Value = value[index];
                    }
                }
            }
        }



        public void AddNumber(Number newNumber)
        {
            Numbers.Add(newNumber);
        }

        public void SetStatus()
        {

            if (this.ValidReplacements.Count > 1)
            {
                this.Status = " AMB";
                return;
            }

            if (this.ValidReplacements.Count == 1)
            {
                return;
            }

            if (this.AccountNumberValue.Contains('?'))
            {
                this.Status = " ILL";
                return;
            }

            if (!AccountNumberValidator.IsAccountNumberValid(this.AccountNumberValue))
            {
                this.Status = " ERR";
                return;
            }
        }

        public void FindAndSetValidReplacements()
        {
            for (int index = 0; index < Numbers.Count; index++)
            {
                StringBuilder accountNumberCopy = new StringBuilder(AccountNumberValue);
                foreach (var replacementValue in Numbers[index].ReplacementValues)
                {
                    accountNumberCopy[index] = replacementValue;
                    if (AccountNumberValidator.IsAccountNumberValid(accountNumberCopy.ToString()))
                    {
                        this.ValidReplacements.Add(accountNumberCopy.ToString());
                    }
                }
            }
            this.ValidReplacements.Sort();
        }

        public void FixIfOneReplacement()
        {
            if(this.ValidReplacements.Count == 1)
            {
                this.AccountNumberValue = this.ValidReplacements[0];
                this.ValidReplacements.Clear();
            }
        }

        public string NumberAndStatus()
        {
            return this.AccountNumberValue + this.Status;
        }
        public string FullInformation()
        {
            StringBuilder replacementsInfo = new StringBuilder();
            if (this.ValidReplacements.Count > 0)
            {
                replacementsInfo.Append(" [");
                foreach (var replacement in this.ValidReplacements)
                {
                    replacementsInfo.Append($"'{replacement}'");
                    if (!this.ValidReplacements.Last().Equals(replacement))
                    {
                        replacementsInfo.Append(", ");
                    }
                }
                replacementsInfo.Append("]");
            }

            return this.NumberAndStatus() + replacementsInfo;
        }
    }
}