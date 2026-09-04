using System;

namespace junmidsen3.Utilities
{
    internal class LogLevelNormalizer
    {
        private static readonly Dictionary<string, string> LevelMap = new()
        {
            ["INFORMATION"] = "INFO",
            ["INFO"] = "INFO",
            ["WARNING"] = "WARN",
            ["WARN"] = "WARN",
            ["DEBUG"] = "DEBUG",
            ["ERROR"] = "ERROR"
        };

        public static string Normalize(string rawLevel)
        {
            return LevelMap.TryGetValue(rawLevel, out var normalized) ? normalized : "INFO";
        }
    }
}
