using System.Collections.Generic;

namespace BankOCR
{
    public static class NumberFactory
    {
        static readonly Dictionary<string, char> NumberDictionary = new Dictionary<string, char>{
               {" _ "+
                "| |"+
                "|_|", '0'},
               {"   "+
                "  |"+
                "  |", '1'},
               {" _ "+
                " _|"+
                "|_ ", '2'},
               {" _ "+
                " _|"+
                " _|", '3'},
               {"   "+
                "|_|"+
                "  |", '4'},
               {" _ "+
                "|_ "+
                " _|", '5'},
               {" _ "+
                "|_ "+
                "|_|", '6'},
               {" _ "+
                "  |"+
                "  |", '7'},
               {" _ "+
                "|_|"+
                "|_|", '8'},
               {" _ "+
                "|_|"+
                " _|", '9'}
         };


        public static Number GetNumber(string representation)
        {
            if (NumberDictionary.ContainsKey(representation))
            {
                return new Number(NumberDictionary[representation], GetReplacements(representation));
            }
            return new Number('?', GetReplacements(representation));
        }


        public static List<char> GetReplacements(string representation)
        {
            List<char> replacements = new List<char>();
            foreach (var entry in NumberDictionary)
            {
                int wrongCharsCount = 0;
                for (int i = 0; i < entry.Key.Length; i++)
                {
                    if (representation[i] != entry.Key[i])
                    {
                        wrongCharsCount++;
                    }

                    if (wrongCharsCount > 1)
                    {
                        break;
                    }
                }
                if (wrongCharsCount == 1)
                {
                    replacements.Add(entry.Value);
                }
            }
            return replacements;
        }
    }
}