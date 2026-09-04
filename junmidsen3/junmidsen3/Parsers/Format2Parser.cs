using junmidsen3.Interfaces;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using junmidsen3.Interfaces;
using junmidsen3.Models;
using junmidsen3.Utilities;

namespace junmidsen3.Parsers
{
    internal class Format2Parser : ILogParser
    {
        private static readonly Regex Pattern = new Regex(
            @"^(?<date>\d{4}-\d{2}-\d{2}) (?<time>\d{2}:\d{2}:\d{2}\.\d+)\| (?<level>[A-Z]+)\|.*?\|(?<method>.*?)\| (?<message>.+)$"
        );

        public bool TryParse(string line, out LogEntry logEntry)
        {
            logEntry = null!;
            var match = Pattern.Match(line);

            if (!match.Success)
                return false;

            logEntry = new LogEntry
            {
                Date = DateTime.ParseExact(match.Groups["date"].Value, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                               .ToString("yyyy-MM-dd"),
                Time = match.Groups["time"].Value,
                Level = LogLevelNormalizer.Normalize(match.Groups["level"].Value),
                Method = match.Groups["method"].Value.Trim(),
                Message = match.Groups["message"].Value
            };
            return true;
        }
    }
}

