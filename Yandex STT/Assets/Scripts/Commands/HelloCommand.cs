using CustomRandom;
using Algorithms;

namespace Commands
{
    public class HelloCommand : Command
    {
        public new string name = "Привет";
        public new string[] patterns = { 
                                        "Привет", 
                                        "Ку", 
                                        "Прив", 
                                        "Хелло", 
                                        "Бонжур" 
                                    };
        public new string[] answers = { 
                                    "Привет", 
                                    "Здравствуйте", 
                                    "Здравствуй" 
                                 };

        public new string Exectute()
        {
            int index = Randomizer.GetRandom(0, answers.Length);

            return answers[index];
        }
    }
}
