using System;
using System.Collections.Generic;
using System.Linq;
using week_5_dungeon_mikerovers_wouterbouwman.Algorithm;

namespace week_5_dungeon_mikerovers_wouterbouwman.Commands
{
    public class GrenadeCommand : ICommand
    {
        public void Execute(Graph graph)
        {
            System.Console.WriteLine("De kerker schudt op zijn grondvesten, de tegenstander in een aangrezende hallway is vermorzeld!" +
                                     "Een donderend geluid maakt duidelijk dat gedeeltes van de kerker zijn integestort...");
            
            MinimumSpanningTree algorithm = new MinimumSpanningTree();
            HashSet<Edge> edges = algorithm.Execute(graph);
           
            foreach (var edge in graph.Edges)
            {
                if (!edges.Contains(edge))
                {
                    edge.Walkable = false;
                }
            }

            List<Edge> edgesFromStart = graph.StartPoint.Edges.ToList();
            Random random = new Random();
            int r = random.Next(edgesFromStart.Count);
            edgesFromStart[r].Weight = 0;
        }
    }
}