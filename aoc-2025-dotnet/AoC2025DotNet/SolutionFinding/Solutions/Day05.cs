using AoC2025DotNet.Helpers;

namespace AoC2025DotNet.SolutionFinding.Solutions
{
    public class Day05(IConsoleWriter consoleWriter) : SolutionBase(consoleWriter)
    {
        public override int Day => 5;

        protected override string PartOne()
        {
            IEnumerable<string> input = LoadInput();

            List<(long start, long end)> ranges = ParseRanges(input);
            List<long> ids = ParseIds(input);

            int inRangeCount = 0;

            foreach (long id in ids)
            {
                foreach ((long start, long end) in ranges)
                {
                    if (id >= start && id <= end)
                    {
                        inRangeCount++;
                        break;
                    }
                }
            }

            return inRangeCount.ToString();
        }

        protected override string PartTwo()
        {
            return "Part Two Not Implemented";
        }

        private static List<(long start, long end)> ParseRanges(IEnumerable<string> lines)
        {
            List<(long start, long end)> ranges = [];
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line)) break;

                string[] parts = line.Split('-');
                if (parts.Length != 2
                    || !long.TryParse(parts[0], out long start)
                    || !long.TryParse(parts[1], out long end))
                {
                    throw new InvalidDataException($"Invalid range line: {line}");
                }
                ranges.Add((start, end));
            }
            return ranges;
        }

        private static List<long> ParseIds(IEnumerable<string> lines)
        {
            List<long> ids = [];
            bool breakFound = false;

            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    breakFound = true;
                    continue;
                }
                if (!breakFound) continue;

                if (!long.TryParse(line, out long id))
                {
                    throw new InvalidDataException($"Invalid ID line: {line}");
                }
                ids.Add(id);
            }
            return ids;
        }
    }
}
