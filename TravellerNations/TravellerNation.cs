using TravellerEconomySystem;
using TravellerGalaxyGenertor;
using TravellerLocationSystem;
using TravellerMapSystem.Worlds;
using TravellerEconomy = TravellerEconomySystem.TravellerEconomy;

namespace TravellerNations;

public class TravellerNation : ITravellerEconomicNation
{
    public Dictionary<TravellerLocationSystem.TravellerLocation, KnownUniverseSystem> Systems { get; }

    public Dictionary<string, IExpenditure> Expenitures { get; }
    public Dictionary<string, IMilitaryAsset> Military { get; }

    public TravellerEconomy Economy { get; }
    public string password { get; }
    public string NationName { get; }

    public TravellerNation(List<TravellerLocation> systemsLocations, 
        Dictionary<string, IMilitaryAsset> military, 
        string password, string nationName)
    {
        Systems = GetSystemsFromLocations(systemsLocations);
        Expenitures = new Dictionary<string, IExpenditure>();
        Economy = new TravellerEconomy(this);
        
        Military = military;
        this.password = password;
        NationName = nationName;

        foreach (var mil in Military)
        {
            Expenitures.Add(mil.Key,mil.Value);
        }
    }

    private Dictionary<TravellerLocation, KnownUniverseSystem> GetSystemsFromLocations(List<TravellerLocation> systemsLocations)
    {
        var sectorID = globals.subsectorService.GetSubsectorID("Everly");
        var sector = globals.subsectorService.GetSubsector(sectorID);

        var systems = new Dictionary<TravellerLocation, KnownUniverseSystem>();
        
        
        foreach (var location in systemsLocations)
        {
            var locationReal = location as TravellerSubsectorLocation;
            var system = sector.GetSystem(locationReal.SubsectorX,locationReal.SubsectorY);
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
        return $"{NationName}: {Economy.ToString()} " +
               $"({Systems.Select(x => x.Value.Name).Aggregate("",(h,t) => h+" "+t)})";
    }
}