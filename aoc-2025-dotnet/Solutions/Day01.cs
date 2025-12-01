using AoC2025DotNet.Helpers;

namespace AoC2025DotNet.Solutions
{
    internal class Day01
    {
        public static void Solution()
        {
            RunSolutionOne();
            RunSolutionTwo();
        }

        private static void RunSolutionOne()
        {
            Dial dial = new();

            using Stream fs = InputLoader.LoadInput(1);
            using StreamReader reader = new(fs);

            string? line;
            while ((line = reader.ReadLine()) is not null)
            {
                char direction = line[0];
                int distance = int.Parse(line[1..]);

                dial.Rotate(direction, distance);
            }

            Console.WriteLine($"Solution one: {dial.TimesAt0}");
        }

        private static void RunSolutionTwo()
        {
            Dial dial = new();

            using Stream fs = InputLoader.LoadInput(1);
            using StreamReader reader = new(fs);

            string? line;
            while ((line = reader.ReadLine()) is not null)
            {
                char direction = line[0];
                int distance = int.Parse(line[1..]);

                dial.RotateCountingAllZeros(direction, distance);
            }

            Console.WriteLine($"Solution two: {dial.TimesAt0}");
        }

        private class Dial
        {
            public int Location { get; private set; } = 50;
            public int TimesAt0 { get; private set; } = 0;

            public void Rotate(char direction, int distance)
            {
                int singleRotationDist = distance % 100;

                if (direction == 'L')
                {
                    Location -= singleRotationDist;
                    if (Location < 0)
                    {
                        Location = Location + 100;
                    }
                }
                else if (direction == 'R')
                {
                    Location += singleRotationDist;
                    if (Location > 99)
                    {
                        Location = Location - 100;
                    }
                }
                
                if (Location == 0) 
                    TimesAt0++;
                
                // Console.WriteLine($"The dial is rotated {direction}{distance} to point at {Location}.");
            }

            public void RotateCountingAllZeros(char direction, int distance)
            {
                (int timesPast0, int singleRotationDist) = Math.DivRem(distance, 100);

                if (Location == 0)
                {
                    if (direction == 'R')
                        Location = singleRotationDist;
                    else
                        Location = 100 - singleRotationDist;
                }
                else
                {
                    if (direction == 'L')
                    {
                        Location -= singleRotationDist;
                        if (Location < 0)
                        {
                            Location = Location + 100;
                            timesPast0++;
                        }
                    }
                    else if (direction == 'R')
                    {
                        Location += singleRotationDist;
                        if (Location == 100) Location = 0;
                        else if (Location > 100)
                        {
                            Location = Location - 100;
                            timesPast0++;
                        }
                    }
                }

                TimesAt0 += timesPast0;
                if (Location == 0) 
                    TimesAt0++;

                // Console.WriteLine($"The dial is rotated {direction}{distance} to point at {Location}; during this rotation, it points at zero {timesPast0} times.");
            }

        }
    }
}
