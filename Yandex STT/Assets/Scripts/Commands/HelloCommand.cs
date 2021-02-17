using CustomRandom;
using Algorithms;

namespace Commands
{
    public class HelloCommand : Command
    {
        public new string name = "������";
        public new string[] patterns = { 
                                        "������", 
                                        "��", 
                                        "����", 
                                        "�����", 
                                        "������" 
                                    };
        public new string[] answers = { 
                                    "������", 
                                    "������������", 
                                    "����������" 
                                 };

        public new string Exectute()
        {
            int index = Randomizer.GetRandom(0, answers.Length);

            return answers[index];
        }
    }
}
