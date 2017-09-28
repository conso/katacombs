using FakeItEasy;
using NUnit.Framework;

namespace Codurance_Katacombs.Tests
{
    [TestFixture]
    public class KatacombsEngineShould
    {
        private KatacombsEngine _katacombsEngine;
        private IKatacombsWorld _katacombsWorld;
        private string[] _lastMessage;
        private Location _initialLocation;
        private Location _nextLocation;
        

        [SetUp]
        public void TestSetup()
        {
            _initialLocation = new LocationBuilder("Initial environment title", "Initial environment message")
                .WithNorth("Next location title")
                .Build();
            _nextLocation = new LocationBuilder("Next location title", "Next location message")
                .WithSouth("Initial environment title")
                .Build();

            _lastMessage = null;
            _katacombsWorld = A.Fake<IKatacombsWorld>();
            A.CallTo(() => _katacombsWorld.GetStartingLocation()).Returns(_initialLocation);

            _katacombsEngine = new KatacombsEngine(_katacombsWorld);
            _katacombsEngine.ShowMessage += RecordLastMessage;
            _katacombsEngine.Startup();
        }

        [Test]
        public void Show_main_description_for_initial_location_when_started()
        {
            Assert.That(_lastMessage, Is.EquivalentTo(_initialLocation.Display()));
        }

        [Test]
        public void Display_main_description_when_moving_to_next_location()
        {
            A.CallTo(() => _katacombsWorld.GetLocation(A<string>._)).Returns(_nextLocation);

            _katacombsEngine.Execute("GO N");

            Assert.That(_lastMessage, Is.EquivalentTo(_nextLocation.Display()));
        }

        [Test]
        public void Display_initial_description_when_moving_to_next_location_and_back()
        {
            A.CallTo(() => _katacombsWorld.GetLocation(A<string>._)).ReturnsNextFromSequence(_nextLocation, _initialLocation);

            _katacombsEngine.Execute("GO N");
            _katacombsEngine.Execute("GO S");

            Assert.That(_lastMessage, Is.EquivalentTo(_initialLocation.Display()));
        }

        private void RecordLastMessage(string[] messageText)
        {
            _lastMessage = messageText;
        }
    }
}
