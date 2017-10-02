namespace Codurance_Katacombs.Commands
{
    public interface ICommandFactory
    {
        ILocationCommand GetCommand(string commandText, IKatacombsWorld world);
    }
}