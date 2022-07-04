﻿using System;
using TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds;

namespace TravellerGalaxyGenertor.TravellerGalaxy.Information.Settlemeant;

public class KnownUniversePrivateVilla : KnownUniversePlanetarySettlement
{
    enum PrivateVillaBuildings
    {
        MainHouse = 0,
        ServantHousing = 1,
        StorageHall = 2,
        BathHouse =3,
        PrivateSportsField = 4,
        HiddenArea =5,
        LandingPad,
        VehicleGarage,
        GeneratorChamber,
        CommsOutpost
    }
    public KnownUniversePrivateVilla(SettlementSize size, int population) : base(size, population)
    {       
        var random = new Random(((int) size) +population) ;
        for (int i = 0; i < (int) size; i++)
        {
            var buildingType = (PrivateVillaBuildings) random.Next(0, 7); 
            Buildings.Add(new KnownUniverseBuilding(buildingType.ToString()));
        }
    }
}