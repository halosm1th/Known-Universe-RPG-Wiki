namespace TravellerGalaxyGenertor.TravellerGalaxy.Interfaces
{
    public interface IWorld
    {
        string WorldType { get; }
        string Name { get; }
        string Population { get; }
        int TechLevel { get; }
        int WorldNumber { get; }
        string ToString();
        string WorldData();
        string ShortDescription();
    }
}