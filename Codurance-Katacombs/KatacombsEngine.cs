using System;
using Codurance_Katacombs.Commands;

namespace Codurance_Katacombs
{
    public class KatacombsEngine : IKatacombsEngine
    {
        public event Action<string[]> ShowMessage;

        private readonly IKatacombsWorld _world;
        private readonly ICommandFactory _commandFactory;

        public KatacombsEngine(IKatacombsWorld world, ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
            _world = world;
            _world.DisplayMessage += DisplayMessage;
        }

        public void Startup()
        {
            DisplayMessage(_world.CurrentLocation().Display());
        }

        public void Execute(string commandText)
        {
            ILocationCommand command = _commandFactory.GetCommand(commandText, _world);
            command.Execute();
        }

        private void DisplayMessage(string[] messageText)
        {
            ShowMessage?.Invoke(messageText);
        }

        
    }
}