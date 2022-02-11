#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using TravellerFactionSystem.FactionEnums;
using TravellerFactionSystem.Location;

namespace TravellerFactionSystem.Faction_Assets
{
    public class TravellerPlanetaryBaseAsset : TravellerPopulatedFactionAsset
    {
        public TravellerPlanetaryBaseAsset(string name = "Planet Base", string description = "",
            int currentLocationID = 0,
            TravellerFactionAssetValue? economicValue = default, TravellerFactionAssetValue? socialValue = default,
            TravellerFactionAssetValue? politicalValue = default,
            List<TravellerFactionPersonAsset>? assetPopulation = null, int maxNumberOfPeopleWithAsset = 1,
            int minNumberOfPeopleWithAsset = 1,
            TravellerPlanetaryBaseLevels planetaryBaseLevel = TravellerPlanetaryBaseLevels.Shack)
            : base(name, description, currentLocationID, economicValue, socialValue, politicalValue, assetPopulation,
                maxNumberOfPeopleWithAsset, minNumberOfPeopleWithAsset)
        {
            PlanetaryBaseLevel = planetaryBaseLevel;
        }

        public TravellerPlanetaryBaseLevels PlanetaryBaseLevel { get; set; }

        public TravellerLocation GetLocation()
        {
            return TravellerLocationService.GetLocation(CurrentLocationID);
        }

        public override string ToString()
        {
            return $"(Planet) {Name} [{PlanetaryBaseLevel.ToString().Replace("_", " ")}]: {Description}";
        }

        public override string FullToString()
        {
            return $"{Name} [{PlanetaryBaseLevel.ToString().Replace("_", " ")}]: " +
                   $"{Description}. Workers (Min: {MinNumberOfPeopleWithAsset} , Max: {MaxNumberOfPeopleWithAsset}): " +
                   $"{string.Join(", ", AssetPopulation?.Select(x => x.NPCAsset.Name) ?? Array.Empty<string?>())} " +
                   $"(P: [{PoliticalValue}] E: [{EconomicValue}] S: [{SocialValue}]) [{CurrentLocationID}]";
        }
    }
}