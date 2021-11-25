﻿namespace PuzzleSolver.Abstractions
{
    public abstract class GeneratorTemplate
    {
        private readonly IValidator validator;

        public GeneratorTemplate(IValidator validator)
        {
            this.validator = validator;
        }

        public abstract string Generate(int knownFields);
    }
}