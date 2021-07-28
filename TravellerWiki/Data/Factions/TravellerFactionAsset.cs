using System;
using System.Linq;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace TravellerWiki.Data.Factions
{
    public class TravellerFactionAsset
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TravellerLocation CurrentLocation { get; set; }
        
        public TravellerFactionAssetValue EconomicValue { get; set; }
        public TravellerFactionAssetValue SocialValue { get; set; }
        public TravellerFactionAssetValue PoliticalValue { get; set; }

        [JsonIgnore] protected Random _random;

        public TravellerFactionAsset(string name = "Faction Asset", string description = "A Faction Asset", TravellerLocation currentLocation = default, 
            TravellerFactionAssetValue economicValue = default, TravellerFactionAssetValue socialValue = default, TravellerFactionAssetValue politicalValue = default)
        {
            Name = name;
            Description = description;
            CurrentLocation = currentLocation;
            EconomicValue = economicValue;
            SocialValue = socialValue;
            PoliticalValue = politicalValue;
            if(String.IsNullOrEmpty(name)) name = "WTF";

            var seed = name?.Aggregate(0, (h, t) => h + t) ?? 0;
            _random = new Random(seed);
        }

        public virtual string FullToString()
        {
            return $"{Name} ({CurrentLocation}): {Description}. [P: [{PoliticalValue}] E: [{EconomicValue}] S: [{SocialValue}]]";
        }

        public override string ToString()
        {
            return $"{Name}: {Description} [{CurrentLocation}].";
        }
    }
}