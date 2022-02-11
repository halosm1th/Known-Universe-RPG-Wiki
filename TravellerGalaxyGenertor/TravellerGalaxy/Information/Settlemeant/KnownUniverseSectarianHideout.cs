using System;
using TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds;

namespace TravellerGalaxyGenertor.TravellerGalaxy.Information.Settlemeant;

public class KnownUniverseSectarianHideout : KnownUniversePlanetarySettlement
{
    enum SectarianHideoutBuildings
    {
        MainBuilding = 0,
        Dormitory = 1,
        StorageRoom = 2,
        RecreationHall =3,
        PrayerRoom = 4,
        MastersChamber =5,
        WorkRoom = 6,
    }
    public KnownUniverseSectarianHideout(SettlementSize size, int population) : base(size, population)
    {
        var random = new Random(((int) size) +population) ;
        for (int i = 0; i < (int) size; i++)
        {
            var buildingType = (SectarianHideoutBuildings) random.Next(0, 7); 
            Buildings.Add(new KnownUniverseBuilding(buildingType.ToString()));
        }
    }
}