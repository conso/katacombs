using System.Collections.Generic;
using System.Linq;
using Codurance_Katacombs.Core;
using NUnit.Framework;

namespace Codurance_Katacombs.Tests.Core
{
    [TestFixture]
    public class KatacombsWorldShould
    {
        private const string NO_ITEMS_MESSAGE = "YOU HAVE NO ITEMS IN YOUR BAG.";
        private const string NO_GOLD_MESSAGE = "YOU HAVE 0 GOLD COINS.";
        private IKatacombsWorld _katacombsWorld;
        private Location _startLocation;
        private Location _nextLocation;
        private string[] _messageLines;

        [SetUp]
        public void TestSetup()
        {
            _startLocation = new Location("first location", "starting location", new LocationCommands());
            _nextLocation = new Location("next location", "another location", new LocationCommands());
            IList<Location> definedLocations = new List<Location> {_startLocation, _nextLocation};
            _katacombsWorld = new KatacombsWorld(definedLocations, _startLocation.Title);
            _katacombsWorld.DisplayMessage += (message) => _messageLines = message;
        }

        [Test]
        public void Set_current_location_to_another_location()
        {
            _katacombsWorld.SetCurrentLocationTo(_nextLocation.Title);

            Assert.That(_katacombsWorld.DisplayCurrentLocation(), Is.EqualTo(_nextLocation.Display()));
        }

        [Test]
        public void Display_location_message_when_set_current_location_to_next_location()
        {
            _katacombsWorld.SetCurrentLocationTo(_nextLocation.Title);

            Assert.That(_messageLines, Is.EquivalentTo(_nextLocation.Display()));
        }

        [Test]
        public void Display_message_when_neither_items_nor_gold_are_in_the_bag()
        {
            _katacombsWorld.DisplayInventory();

            Assert.That(_messageLines.ElementAt(_messageLines.Length-2), Is.EquivalentTo(NO_GOLD_MESSAGE));
            Assert.That(_messageLines.Last(), Is.EquivalentTo(NO_ITEMS_MESSAGE));
        }
    }
}
