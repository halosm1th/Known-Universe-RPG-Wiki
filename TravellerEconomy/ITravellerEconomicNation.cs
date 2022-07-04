using TravellerMapSystem.Worlds;
using TravellerLocationSystem;

namespace TravellerEconomySystem;

public interface ITravellerEconomicNation
{
    public Dictionary<TravellerLocationSystem.TravellerSectorLocation, KnownUniverseSystem> Systems { get; }
    public Dictionary<string, IExpenditure> Expenitures { get; }
}