using Codurance_Katacombs.Commands;
using Codurance_Katacombs.Core;
using FakeItEasy;
using NUnit.Framework;

namespace Codurance_Katacombs.Tests.Core
{
    [TestFixture]
    public class KatacombsEngineShould
    {
        private string title= "title";
        private string description = "description";
        private KatacombsEngine _katacombsEngine;
        private IKatacombsWorld _katacombsWorld;
        private ILocationCommands _locationCommands;
        private string[] _lastMessage;
        private string[] _currentLocationMessage;

        [SetUp]
        public void TestSetup()
        {
            _lastMessage = null;
            _currentLocationMessage = new[] { title, description };
            _locationCommands = A.Fake<ILocationCommands>();
            _katacombsWorld = A.Fake<IKatacombsWorld>();
            A.CallTo(() => _katacombsWorld.DisplayCurrentLocation()).Returns(_currentLocationMessage);
            _katacombsEngine = new KatacombsEngine(_katacombsWorld);
            _katacombsEngine.DisplayMessage += (message) => _lastMessage = message;
            _katacombsEngine.Startup();
        }


        [Test]
        public void Show_main_description_for_initial_location_when_started()
        {
            Assert.That(_lastMessage, Is.EquivalentTo(_currentLocationMessage));
        }

        [Test]
        public void Execute_commands()
        {
            var fakeCommand = A.Fake<ILocationCommand>();
            var commandText = "GO N";

            A.CallTo(() => _katacombsWorld.CommandForCurrentLocation(commandText)).Returns(fakeCommand);

            _katacombsEngine.Execute(commandText);

            A.CallTo(() => fakeCommand.Execute()).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
