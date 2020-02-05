namespace Algorithms.Tests
{
    using System;
    using System.Collections.Generic;

    public class EnumerableEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        private readonly IEqualityComparer<T> _elementsComparer;

        public EnumerableEqualityComparer()
        {
            _elementsComparer = EqualityComparer<T>.Default;
        }

        public EnumerableEqualityComparer(IEqualityComparer<T> elementsComparer)
        {
            _elementsComparer = elementsComparer ?? throw new ArgumentNullException(nameof(elementsComparer));
        }

        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if ((x != null && y == null) || x == null)
            {
                return false;
            }

            var equals = false;

            var xCollectionIsEmpty = true;

            using (var xEnumerator = x.GetEnumerator())
            using (var yEnumerator = y.GetEnumerator())
            {
                while (xEnumerator.MoveNext())
                {
                    xCollectionIsEmpty = false;

                    var yHasElement = yEnumerator.MoveNext();
                    equals = yHasElement && _elementsComparer.Equals(xEnumerator.Current, yEnumerator.Current);

                    if (equals == false)
                    {
                        break;
                    }
                }

                if (yEnumerator.MoveNext())
                {
                    equals = false;
                }

                if (xCollectionIsEmpty)
                {
                    equals = yEnumerator.MoveNext();
                }
            }

            return equals;
        }

        public int GetHashCode(IEnumerable<T> obj)
        {
            var hashCode = 0;

            foreach (var element in obj)
            {
                if (element == null)
                {
                    hashCode ^= 0;
                }

                hashCode ^= obj.GetHashCode();
            }

            return hashCode;
        }
    }
}
