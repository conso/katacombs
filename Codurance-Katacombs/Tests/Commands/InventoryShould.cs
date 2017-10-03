using System.Collections.Generic;
using Codurance_Katacombs.Commands;
using Codurance_Katacombs.Core;
using FakeItEasy;
using NUnit.Framework;

namespace Codurance_Katacombs.Tests.Commands
{
    [TestFixture]
    public class InventoryShould
    {
        private IKatacombsWorld _world;
        private List<string> _messages;
        private const string EMPTY_BAG_MESSAGE = "THERE ARE NO ITEMS IN THE BAG.";

        [SetUp]
        public void TestSetup()
        {
            _messages = new List<string>();
            _world = A.Fake<IKatacombsWorld>();
            _world.DisplayMessage += CollectMessage;
        }

        [Test]
        public void Display_inventory_of_items_in_the_bag()
        {
            ILocationCommand inventoryCommand = new Inventory();
            inventoryCommand.SetContext(_world);

            inventoryCommand.Execute();

            A.CallTo(() => _world.DisplayInventory()).MustHaveHappened(Repeated.Exactly.Once);
        }

        private void CollectMessage(string[] messageText)
        {
            _messages.AddRange(messageText);
        }
    }
}
