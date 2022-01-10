using System;

namespace PuzzleSolver.Models.Exceptions
{
    public class UnsolvablePuzzleException : Exception
    {
        public UnsolvablePuzzleException()
        {
        }

        public UnsolvablePuzzleException(string message) : base(message)
        {
        }
    }
}
