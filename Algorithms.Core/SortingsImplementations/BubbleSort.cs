namespace Algorithms.Core.SortingsImplementations
{
    using System.Collections.Generic;

    public class BubbleSort<T> : ISortingAlgorithm<T>
    {
        public void Sort(IList<T> listToSort, IComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            for (var i = 0; i <= listToSort.Count - 2; i++)
            {
                for (var j = 0; j <= listToSort.Count - 2; j++)
                {
                    if (comparer.Compare(listToSort[j], listToSort[j + 1]) > 0)
                    {
                        var temporaryElement = listToSort[j + 1];
                        listToSort[j + 1] = listToSort[j];
                        listToSort[j] = temporaryElement;
                    }
                }
            }
        }
    }
}
