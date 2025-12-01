using System;
using System.Collections.Generic;
using System.Text;
using AoC2025DotNet.Helpers;

namespace AoC2025DotNet.Solutions
{
    internal class Day01
    {
        public static void Solution()
        {
            Dial dial = new();

            using Stream fs = InputLoader.LoadInput(1, true);
            using StreamReader reader = new(fs);

            string? line;
            while ((line = reader.ReadLine()) is not null)
            {
                char direction = line[0];
                int distance = int.Parse(line[1..]);

                dial.Rotate(direction, distance);
            }

            Console.WriteLine($"Times at 0: {dial.TimesAt0}");
        }

        private class Dial
        {
            public int CurrentPosition { get; private set; } = 50;
            public int TimesAt0 { get; private set; } = 0;

            public void Rotate(char direction, int distance)
            {
                int singleRotationDist = distance % 100;

                if (direction == 'L')
                {
                    CurrentPosition -= singleRotationDist;
                    if (CurrentPosition < 0)
                    {
                        CurrentPosition = 99 + (CurrentPosition + 1);
                    }
                }
                else if (direction == 'R')
                {
                    CurrentPosition += singleRotationDist;
                    if (CurrentPosition > 99)
                    {
                        CurrentPosition = CurrentPosition - 100;
                    }
                }

                Console.WriteLine($"The dial is rotated {direction}{distance} to point at {CurrentPosition}.");

                if (CurrentPosition == 0) TimesAt0++;
            }

        }
    }
}
