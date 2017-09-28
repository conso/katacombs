using System;
using System.Collections.Generic;

namespace Codurance_Katacombs
{
    public class Location
    {
        public event Action<string> ChangeTo;

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

        public void ChangeLocationTo(string nextLocationTitle)
        {
            ChangeTo?.Invoke(nextLocationTitle);
        }

        public void AddMovingCommand(string commandText, string destinationTitle)
        {
            _availableCommands.Add(commandText, new MoveTo(destinationTitle, this));
        }
    }
}