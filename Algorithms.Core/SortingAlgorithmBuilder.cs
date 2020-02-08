namespace Algorithms.Core
{
    using System;
    using System.Collections.Generic;
    using Algorithms.Core.SortingsAlgorithms;

    public class SortingAlgorithmBuilder<T>
    {
        private readonly Dictionary<SortingAlgorithmType, ISortingAlgorithm<T>> _algorithmsByTypes =
            new Dictionary<SortingAlgorithmType, ISortingAlgorithm<T>>
            {
                { SortingAlgorithmType.Bubble, new BubbleSort<T>() }
            };

        public ISortingAlgorithm<T> Build(SortingAlgorithmType sortingAlgorithmType)
        {
            if (_algorithmsByTypes.TryGetValue(sortingAlgorithmType, out ISortingAlgorithm<T> algorithmInstance))
            {
                return algorithmInstance;
            }

            throw new ArgumentException("There is no sorting for current type", nameof(sortingAlgorithmType));
        }
    }
}
