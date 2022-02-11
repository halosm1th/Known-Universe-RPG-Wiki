using System;
using TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds;

namespace TravellerGalaxyGenertor.TravellerGalaxy.Information.Settlemeant;

public class KnownUniverseOwned_City : KnownUniversePlanetarySettlement
{
    enum OwnedCityBuildings
    {
        PoliceHQ,
        FireHQ,
        OwnersHouse,
        HousingDistrict,
        HopstialHQ,
        OfficeDistrict,
        ManufacturingDistrict,
        LowerIncomeHousing,
        InvstorHousing,
        MiddleIncomeHousing,
        Garbage,
        PressHQ,
    }
    
    public KnownUniverseOwned_City(SettlementSize size, int population) : base(size, population)
    {        
        var random = new Random(((int) size) +population) ;
        for (int i = 0; i < (int) size; i++)
        {
            var buildingType = (OwnedCityBuildings) random.Next(0, 7); 
            Buildings.Add(new KnownUniverseBuilding(buildingType.ToString()));
        }
    }
}