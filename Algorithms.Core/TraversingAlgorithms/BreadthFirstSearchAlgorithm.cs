namespace Algorithms.Core.TraversingAlgorithms
{
    using System.Collections.Generic;
    using System.Linq;
    using Algorithms.Core.DataStructures;
    using Algorithms.Core.SortingsImplementations;

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

        public BreadthFirstSearchResult<T> SearchShortestWay<T>(IGraph<T> graph, T startVertex, T lookingForVertex)
        {
            var fullPath = new Dictionary<T, T>();

            var shortestPath = new HashSet<T>();

            if (!graph.Adjacencies.ContainsKey(startVertex) || !graph.Adjacencies.ContainsKey(lookingForVertex))
            {
                return new BreadthFirstSearchResult<T>(false);
            }

            var queue = new DataStructures.Queue<T>();
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                void GoThroughAdjacencies()
                {
                    foreach (var neighbor in graph.Adjacencies[vertex])
                    {
                        if (!fullPath.ContainsKey(neighbor))
                        {
                            fullPath[neighbor] = vertex;

                            if (neighbor.Equals(lookingForVertex))
                            {
                                return;
                            }

                            queue.Enqueue(neighbor);
                        }
                    }
                }

                GoThroughAdjacencies();
            }

            if (!fullPath.TryGetValue(lookingForVertex, out _))
            {
                return new BreadthFirstSearchResult<T>(false);
            }

            var current = lookingForVertex;

            while (!current.Equals(startVertex))
            {
                shortestPath.Add(current);
                current = fullPath[current];
            }

            shortestPath.Add(startVertex);
            shortestPath = shortestPath.Reverse().ToHashSet();

            return new BreadthFirstSearchResult<T>(true, shortestPath);
        }
    }
}
