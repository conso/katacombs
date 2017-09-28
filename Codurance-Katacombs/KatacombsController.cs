namespace Codurance_Katacombs
{
    public class KatacombsController
    {
        private readonly IKatacombsEngine _katacombsEngine;
        private readonly IWrapConsole _console;

        public KatacombsController(IKatacombsEngine katacombsEngine, IWrapConsole console)
        {
            _katacombsEngine = katacombsEngine;
            _katacombsEngine.ShowMessage += DisplayMessageToConsole;
            _console = console;
            _console.ReadLine += ExecuteCommand;
        }

        private void DisplayMessageToConsole(string[] textMessage)
        {
            _console.Write(textMessage);
        }

        private void ExecuteCommand(string commandText)
        {
            _katacombsEngine.Execute(commandText);
        }

        public void StartGame()
        {
            _katacombsEngine.Startup();
        }
    }
}
        