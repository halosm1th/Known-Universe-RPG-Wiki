using System;
using TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds;

namespace TravellerGalaxyGenertor.TravellerGalaxy.Information.Settlemeant;

public class KnownUniverseResearchOutpost : KnownUniversePlanetarySettlement
{
    enum ResearchOutpostBuildings
    {
        CentralOutpost = 0,
        Dormitory = 1,
        StorageRoom = 2,
        RecreationHall =3,
        ResearchOutpost= 4,
        MastersChamber =5,
        WorkRoom = 6,
        LandingPad,
        VehicleGarage,
        Generator,
        CommsOutpost
    }
    public KnownUniverseResearchOutpost(SettlementSize size, int population) : base(size, population)
    {        
        var random = new Random(((int) size) +population) ;
        for (int i = 0; i < (int) size; i++)
        {
            var buildingType = (ResearchOutpostBuildings) random.Next(0, 7); 
            Buildings.Add(new KnownUniverseBuilding(buildingType.ToString()));
        }
    }
}