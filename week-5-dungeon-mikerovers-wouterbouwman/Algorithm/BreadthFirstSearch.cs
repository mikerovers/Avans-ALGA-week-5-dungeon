using System;
using System.Collections.Generic;

namespace week_5_dungeon_mikerovers.Algorithm
{
    public class BreadthFirstSearch
    {                
        public HashSet<Vertex> Execute(Graph graph, Vertex start, Vertex end)
        {
            Queue<Vertex> queue = new Queue<Vertex>();
            Dictionary<Vertex, Vertex> visited = new Dictionary<Vertex, Vertex>();
            
            queue.Enqueue(start);

            void Loop()
            {
                while (queue.Count > 0)
                {
                    Vertex vertex = queue.Dequeue();
    
                    foreach (Edge edge in vertex.Edges)
                    {
                        var other = edge.Other(vertex);
                            
                        if (other == end)
                        {
                            visited[other] = vertex;
                            
                            return;
                        }
                    
                        if (edge.Walkable && !queue.Contains(other) && !visited.ContainsKey(other))
                        {
                            visited[other] = vertex;
                            queue.Enqueue(other);
                        }
                    }
                }
            }
            
            Loop();            
            
            Func<Vertex, HashSet<Vertex>> shortestPath = v =>
            {
                var path = new HashSet<Vertex>();

                var current = v;
                while (!current.Equals(start)) {
                    path.Add(current);
                    current = visited[current];
                };

                path.Add(start);
                path.Remove(end);

                return path;
            };

            
            return shortestPath(end);
        }
    }
}