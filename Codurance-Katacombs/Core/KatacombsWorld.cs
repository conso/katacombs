using System;
using System.Collections.Generic;
using Codurance_Katacombs.Commands;

namespace Codurance_Katacombs.Core
{
    public class KatacombsWorld : IKatacombsWorld
    {
        public event Action<string[]> DisplayMessage;

        private readonly Locations _locations;
        private readonly Bag _items;

        public KatacombsWorld(ICollection<Location> definedLocations, string startupLocationTitle) 
            : this(definedLocations, startupLocationTitle, new Bag())
        { }

        public KatacombsWorld(ICollection<Location> definedLocations, string startupLocationTitle, Bag userItems)
        {
            _locations = new Locations(definedLocations, startupLocationTitle);
            _items = userItems;
        }
        
        public void SetCurrentLocationTo(string locationTitle)
        {
            _locations.SetCurrentLocationTo(locationTitle);
            ShowMessage(_locations.DisplayCurrentLocation());
        }

        public void DisplayInventory()
        {
            ShowMessage(_items.ToText());
        }

        public ILocationCommand CommandForCurrentLocation(string commandText)
        {
            return _locations.CommandForCurrentLocation(commandText);
        }

        public string[] DisplayCurrentLocation()
        {
            return _locations.DisplayCurrentLocation();
        }

        private void ShowMessage(string[] textMessage)
        {
            DisplayMessage?.Invoke(textMessage);
        }
    }
}