using System.Collections.Generic;
using System.Linq;
using Codurance_Katacombs.Builders;
using Codurance_Katacombs.Core;
using Codurance_Katacombs.Core.Controller;
using Codurance_Katacombs.Infrastructure;
using FakeItEasy;
using NUnit.Framework;

namespace Codurance_Katacombs.Acceptance
{
    [TestFixture]
    public partial class MovingAroundTheWorldFeature
    {
        private IWrapConsole _fakeConsole;
        private IKatacombsEngine _katacombsEngine;
        private KatacombsController _katacombsController;
        private List<string> _readMessages;

        [SetUp]
        public void TestSetup()
        {
            _readMessages = new List<string>();
            _fakeConsole = A.Fake<IWrapConsole>();
            _katacombsEngine = new KatacombsEngine(SetupWorld());
            _katacombsController = new KatacombsController(_katacombsEngine, _fakeConsole);

            _katacombsEngine.DisplayMessage += (messageText) => _readMessages.AddRange(messageText);
        }

        private void Given_I_startup_the_game_with_3_locations()
        {
            _katacombsController.StartGame();
        }

        private void When_I_move_to_all_locations_and_back()
        {
            _fakeConsole.ReadLine += Raise.FreeForm.With("GO N");
            _fakeConsole.ReadLine += Raise.FreeForm.With("GO W");
            _fakeConsole.ReadLine += Raise.FreeForm.With("GO UP");
            _fakeConsole.ReadLine += Raise.FreeForm.With("GO DOWN");
            _fakeConsole.ReadLine += Raise.FreeForm.With("GO E");
            _fakeConsole.ReadLine += Raise.FreeForm.With("GO S");
        }

        private void Then_all_location_messages_should_have_shown_in_correct_order()
        {
            Assert.That(_readMessages.Count, Is.EqualTo(14));
            Assert.That(_readMessages.ElementAt(0), Is.EqualTo(_readMessages.ElementAt(12)));
            Assert.That(_readMessages.ElementAt(1), Is.EqualTo(_readMessages.ElementAt(13)));
            Assert.That(_readMessages.ElementAt(2), Is.EqualTo(_readMessages.ElementAt(10)));
            Assert.That(_readMessages.ElementAt(3), Is.EqualTo(_readMessages.ElementAt(11)));
            Assert.That(_readMessages.ElementAt(4), Is.EqualTo(_readMessages.ElementAt(8)));
            Assert.That(_readMessages.ElementAt(5), Is.EqualTo(_readMessages.ElementAt(9)));
        }

        private IKatacombsWorld SetupWorld()
        {
            IList<Location> locations = new List<Location>
            {
                new LocationBuilder("title 1", "description 1").WithNorth("title 2").Build(),
                new LocationBuilder("title 2", "description 2").WithSouth("title 1").WithWest("title 3").Build(),
                new LocationBuilder("title 3", "description 3").WithEast("title 2").WithUp("title 4").Build(),
                new LocationBuilder("title 4", "description 4").WithDown("title 3").Build()
            };
            return new KatacombsWorld(locations, locations.First().Title);
        }
    }
}