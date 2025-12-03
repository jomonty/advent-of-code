using AoC2025DotNet.Benchmarks.Dependencies;
using AoC2025DotNet.Helpers;
using AoC2025DotNet.SolutionFinding;
using AoC2025DotNet.SolutionFinding.Solutions;
using BenchmarkDotNet.Attributes;
using Microsoft.VSDiagnostics;

namespace AoC2025DotNet.Benchmarks
{
    // For more information on the VS BenchmarkDotNet Diagnosers see https://learn.microsoft.com/visualstudio/profiling/profiling-with-benchmark-dotnet
    // [CPUUsageDiagnoser]
    [MemoryDiagnoser]
    public class Benchmarks
    {
        //public IEnumerable<ISolution> Solutions()
        //{
        //    IConsoleWriter consoleWriter = new NullConsoleWriter();

        //    yield return new Day01(consoleWriter);
        //    yield return new Day02(consoleWriter);
        //}

        //[Benchmark]
        //[ArgumentsSource(nameof(Solutions))]
        //public void RunSolutions(ISolution solution)
        //{
        //    solution.Solve(0);
        //}

        private static readonly IConsoleWriter s_consoleWriter = new NullConsoleWriter();
        private readonly ISolution _solution = new Day02(s_consoleWriter);

        [Benchmark]
        public void SolutionPartOne()
        {
            _solution.Solve(1);
        }

        [Benchmark]
        public void SolutionPartTwo()
        {
            _solution.Solve(2);
        }
    }
}
