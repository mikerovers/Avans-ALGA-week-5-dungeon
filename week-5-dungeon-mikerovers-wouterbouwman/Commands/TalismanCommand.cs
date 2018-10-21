using System.Linq;
using week_5_dungeon_mikerovers_wouterbouwman.Algorithm;

namespace week_5_dungeon_mikerovers_wouterbouwman.Commands
{
    public class TalismanCommand : ICommand
    {
        public void Execute(Graph graph)
        {
            BreadthFirstSearch algorithm = new BreadthFirstSearch();
            var vertices = algorithm.Execute(graph, graph.StartPoint, graph.EndPoint);
            
            string count = (vertices.Count()).ToString();
            System.Console.WriteLine($"De talisman licht op en fluistert dat het eindpunt {count} ver weg is");
        }
    }
}