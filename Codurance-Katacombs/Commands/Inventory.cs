using Codurance_Katacombs.Core;

namespace Codurance_Katacombs.Commands
{
    public class Inventory : ILocationCommand
    {
        private IKatacombsWorld _world;

        public void Execute()
        {
            _world.DisplayInventory();
        }

        public void SetContext(IKatacombsWorld world)
        {
            _world = world;
        }
    }
}