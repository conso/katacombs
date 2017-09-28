namespace Codurance_Katacombs.Tests
{
    public class LocationBuilder
    {
        private readonly string _title;
        private readonly string _description;
        private string _northernLocationTitle;
        private string _southernLocationTitle;

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

        public Location Build()
        {
            var location = new Location(_title, _description);
            if(_northernLocationTitle!= null)
                location.AddMovingCommand("GO N", _northernLocationTitle);
            if(_southernLocationTitle!= null)
                location.AddMovingCommand("GO S", _southernLocationTitle);
            return location;
        }
    }
}