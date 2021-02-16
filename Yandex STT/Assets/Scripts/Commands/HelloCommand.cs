

namespace Commands
{
    public class HelloCommand : ICommand
    {
        string ICommand.name { get; set; } = "Привет";
        string[] ICommand.patterns { get; set; } = { "Привет", "Ку", "Прив" };
        string[] ICommand.answers { get; set; } = { "Привет", "Привет, мой Господин" };

        public string Exectute()
        {
            int index = Randomizer.GetRandom(0, ICommand.ans);

            return "";
        }
    }
}
