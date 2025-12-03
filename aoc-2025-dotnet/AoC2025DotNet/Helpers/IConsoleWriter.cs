namespace AoC2025DotNet.Helpers
{
    public interface IConsoleWriter
    {
        void WriteDebug(string message);
        void WriteError(string message);
        void WriteInfo(string message);
    }
}
