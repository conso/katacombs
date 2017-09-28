using NUnit.Framework;

namespace Codurance_Katacombs.Tests
{
    [TestFixture]
    public class LocationShould
    {
        private Location _location;
        private string _lastDestination;
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
            _location.ChangeTo += ChangeLocationEvent;
        }

        [Test]
        public void Display_main_message()
        {
            
            var location = new Location(_locationTitle, _locationDescription);

            var mainMessage = location.Display();

            Assert.That(mainMessage, Is.EquivalentTo(new[] {_locationTitle, _locationDescription}));
        }

        [Test]
        public void Execute_command_for_going_North()
        {
            _location.AddMovingCommand("GO N", _northernLocationTitle);

            _location.Execute("GO N");

            Assert.That(_lastDestination, Is.EqualTo(_northernLocationTitle));
        }

        private void ChangeLocationEvent(string destinationTitle)
        {
            _lastDestination = destinationTitle;
        }
    }


    
}
