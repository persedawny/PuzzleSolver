using Microsoft.Extensions.DependencyInjection;
using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core
{
    public class DependencyConfiguration
    {
        public static IServiceCollection Configure(IServiceCollection services)
        {
            services.AddSingleton<IPuzzleServiceProvider, PuzzleServiceProvider>();
            return services;
        }
    }
}
