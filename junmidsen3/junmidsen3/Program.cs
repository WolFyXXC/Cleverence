using System;
using junmidsen3.Core;

class Program
{
    static void Main()
    {
        var baseDir = AppDomain.CurrentDomain.BaseDirectory;
        var projectRoot = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName
                          ?? throw new InvalidOperationException("Не удалось определить корневую директорию");

        var inputPath = Path.Combine(projectRoot, "input.txt");
        var outputPath = Path.Combine(projectRoot, "output.txt");
        var problemsPath = Path.Combine(projectRoot, "problems.txt");

        var processor = new LogProcessor(inputPath, outputPath, problemsPath);
        processor.Process();
    }
}