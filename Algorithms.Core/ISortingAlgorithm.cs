namespace Algorithms.Core
{
    using System.Collections.Generic;

    public interface ISortingAlgorithm<T>
    {
        void Sort(IList<T> collectionToSort, IComparer<T> comparer = null);
    }
}
