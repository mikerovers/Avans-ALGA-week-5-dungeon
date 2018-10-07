namespace week_5_dungeon_mikerovers.Commands
{
    public class CommandFactory
    {
        public ICommand RetreiveCommand(string command)
        {
            switch (command.ToLower())
            {
                case "handgranaat":
                    return new GrenadeCommand();
                case "talisman":
                    return new TalismanCommand();
                case "kompas":
                    return new CompassCommand();;
                default:
                    return new NullCommand();
            }
        }
    }
}