#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using TravellerFactionSystem.FactionEnums;

namespace TravellerFactionSystem.Faction_Assets
{
    public class TravellerPlanetaryBaseAsset : TravellerPopulatedFactionAsset
    {
        public TravellerPlanetaryBaseLevels PlanetaryBaseLevel { get; set; }

        public TravellerPlanetaryBaseAsset(string name = "Planet Base", string description = "", TravellerLocation? currentLocation = default, 
            TravellerFactionAssetValue? economicValue = default, TravellerFactionAssetValue? socialValue  = default, TravellerFactionAssetValue? politicalValue = default, 
            List<TravellerFactionPersonAsset>? assetPopulation = null, int maxNumberOfPeopleWithAsset = 1, int minNumberOfPeopleWithAsset = 1, 
            TravellerPlanetaryBaseLevels planetaryBaseLevel = TravellerPlanetaryBaseLevels.Shack) 
            : base(name, description, currentLocation, economicValue, socialValue, politicalValue, assetPopulation, 
                maxNumberOfPeopleWithAsset, minNumberOfPeopleWithAsset)
        {
            PlanetaryBaseLevel = planetaryBaseLevel;
        }

        public override string ToString()
        {
            return $"(Planet) {Name} [{PlanetaryBaseLevel.ToString().Replace("_", " ")}]: {Description}";
        }

        public override string FullToString()
        {
            return $"{Name} [{PlanetaryBaseLevel.ToString().Replace("_"," ")}]: " +
                   $"{Description}. Workers (Min: {MinNumberOfPeopleWithAsset} , Max: {MaxNumberOfPeopleWithAsset}): " +
                   $"{string.Join(", ", AssetPopulation?.Select(x => x.NPCAsset.Name) ?? Array.Empty<string?>())} " + 
                   $"(P: [{PoliticalValue}] E: [{EconomicValue}] S: [{SocialValue}]) [{CurrentLocation}]";
        }
    }
}