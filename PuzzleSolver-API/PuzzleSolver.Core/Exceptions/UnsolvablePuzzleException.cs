using System;

namespace PuzzleSolver.Core.Exceptions
{
    internal class UnsolvablePuzzleException : Exception
    {
        public UnsolvablePuzzleException()
        {
        }

        public UnsolvablePuzzleException(string? message) : base(message)
        {
        }
    }
}
