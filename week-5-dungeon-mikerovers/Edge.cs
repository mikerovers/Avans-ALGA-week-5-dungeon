using System;

namespace week_5_dungeon_mikerovers
{
    public class Edge
    {
        private int _weight;
        private Vertex _node1;
        private Vertex _node2;
        private bool _walkable;

        public Edge(Vertex node1, Vertex node2, int weight)
        {
            _node1 = node1;
            _node2 = node2;
            _weight = weight;
            _walkable = true;
        }

        public Vertex Node1 => _node1;
        public Vertex Node2 => _node2;

        public int Weight { get => _weight; set => _weight = value; }

        public bool Walkable
        {
            get => _walkable;
            set => _walkable = value;
        }

        public Vertex Other(Vertex vertex)
        {
            if (vertex == _node1)
            {
                return _node2;
            } else if (vertex == _node2)
            {
                return _node1;
            }

            return null;
        }

        public override string ToString()
        {
            if (_walkable)
            {
                return _weight.ToString();
            }
            else
            {
                return "~";
            }
        }

        public Vertex GetToVertex()
        {
            return _node2;
        }
        
        public Vertex GetFromVertex()
        {
            return _node1;
        }
       
        public void Draw(Vertex origin)
        {
            System.Console.Write("-" + ToString() + "-");
            if (Other(origin) != null)
            {
                Other(origin).Draw();
            }
        }

        public void DrawVertical()
        {
            System.Console.Write(ToString());
        }
    }
}