using System.Reflection;

namespace AoC2025DotNet.Helpers
{
    internal class InputLoader
    {
        public static Stream LoadInput(int day, bool getSample = false)
        {
            if (!TryGetRunningLocation(out string? root) || root is null)
                throw new InvalidDataException("Input data not found.");

            string location = Path.Combine(root, "Inputs", $"Day{day:D2}", $"day_{day:D2}{(getSample ? "_sample" : "")}.txt");

            return File.OpenRead(location);
        }

        private static bool TryGetRunningLocation(out string? root)
        {
            root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            return !string.IsNullOrEmpty(root);
        }
    }
}
