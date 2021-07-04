using System.Collections.Generic;

namespace BankOCR
{
    public class Number
    {
        public Number(char value, List<char> replacementValues)
        {
            this.Value = value;
            this.ReplacementValues = replacementValues;
        }

        public char Value { get; set; }
        public List<char> ReplacementValues { get; set; }
    }
}