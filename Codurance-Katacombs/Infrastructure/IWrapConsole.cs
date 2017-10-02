using System;

namespace Codurance_Katacombs.Infrastructure
{
    public interface IWrapConsole
    {
        void Write(params string[] textLines);
        event Action<string> ReadLine;
    }
}