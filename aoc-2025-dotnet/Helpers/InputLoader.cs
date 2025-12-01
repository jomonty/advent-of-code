// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AoC2025DotNet.Helpers
{
    internal class InputLoader
    {
        public static Stream LoadInput(int day, bool getSample = false)
        {
            if (!TryGetRunningLocation(out string? root) || root == null)
                throw new Exception();

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
