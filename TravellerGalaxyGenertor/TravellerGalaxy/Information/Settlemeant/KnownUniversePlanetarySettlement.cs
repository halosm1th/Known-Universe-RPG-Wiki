using System.Collections.Generic;
using TravellerFactionSystem.Location;
using TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds;

namespace TravellerGalaxyGenertor.TravellerGalaxy.Information.Settlemeant;

public abstract class KnownUniversePlanetarySettlement : TravellerLocation
{
    public SettlementSize Size;
    public int Population;
    public List<KnownUniverseBuilding> Buildings { get; set; }

    public KnownUniversePlanetarySettlement(SettlementSize size, int population)
    {
        Size = size;
        Population = population;
        Buildings = new List<KnownUniverseBuilding>();
    }

}