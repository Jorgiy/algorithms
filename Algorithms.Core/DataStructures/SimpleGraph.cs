namespace Algorithms.Core.DataStructures
{
    using System;
    using System.Collections.Generic;
    using static Constants;

    public class SimpleGraph<T> : IGraph<T>
    {
        public SimpleGraph(IEqualityComparer<T> equalityComparer = null)
        {
            Adjacencies = new Dictionary<T, HashSet<T>>(equalityComparer);
        }

        public SimpleGraph(IEnumerable<T> vertices, IEnumerable<Edge<T>> edges, IEqualityComparer<T> equalityComparer = null)
            : this(equalityComparer)
        {
            foreach (var vertex in vertices)
            {
                AddVertex(vertex);
            }

            foreach (var edge in edges)
            {
                AddEdge(edge);
            }
        }

        public Dictionary<T, HashSet<T>> Adjacencies { get; } = new Dictionary<T, HashSet<T>>();

        public void AddVertex(T vertex)
        {
            Adjacencies[vertex] = new HashSet<T>();
        }

        public void AddEdge(Edge<T> edge)
        {
            ValidateEdge(edge);
            Adjacencies[edge.Vertex1].Add(edge.Vertex2);
            Adjacencies[edge.Vertex2].Add(edge.Vertex1);
        }

        public bool RemoveVertex(T vertex)
        {
            var removed = Adjacencies.Remove(vertex);

            foreach (var adjacency in Adjacencies)
            {
                adjacency.Value.Remove(vertex);
            }

            return removed;
        }

        public void RemoveEdge(Edge<T> edge)
        {
            ValidateEdge(edge);
            Adjacencies[edge.Vertex1].Remove(edge.Vertex2);
            Adjacencies[edge.Vertex2].Remove(edge.Vertex1);
        }

        private void ValidateEdge(Edge<T> edge)
        {
            var exceptions = new List<Exception>();

            if (!Adjacencies.ContainsKey(edge.Vertex1))
            {
                exceptions.Add(new ArgumentException(string.Format(NoSuchVertexInGraph, edge.Vertex1)));
            }

            if (!Adjacencies.ContainsKey(edge.Vertex2))
            {
                exceptions.Add(new ArgumentException(string.Format(NoSuchVertexInGraph, edge.Vertex2)));
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
