namespace Codurance_Katacombs
{
    public class KatacombsGameController
    {
        private readonly IWrapConsole _console;

        public KatacombsGameController(IWrapConsole console)
        {
            _console = console;
        }

        public void StartGame()
        {
            _console.Display("Initial environment message");
        }
    }
}
