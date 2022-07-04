using TravellerEconomySystem;
using TravellerGalaxyGenertor;
using TravellerLocationSystem;
using TravellerMapSystem.Worlds;
using TravellerEconomy = TravellerEconomySystem.TravellerEconomy;

namespace TravellerNations;

public class TravellerNation : ITravellerEconomicNation
{
    public Dictionary<TravellerLocationSystem.TravellerSectorLocation, KnownUniverseSystem> Systems { get; }
    public Dictionary<string, IExpenditure> Expenitures { get; }
    public Dictionary<string, IMilitaryAsset> Military { get; }

    public TravellerEconomy Economy { get; }
    public string password { get; }
    public string NationName { get; }

    public TravellerNation(List<TravellerSectorLocation> systemsLocations, Dictionary<string, IMilitaryAsset> military, string password, string nationName)
    {
        Systems = GetSystemsFromLocations(systemsLocations);
        Military = military;
        Economy = new TravellerEconomy(this);
        this.password = password;
        NationName = nationName;
    }

    private Dictionary<TravellerSectorLocation, KnownUniverseSystem> GetSystemsFromLocations(List<TravellerSectorLocation> systemsLocations)
    {
        var sectorID = globals.subsectorService.GetSectorID("Everly");
        var sector = globals.subsectorService.GetSector(sectorID);

        var systems = new Dictionary<TravellerSectorLocation, KnownUniverseSystem>();
        
        
        foreach (var location in systemsLocations)
        {
            var system = sector.GetSystem(location);
            systems.Add(location, system);
        }

        return systems;
    }

    public void Update()
    {
        Economy.UpdateEconomicStatus();
    }

    public override string ToString()
    {
        return $"{NationName}: {Economy.ToString()}";
    }
}