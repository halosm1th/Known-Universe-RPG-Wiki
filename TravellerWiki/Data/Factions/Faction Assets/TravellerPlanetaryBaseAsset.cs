#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
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

        public override string ToString()
        {
            return $"(Planet) {Name} [{PlanetaryBaseLevel.ToString().Replace("_"," ")}]: " +
                   $"{Description}. Workers (Min: {MinNumberOfPeopleWithAsset} , Max: {MaxNumberOfPeopleWithAsset}): " +
                   $"{string.Join(", ", AssetPopulation?.Select(x => x.NPCAsset.Name) ?? Array.Empty<string?>())}" + 
                   $"(P: [{PoliticalValue}] E: [{EconomicValue}] S: [{SocialValue}]) [{CurrentLocation}]";
        }
    }
}