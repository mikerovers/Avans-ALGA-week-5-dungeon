using week_5_dungeon_mikerovers.Commands;

namespace week_5_dungeon_mikerovers
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandFactory commandFactory = new CommandFactory();
            Graph graph = new Graph(4);
            System.Console.Write("\n");;

            while (true)
            {
                System.Console.WriteLine("S = Room: Startpunt");
                System.Console.WriteLine("E = Room: Eindpunt");
                System.Console.WriteLine("X = Room: Niet bezocht");
                System.Console.WriteLine("* = Room: Bezocht");
                System.Console.WriteLine("~ = Hallway: Ingestort");
                System.Console.WriteLine("0 = Hallway: Level tegenstander (cost)");
                graph.PrintGraph();
                System.Console.WriteLine("\n");
                System.Console.WriteLine("Acties: talisman, handgranaat, kompas");
                System.Console.Write("->  ");
                
                string input = System.Console.ReadLine();
                System.Console.Clear();
                
                ICommand command = commandFactory.RetreiveCommand(input);
                command.Execute(graph);
            }  
        }
    }
}