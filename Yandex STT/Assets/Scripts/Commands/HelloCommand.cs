

namespace Commands
{
    public class HelloCommand : ICommand
    {
        string ICommand.name { get; set; } = "������";
        string[] ICommand.patterns { get; set; } = { "������", "��", "����" };
        string[] ICommand.answers { get; set; } = { "������", "������, ��� ��������" };

        public string Exectute()
        {
            int index = Randomizer.GetRandom(0, ICommand.ans);

            return "";
        }
    }
}
