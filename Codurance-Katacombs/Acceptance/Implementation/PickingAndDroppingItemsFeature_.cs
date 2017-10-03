using System.Collections.Generic;
using System.Linq;
using Codurance_Katacombs.Commands;
using Codurance_Katacombs.Core;
using Codurance_Katacombs.Core.Controller;
using Codurance_Katacombs.Infrastructure;
using FakeItEasy;
using NUnit.Framework;

namespace Codurance_Katacombs.Acceptance
{
    [TestFixture]
    public partial class PickingAndDroppingItemsFeature
    {
        private IWrapConsole _fakeConsole;
        private IKatacombsEngine _katacombsEngine;
        private KatacombsController _katacombsController;
        private List<string> _readMessages;
        private const string NO_ITEMS_MESSAGE = "YOU HAVE NO ITEMS IN YOUR BAG.";
        private const string NO_GOLD_MESSAGE = "YOU HAVE 0 GOLD COINS.";

        [SetUp]
        public void TestSetup()
        {
            _readMessages = new List<string>();
            _fakeConsole = A.Fake<IWrapConsole>();
            _katacombsEngine = new KatacombsEngine(SetupWorld(), new CommandFactory());
            _katacombsController = new KatacombsController(_katacombsEngine, _fakeConsole);

            _katacombsEngine.DisplayMessage += (messageText) => _readMessages.AddRange(messageText);
        }

        private IKatacombsWorld SetupWorld()
        {
            Location location = new Location("title", "description");
            return new KatacombsWorld(new[]{location}.ToList(), location.Title);
        }
        
        private void Given_I_have_an_empty_bag()
        {
            _katacombsController.StartGame();
        }

        private void When_I_check_the_content_of_the_bag()
        {
            _fakeConsole.ReadLine += Raise.FreeForm.With("BAG");
        }

        private void Then_message_should_have_been_shown()
        {
            Assert.That(_readMessages.ElementAt(_readMessages.Count - 2), Is.EqualTo(NO_GOLD_MESSAGE));
            Assert.That(_readMessages.Last(), Is.EqualTo(NO_ITEMS_MESSAGE));
        }
    }
}
