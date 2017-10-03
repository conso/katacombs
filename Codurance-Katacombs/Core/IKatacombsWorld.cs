using System;
using Codurance_Katacombs.Commands;

namespace Codurance_Katacombs.Core
{
    public interface IKatacombsWorld
    {
        event Action<string[]> DisplayMessage;
        void SetCurrentLocationTo(string locationTitle);
        void DisplayInventory();
        ILocationCommand CommandForCurrentLocation(string commandText);
        string[] DisplayCurrentLocation();
    }
}