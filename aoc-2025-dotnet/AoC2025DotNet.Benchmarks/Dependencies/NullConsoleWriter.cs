using AoC2025DotNet.Helpers;

namespace AoC2025DotNet.Benchmarks.Dependencies
{
    internal class NullConsoleWriter : IConsoleWriter
    {
        public void WriteDebug(string message)
        {
            // Do nothing
        }

        public void WriteError(string message)
        {
            // Do nothing
        }

        public void WriteInfo(string message)
        {
            // Do nothing
        }
    }
}
