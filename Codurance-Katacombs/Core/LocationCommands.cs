using System.Collections.Generic;
using Codurance_Katacombs.Commands;

namespace Codurance_Katacombs.Core
{
    public class LocationCommands : ILocationCommands
    {
        private readonly IDictionary<string, ILocationCommand> _availableCommands;

        public LocationCommands()
        {
            _availableCommands = new Dictionary<string, ILocationCommand> {{"BAG", new Inventory()}};
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