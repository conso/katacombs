using System;

namespace Codurance_Katacombs
{
    public interface IKatacombsEngine
    {
        void Startup();
        event Action<string[]> ShowMessage;
        void Execute(string commandText);
    }
}