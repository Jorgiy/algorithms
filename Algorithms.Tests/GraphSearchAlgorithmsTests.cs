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
        public static IEnumerable<object[]> GetGraphSearchAlgorithmsTestData(int testsCount)
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

        public static IEnumerable<object[]> ShortestWaysTestData(int testsCount)
        {
            var testCases = new[]
            {
                new object[]
                {
                    "A", "E", new[] { "A", "C", "E" }
                },
                new object[]
                {
                    "A", "D", new[] { "A", "B", "D" }
                },
                new object[]
                {
                    "C", "F", new[] { "C", "D", "F" }
                },
                new object[]
                {
                    "F", "F", new[] { "F" }
                }
            };

            return testCases.Take(testsCount);
        }

        [Theory]
        [MemberData(nameof(GetGraphSearchAlgorithmsTestData), 6)]
        public void Traverse_SimpleGraphOnInput_CorrectTraversing(ITraversingAlgorithm traversingAlgorithm, string[] expectedRoute, string startVertex)
        {
            // arrange
            var graph = GetGraph();

            // act
            var route = traversingAlgorithm.Traverse(graph, startVertex);

            // assert
            Assert.Equal(expectedRoute, route, new EnumerableEqualityComparer<string>());
        }

        [Theory]
        [MemberData(nameof(ShortestWaysTestData), 3)]
        public void SearchShortestWay_TwoVertexOnInput_ShortestWayFound(string startVertex, string lookingForVertex, string[] expectedShortestPath)
        {
            // arrange
            var algorithm = new BreadthFirstSearchAlgorithm();
            var graph = GetGraph();

            // act
            var result = algorithm.SearchShortestWay(graph, startVertex, lookingForVertex);

            // assert
            Assert.True(result.Success);
            Assert.Equal(expectedShortestPath, result.Route, new EnumerableEqualityComparer<string>());
        }

        [Fact]
        public void SearchShortestWay_LookForNotExistingVertex_NothingFound()
        {
            // arrange
            var algorithm = new BreadthFirstSearchAlgorithm();
            var graph = GetGraph();

            // act
            var result = algorithm.SearchShortestWay(graph, "A", "G");

            // assert
            Assert.False(result.Success);
        }

        [Fact]
        public void SearchShortestWay_StartVertexNotExist_NothingFound()
        {
            // arrange
            var algorithm = new BreadthFirstSearchAlgorithm();
            var graph = GetGraph();

            // act
            var result = algorithm.SearchShortestWay(graph, "G", "E");

            // assert
            Assert.False(result.Success);
        }

        [Fact]
        public void SearchShortestWay_LookForNotConnectedVertex_NothingFound()
        {
            // arrange
            var algorithm = new BreadthFirstSearchAlgorithm();
            var graph = GetGraph();
            graph.AddVertex("G");

            // act
            var result = algorithm.SearchShortestWay(graph, "C", "G");

            // assert
            Assert.False(result.Success);
        }

        [Fact]
        public void SearchShortestWay_StartAndLookingForVertexAreNotExist_NothingFound()
        {
            // arrange
            var algorithm = new BreadthFirstSearchAlgorithm();
            var graph = GetGraph();

            // act
            var result = algorithm.SearchShortestWay(graph, "G", "H");

            // assert
            Assert.False(result.Success);
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
