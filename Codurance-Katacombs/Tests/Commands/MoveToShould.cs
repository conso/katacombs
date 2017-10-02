using Codurance_Katacombs.Commands;
using Codurance_Katacombs.Core;
using FakeItEasy;
using NUnit.Framework;

namespace Codurance_Katacombs.Tests.Commands
{
    [TestFixture]
    public class MoveToShould
    {
        [Test]
        public void Change_current_position_to_next_location()
        {
            string nextLocation = "next location";
            var moveToCommand = new MoveTo(nextLocation);
            var fakeWorld = A.Fake<IKatacombsWorld>();
            moveToCommand.SetContext(fakeWorld);

            moveToCommand.Execute();

            A.CallTo(() => fakeWorld.SetCurrentLocationTo(nextLocation)).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
