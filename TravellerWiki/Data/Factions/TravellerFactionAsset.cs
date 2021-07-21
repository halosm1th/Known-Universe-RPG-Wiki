using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TravellerWiki.Data.Factions
{
    public class TravellerFactionAsset
    {
        public string Name { get; set; }
        private string Description { get; set; }
        public TravellerLocation CurrentLocation { get; set; }
        
        public TravellerFactionAssetValue EconomicValue { get; set; }
        public TravellerFactionAssetValue SocialValue { get; set; }
        public TravellerFactionAssetValue PoliticalValue { get; set; }

        public TravellerFactionAsset(string name = "Faction Asset", string description = "A Faction Asset", TravellerLocation currentLocation = default, 
            TravellerFactionAssetValue economicValue = default, TravellerFactionAssetValue socialValue = default, TravellerFactionAssetValue politicalValue = default)
        {
            Name = name;
            Description = description;
            CurrentLocation = currentLocation;
            EconomicValue = economicValue;
            SocialValue = socialValue;
            PoliticalValue = politicalValue;
        }

        public override string ToString()
        {
            return $"{Name}: {Description} [{CurrentLocation}]. Economic Value: {EconomicValue}. Social Value: {SocialValue}. Political Value: {PoliticalValue}";
        }
    }
}