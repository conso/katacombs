using Codurance_Katacombs.Core;

namespace Codurance_Katacombs.Commands
{
    public class CommandFactory : ICommandFactory
    {
        public ILocationCommand GetCommand(string commandText, IKatacombsWorld world)
        {
            var command = world.CurrentLocation().GetCommand(commandText);
            command.SetContext(world);
            return command;
        }
    }
}