using System.CommandLine;
using System.Reflection;
using AoC2025DotNet.Helpers;
using AoC2025DotNet.SolutionFinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AoC2025DotNet
{
    internal class Program
    {
        static int Main(string[] args)
        {
            // Input data should be located in Inputs/DayXX/day_XX.txt relative to the running assembly location
            // Input data not included per AoC policy

            Option<int> day = new(name: "--day")
            {
                DefaultValueFactory = (_) => 1,
                Description = "The day of the solution to run (1-25)"
            };

            Option<int> part = new(name: "--part")
            {
                DefaultValueFactory = (_) => 0,
                Description = "The part of the solution to run (0 for both, 1 or 2)"
            };

            Option<bool> debug = new(name: "--debug")
            {
                Description = "Enable debug output",
            };

            RootCommand cmd = new("AoC 2025 Solutions");
            cmd.Options.Add(day);
            cmd.Options.Add(part);
            cmd.Options.Add(debug);

            cmd.SetAction(parseResult =>
            {
                IHost host = CreateHost(args, parseResult.GetValue(debug));
                ISolutionFactory slnFactory = host.Services.GetRequiredService<ISolutionFactory>();

                ISolution sln = slnFactory.GetSolution(parseResult.GetValue(day));
                sln.Solve(parseResult.GetValue(part));
                return 0;
            });

            ParseResult parseResult = cmd.Parse(args);
            return parseResult.Invoke();
        }

        private static IHost CreateHost(string[] args, bool debug = false)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    ConfigureServices(services);

                    services.Configure<ConsoleWriterOptions>(opts =>
                    {
                        if (debug)
                            opts.ConsoleMessageLevel = ConsoleMessageLevel.Debug;
                    });
                })
                .Build();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISolutionFactory, SolutionFactory>();
            services.AddSingleton<IConsoleWriter, ConsoleWriter>();

            IEnumerable<Type> solutions = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.IsClass
                    && !type.IsAbstract
                    && typeof(ISolution).IsAssignableFrom(type)
                    && type != typeof(ISolution));

            foreach (Type type in solutions)
            {
                services.AddSingleton(typeof(ISolution), type);
            }
        }
    }
}
