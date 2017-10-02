using System.Collections.Generic;
using Codurance_Katacombs.Core;
using NUnit.Framework;

namespace Codurance_Katacombs.Tests.Core
{
    [TestFixture]
    public class KatacombsWorldShould
    {
        private IKatacombsWorld _katacombsWorld;
        private Location _startLocation;
        private Location _nextLocation;

        [SetUp]
        public void TestSetup()
        {
            _startLocation = new Location("first location", "starting location");
            _nextLocation = new Location("next location", "another location");
            IList<Location> definedLocations = new List<Location> {_startLocation, _nextLocation};
            _katacombsWorld = new KatacombsWorld(definedLocations, _startLocation.Title);
        }

        [Test]
        public void Set_current_location_to_another_location()
        {
            _katacombsWorld.SetCurrentLocationTo(_nextLocation.Title);

            Assert.That(_katacombsWorld.CurrentLocation().Display(), Is.EqualTo(_nextLocation.Display()));
        }

        [Test]
        public void Display_message_when_set_new_current_location_to_another_location()
        {
            string[] messageLines = null;
            _katacombsWorld.DisplayMessage += (message) => messageLines = message;

            _katacombsWorld.SetCurrentLocationTo(_nextLocation.Title);

            Assert.That(messageLines, Is.EquivalentTo(_nextLocation.Display()));
        }
    }
}
