using System;
using System.Collections.Generic;
using System.Linq;
using Codurance_Katacombs.Commands;

namespace Codurance_Katacombs.Core
{
    public class KatacombsWorld : IKatacombsWorld
    {
        public event Action<string[]> DisplayMessage;
        private Location CurrentLocation { get; set; }

        private readonly IDictionary<string, Location> _definedLocations;
        private readonly Bag _items;

        public KatacombsWorld(ICollection<Location> definedLocations, string startupLocationTitle) 
            : this(definedLocations, startupLocationTitle, new Bag())
        { }

        public KatacombsWorld(ICollection<Location> definedLocations, string startupLocationTitle, Bag userItems)
        {
            _definedLocations = definedLocations.ToDictionary(location => location.Title);
            CurrentLocation = _definedLocations[startupLocationTitle];
            _items = userItems;
        }
        
        public void SetCurrentLocationTo(string locationTitle)
        {
            CurrentLocation = _definedLocations[locationTitle];
            ShowMessage(CurrentLocation.Display());
        }

        public void DisplayInventory()
        {
            ShowMessage(_items.ToText());
        }

        public ILocationCommand CommandForCurrentLocation(string commandText)
        {
            return CurrentLocation.GetCommand(commandText);
        }

        public string[] DisplayCurrentLocation()
        {
            return CurrentLocation.Display();
        }

        private void ShowMessage(string[] textMessage)
        {
            DisplayMessage?.Invoke(textMessage);
        }
    }
}