using Codurance_Katacombs.Commands;

namespace Codurance_Katacombs.Core
{
    public class Location
    {
        public string Title { get; }
        private readonly string _description;
        private readonly ILocationCommands _locationCommands;

        public Location(string title, string description, ILocationCommands locationCommands)
        {
            Title = title;
            _description = description;
            _locationCommands = locationCommands;
        }

        public string[] Display()
        {
            return new[] {Title, _description};
        }
        
        public void AddMoveToCommand(string commandText, string destinationTitle)
        {
            _locationCommands.AddMoveToCommand(commandText, destinationTitle);
        }

        public ILocationCommand GetCommand(string commandText)
        {
            var locationCommand = _locationCommands.GetCommand(commandText);
            return locationCommand;
        }
    }
}