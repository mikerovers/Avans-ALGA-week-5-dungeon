using System;
using System.Net.Mime;
using week_5_dungeon_mikerovers_wouterbouwman.Commands;

namespace week_5_dungeon_mikerovers_wouterbouwman
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandFactory commandFactory = new CommandFactory();
            System.Console.WriteLine("Enter your desired dungeon size:");
            
            string sizeInput = System.Console.ReadLine();
            int number;

            if (!Int32.TryParse(sizeInput, out number))
            {
                System.Console.WriteLine("The entered size is not valid.");
                Environment.Exit(1);
            }

            Graph graph = new Graph(number);
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