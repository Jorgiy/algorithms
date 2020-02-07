namespace Algorithms.Core.DataStructures
{
    using System.Collections.Generic;

    public class SimpleGraph<T> : IGraph<T>
    {
        public SimpleGraph()
        {
        }

        public SimpleGraph(IEnumerable<T> vertices, IEnumerable<Edge<T>> edges)
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
            if (Adjacencies.ContainsKey(edge.Vertex1) && Adjacencies.ContainsKey(edge.Vertex2))
            {
                Adjacencies[edge.Vertex1].Add(edge.Vertex2);
                Adjacencies[edge.Vertex2].Add(edge.Vertex1);
            }
        }

        public void RemoveVertex(T vertex)
        {
            Adjacencies.Remove(vertex);

            foreach (var adjacency in Adjacencies)
            {
                adjacency.Value.Remove(vertex);
            }
        }

        public void DeleteEdge(Edge<T> edge)
        {
            if (Adjacencies.ContainsKey(edge.Vertex1) && Adjacencies.ContainsKey(edge.Vertex2))
            {
                Adjacencies[edge.Vertex1].Remove(edge.Vertex2);
                Adjacencies[edge.Vertex2].Remove(edge.Vertex1);
            }
        }
    }
}
