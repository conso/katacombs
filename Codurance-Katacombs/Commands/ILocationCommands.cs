namespace Codurance_Katacombs.Commands
{
    public interface ILocationCommands
    {
        ILocationCommand GetCommand(string commandText);
        void AddMoveToCommand(string commandText, string destinationTitle);
    }
}