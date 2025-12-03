using System.Reflection;
using AoC2025DotNet.Helpers;

namespace AoC2025DotNet.SolutionFinding
{
    public abstract class SolutionBase(IConsoleWriter consoleWriter) : ISolution
    {
        private const string InputFileNameTemplate = "day_{0:D2}.txt";
        private const string SampleInputFileNameTemplate = "day_{0:D2}_sample.txt";

        protected readonly IConsoleWriter Writer = consoleWriter;

        public abstract int Day { get; }
        protected abstract string PartOne();
        protected abstract string PartTwo();

        public void Solve(int part)
        {
            int[] validParts = [0, 1, 2];
            if (!validParts.Contains(part))
            {
                Writer.WriteError($"Invalid part {part} requested for Day {Day}.");
                return;
            }

            Writer.WriteInfo($"\nSolution for day {Day}:");

            if (part == 0 || part == 1)
            {
                string result = PartOne();
                Writer.WriteInfo($"Part 1: {result}");
            }
            if (part == 0 || part == 2)
            {
                string result = PartTwo();
                Writer.WriteInfo($"Part 2: {result}");
            }
        }

        protected IEnumerable<string> LoadInput(bool getSample = false)
        {
            if (!TryGetRunningLocation(out string? root) || root is null)
                throw new InvalidDataException("Input data not found.");

            string fileName = getSample
                ? string.Format(SampleInputFileNameTemplate, Day)
                : string.Format(InputFileNameTemplate, Day);

            string location = Path.Combine(root, "Inputs", $"Day{Day:D2}", fileName);

            using Stream fs = File.OpenRead(location);
            using StreamReader reader = new(fs);

            string? line;
            while ((line = reader.ReadLine()) is not null)
            {
                yield return line;
            }
        }

        private static bool TryGetRunningLocation(out string? root)
        {
            root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            return !string.IsNullOrEmpty(root);
        }
    }
}
