using System.Collections.Generic;
using Codurance_Katacombs.Commands;

namespace Codurance_Katacombs
{
    public class Location
    {
        private readonly string _title;
        private readonly string _description;
        private readonly IDictionary<string, ILocationCommand> _availableCommands;

        public Location(string title, string description)
        {
            _title = title;
            _description = description;
            _availableCommands = new Dictionary<string, ILocationCommand>();
        }

        public string[] Display()
        {
            return new[] {_title, _description};
        }

        public void Execute(string commandText)
        {
            _availableCommands[commandText].Execute();
        }

        public void AddMovingCommand(string commandText, string destinationTitle)
        {
            _availableCommands.Add(commandText, new MoveTo(destinationTitle));
        }

        public ILocationCommand GetCommand(string commandText)
        {
            return !_availableCommands.ContainsKey(commandText) ? null : _availableCommands[commandText];
        }
    }
}