namespace Algorithms.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Algorithms.Core;
    using Algorithms.Core.DataStructures;
    using Algorithms.Core.TraversingAlgorithms;
    using Xunit;

    public class GraphSearchAlgorithmsTests
    {
        public static IEnumerable<object[]> GraphSearchAlgorithms(int testsCount)
        {
            var testCases = new[]
            {
                new object[]
                {
                    new BreadthFirstSearchAlgorithm(),
                    new[] { "A", "B", "C", "D", "E", "F" },
                    "A"
                },
                new object[]
                {
                    new DepthFirstSearchAlgorithm(),
                    new[] { "A", "C", "E", "D", "B", "F" },
                    "A"
                },
                new object[]
                {
                    new DepthFirstSearchRecursiveAlgorithm(),
                    new[] { "A", "B", "D", "C", "E", "F" },
                    "A"
                },
                new object[]
                {
                    new BreadthFirstSearchAlgorithm(),
                    new[] { "C", "A", "D", "E", "B", "F" },
                    "C"
                },
                new object[]
                {
                    new DepthFirstSearchAlgorithm(),
                    new[] { "C", "E", "D", "B", "A", "F" },
                    "C"
                },
                new object[]
                {
                    new DepthFirstSearchRecursiveAlgorithm(),
                    new[] { "C", "A", "B", "D", "F", "E" },
                    "C"
                }
            };

            return testCases.Take(testsCount);
        }

        [Theory]
        [MemberData(nameof(GraphSearchAlgorithms), 6)]
        public void Traverse_SimpleGraphOnInput_CorrectTraversing(ITraversingAlgorithm traversingAlgorithm, string[] expectedRoute, string startVertex)
        {
            // arrange
            var graph = GetGraph();

            // act
            var route = traversingAlgorithm.Traverse(graph, startVertex);

            // assert
            Assert.Equal(expectedRoute, route, new EnumerableEqualityComparer<string>());
        }

        private IGraph<string> GetGraph()
        {
            var edges = new[]
            {
                new Edge<string>("A", "B"),
                new Edge<string>("A", "C"),
                new Edge<string>("C", "D"),
                new Edge<string>("C", "E"),
                new Edge<string>("D", "F"),
                new Edge<string>("B", "D")
            };

            return new SimpleGraph<string>(new[] { "A", "B", "C", "D", "E", "F" }, edges);
        }
    }
}
