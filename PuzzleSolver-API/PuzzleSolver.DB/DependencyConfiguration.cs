using Microsoft.Extensions.DependencyInjection;
using PuzzleSolver.Abstractions;
using PuzzleSolver.DB.Repositories;
using PuzzleSolver.Models.Entities;

namespace PuzzleSolver.DB
{
    public class DependencyConfiguration
    {
        public static IServiceCollection Configure(IServiceCollection services)
        {
            services.AddSingleton<ICollectionProvider<PuzzleEntity>, PuzzleCollectionProvider>();
            services.AddSingleton<IRepository<PuzzleEntity>, PuzzleRepository>();
            return services;
        }
    }
}
