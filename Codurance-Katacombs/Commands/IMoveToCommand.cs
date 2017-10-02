namespace Codurance_Katacombs.Commands
{
    public interface IMoveToCommand : ILocationCommand
    {
        void SetContext(IKatacombsWorld world);

    }
}