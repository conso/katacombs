using System;
using Codurance_Katacombs.Commands;

namespace Codurance_Katacombs.Core
{
    public class KatacombsEngine : IKatacombsEngine
    {
        public event Action<string[]> DisplayMessage;

        private readonly IKatacombsWorld _world;
        private readonly ICommandFactory _commandFactory;

        public KatacombsEngine(IKatacombsWorld world, ICommandFactory commandFactory)
        {
            _world = world;
            _world.DisplayMessage += DisplayMessageEvent;
            _commandFactory = commandFactory;
        }

        public void Startup()
        {
            DisplayMessageEvent(_world.CurrentLocation().Display());
        }

        public void Execute(string commandText)
        {
            ILocationCommand command = _commandFactory.GetCommand(commandText, _world);
            command.Execute();
        }

        private void DisplayMessageEvent(string[] messageText)
        {
            DisplayMessage?.Invoke(messageText);
        }
    }
}