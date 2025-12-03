namespace AoC2025DotNet.SolutionFinding
{
    internal interface ISolutionFactory
    {
        IEnumerable<ISolution> GetAllSolutions();
        ISolution GetSolution(int day);
    }
}
