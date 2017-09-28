namespace Codurance_Katacombs
{
    public class KatacombsController
    {
        private readonly IWrapConsole _console;
        private Location _currentLocation;

        public KatacombsController(IWrapConsole console)
        {
            _console = console;
            _console.ReadLine += ExecuteCommand;
            _currentLocation = new Location("Initial environment title", "Initial environment message");
        }

        private void ExecuteCommand(string commandText)
        {
            _currentLocation = commandText == "GO N" ? 
                new Location("Next location title", "Next location message") : 
                new Location("Initial environment title", "Initial environment message");

            _console.Write(_currentLocation.Display());
        }

        public void StartGame()
        {
            _console.Write(_currentLocation.Display());
        }
    }
}
