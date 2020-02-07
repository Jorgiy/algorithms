namespace Algorithms.Core.TraversingAlgorithms
{
    using System.Collections.Generic;
    using Algorithms.Core.DataStructures;

    public class DepthFirstSearchAlgorithm : ITraversingAlgorithm
    {
        public HashSet<T> Traverse<T>(IGraph<T> graph, T startVertex)
        {
            var discovered = new HashSet<T>();

            if (!graph.Adjacencies.ContainsKey(startVertex))
            {
                return discovered;
            }

            var stack = new DataStructures.Stack<T>();
            stack.Push(startVertex);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (discovered.Contains(vertex))
                {
                    continue;
                }

                discovered.Add(vertex);

                foreach (var neighbor in graph.Adjacencies[vertex])
                {
                    if (!discovered.Contains(neighbor))
                    {
                        stack.Push(neighbor);
                    }
                }
            }

            return discovered;
        }
    }
}
