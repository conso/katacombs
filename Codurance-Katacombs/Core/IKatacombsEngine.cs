using System;

namespace Codurance_Katacombs.Core
{
    public interface IKatacombsEngine
    {
        void Startup();
        event Action<string[]> DisplayMessage;
        void Execute(string commandText);
    }
}