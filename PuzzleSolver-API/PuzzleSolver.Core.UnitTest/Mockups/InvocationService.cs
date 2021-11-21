using System;
using System.Collections.Generic;

namespace PuzzleSolver.Core.UnitTest.Mockups
{
    internal class InvocationService
    {
        private Dictionary<string, int> invocations = new Dictionary<string, int>();

        public void AddOrUpdateInvocation(string key)
        {
            if (invocations.ContainsKey(key))
                invocations[key] = invocations[key]++;
            else
                invocations.Add(key, 1);
        }

        private int GetInvocationValue(string key)
        {
            if (invocations.ContainsKey(key))
                return invocations[key];

            throw new Exception("Key not found!");
        }
    }
}
