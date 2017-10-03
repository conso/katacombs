using System.Collections.Generic;
using System.Linq;
using Codurance_Katacombs.Commands;

namespace Codurance_Katacombs.Core
{
    public class Locations
    {
        private readonly IDictionary<string, Location> _indexedLocations;
        private Location _currentLocation;
        
        public Locations(ICollection<Location> definedLocations, string startupLocationTitle)
        {
            _indexedLocations = definedLocations.ToDictionary(location => location.Title);
            _currentLocation = LocationForTitle(startupLocationTitle);
        }

        public Location LocationForTitle(string locationTitle)
        {
            return _indexedLocations[locationTitle];
        }

        public void SetCurrentLocationTo(string locationTitle)
        {
            _currentLocation = LocationForTitle(locationTitle);
        }

        public ILocationCommand CommandForCurrentLocation(string commandText)
        {
            return _currentLocation.GetCommand(commandText);
        }

        public string[] DisplayCurrentLocation()
        {
            return _currentLocation.Display();
        }
    }
}