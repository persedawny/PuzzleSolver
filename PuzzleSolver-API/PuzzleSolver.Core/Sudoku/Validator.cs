using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core.Sudoku
{
    internal class Validator : IValidator
    {
        public bool IsValid(PuzzleTemplate puzzle)
        {
            // TODO: Implement after unit tests
            //throw new System.NotImplementedException();
            foreach (Field field in puzzle.fields) {
                foreach (Field s in puzzle.fields)
                {
                    if (s.Index != field.Index && s.Value != null && field.Value != null)
                    {
                        if (s.GetColumnID() == field.GetColumnID())
                        {
                            if (s.Value == field.Value)
                            {
                                return false;
                            }
                        }

                        if (s.GetRowID() == field.GetRowID())
                        {
                            if (s.Value == field.Value)
                            {
                                return false;
                            }
                        }

                        if (s.GetBlockID() == field.GetBlockID())
                        {
                            if (s.Value == field.Value)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool IsValidMove(PuzzleTemplate puzzle)
        {
            // TODO: Implement after unit tests
            throw new System.NotImplementedException();
        }
    }
}
