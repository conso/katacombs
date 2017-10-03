using System;
using System.Collections.Generic;
using System.Linq;

namespace Codurance_Katacombs.Core
{
    public class KatacombsWorld : IKatacombsWorld
    {
        public event Action<string[]> DisplayMessage;
        public Location CurrentLocation { get; private set; }

        private readonly IDictionary<string, Location> _definedLocations;
        private readonly Bag _items;

        public KatacombsWorld(IList<Location> definedLocations, string startupLocationTitle) 
            : this(definedLocations, startupLocationTitle, new Bag())
        { }

        public KatacombsWorld(IList<Location> definedLocations, string startupLocationTitle, Bag userItems)
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

        private void ShowMessage(string[] textMessage)
        {
            DisplayMessage?.Invoke(textMessage);
        }
    }
}