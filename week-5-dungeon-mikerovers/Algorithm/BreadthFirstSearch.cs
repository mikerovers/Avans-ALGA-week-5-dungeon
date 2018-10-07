using System;
using System.Collections.Generic;
using System.Linq;

namespace week_5_dungeon_mikerovers
{
    public class BreadthFirstSearch
    {                
        public HashSet<Vertex> Execute(Graph graph, Vertex start, Vertex end)
        {
            Queue<Vertex> queue = new Queue<Vertex>();
            HashSet<Vertex> visited = new HashSet<Vertex>();
            
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                Vertex vertex = queue.Dequeue();
                visited.Add(vertex);
    
                foreach (Edge edge in vertex.Edges)
                {
                    var other = edge.Other(vertex);
                    
                    if (edge.Walkable && !queue.Contains(other) && !visited.Contains(other))
                    {
                        queue.Enqueue(other);
                    }

                    if (other == end)
                    {
                        return visited;
                    }
                }
            }

            return visited;
        }
    }
}