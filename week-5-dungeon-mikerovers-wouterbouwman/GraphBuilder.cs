using System;
using System.Collections.Generic;
using week_5_dungeon_mikerovers.Exception;

namespace week_5_dungeon_mikerovers
{
    public class GraphBuilder
    {
        private readonly Random RandomGen = new Random();
                                              
        public Vertex[,] GenerateGrid(int size)
        {
            if (size < 3)
            {
                throw new GridSizeException("Grid size must to at least 3. Given: " + size);
            } 
            
            Vertex[,] grid = new Vertex[size, size];
            
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Vertex vertex = new Vertex('X');
                    grid[x, y] = vertex;
                }
            }

            return grid;
        }

        public HashSet<Edge> ConnectVertices(Vertex[,] vertices)
        {           
            HashSet<Edge> edges = new HashSet<Edge>();

            for (int y = 0; y < vertices.GetLength(1); y++)
            {
                for (int x = 0; x < vertices.GetLength(0); x++)
                {
                    // If vertex has eastern vertex, connect them.
                    if (x < vertices.GetLength(0) - 1)
                    {
                        var v1 = vertices[x, y];
                        var v2 = vertices[x + 1, y];
                        
                        Edge edge = new Edge(v1, v2, EdgeRandomWeight());
                        v1.EasternEdge = edge;
                        v2.WesternEdge = edge;
                        
                        edges.Add(edge);
                    }
                    
                    // If vertex has southern vertex, connect them.
                    if (y < vertices.GetLength(1) - 1)
                    {
                        var v1 = vertices[x, y];
                        var v2 = vertices[x, y + 1];
                        
                        Edge edge = new Edge(v1, v2, EdgeRandomWeight());
                        v1.SouthernEdge = edge;
                        v2.NorthernEdge = edge;
                        edges.Add(edge);
                    }
                }
            }

            return edges;
        }

        private int EdgeRandomWeight()
        {
            return RandomGen.Next(1, 10);
        }
    }
}