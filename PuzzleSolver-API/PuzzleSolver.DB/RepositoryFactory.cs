using PuzzleSolver.Abstractions;
using PuzzleSolver.DB.Repositories;

namespace PuzzleSolver.DB
{
    public class RepositoryFactory
    {
        public static IRepository<PuzzleEntity> GetPuzzleRepository()
        {
            return new PuzzleRepository(new CollectionProvider());
        }
    }
}
