using System;
using System.Collections.Generic;

namespace week_5_dungeon_mikerovers
{
    public class Graph
    {
        private GraphBuilder _graphBuilder;
        private int _rowLength;
        private HashSet<Vertex> _vertices;
        private Vertex[,] _drawGrid;
        public Vertex StartPoint { get; private set; }
        public Vertex EndPoint { get; private set; }
        public HashSet<Edge> Edges { get; private set; }

        public Graph(int size = 4)
        {
            _rowLength = size;
            Edges = new HashSet<Edge>();
            _drawGrid = new Vertex[_rowLength, _rowLength];
            _vertices = new HashSet<Vertex>();
            _graphBuilder = new GraphBuilder();

            _drawGrid = _graphBuilder.GenerateGrid(_rowLength);
            Edges = _graphBuilder.ConnectVertices(_drawGrid);
            for (int x = 0; x < _drawGrid.GetLength(0); x++)
            {
                for (int y = 0; y < _drawGrid.GetLength(1); y++)
                {
                    _vertices.Add(_drawGrid[x, y]);
                }
            }
            InitializePoints();
        }

        public HashSet<Vertex> Vertices => _vertices;

        public void InitializePoints()
        {
            Random random = new Random();
            Vertex start = _drawGrid[random.Next(0, _rowLength), random.Next(0, _rowLength)];
            StartPoint = start;
            Vertex end = null;
            
            while (end == null)
            {
                var temp = _drawGrid[random.Next(0, _rowLength), random.Next(0, _rowLength)];
                if (temp != start)
                {
                    end = temp;
                }
            }

            EndPoint = end;
            StartPoint.Label = 'S';
            EndPoint.Label = 'E';
        }

        public void PrintGraph()
        {
            System.Console.WriteLine("\n");
            
            for (var y = 0; y < _drawGrid.GetLength(1); y++)
            {
                Vertex first = _drawGrid[0, y];

                first.Draw();
                if (first.SouthernEdge != null)
                {
                    System.Console.Write("\n");
                    for (var x = 0; x < _drawGrid.GetLength(0) * 4; x++)
                    {
                        if (x % 4 == 0)
                        {
                            System.Console.Write("|");
                        }
                        else
                        {
                            System.Console.Write(" ");
                        }
                    }

                    System.Console.Write("\n");

                    for (var x = 0; x < _drawGrid.GetLength(0) * 4; x++)
                    {
                        var v = _drawGrid[x / 4, y];

                        if (x % 4 == 0)
                        {
                            v.SouthernEdge.DrawVertical();
                        }
                        else
                        {
                            System.Console.Write(" ");
                        }
                    }
                    
                    System.Console.Write("\n");
                    
                    for (var x = 0; x < _drawGrid.GetLength(0) * 4; x++)
                    {
                        if (x % 4 == 0)
                        {
                            System.Console.Write("|");
                        }
                        else
                        {
                            System.Console.Write(" ");
                        }
                    }
                    
                    System.Console.Write("\n");
                }
            }
            
            System.Console.WriteLine("\n");
        }

        public int GetLengthToEnd()
        {
            var algorithm = new BreadthFirstSearch();
            var result = algorithm.Execute(this, StartPoint, EndPoint);

            return result.Count;
        }
    }
}