namespace Codurance_Katacombs
{
    public class Location
    {
        private readonly string _title;
        private readonly string _description;

        public Location(string title, string description)
        {
            _title = title;
            _description = description;
        }

        public string[] Display()
        {
            return new[] {_title, _description};
        }
    }
}