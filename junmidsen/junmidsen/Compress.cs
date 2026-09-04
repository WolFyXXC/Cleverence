using System;
using System.Text;
using System.Text.RegularExpressions;

namespace junmidsen
{
    internal class Compress
    {
        public static string compress(string input)
        {
            if (!Regex.IsMatch(input, "^[a-z]*$"))
                throw new ArgumentException("Строка должна содержать только маленькие латинские буквы");

            var result = new StringBuilder();

            int i = 0;
            while (i < input.Length)
            {
                char currentChar = input[i];
                int count = 1;

                while (i + count < input.Length && input[i + count] == currentChar)
                    count++;

                result.Append(currentChar);

                if (count > 1)
                    result.Append(count);

                i += count;
            }
            return result.ToString();
        }
    }
}
