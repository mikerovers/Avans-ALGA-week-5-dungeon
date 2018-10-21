namespace week_5_dungeon_mikerovers_wouterbouwman.Commands
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
                    return new CompassCommand();
                case "start":
                    return new ChangeStartCommand();
                case "end":
                    return new ChangeEndCommand();
                default:
                    return new NullCommand();
            }
        }
    }
}