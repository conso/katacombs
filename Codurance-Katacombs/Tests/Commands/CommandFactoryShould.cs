using Codurance_Katacombs.Commands;
using Codurance_Katacombs.Core;
using FakeItEasy;
using NUnit.Framework;

namespace Codurance_Katacombs.Tests.Commands
{
    [TestFixture]
    public class CommandFactoryShould
    {
        [Test]
        public void Create_command_from_current_location()
        {
            var fakeWorld = A.Fake<IKatacombsWorld>();
            var location = new Location("location 1", "description");
            location.AddMoveToCommand("GO N", "location 2");
            A.CallTo(() => fakeWorld.CurrentLocation).Returns(location);

            CommandFactory commandFactory = new CommandFactory();
            Assert.That(commandFactory.GetCommand("GO N", fakeWorld), Is.EqualTo(location.GetCommand("GO N")));
        }
    }
}
