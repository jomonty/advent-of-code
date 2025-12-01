namespace AoC2025DotNet.SolutionFinding
{
    internal interface ISolution
    {
        public int Day { get; }
        public void Solve(int part);
    }
}
