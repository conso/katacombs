using Codurance_Katacombs.Builders;
using Codurance_Katacombs.Commands;
using Codurance_Katacombs.Core;
using NUnit.Framework;

namespace Codurance_Katacombs.Tests.Core
{
    [TestFixture]
    public class LocationShould
    {
        private Location _location;
        private string _northernLocationTitle;
        private string _locationTitle;
        private string _locationDescription;

        [SetUp]
        public void TestSetup()
        {
            _locationTitle = "location title";
            _locationDescription = "location description";
            _northernLocationTitle = "northern location";
            _location = new LocationBuilder(_locationTitle, _locationDescription).Build();
        }

        [Test]
        public void Display_main_message()
        {
            
            var location = new Location(_locationTitle, _locationDescription);

            var mainMessage = location.Display();

            Assert.That(mainMessage, Is.EquivalentTo(new[] {_locationTitle, _locationDescription}));
        }

        [Test]
        public void Contain_system_commands()
        {
            
            var location = new Location(_locationTitle, _locationDescription);

            var inventoryCommand = location.GetCommand("BAG");

            Assert.That(inventoryCommand, Is.TypeOf<Inventory>());
        }

        [Test]
        public void Get_commands_when_present()
        {
            _location.AddMoveToCommand("GO N", _northernLocationTitle);

            var command = _location.GetCommand("GO N");

            Assert.That(command, Is.InstanceOf<ILocationCommand>());
        }
    }
}
