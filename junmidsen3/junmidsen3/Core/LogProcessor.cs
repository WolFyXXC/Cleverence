using junmidsen3.Interfaces;
using System;
using System.Text;

namespace junmidsen3.Core
{
    internal class LogProcessor
    {
        private readonly string _inputPath;
        private readonly string _outputPath;
        private readonly string _problemsPath;
        private readonly List<ILogParser> _parsers;

        public LogProcessor(string inputPath, string outputPath, string problemsPath)
        {
            _inputPath = inputPath;
            _outputPath = outputPath;
            _problemsPath = problemsPath;
            _parsers = new List<ILogParser>
            {
                new Parsers.Format1Parser(),
                new Parsers.Format2Parser()
            };
        }

        public void Process()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var win1251 = Encoding.GetEncoding("windows-1251");

            using var reader = new StreamReader(_inputPath, win1251);
            using var writer = new StreamWriter(_outputPath, false, win1251);
            using var problemWriter = new StreamWriter(_problemsPath, false, win1251);

            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var result = ParseLine(line);

                if (result.IsValid)
                    writer.WriteLine(result.FormattedLine);
                else
                    problemWriter.WriteLine(line);
            }

            Console.WriteLine("Готово! Проверь файлы output.txt и problems.txt.");
        }

        private ParseResult ParseLine(string line)
        {
            try
            {
                foreach (var parser in _parsers)
                {
                    if (parser.TryParse(line, out var logEntry))
                        return new ParseResult(true, logEntry.ToString());
                }
                return new ParseResult(false, null);
            }
            catch
            {
                return new ParseResult(false, null);
            }
        }
    }
}
