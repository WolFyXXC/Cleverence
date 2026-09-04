using junmidsen3.Models;

namespace junmidsen3.Interfaces
{
    internal interface ILogParser
    {
            bool TryParse(string line, out LogEntry logEntry);
    }
}
