using Codurance_Katacombs.Core;

namespace Codurance_Katacombs.Builders
{
    public class LocationBuilder
    {
        private readonly string _title;
        private readonly string _description;
        private string _northernLocationTitle;
        private string _southernLocationTitle;
        private string _westernLocationTitle;
        private string _easternLocationTitle;
        private string _upperLocationTitle;
        private string _lowerLocationTitle;

        public LocationBuilder(string title, string description)
        {
            _title = title;
            _description = description;
        }

        public LocationBuilder WithNorth(string northernLocationTitle)
        {
            _northernLocationTitle = northernLocationTitle;
            return this;
        }

        public LocationBuilder WithSouth(string southernLocationTitle)
        {
            _southernLocationTitle = southernLocationTitle;
            return this;
        }

        public LocationBuilder WithWest(string westernLocationTitle)
        {
            _westernLocationTitle = westernLocationTitle;
            return this;
        }

        public LocationBuilder WithEast(string easternLocationTitle)
        {
            _easternLocationTitle = easternLocationTitle;
            return this;
        }

        public LocationBuilder WithUp(string upperLocationTitle)
        {
            _upperLocationTitle = upperLocationTitle;
            return this;
        }

        public LocationBuilder WithDown(string lowerLocationTitle)
        {
            _lowerLocationTitle = lowerLocationTitle;
            return this;
        }



        public Location Build()
        {
            var location = new Location(_title, _description);
            if (!string.IsNullOrWhiteSpace(_northernLocationTitle))
                location.AddMoveToCommand("GO N", _northernLocationTitle);
            if (!string.IsNullOrWhiteSpace(_southernLocationTitle))
                location.AddMoveToCommand("GO S", _southernLocationTitle);
            if (!string.IsNullOrWhiteSpace(_westernLocationTitle))
                location.AddMoveToCommand("GO W", _westernLocationTitle);
            if (!string.IsNullOrWhiteSpace(_easternLocationTitle))
                location.AddMoveToCommand("GO E", _easternLocationTitle);
            if (!string.IsNullOrWhiteSpace(_upperLocationTitle))
                location.AddMoveToCommand("GO UP", _upperLocationTitle);
            if (!string.IsNullOrWhiteSpace(_lowerLocationTitle))
                location.AddMoveToCommand("GO DOWN", _lowerLocationTitle);
            return location;
        }

        
    }
}