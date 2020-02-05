namespace Algorithms.App
{
    using System;
    using Algorithms.Core;

    public class Program
    {
        private static int[] ArrayToSort => new[] { 5, 7, 8, 1, 4, 98, 6, 2, 0, 12, 123 };

        public static void Main(string[] args)
        {
            var array = ArrayToSort;

            // Bubble sort
            BubbleSort.Sort(array);
            Console.Write($"Bubble sort result: {string.Join(", ", array)}");
        }
    }
}
