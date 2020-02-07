namespace Algorithms.Core.TraversingAlgorithms
{
    using System.Collections.Generic;
    using Algorithms.Core.DataStructures;

    public class BreadthFirstSearchAlgorithm : ITraversingAlgorithm
    {
        public HashSet<T> Traverse<T>(IGraph<T> graph, T startVertex)
        {
            var discovered = new HashSet<T>();

            if (!graph.Adjacencies.ContainsKey(startVertex))
            {
                return discovered;
            }

            var queue = new DataStructures.Queue<T>();
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (discovered.Contains(vertex))
                {
                    continue;
                }

                discovered.Add(vertex);

                foreach (var neighbor in graph.Adjacencies[vertex])
                {
                    if (!discovered.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return discovered;
        }

        public BreadthFirstSearchResult<T> ShortestWay<T>(IGraph<T> graph, T startVertex, T lookingForVertex)
        {
            var discovered = new HashSet<T>();

            if (!graph.Adjacencies.ContainsKey(startVertex) || !graph.Adjacencies.ContainsKey(lookingForVertex))
            {
                return new BreadthFirstSearchResult<T>(false);
            }

            var queue = new DataStructures.Queue<T>();
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (vertex.Equals(lookingForVertex))
                {
                    return new BreadthFirstSearchResult<T>(true, discovered);
                }

                if (discovered.Contains(vertex))
                {
                    continue;
                }

                discovered.Add(vertex);

                foreach (var neighbor in graph.Adjacencies[vertex])
                {
                    if (!discovered.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return new BreadthFirstSearchResult<T>(false);
        }
    }
}
