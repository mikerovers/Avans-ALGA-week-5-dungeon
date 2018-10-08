using System;

namespace week_5_dungeon_mikerovers.Commands
{
    public class ChangeEndCommand : ICommand
    {
        public void Execute(Graph graph)
        {
            System.Console.WriteLine("\nPlease enter the new X coordinate for the new end point:");
            ConsoleKeyInfo xKey = System.Console.ReadKey();
            System.Console.WriteLine("\nPlease enter the new Y coordinate for the new end point:");
            ConsoleKeyInfo yKey = System.Console.ReadKey();

            if (!char.IsDigit(xKey.KeyChar) || !char.IsDigit(yKey.KeyChar))
            {
                PrintNotValid();
                
                return;
            }
           
            int xPos = int.Parse(xKey.KeyChar.ToString());
            int yPos = int.Parse(yKey.KeyChar.ToString());

            if (xPos > graph._rowLength || yPos > graph._rowLength)
            {
                PrintNotValid();

                return;
            }

            Vertex end = graph._drawGrid[xPos, yPos];
            if (end == graph.StartPoint)
            {
                PrintNotValid();
                
                return;
            }
            graph.EndPoint.Label = 'X';
            end.Label = 'E';
            graph.EndPoint = end;
        }
        
        public void PrintNotValid()
        {
            System.Console.WriteLine("Input not valid.");
        }
    }
}