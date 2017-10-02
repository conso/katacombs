using Codurance_Katacombs.Infrastructure;

namespace Codurance_Katacombs.Core.Controller
{
    public class KatacombsController
    {
        private readonly IKatacombsEngine _katacombsEngine;
        private readonly IWrapConsole _console;

        public KatacombsController(IKatacombsEngine katacombsEngine, IWrapConsole console)
        {
            _katacombsEngine = katacombsEngine;
            _katacombsEngine.DisplayMessage += DisplayMessageToConsole;
            _console = console;
            _console.ReadLine += ExecuteCommand;
        }

        public void StartGame()
        {
            _katacombsEngine.Startup();
        }

        private void DisplayMessageToConsole(string[] textMessage)
        {
            _console.Write(textMessage);
        }

        private void ExecuteCommand(string commandText)
        {
            _katacombsEngine.Execute(commandText);
        }
    }
}
        