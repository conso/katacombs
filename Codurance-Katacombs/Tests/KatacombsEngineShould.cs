using Codurance_Katacombs.Commands;
using FakeItEasy;
using NUnit.Framework;

namespace Codurance_Katacombs.Tests
{
    [TestFixture]
    public class KatacombsEngineShould
    {
        private string title= "title";
        private string description = "description";
        private KatacombsEngine _katacombsEngine;
        private IKatacombsWorld _katacombsWorld;
        private ICommandFactory _commandFactory;
        private string[] _lastMessage;

        [SetUp]
        public void TestSetup()
        {
            _lastMessage = null;
            _commandFactory = A.Fake<ICommandFactory>();
            _katacombsWorld = A.Fake<IKatacombsWorld>();
            var initialLocation = new Location(title, description);
            A.CallTo(() => _katacombsWorld.CurrentLocation()).Returns(initialLocation);
            _katacombsEngine = new KatacombsEngine(_katacombsWorld, _commandFactory);
            _katacombsEngine.ShowMessage += (message) => _lastMessage = message;

            _katacombsEngine.Startup();
        }


        [Test]
        public void Show_main_description_for_initial_location_when_started()
        {
            Assert.That(_lastMessage, Is.EquivalentTo(new []{title, description}));
        }

        [Test]
        public void Execute_commands()
        {
            var fakeCommand = A.Fake<IMoveToCommand>();
            A.CallTo(() => _commandFactory.GetCommand(A<string>._, A<IKatacombsWorld>._)).Returns(fakeCommand);

            _katacombsEngine.Execute("GO N");

            A.CallTo(() => fakeCommand.Execute()).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
