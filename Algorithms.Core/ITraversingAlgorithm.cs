namespace Algorithms.Core
{
    using System.Collections.Generic;
    using Algorithms.Core.DataStructures;

    public interface ITraversingAlgorithm
    {
        HashSet<T> Traverse<T>(IGraph<T> graph, T startVertex);
    }
}