using AoC2025DotNet.Helpers;

namespace AoC2025DotNet.SolutionFinding.Solutions
{
    public class Day04(IConsoleWriter consoleWriter) : SolutionBase(consoleWriter)
    {
        private const char RollPresent = '@';
        private const char NoRollPresent = '.';

        public override int Day => 4;

        protected override string PartOne()
        {
            string[] input = [.. LoadInput()];
            char[][] inputArray = BuildCharArray(input);

            _ = RemoveAccessible(inputArray, out int removed);

            return removed.ToString();
        }

        protected override string PartTwo()
        {
            string[] input = [.. LoadInput()];
            char[][] inputArray = BuildCharArray(input);

            int totalRemoved = 0;

            while (true)
            {
                char[][] newInput = RemoveAccessible(inputArray, out int removed);

                if (removed == 0)
                    break;

                totalRemoved += removed;
                inputArray = newInput;
            }

            return totalRemoved.ToString();
        }

        private static char[][] RemoveAccessible(char[][] input, out int removed)
        {
            removed = 0;
            char[][] outArray = BuildCharArray([.. input.Select(row => new string(row))]);

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == NoRollPresent)
                        continue;

                    int countAdjacent = 0;

                    // Check above
                    if (i > 0)
                    {
                        countAdjacent += CountAdjacentInRow(input[i - 1], j, false);
                    }

                    // Check current
                    countAdjacent += CountAdjacentInRow(input[i], j, true);

                    // Check below
                    if (i < input.Length - 1)
                    {
                        countAdjacent += CountAdjacentInRow(input[i + 1], j, false);
                    }

                    if (countAdjacent < 4)
                    {
                        removed++;
                        outArray[i][j] = NoRollPresent;
                    }
                }
            }

            return outArray;
        }

        private static int CountAdjacentInRow(char[] row, int position, bool excludeSelf)
        {
            int[] indexesToCheck;

            if (position == 0)
            {
                indexesToCheck = excludeSelf ? [1] : [0, 1];
            }
            else if (position == row.Length - 1)
            {
                indexesToCheck = excludeSelf ? [row.Length - 2] : [row.Length - 1, row.Length - 2];
            }
            else
            {
                indexesToCheck = excludeSelf ? [position - 1, position + 1] : [position - 1, position, position + 1];
            }

            int adjacentCount = 0;
            foreach (int index in indexesToCheck)
            {
                if (row[index] == RollPresent)
                    adjacentCount++;
            }

            return adjacentCount;
        }

        private static char[][] BuildCharArray(string[] input)
        {
            char[][] inputArr = new char[input.Length][];
            for (int i = 0; i < input.Length; i++)
            {
                inputArr[i] = input[i].ToCharArray();
            }
            return inputArr;
        }
    }
}
