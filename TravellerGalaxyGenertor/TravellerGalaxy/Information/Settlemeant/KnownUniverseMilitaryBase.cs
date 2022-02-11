using System;
using TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds;

namespace TravellerGalaxyGenertor.TravellerGalaxy.Information.Settlemeant;

public class KnownUniverseMilitaryBase : KnownUniversePlanetarySettlement
{    
    enum MilitaryBaseBuildings
    {
        BaseHQ = 0,
        RestArea = 1,
        BaseEntrance = 2,
        BaseMedical =3,
        BaseMess = 4,
        BaseWeaponsStorage =5,
        BaseGearStorage = 6,
        BaseLandingPad,
        BaseVehicleGarage,
        BaseGenerator,
        BaseCommsOutpost
    }
    public KnownUniverseMilitaryBase(SettlementSize size, int population) : base(size, population)
    {        
        var random = new Random(((int) size) +population) ;
        for (int i = 0; i < (int) size; i++)
        {
            var buildingType = (MilitaryBaseBuildings) random.Next(0, 7); 
            Buildings.Add(new KnownUniverseBuilding(buildingType.ToString()));
        }
    }
}