namespace Algorithms.Tests
{
    using Algorithms.Core;
    using Xunit;

    public class SortingAlgorithmTests
    {
        [Theory]
        [InlineData(SortingAlgorithmType.Bubble)]
        public void Sort_PassArrayOfIntegers_SortedProperly(SortingAlgorithmType sortingAlgorithmType)
        {
            // arrange
            var sortingAlgorithm = new SortingAlgorithmBuilder<int>().Build(sortingAlgorithmType);
            var arrayForSorting = new[] { 5, 7, 8, 1, 4, 98, 6, 2, 0, 12, 123 };

            // act
            sortingAlgorithm.Sort(arrayForSorting);

            // assert
            // TODO:insert collection checking assertion
        }
    }
}
