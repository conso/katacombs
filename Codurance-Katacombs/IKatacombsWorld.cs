using System;

namespace Codurance_Katacombs
{
    public interface IKatacombsWorld
    {
        void Startup();
        event Action<string[]> ShowMessage;
        void Execute(string commandText);
    }
}