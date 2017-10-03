using System;

namespace Codurance_Katacombs.Core
{
    public interface IKatacombsWorld
    {
        event Action<string[]> DisplayMessage;
        Location CurrentLocation { get; }
        void SetCurrentLocationTo(string locationTitle);
        void DisplayInventory();
    }
}