using System;

namespace Codurance_Katacombs.Core
{
    public class KatacombsEngine : IKatacombsEngine
    {
        public event Action<string[]> DisplayMessage;

        private readonly IKatacombsWorld _world;

        public KatacombsEngine(IKatacombsWorld world)
        {
            _world = world;
            _world.DisplayMessage += DisplayMessageEvent;
        }

        public void Startup()
        {
            DisplayMessageEvent(_world.DisplayCurrentLocation());
        }

        public void Execute(string commandText)
        {
            var command = _world.CommandForCurrentLocation(commandText);
            command.SetContext(_world);
            command.Execute();
        }

        private void DisplayMessageEvent(string[] messageText)
        {
            DisplayMessage?.Invoke(messageText);
        }
    }
}