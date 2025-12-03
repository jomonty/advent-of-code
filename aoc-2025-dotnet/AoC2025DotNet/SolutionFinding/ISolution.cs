namespace AoC2025DotNet.SolutionFinding
{
    public interface ISolution
    {
        public int Day { get; }
        public void Solve(int part);
    }
}
