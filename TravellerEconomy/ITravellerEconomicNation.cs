using TravellerMapSystem.Worlds;
using TravellerLocationSystem;

namespace TravellerEconomySystem;

public interface ITravellerEconomicNation
{
    public Dictionary<TravellerLocationSystem.TravellerLocation, KnownUniverseSystem> Systems { get; }
    public Dictionary<string, IExpenditure> Expenitures { get; }
}