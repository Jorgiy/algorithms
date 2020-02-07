namespace Algorithms.Core.DataStructures
{
    using System.Collections.Generic;

    public interface IGraph<T>
    {
        Dictionary<T, HashSet<T>> Adjacencies { get; }

        void AddVertex(T vertex);

        void AddEdge(Edge<T> edge);

        void RemoveVertex(T vertex);

        void DeleteEdge(Edge<T> edge);
    }
}