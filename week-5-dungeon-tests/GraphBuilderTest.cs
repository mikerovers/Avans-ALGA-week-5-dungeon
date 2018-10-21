using System.Collections.Generic;
using week_5_dungeon_mikerovers;
using week_5_dungeon_mikerovers.Exception;
using Xunit;

namespace week_5_dungeon_tests
{
    public class GraphBuilderTest
    {
        private GraphBuilder _graphBuilder;
        
        public GraphBuilderTest()
        {
            _graphBuilder = new GraphBuilder();
        }
        
        [Fact]
        public void TestGraphSizeLessThenThree()
        {
            // Arrange
            int size = 2;
            // Act
            // Assert
            Assert.Throws<GridSizeException>(() => _graphBuilder.GenerateGrid(size));
        }

        [Fact]
        public void TestGraphSizeFour()
        {
            // Arrange
            int size = 4;
            
            // Act
            Vertex[,] vertices = _graphBuilder.GenerateGrid(size);

            // Assert
            Assert.Equal(vertices.GetLength(0), 4);
            Assert.Equal(vertices.GetLength(1), 4);
        }

        [Fact]
        public void TestConnectEdgesThree()
        {
            // Arrange
            int size = 3;
            Vertex[,] vertices = _graphBuilder.GenerateGrid(size);

            // Act
            HashSet<Edge> edges = _graphBuilder.ConnectVertices(vertices);

            // Assert
            Assert.Equal(12, edges.Count);
            Assert.NotEqual(null, vertices[0, 0].EasternEdge);
            Assert.Equal(null, vertices[0, 0].WesternEdge);
            Assert.Equal(null, vertices[0, 0].NorthernEdge);
            Assert.NotEqual(null, vertices[0, 0].SouthernEdge);
            Assert.NotEqual(null, vertices[1, 1].EasternEdge);
            Assert.NotEqual(null, vertices[1, 1].WesternEdge);
            Assert.NotEqual(null, vertices[1, 1].NorthernEdge);
            Assert.NotEqual(null, vertices[1, 1].SouthernEdge);
            Assert.NotEqual(null, vertices[2, 2].NorthernEdge);
            Assert.NotEqual(null, vertices[2, 2].WesternEdge);
            Assert.Equal(null, vertices[2, 2].EasternEdge);
            Assert.Equal(null, vertices[2, 2].SouthernEdge);
        }
        
        [Fact]
        public void TestConnectEdgesLargeAmount()
        {
            // Arrange
            int size = 100;
            Vertex[,] vertices = _graphBuilder.GenerateGrid(size);

            // Act
            HashSet<Edge> edges = _graphBuilder.ConnectVertices(vertices);

            // Assert
            Assert.Equal(19800, edges.Count);
        }
    }
}