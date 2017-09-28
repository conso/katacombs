namespace Codurance_Katacombs
{
    public class KatacombsController
    {
        private readonly IKatacombsWorld _katacombsWorld;
        private readonly IWrapConsole _console;

        public KatacombsController(IKatacombsWorld katacombsWorld, IWrapConsole console)
        {
            _katacombsWorld = katacombsWorld;
            _katacombsWorld.ShowMessage += ProxyWorldMessageToConsole;
            _console = console;
            _console.ReadLine += ExecuteCommand;
            
        }

        private void ProxyWorldMessageToConsole(string[] textMessage)
        {
            _console.Write(textMessage);
        }

        private void ExecuteCommand(string commandText)
        {
            _katacombsWorld.Execute(commandText);
        }

        public void StartGame()
        {
            _katacombsWorld.Startup();
        }
    }
}
        