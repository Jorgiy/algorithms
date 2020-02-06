namespace Algorithms.Tests
{
    using System;
    using Algorithms.Core.DataStructures;
    using Xunit;
    using static Core.Constants;

    public class StackTests
    {
        [Fact]
        public void PushPop_AddElementsAndPop_LastPopped()
        {
            // arrange
            var stack = new Stack<int>(1);

            // act
            stack.Push(2);
            stack.Push(3);

            // assert
            Assert.Equal(3, stack.Pop());
        }

        [Fact]
        public void PushPop_AddElementsAndPopAll_FirstPopped()
        {
            // arrange
            var stack = new Stack<int>(1);

            // act
            stack.Push(2);
            stack.Push(3);
            var countOfElementsInStack = stack.Count;

            for (var i = 0; i < countOfElementsInStack - 1; i++)
            {
                stack.Pop();
            }

            // assert
            Assert.Equal(1, stack.Pop());
        }

        [Fact]
        public void PushPop_AddElementsAndPopMoreThanExistInStack_ThrowsException()
        {
            // arrange
            var stack = new Stack<int>(1);

            // act
            stack.Push(2);
            stack.Push(3);
            var countOfElementsInStack = stack.Count;

            for (var i = 0; i < countOfElementsInStack; i++)
            {
                stack.Pop();
            }

            // assert
            var exception = Assert.Throws<Exception>(() => stack.Pop());
            Assert.Equal(StackErrorMessage, exception.Message);
        }

        [Fact]
        public void PushPop_AddElementsAndPopLessThanPushed_StackReturnsCorrectCounts()
        {
            // arrange
            var stack = new Stack<int>();
            var numberOfPushed = 4;
            var numberOfPopped = numberOfPushed - 2;

            // act
            for (var i = 0; i < numberOfPushed; i++)
            {
                stack.Push(1);
            }

            var stackElementsCountAfterPush = stack.Count;

            for (var i = 0; i < numberOfPopped; i++)
            {
                stack.Pop();
            }

            var stackElementsCountAfterPop = stack.Count;

            // assert
            Assert.Equal(4, stackElementsCountAfterPush);
            Assert.Equal(2, stackElementsCountAfterPop);
        }
    }
}
