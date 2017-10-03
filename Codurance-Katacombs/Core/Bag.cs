using System.Collections.Generic;
 using System.Linq;

namespace Codurance_Katacombs.Core
{
    public class Bag
    {
        private const string NO_ITEMS_MESSAGE = "YOU HAVE NO ITEMS IN YOUR BAG.";
        private const string NO_GOLD_MESSAGE = "YOU HAVE 0 GOLD COINS.";
        private readonly IDictionary<string,Item> _items;
        private int _goldCoins;

        public Bag() : 
            this(new Item[] { }, 0)
        {}

        public Bag(IEnumerable<Item> items, int goldCoins)
        {
            _items = items.ToDictionary(i => i.Title, i => i);
            _goldCoins = 0;
        }

        public string[] ToText()
        {
            var goldMessage = NO_GOLD_MESSAGE;
            if (_goldCoins > 0)
                goldMessage = $"YOU HAVE {_goldCoins} GOLD COINS.";

            var itemsMessage = NO_ITEMS_MESSAGE;
            if (_items.Any())
                itemsMessage = $"THE BAG CONTAINS: {string.Join(", ", _items.Select(i => i.Value.Title))}.";
            return new[] {goldMessage, itemsMessage};
        }
    }
}