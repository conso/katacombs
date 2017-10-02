using System;

namespace Codurance_Katacombs
{
    public class KatacombsWorld : IKatacombsWorld
    {
        public event Action<string[]> DisplayMessage;
        public void SetCurrentLocationTo(string locationTitle)
        {
            throw new NotImplementedException();
        }

        public Location CurrentLocation()
        {
            throw new NotImplementedException();
        }
    }
}