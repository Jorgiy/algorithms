namespace Algorithms.Core.DataStructures
{
    using System.Collections.Generic;

    public interface IGraph<T>
    {
        Dictionary<T, HashSet<T>> Adjacencies { get; }

        void AddVertex(T vertex);

        void AddEdge(Edge<T> edge);

        bool RemoveVertex(T vertex);

        void RemoveEdge(Edge<T> edge);
    }
}