using System;

namespace junmidsen3.Core
{
    internal class ParseResult
    {
        public bool IsValid { get; }
        public string? FormattedLine { get; }

        public ParseResult(bool isValid, string? formattedLine)
        {
            IsValid = isValid;
            FormattedLine = formattedLine;
        }
    }
}
