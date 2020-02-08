namespace Algorithms.Core.SearchAlgorithms
{
    using System.Collections.Generic;
    using System.Linq;

    public class BinarySearchAlgorithm<T>
    {
        public BinarySearchAlgorithmResult Search(IList<T> listForSearch, T searchingElement, IComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            if (listForSearch == null || listForSearch.Count == 0)
            {
                return new BinarySearchAlgorithmResult(false);
            }

            if (listForSearch.Count == 1)
            {
                return listForSearch.First().Equals(searchingElement)
                    ? new BinarySearchAlgorithmResult(true, 0)
                    : new BinarySearchAlgorithmResult(false);
            }

            var indexOfTheMiddleElement = (listForSearch.Count - 1) / 2;

            if (listForSearch[indexOfTheMiddleElement].Equals(searchingElement))
            {
                return new BinarySearchAlgorithmResult(true, indexOfTheMiddleElement);
            }

            if (comparer.Compare(listForSearch[indexOfTheMiddleElement], searchingElement) > 1)
            {
                return Search(
                    listForSearch.Take(listForSearch.Count - indexOfTheMiddleElement - 2).ToArray(),
                    searchingElement,
                    comparer);
            }

            return Search(
                listForSearch.Skip(indexOfTheMiddleElement == 0 ? 1 : indexOfTheMiddleElement).ToArray(),
                searchingElement,
                comparer);
        }
    }
}
