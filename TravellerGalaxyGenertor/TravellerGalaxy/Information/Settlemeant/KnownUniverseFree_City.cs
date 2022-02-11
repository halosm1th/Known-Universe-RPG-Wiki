using TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds;

namespace TravellerGalaxyGenertor.TravellerGalaxy.Information.Settlemeant;

public class KnownUniverseFree_City : KnownUniversePlanetarySettlement
{
    enum FreedCityBuildings
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
    public KnownUniverseFree_City(SettlementSize size, int population) : base(size, population)
    {
    }
}