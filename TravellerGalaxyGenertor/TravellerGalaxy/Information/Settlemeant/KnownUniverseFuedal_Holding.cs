using System;
using TravellerGalaxyGenertor.TravellerGalaxy.Information.Settlemeant;
using TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds;

public class KnownUniverseFuedal_Holding : KnownUniversePlanetarySettlement
{    
    enum PrivateVillaBuildings
    {
        FuedalKeep = 0,
        ManorHouse = 1,
        ManorField = 2,
        FuedalBuilding =3,
        PeasantHousing = 4,
        PeasantField =5,
        KeepLandingPad,
        GeneratorMasters,
        CommKeeper
    }
    public KnownUniverseFuedal_Holding(SettlementSize size, int population) : base(size, population)
    {      
        var random = new Random(((int) size) +population) ;
        for (int i = 0; i < (int) size; i++)
        {
            var buildingType = (PrivateVillaBuildings) random.Next(0, 7); 
            Buildings.Add(new KnownUniverseBuilding(buildingType.ToString()));
        }
    }
}