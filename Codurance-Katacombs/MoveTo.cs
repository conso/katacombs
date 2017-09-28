namespace Codurance_Katacombs
{
    public class MoveTo : ILocationCommand
    {
        private readonly string _destination;
        private readonly Location _from;

        public MoveTo(string destinationTitle, Location from)
        {
            _destination = destinationTitle;
            _from = from;
        }

        public void Execute()
        {
            _from.ChangeLocationTo(_destination);
        }
    }
}