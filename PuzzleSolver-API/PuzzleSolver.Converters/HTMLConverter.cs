﻿using PuzzleSolver.Abstractions;

namespace PuzzleSolver.Core.Converters
{
    public class HtmlConverter<T> : IConverter<T>
    {
        public string Convert(T value)
        {
            throw new System.NotImplementedException();
        }

        public T Deserialize(string convertValue)
        {
            throw new System.NotImplementedException();
        }
    }
}