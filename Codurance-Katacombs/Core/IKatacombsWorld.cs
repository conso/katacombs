using System;

namespace Codurance_Katacombs.Core
{
    public interface IKatacombsWorld
    {
        event Action<string[]> DisplayMessage;

        void SetCurrentLocationTo(string locationTitle);

        Location CurrentLocation();
    }
}