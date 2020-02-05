namespace Algorithms.Core
{
    using System.Collections.Generic;

    public static class BubbleSort
    {
        public static void Sort<T>(IList<T> collectionToSort, IComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            for (var i = 0; i <= collectionToSort.Count - 2; i++)
            {
                for (var j = 0; j <= collectionToSort.Count - 2; j++)
                {
                    if (comparer.Compare(collectionToSort[j], collectionToSort[j + 1]) > 0)
                    {
                        var temporaryElement = collectionToSort[j + 1];
                        collectionToSort[j + 1] = collectionToSort[j];
                        collectionToSort[j] = temporaryElement;
                    }
                }
            }
        }
    }
}
