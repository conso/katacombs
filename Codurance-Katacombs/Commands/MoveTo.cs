using Codurance_Katacombs.Core;

namespace Codurance_Katacombs.Commands
{
    public class MoveTo : ILocationCommand
    {
        private readonly string _destination;
        private IKatacombsWorld _world;

        public MoveTo(string destinationTitle)
        {
            _destination = destinationTitle;
        }

        public void SetContext(IKatacombsWorld world)
        {
            _world = world;
        }

        public void Execute()
        {
            _world.SetCurrentLocationTo(_destination);
        }
    }
}