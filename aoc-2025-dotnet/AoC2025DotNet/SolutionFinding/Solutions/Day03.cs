using AoC2025DotNet.Helpers;

namespace AoC2025DotNet.SolutionFinding.Solutions
{
    public class Day03(IConsoleWriter consoleWriter) : SolutionBase(consoleWriter)
    {
        public override int Day => 3;
        protected override string PartOne()
        {
            List<int> joltages = [];

            foreach (string line in LoadInput())
            {
                (char first, int firstIndex) = GetLargestDigit(line, 0, 1);
                (char second, int secondIndex) = GetLargestDigit(line, firstIndex + 1, 0);

                char[] joltage = [first, second];
                string joltageStr = new(joltage);
                joltages.Add(int.Parse(joltageStr));
            }

            return joltages.Sum().ToString();
        }

        protected override string PartTwo()
        {
            List<long> joltages = [];
            const int expectedSize = 12;

            foreach (string line in LoadInput())
            {
                char[] digits = new char[expectedSize];
                int lastIndex = -1;

                for (int i = 0; i < expectedSize; i++)
                {
                    (char digit, int index) = GetLargestDigit(line, lastIndex + 1, expectedSize - i - 1);
                    digits[i] = digit;
                    lastIndex = index;
                }

                string joltageStr = new(digits);
                joltages.Add(long.Parse(joltageStr));
            }

            return joltages.Sum().ToString();
        }

        private static (char, int) GetLargestDigit(string str, int startIndex, int endReservedDigits)
        {
            char largest = str[startIndex];
            int largestIndex = startIndex;

            for (int i = startIndex + 1; i < str.Length - endReservedDigits; i++)
            {
                if (str[i] > largest)
                {
                    largest = str[i];
                    largestIndex = i;
                }
            }

            return (largest, largestIndex);
        }
    }
}
