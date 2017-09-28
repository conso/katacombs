namespace Codurance_Katacombs
{
    public interface IKatacombsWorld
    {
        Location GetStartingLocation();
        Location GetLocation(string locationTitle);
    }
}