using PuzzleSolver.Abstractions;
using PuzzleSolver.DB.Repositories;
using PuzzleSolver.DB.Repositories.Puzzle;

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
