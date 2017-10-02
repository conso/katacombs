using System.Collections.Generic;
using Codurance_Katacombs.Commands;

namespace Codurance_Katacombs.Core
{
    public class Location
    {
        public string Title { get; }
        private readonly string _description;
        private readonly IDictionary<string, ILocationCommand> _availableCommands;

        public Location(string title, string description)
        {
            Title = title;
            _description = description;
            _availableCommands = new Dictionary<string, ILocationCommand>();
        }

        public string[] Display()
        {
            return new[] {Title, _description};
        }
        
        public void AddMoveToCommand(string commandText, string destinationTitle)
        {
            _availableCommands.Add(commandText, new MoveTo(destinationTitle));
        }

        public ILocationCommand GetCommand(string commandText)
        {
            return !_availableCommands.ContainsKey(commandText) ? null : _availableCommands[commandText];
        }
    }
}