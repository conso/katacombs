using FakeItEasy;
using NUnit.Framework;

namespace Codurance_Katacombs.Tests
{
    [TestFixture]
    public class KatacombsGameControllerShould
    {
        private IWrapConsole _console;
        private KatacombsController _katacombsController;

        [SetUp]
        public void TestSetup()
        {
            _console = A.Fake<IWrapConsole>();
            _katacombsController = new KatacombsController(_console);
            _katacombsController.StartGame();
        }

        [Test]
        public void Display_main_description_for_initial_location()
        {
            A.CallTo(() => _console.Write("Initial environment title", "Initial environment message"))
                .MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Display_main_description_when_moving_to_next_location()
        {
            _console.ReadLine += Raise.FreeForm.With("GO N");

            A.CallTo(() => _console.Write("Next location title", "Next location message"))
                .MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void Display_initial_description_when_moving_to_next_location_and_back()
        {
            _console.ReadLine += Raise.FreeForm.With("GO N");
            _console.ReadLine += Raise.FreeForm.With("GO S");

            A.CallTo(() => _console.Write("Initial environment title", "Initial environment message"))
                .MustHaveHappened(Repeated.Exactly.Twice);
        }
    }
}
