using TravellerFactionSystem.Location;

namespace TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds;

public class KnownUniverseBuilding : TravellerLocation
{
    public string Type { get; }

    public KnownUniverseBuilding(string type)
    {
        Type = type;
    }
}