using junmidsen;
using System;
using System.Text;

namespace JunMidsen
{ 
    class Program
    {
        static void Main()
        {
            string original = "aaabbcccdde";
            string compressed = Compress.compress(original);
            string decompressed = Decompress.decompress(compressed);

            Console.WriteLine($"Данная строка: {original}");
            Console.WriteLine($"Строка после алгоритма компрессии: {compressed}");
            Console.WriteLine($"Строка после алгоритма декомпрессии: {decompressed}");
        }
    }
}