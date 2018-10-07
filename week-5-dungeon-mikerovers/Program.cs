using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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