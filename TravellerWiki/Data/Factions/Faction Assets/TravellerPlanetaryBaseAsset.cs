using System.Collections.Generic;
using Newtonsoft.Json;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data.Factions.Faction_Assets
{
    public class TravellerPlanetaryBaseAsset : TravellerPopulatedFactionAsset
    {
        public TravellerPlanetaryBaseLevels PlanetaryBaseLevel { get; set; }

        public TravellerPlanetaryBaseAsset(string name, string description, TravellerLocation currentLocation, 
            TravellerFactionAssetValue economicValue, TravellerFactionAssetValue socialValue, TravellerFactionAssetValue politicalValue, 
            List<TravellerFactionPersonAsset> assetPopulation, int maxNumberOfPeopleWithAsset, int minNumberOfPeopleWithAsset, 
            TravellerPlanetaryBaseLevels planetaryBaseLevel) 
            : base(name, description, currentLocation, economicValue, socialValue, politicalValue, assetPopulation, 
                maxNumberOfPeopleWithAsset, minNumberOfPeopleWithAsset)
        {
            PlanetaryBaseLevel = planetaryBaseLevel;
        }
    }
}