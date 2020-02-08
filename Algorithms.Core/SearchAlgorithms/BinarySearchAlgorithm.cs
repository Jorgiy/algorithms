namespace Algorithms.Core.SearchAlgorithms
{
    using System.Collections.Generic;

    public class BinarySearchAlgorithm<T>
    {
        private readonly IComparer<T> _comparer;

        public BinarySearchAlgorithm()
        {
            _comparer = Comparer<T>.Default;
        }

        public BinarySearchAlgorithm(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public BinarySearchAlgorithmResult Search(IList<T> listForSearch, T searchingElement)
        {
            if (listForSearch == null || listForSearch.Count == 0)
            {
                return new BinarySearchAlgorithmResult(false);
            }

            return Search(new SearchInput
            {
                ListForSearch = listForSearch,
                LeftBoundIndex = 0,
                RightBoundIndex = listForSearch.Count - 1,
                SearchingElement = searchingElement
            });
        }

        private BinarySearchAlgorithmResult Search(SearchInput searchInput)
        {
            if (searchInput.LeftBoundIndex == searchInput.RightBoundIndex)
            {
                return searchInput.ListForSearch[searchInput.RightBoundIndex].Equals(searchInput.SearchingElement)
                    ? new BinarySearchAlgorithmResult(true, searchInput.RightBoundIndex)
                    : new BinarySearchAlgorithmResult(false);
            }

            var indexOfTheMiddleElement = searchInput.LeftBoundIndex + (searchInput.RightBoundIndex - searchInput.LeftBoundIndex) / 2;

            if (searchInput.ListForSearch[indexOfTheMiddleElement].Equals(searchInput.SearchingElement))
            {
                return new BinarySearchAlgorithmResult(true, indexOfTheMiddleElement);
            }

            if (_comparer.Compare(searchInput.ListForSearch[indexOfTheMiddleElement], searchInput.SearchingElement) > 0)
            {
                return Search(new SearchInput
                {
                    ListForSearch = searchInput.ListForSearch,
                    LeftBoundIndex = searchInput.LeftBoundIndex,
                    RightBoundIndex = indexOfTheMiddleElement - 1,
                    SearchingElement = searchInput.SearchingElement
                });
            }

            return Search(new SearchInput
            {
                ListForSearch = searchInput.ListForSearch,
                LeftBoundIndex = indexOfTheMiddleElement + 1,
                RightBoundIndex = searchInput.RightBoundIndex,
                SearchingElement = searchInput.SearchingElement
            });
        }

        private struct SearchInput
        {
            public IList<T> ListForSearch { get; set; }

            public T SearchingElement { get; set; }

            public int LeftBoundIndex { get; set; }

            public int RightBoundIndex { get; set; }
        }
    }
}
