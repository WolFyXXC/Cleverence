using System;

namespace junmidsen3.Models
{
    internal class LogEntry
    {
        public string Date { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Date}\t{Time}\t{Level}\t{Method}\t{Message}";
        }
    }
}
