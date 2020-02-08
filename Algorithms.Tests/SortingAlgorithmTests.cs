namespace Algorithms.Tests
{
    using System;
    using System.Collections.Generic;
    using Algorithms.Core;
    using Xunit;

    public class SortingAlgorithmTests
    {
        public static IEnumerable<object[]> GetSearchingAlgorithms()
        {
            foreach (var sortingAlgorithmType in Enum.GetValues(typeof(SortingAlgorithmType)))
            {
                yield return new[] { sortingAlgorithmType };
            }
        }

        [Theory]
        [MemberData(nameof(GetSearchingAlgorithms))]
        public void Sort_PassArrayOfIntegers_SortedProperly(SortingAlgorithmType sortingAlgorithmType)
        {
            // arrange
            var sortingAlgorithm = new SortingAlgorithmBuilder<int>().Build(sortingAlgorithmType);
            var arrayForSorting = new[] { 5, 7, 8, 1, 4, 98, 6, 2, 0, 12, 123 };

            // act
            sortingAlgorithm.Sort(arrayForSorting);

            // assert
            var sortedArray = new[] { 0, 1, 2, 4, 5, 6, 7, 8, 12, 98, 123 };
            Assert.Equal(sortedArray, arrayForSorting, new EnumerableEqualityComparer<int>());
        }
    }
}
