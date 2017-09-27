using FakeItEasy;
using NUnit.Framework;

namespace Codurance_Katacombs.Tests
{
    [TestFixture]
    public class KatacombsGameControllerShould
    {
        [Test]
        public void Display_initial_environment_message()
        {
            IWrapConsole console = A.Fake<IWrapConsole>();

            var controller = new KatacombsGameController(console);
            controller.StartGame();

            A.CallTo(() => console.Display("Initial environment message")).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
