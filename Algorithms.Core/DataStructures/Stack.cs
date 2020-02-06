namespace Algorithms.Core.DataStructures
{
    using System;
    using static Constants;

    public class Stack<T>
    {
        private Node<T> _top;

        public Stack()
        {
        }

        public Stack(T firstElement)
        {
            Push(firstElement);
        }

        public int Count { get; private set; }

        public void Push(T data)
        {
            var newNode = new Node<T>(data);

            if (_top == null)
            {
                _top = newNode;
            }
            else
            {
                newNode.Previous = _top;
                _top = newNode;
            }

            Count++;
        }

        public T Pop()
        {
            if (_top == null)
            {
                throw new Exception(StackErrorMessage);
            }

            Count--;

            var result = _top.Data;

            _top = _top.Previous;

            return result;
        }
    }
}
