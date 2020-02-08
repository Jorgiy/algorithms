namespace Algorithms.Tests
{
    using Algorithms.Core.SearchAlgorithms;
    using Algorithms.Core.SortingsAlgorithms;
    using Xunit;

    public class BinarySearchAlgorithmTests
    {
        [Fact]
        public void Search_SortedArray_ElementFound()
        {
            // arrange
            var array = new[] { 5, 7, 8, 1, 4, 98, 6, 2, 0, 12, 123 };
            new BubbleSort<int>().Sort(array);
            var searchAlgorithm = new BinarySearchAlgorithm<int>();
            var lookingForElement = 12;

            // act
            var elementSearchResult = searchAlgorithm.Search(array, lookingForElement);

            // assert
            Assert.True(elementSearchResult.Success);
            Assert.Equal(8, elementSearchResult.Index);
        }

        [Fact]
        public void Search_UnsortedArray_ElementMotFound()
        {
            // arrange
            var array = new[] { 5, 7, 8, 1, 4, 98, 6, 2, 0, 12, 123 };
            var searchAlgorithm = new BinarySearchAlgorithm<int>();
            var lookingForElement = 12;

            // act
            var elementSearchResult = searchAlgorithm.Search(array, lookingForElement);

            // assert
            Assert.False(elementSearchResult.Success);
        }

        [Fact]
        public void Search_EmptyArray_ElementMotFound()
        {
            // arrange
            var array = new int[] { };
            var searchAlgorithm = new BinarySearchAlgorithm<int>();
            var lookingForElement = 12;

            // act
            var elementSearchResult = searchAlgorithm.Search(array, lookingForElement);

            // assert
            Assert.False(elementSearchResult.Success);
        }

        [Fact]
        public void Search_InputArrayAndSearchNotExistingElement_ElementMotFound()
        {
            // arrange
            var array = new[] { 5, 7, 8, 1, 4, 98, 6, 2, 0, 12, 123 };
            new BubbleSort<int>().Sort(array);
            var searchAlgorithm = new BinarySearchAlgorithm<int>();
            var lookingForElement = 100;

            // act
            var elementSearchResult = searchAlgorithm.Search(array, lookingForElement);

            // assert
            Assert.False(elementSearchResult.Success);
        }

        [Fact]
        public void Search_OneElementArrayInput_ElementFound()
        {
            // arrange
            var array = new[] { 12 };
            var searchAlgorithm = new BinarySearchAlgorithm<int>();
            var lookingForElement = 12;

            // act
            var elementSearchResult = searchAlgorithm.Search(array, lookingForElement);

            // assert
            Assert.True(elementSearchResult.Success);
            Assert.Equal(0, elementSearchResult.Index);
        }

        [Fact]
        public void Search_TwoElementArrayInput_ElementFound()
        {
            // arrange
            var array = new[] { 12, 13 };
            var searchAlgorithm = new BinarySearchAlgorithm<int>();
            var lookingForElement = 13;

            // act
            var elementSearchResult = searchAlgorithm.Search(array, lookingForElement);

            // assert
            Assert.True(elementSearchResult.Success);
            Assert.Equal(1, elementSearchResult.Index);
        }
    }
}
