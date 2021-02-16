

namespace Commands
{
    interface ICommand
    {
        public string name { get; set; }
        public string[] patterns { get; set; }
        public string[] answers { get; set; }
        public string Exectute();
    }
}