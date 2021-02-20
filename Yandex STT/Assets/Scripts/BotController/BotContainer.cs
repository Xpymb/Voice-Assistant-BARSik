using Commands;

namespace BotController
{
    public class BotContainer
    {
        readonly ICommand[] commands = {
                                           new HelloCommand(),
                                           new SearchCommand(),
                                       };

        public ICommand ChooseCommand(string str)
        {
            foreach (ICommand command in commands)
            {
                if (command.IsItI(str))
                {
                    return command;
                }
            }

            return null;
        }
    }

}