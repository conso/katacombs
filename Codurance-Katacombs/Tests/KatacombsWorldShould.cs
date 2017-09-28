using FakeItEasy;
using NUnit.Framework;

namespace Codurance_Katacombs.Tests
{
    [TestFixture]
    public class KatacombsWorldShould
    {
        private IKatacombsWorld _katacombsWorld;
        private string[] _lastMessage;
        private readonly string[] _initialMessage =  { "Initial environment title", "Initial environment message" };

        [SetUp]
        public void TestSetup()
        {
            _lastMessage = null;
            _katacombsWorld = new KatacombsWorld();
            _katacombsWorld.ShowMessage += RecordLastMessage;
            _katacombsWorld.Startup();
        }

        [Test]
        public void Show_main_description_for_initial_location_when_started()
        {
            Assert.That(_lastMessage, Is.EquivalentTo(_initialMessage));
        }

        [Test]
        public void Display_main_description_when_moving_to_next_location()
        {
            _katacombsWorld.Execute("GO N");

            var nextLocationMessage = new[] {"Next location title", "Next location message"};
            Assert.That(_lastMessage, Is.EquivalentTo(nextLocationMessage));
        }

        [Test]
        public void Display_initial_description_when_moving_to_next_location_and_back()
        {
            _katacombsWorld.Execute("GO N");
            _katacombsWorld.Execute("GO S");

            Assert.That(_lastMessage, Is.EquivalentTo(_initialMessage));
        }

        private void RecordLastMessage(string[] messageText)
        {
            _lastMessage = messageText;
        }
    }
}
