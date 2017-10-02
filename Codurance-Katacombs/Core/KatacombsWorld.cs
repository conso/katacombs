using System;
using System.Collections.Generic;
using System.Linq;

namespace Codurance_Katacombs.Core
{
    public class KatacombsWorld : IKatacombsWorld
    {
        public event Action<string[]> DisplayMessage;

        private readonly IDictionary<string, Location> _definedLocations;
        private Location _currentLocation;
        
        public KatacombsWorld(IList<Location> definedLocations, string startupLocationTitle)
        {
            _definedLocations = definedLocations.ToDictionary(location => location.Title);
            _currentLocation = _definedLocations[startupLocationTitle];
        }

        public void SetCurrentLocationTo(string locationTitle)
        {
            _currentLocation = _definedLocations[locationTitle];
            ShowCurrentLocationMessage();
        }

        public Location CurrentLocation()
        {
            return _currentLocation;
        }

        private void ShowCurrentLocationMessage()
        {
            DisplayMessage?.Invoke(_currentLocation.Display());
        }
    }
}