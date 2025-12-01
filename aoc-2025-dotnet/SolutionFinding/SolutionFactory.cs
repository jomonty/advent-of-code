namespace AoC2025DotNet.SolutionFinding
{
    internal class SolutionFactory(IEnumerable<ISolution> solutions) : ISolutionFactory
    {
        private readonly IEnumerable<ISolution> _solutions = solutions;

        public ISolution GetSolution(int day)
        {
            return _solutions.Single(s => s.Day == day);
        }
    }
}
