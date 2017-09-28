using System;       

namespace Codurance_Katacombs
{
    public class KatacombsEngine : IKatacombsEngine
    {
        public event Action<string[]> ShowMessage;

        private readonly IKatacombsWorld _world;
        private Location _currentLocation;

        public KatacombsEngine(IKatacombsWorld world)
        {
            _world = world;
            _currentLocation = _world.GetStartingLocation();
            _currentLocation.ChangeTo += ChangeCurrentLocationTo;
        }

        public void Startup()
        {
            DisplayCurrentLocationMessage();
        }

        public void Execute(string commandText)
        {
            _currentLocation.Execute(commandText);
        }

        private void DisplayCurrentLocationMessage()
        {
            ShowMessage?.Invoke(_currentLocation.Display());
        }

        private void ChangeCurrentLocationTo(string locationTitle)
        {
            _currentLocation.ChangeTo -= ChangeCurrentLocationTo;
            _currentLocation = _world.GetLocation(locationTitle);
            _currentLocation.ChangeTo += ChangeCurrentLocationTo;

            DisplayCurrentLocationMessage();
        }
    }
}