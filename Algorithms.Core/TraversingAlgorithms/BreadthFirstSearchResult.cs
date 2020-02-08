namespace Algorithms.Core.TraversingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using static Constants;

    public class BreadthFirstSearchResult<T>
    {
        private readonly HashSet<T> _route;

        public BreadthFirstSearchResult(bool success, HashSet<T> route = null)
        {
            Success = success;
            _route = route;
        }

        public bool Success { get; }

        public HashSet<T> Route => Success ? _route : throw new Exception(BreadthFirstNotFoundResultErrorMessage);
    }
}
