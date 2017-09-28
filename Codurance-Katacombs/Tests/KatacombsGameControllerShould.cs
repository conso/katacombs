using FakeItEasy;
using NUnit.Framework;

namespace Codurance_Katacombs.Tests
{
    [TestFixture]
    public class KatacombsGameControllerShould
    {
        private IWrapConsole _console;
        private KatacombsController _katacombsController;
        private IKatacombsEngine _engine;

        [SetUp]
        public void TestSetup()
        {
            _engine = A.Fake<IKatacombsEngine>();
            _console = A.Fake<IWrapConsole>();
            _katacombsController = new KatacombsController(_engine, _console);
            _katacombsController.StartGame();
        }

        [Test]
        public void Proxy_user_commands_to_the_game_engine()
        {
            string commandText = "GO N";
            _console.ReadLine += Raise.FreeForm.With(commandText);

            A.CallTo(() => _engine.Execute(commandText)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Display_text_lines_to_the_console_when_engine_raises_show_message_event()
        {
            var messageText = new []{ "CIAO MAMMA!", "BONAAAA"};
            _engine.ShowMessage += Raise.FreeForm.With(new []{messageText});

            A.CallTo(() => _console.Write(messageText)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Startup_the_world()
        {
            A.CallTo(() => _engine.Startup()).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
