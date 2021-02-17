

namespace Commands
{
    public class SearchCommand : Command
    {
        public new string name = "Поиск в интернете";
        public new string[] patterns = {
                                        "Найди в интернете",
                                        "Найди в гугле",
                                        "Найди",
                                        "Загугли",
                                    };

        public new string Exectute()
        {
            throw new System.NotImplementedException();
        }
    }
}

