using Codurance_Katacombs.Core;

namespace Codurance_Katacombs.Commands
{
    public interface ILocationCommand
    {
        void Execute();
        void SetContext(IKatacombsWorld world);
    }
}