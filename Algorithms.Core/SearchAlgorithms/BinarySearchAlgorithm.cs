namespace Algorithms.Core.SearchAlgorithms
{
    using System.Collections.Generic;
    using System.Linq;

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

            if (_comparer.Compare(listForSearch[indexOfTheMiddleElement], searchingElement) > 1)
            {
                return Search(listForSearch.Take(listForSearch.Count - indexOfTheMiddleElement - 2).ToArray(), searchingElement);
            }

            return Search(listForSearch.Skip(indexOfTheMiddleElement == 0 ? 1 : indexOfTheMiddleElement).ToArray(), searchingElement);
        }
    }
}
