using System.Collections.Generic;
using Newtonsoft.Json;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.Factions.Faction_Assets;

namespace TravellerWiki.Data.Factions
{
    public class TravellerPopulatedFactionAsset : TravellerFactionAsset
    {
        
        public List<TravellerFactionPersonAsset> AssetPopulation { get; set; }
        
        public int MaxNumberOfPeopleWithAsset { get; set; }
        public int MinNumberOfPeopleWithAsset { get; set; }
        [JsonIgnore] public int CurrentNumberOfPeopleWithAsset => AssetPopulation.Count;

        public TravellerPopulatedFactionAsset(string name, string description, TravellerLocation currentLocation, 
            TravellerFactionAssetValue economicValue, TravellerFactionAssetValue socialValue, TravellerFactionAssetValue politicalValue, 
            List<TravellerFactionPersonAsset> assetPopulation, int maxNumberOfPeopleWithAsset, int minNumberOfPeopleWithAsset) 
            : base(name, description, currentLocation, economicValue, socialValue, politicalValue)
        {
            AssetPopulation = assetPopulation;
            MaxNumberOfPeopleWithAsset = maxNumberOfPeopleWithAsset;
            MinNumberOfPeopleWithAsset = minNumberOfPeopleWithAsset;
        }
    }
}