namespace TravellerGalaxyGenertor.TravellerGalaxy.Interfaces
{
    public interface IWorld
    {
        string Name { get; }
        int WorldNumber { get; }
        string ToString();
        string WorldData();
        string ShortDescription();
    }
}