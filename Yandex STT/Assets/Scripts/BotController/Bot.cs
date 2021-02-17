using Yandex;
using Commands;
using AudioManager;

namespace BotController
{
    public class Bot
    {
        static ICommand _command = new HelloCommand();

        bool flag = _command.IsItI("11"); 
    }
}
