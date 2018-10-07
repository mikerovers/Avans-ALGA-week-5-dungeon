namespace week_5_dungeon_mikerovers.Commands
{
    public class NullCommand : ICommand
    {
        public void Execute(Graph graph)
        {
            System.Console.WriteLine("Command not recognised.");
        }
    }
}