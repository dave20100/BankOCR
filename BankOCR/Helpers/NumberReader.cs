using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace BankOCR
{
    public static class NumberReader
    {
        public static List<string> GetNumbersRepresentation(string accountNumberRepresentation)
        {
            List<string> separateLines = PrepareLines(accountNumberRepresentation);

            List<string> result = new List<string>();

            for(int numberIndex = 0; numberIndex < 9; numberIndex++)
            {
                StringBuilder currentNumber = new StringBuilder();
                for(int columnIndex = 0; columnIndex < 3; columnIndex++)
                {
                    for(int rowIndex = 0; rowIndex < 3; rowIndex++)
                    {
                        currentNumber.Append(separateLines[columnIndex][(numberIndex * 3) + rowIndex]);
                    }
                }
                result.Add(currentNumber.ToString());
            }
            return result;
        }

        private static List<string> PrepareLines(string accountNumberRepresentation) {
            List<string> separateLines = accountNumberRepresentation.Split(Environment.NewLine).ToList();
            separateLines.RemoveAt(0);
            for(int i = 0; i < separateLines.Count; i++)
            {
                separateLines[i] = separateLines[i].PadRight(27);
            }
            return separateLines;
        }
    }
}