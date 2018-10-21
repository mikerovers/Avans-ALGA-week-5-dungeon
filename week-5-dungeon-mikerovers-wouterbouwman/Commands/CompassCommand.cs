using System.Collections.Generic;
using System.Linq;
using System.Text;
using week_5_dungeon_mikerovers.Algorithm;

namespace week_5_dungeon_mikerovers.Commands
{
    public class CompassCommand : ICommand
    {
        public void Execute(Graph graph)
        {
            System.Console.WriteLine("Je haalt het kompas uit je zak. Het trilt in je hand en projecteert in lichtgevende letters op de muur:");
            
            DijkstraShortestPath d = new DijkstraShortestPath();
            var path = d.Execute(graph);
            
            PrintLight(path, graph.EndPoint);
            System.Console.WriteLine("\n");
            PrintEnemies(path, graph.EndPoint);
        }

        private void PrintLight(Dictionary<Vertex, Vertex> path, Vertex start)
        {
            if (path[start] == null)
            {
                return;
            }
            
            PrintLight(path, path[start]);

            string text = start.GetDirectionInString(start.GetEdgeWith(path[start]));
            System.Console.Write(text + " ");
        }

        private void PrintEnemies(Dictionary<Vertex, Vertex> path, Vertex start)
        { 
            StringBuilder builder = new StringBuilder();
            builder.Append("(");
            var enemies = new HashSet<Edge>(CreateEnemyList(path, start, new HashSet<Edge>()).Reverse());
            GetStringFromEnemies(enemies, builder);
            builder.Append(")");
            
            System.Console.WriteLine($"{enemies.Count()} tegenstanders " + builder.ToString());
        }

        public void GetStringFromEnemies(HashSet<Edge> enemies, StringBuilder builder)
        {
            foreach (Edge enemy in enemies)
            {         
                builder.Append($"level {enemy.Weight}");

                if (enemy != enemies.Last())
                {
                    builder.Append(", ");
                }
            }
        }

        public HashSet<Edge> CreateEnemyList(Dictionary<Vertex, Vertex> path, Vertex start, HashSet<Edge> enemies)
        {    
            if (path[start] == null)
            {
                return enemies;
            }

            Edge edge = start.GetEdgeWith(path[start]);
            enemies.Add(edge);
            
            return CreateEnemyList(path, path[start], enemies);
        }
    }
}