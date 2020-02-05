namespace Algorithms.Core.DataStructures
{
    using System;
    using static Constants;

    public class Queue<T>
    {
        private Node<T> _firstNode;

        private Node<T> _lastNode;

        public Queue()
        {
        }

        public Queue(T firstElement)
        {
            Enqueue(firstElement);
        }

        public int Count { get; private set; }

        public void Enqueue(T data)
        {
            var newNode = new Node<T>(data);

            if (_firstNode == null)
            {
                _firstNode = newNode;
                _lastNode = _firstNode;
            }
            else
            {
                _lastNode.Next = newNode;
                _lastNode = _lastNode.Next;
            }

            Count++;
        }

        public T Dequeue()
        {
            if (_firstNode == null)
            {
                throw new Exception(QueueErrorMessage);
            }

            Count--;

            var result = _firstNode.Data;

            _firstNode = _firstNode.Next;

            return result;
        }
    }
}
