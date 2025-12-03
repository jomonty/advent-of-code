using Microsoft.Extensions.Options;

namespace AoC2025DotNet.Helpers
{
    internal class ConsoleWriter(IOptions<ConsoleWriterOptions> options) : IConsoleWriter
    {
        private readonly ConsoleWriterOptions _options = options.Value;

        public void WriteDebug(string message)
        {
            if (_options.ConsoleMessageLevel < ConsoleMessageLevel.Debug)
                return;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void WriteInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    internal class ConsoleWriterOptions
    {
        public ConsoleMessageLevel ConsoleMessageLevel { get; set; } = ConsoleMessageLevel.Info;
    }

    internal enum ConsoleMessageLevel
    {
        Info,
        Debug
    }
}
