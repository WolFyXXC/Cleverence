using System;
using System.Text;

namespace junmidsen
{
    internal class Decompress
    {
        public static string decompress(string compressed)
        {
            if (string.IsNullOrEmpty(compressed))
                return string.Empty;

            var result = new StringBuilder();
            int i = 0;

            while (i < compressed.Length)
            {
                char symbol = compressed[i];
                i++;

                if (!char.IsLetter(symbol))
                    throw new ArgumentException($"Неверный символ на позиции {i - 1}: ожидалась буква");
 
                int count = 1;

                if (i < compressed.Length && char.IsDigit(compressed[i]))
                {
                    count = int.Parse(compressed[i].ToString());
                    i++;
                }
                result.Append(symbol, count);
            }
            return result.ToString();
        }

    }
}
