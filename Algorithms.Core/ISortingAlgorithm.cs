namespace Algorithms.Core
{
    using System.Collections.Generic;

    public interface ISortingAlgorithm<T>
    {
        void Sort(IList<T> listToSort, IComparer<T> comparer = null);
    }
}
