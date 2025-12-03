using AoC2025DotNet.Helpers;

namespace AoC2025DotNet.SolutionFinding.Solutions
{
    public class Day02(IConsoleWriter consoleWriter) : SolutionBase(consoleWriter)
    {
        public override int Day => 2;

        protected override string PartOne()
        {
            string input = LoadInput().First();

            int invalidIds = 0;
            ulong invalidIdSum = 0;

            foreach (string range in input.Split(','))
            {
                string[] bounds = range.Split('-');
                ulong start = ulong.Parse(bounds[0]);
                ulong end = ulong.Parse(bounds[1]);

                for (ulong i = start; i <= end; i++)
                {
                    string iStr = i.ToString();
                    if (iStr.Length % 2 != 0)
                        continue;

                    if (iStr.Substring(0, iStr.Length / 2) == iStr.Substring(iStr.Length / 2))
                    {
                        invalidIdSum += i;
                        invalidIds++;
                    }
                }
            }

            Writer.WriteDebug($"Invalid IDs found: {invalidIds}, Sum: {invalidIdSum}");

            return invalidIdSum.ToString();
        }

        protected override string PartTwo()
        {
            string input = LoadInput().First();

            // return PartTwoStringSolution(input);
            return PartTwoSpanSolution(input);
        }

        private string PartTwoStringSolution(string input)
        {
            int invalidIds = 0;
            ulong invalidIdSum = 0;

            foreach (string range in input.Split(','))
            {
                string[] bounds = range.Split('-');
                ulong start = ulong.Parse(bounds[0]);
                ulong end = ulong.Parse(bounds[1]);

                for (ulong i = start; i <= end; i++)
                {
                    string iStr = i.ToString();

                    // No pattern possible if length < 2
                    if (iStr.Length < 2)
                        continue;

                    // Base case - length >= 2 and all digits are the same
                    if (iStr.Length >= 2 && iStr.Distinct().Count() == 1)
                    {
                        invalidIds++;
                        invalidIdSum += i;
                        continue;
                    }

                    // Look for patterns, up to half the length of the string
                    for (int len = 2; len <= iStr.Length / 2; len++)
                    {
                        if (iStr.Length % len != 0)
                            continue;

                        string pattern = iStr.Substring(0, len);
                        bool patternBroken = false;

                        for (int patternIndex = len; patternIndex < iStr.Length; patternIndex += len)
                        {
                            if (iStr.Substring(patternIndex, len) != pattern)
                            {
                                patternBroken = true;
                                break;
                            }
                        }

                        if (!patternBroken)
                        {
                            invalidIdSum += i;
                            invalidIds++;
                            break;
                        }

                    }
                }
            }

            Writer.WriteDebug($"Invalid IDs found: {invalidIds}, Sum: {invalidIdSum}");

            return invalidIdSum.ToString();
        }

        private string PartTwoSpanSolution(string input)
        {
            int invalidIds = 0;
            ulong invalidIdSum = 0;

            foreach (string range in input.Split(','))
            {
                string[] bounds = range.Split('-');
                ulong start = ulong.Parse(bounds[0]);
                ulong end = ulong.Parse(bounds[1]);

                for (ulong i = start; i <= end; i++)
                {
                    string iStr = i.ToString();
                    ReadOnlySpan<char> iSpan = iStr.AsSpan();

                    // No pattern possible if length < 2
                    if (iSpan.Length < 2)
                        continue;

                    // Base case - length >= 2 and all digits are the same
                    bool allCharsSame = true;
                    foreach (char c in iSpan)
                    {
                        if (c != iSpan[0])
                        {
                            allCharsSame = false;
                            break;
                        }
                    }

                    if (allCharsSame)
                    {
                        invalidIds++;
                        invalidIdSum += i;
                        continue;
                    }

                    // Look for patterns, up to half the length of the string
                    for (int len = 2; len <= iSpan.Length / 2; len++)
                    {
                        if (iSpan.Length % len != 0)
                            continue;

                        ReadOnlySpan<char> pattern = iSpan.Slice(0, len);
                        bool patternBroken = false;

                        for (int patternIndex = len; patternIndex < iSpan.Length; patternIndex += len)
                        {
                            if (!iSpan.Slice(patternIndex, len).SequenceEqual(pattern))
                            {
                                patternBroken = true;
                                break;
                            }
                        }

                        if (!patternBroken)
                        {
                            invalidIdSum += i;
                            invalidIds++;
                            break;
                        }

                    }
                }
            }

            Writer.WriteDebug($"Invalid IDs found: {invalidIds}, Sum: {invalidIdSum}");

            return invalidIdSum.ToString();
        }
    }
}
