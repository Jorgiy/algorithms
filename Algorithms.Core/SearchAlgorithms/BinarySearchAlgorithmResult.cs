namespace Algorithms.Core.SearchAlgorithms
{
    using System;
    using static Constants;

    public class BinarySearchAlgorithmResult
    {
        private readonly int? _index;

        public BinarySearchAlgorithmResult(bool success, int? index = null)
        {
            Success = success;
            _index = index;
        }

        public bool Success { get; }

        public int? Index => Success ? _index : throw new Exception(UnsuccessfulSearchResult);
    }
}
