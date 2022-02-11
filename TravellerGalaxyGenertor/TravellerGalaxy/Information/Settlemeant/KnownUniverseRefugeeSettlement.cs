using System;
using TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds;

namespace TravellerGalaxyGenertor.TravellerGalaxy.Information.Settlemeant;

public class KnownUniverseRefugeeSettlement : KnownUniversePlanetarySettlement
{
    enum RefugeeCampBuildings
    {
        CampHQ = 0,
        RestArea = 1,
        CampEntrance = 2,
        CampMedical =3,
        CampMess = 4,
        CampStorrage =5,
        CampMarket = 6,
        LandingPad,
        VehicleGarage,
        Generator,
        CommsOutpost
    }
    public KnownUniverseRefugeeSettlement(SettlementSize size, int population) : base(size, population)
    {
        var random = new Random(((int) size) +population) ;
        for (int i = 0; i < (int) size; i++)
        {
            var buildingType = (RefugeeCampBuildings) random.Next(0, 7); 
            Buildings.Add(new KnownUniverseBuilding(buildingType.ToString()));
        }
    }
}