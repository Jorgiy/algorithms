namespace Algorithms.Tests
{
    using System;
    using Algorithms.Core.DataStructures;
    using Xunit;
    using static Core.Constants;

    public class QueueTests
    {
        [Fact]
        public void EnqueueDequeue_AddElementsAndDeque_FirstDequeued()
        {
            // arrange
            var queue = new Queue<int>(1);

            // act
            queue.Enqueue(2);
            queue.Enqueue(3);

            // assert
            Assert.Equal(1, queue.Dequeue());
        }

        [Fact]
        public void EnqueueDequeue_AddElementsAndDequeAll_LastDequeued()
        {
            // arrange
            var queue = new Queue<int>(1);

            // act
            queue.Enqueue(2);
            queue.Enqueue(3);
            var countOfQueueElements = queue.Count;

            for (var i = 0; i < countOfQueueElements - 1; i++)
            {
                queue.Dequeue();
            }

            // assert
            Assert.Equal(3, queue.Dequeue());
        }

        [Fact]
        public void EnqueueDequeue_AddElementsAndDequeMoreThanExistInQueue_ThrowsException()
        {
            // arrange
            var queue = new Queue<int>(1);

            // act
            queue.Enqueue(2);
            queue.Enqueue(3);
            var countOfQueueElements = queue.Count;

            for (var i = 0; i < countOfQueueElements; i++)
            {
                queue.Dequeue();
            }

            // assert
            var exception = Assert.Throws<Exception>(() => queue.Dequeue());
            Assert.Equal(QueueErrorMessage, exception.Message);
        }

        [Fact]
        public void EnqueueDequeue_AddElementsAndDequeueLessThanEnqueued_QueueReturnsCorrectCounts()
        {
            // arrange
            var queue = new Queue<int>();
            var numberOfEnqueued = 4;
            var numberOfDequeued = numberOfEnqueued - 2;

            // act
            for (var i = 0; i < numberOfEnqueued; i++)
            {
                queue.Enqueue(1);
            }

            var queueElementsCountAfterEnqueue = queue.Count;

            for (var i = 0; i < numberOfDequeued; i++)
            {
                queue.Dequeue();
            }

            var queueElementsCountAfterDequeue = queue.Count;

            // assert
            Assert.Equal(4, queueElementsCountAfterEnqueue);
            Assert.Equal(2, queueElementsCountAfterDequeue);
        }
    }
}
