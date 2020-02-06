namespace Algorithms.Core.DataStructures
{
    public class Edge<T>
    {
        public Edge(T vertex1, T vertex2)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
        }

        public T Vertex1 { get; }

        public T Vertex2 { get; }
    }
}
