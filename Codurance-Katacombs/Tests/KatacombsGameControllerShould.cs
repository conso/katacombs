using FakeItEasy;
using NUnit.Framework;

namespace Codurance_Katacombs.Tests
{
    [TestFixture]
    public class KatacombsGameControllerShould
    {
        private IWrapConsole _console;
        private KatacombsController _katacombsController;
        private IKatacombsWorld _world;

        [SetUp]
        public void TestSetup()
        {
            _world = A.Fake<IKatacombsWorld>();
            _console = A.Fake<IWrapConsole>();
            _katacombsController = new KatacombsController(_world, _console);
            _katacombsController.StartGame();
        }

        [Test]
        public void Proxy_commands_to_the_world()
        {
            string commandText = "GO N";
            _console.ReadLine += Raise.FreeForm.With(commandText);

            A.CallTo(() => _world.Execute(commandText)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Write_text_lines_to_the_console_when_the_world_raises_show_message_event()
        {
            var messageText = new []{ "CIAO MAMMA!", "BONAAAA"};
            _world.ShowMessage += Raise.FreeForm.With(new []{messageText});

            A.CallTo(() => _console.Write(messageText)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Startup_the_world()
        {
            A.CallTo(() => _world.Startup()).MustHaveHappened(Repeated.Exactly.Once);
        }

    }
}
