using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.Models.DTO;
using PuzzleSolver.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PuzzleSolver.Abstractions
{
    public interface IDatabaseController
    {
        Task<IActionResult> GetAllNamesAsync();
        Task<IActionResult> GetPuzzleByIDAsync(string id);
        Task<IActionResult> InsertPuzzleIntoDatabaseAsync(IEnumerable<PuzzleFieldDTO> fields, PuzzleEntityType type);
    }
}
