using NUnit.Framework;

namespace Codurance_Katacombs.Tests
{
    [TestFixture]
    public class MoveToShould
    {
        private string _lastDestination;

        [Test]
        public void Raise_Change_To_Event()
        {
            var location = new Location("blah", "blah");
            location.ChangeTo += ChangeToEventRaised;
            var moveToCommand = new MoveTo("there", location);

            moveToCommand.Execute();

            Assert.That(_lastDestination, Is.EqualTo("there"));
        }

        private void ChangeToEventRaised(string destination)
        {
            _lastDestination = destination;
        }
    }
}
