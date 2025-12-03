namespace AoC2025DotNet.SolutionFinding
{
    public interface ISolutionFactory
    {
        IEnumerable<ISolution> GetAllSolutions();
        ISolution GetSolution(int day);
    }
}
