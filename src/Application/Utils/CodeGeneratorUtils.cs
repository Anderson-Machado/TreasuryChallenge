using System;
using System.Collections.Generic;
using System.Text;

namespace TreasuryChallenge.Utils
{
    public class CodeGeneratorUtils
    {
        private static readonly Random random = new Random();
        public static string GetCode(int length)
        {
            if (length == default)
            {
                throw new ArgumentException("The maximum size must be greater than zero, check it in appsettings.json.");
            }

            var listLetters = new List<string>() { "A", "B", "C", "D", "E", "F","G", "H", "I", "J", "K",
                               "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V",
                               "W", "X", "Y", "Z", };

            var result = new StringBuilder();
            int indice;
            for (int i = 0; i < length; i++)
            {
                indice = random.Next(25 - i);
                result.Append(listLetters[indice]);
                listLetters.RemoveAt(indice);
            }

            return result.ToString();
        }
    }
}
