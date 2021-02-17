using Algorithms;

namespace Commands
{
    public abstract class Command : ICommand
    {
        public string name;
        public string[] patterns;
        public string[] answers;

        public string Exectute()
        {
            return "";
        }

        public bool IsItI(string str)
        {
            ParseString parseString = new ParseString();
            string foundString;

            foreach (string pattern in patterns)
            {
                foundString = parseString.FindSubstring(pattern, str);

                if (foundString != "")
                    return true;
            }

            return false;
        }
    }
}