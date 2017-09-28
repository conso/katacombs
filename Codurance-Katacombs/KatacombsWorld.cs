using System;

namespace Codurance_Katacombs
{
    public class KatacombsWorld : IKatacombsWorld
    {
        private Location _currentLocation;

        public event Action<string[]> ShowMessage;

        public void Startup()
        {
            _currentLocation = new Location("Initial environment title", "Initial environment message");
            ShowMessage?.Invoke(_currentLocation.Display());
        }

        public void Execute(string commandText)
        {
            _currentLocation = commandText == "GO N" ?
                new Location("Next location title", "Next location message") :
                new Location("Initial environment title", "Initial environment message");

            ShowMessage?.Invoke(_currentLocation.Display());
        }
    }
}