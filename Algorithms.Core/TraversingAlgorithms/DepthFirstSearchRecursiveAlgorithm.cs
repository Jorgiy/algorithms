namespace Algorithms.Core.TraversingAlgorithms
{
    using System.Collections.Generic;
    using Algorithms.Core.DataStructures;

    public class DepthFirstSearchRecursiveAlgorithm : ITraversingAlgorithm
    {
        public HashSet<T> Traverse<T>(IGraph<T> graph, T startVertex)
        {
            var discovered = new HashSet<T>();

            return TraverseRecursive(graph, startVertex, discovered);
        }

        private HashSet<T> TraverseRecursive<T>(IGraph<T> graph, T startVertex, HashSet<T> discovered)
        {
            if (!graph.Adjacencies.ContainsKey(startVertex))
            {
                return discovered;
            }

            discovered.Add(startVertex);

            foreach (var neighbor in graph.Adjacencies[startVertex])
            {
                if (!discovered.Contains(neighbor))
                {
                    TraverseRecursive(graph, neighbor, discovered);
                }
            }

            return discovered;
        }
    }
}
