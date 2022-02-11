using System;
using System.Linq;
using Newtonsoft.Json;
using TravellerFactionSystem.Location;

namespace TravellerFactionSystem
{
    public class TravellerFactionAsset
    {
        [JsonIgnore] protected Random _random;

        public TravellerFactionAsset(string name = "Faction Asset", string description = "A Faction Asset",
            int currentLocationID = default,
            TravellerFactionAssetValue economicValue = default, TravellerFactionAssetValue socialValue = default,
            TravellerFactionAssetValue politicalValue = default)
        {
            Name = name;
            Description = description;
            CurrentLocationID = currentLocationID;
            EconomicValue = economicValue;
            SocialValue = socialValue;
            PoliticalValue = politicalValue;
            if (string.IsNullOrEmpty(name)) name = "WTF";

            var seed = name?.Aggregate(0, (h, t) => h + t) ?? 0;
            _random = new Random(seed);
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int CurrentLocationID { get; set; }

        public TravellerFactionAssetValue EconomicValue { get; set; }
        public TravellerFactionAssetValue SocialValue { get; set; }
        public TravellerFactionAssetValue PoliticalValue { get; set; }

        public virtual string FullToString()
        {
            return
                $"{Name} ({CurrentLocationID}): {Description}. [P: [{PoliticalValue}] E: [{EconomicValue}] S: [{SocialValue}]]";
        }

        public override string ToString()
        {
            return $"{Name}: {Description} [{CurrentLocationID}].";
        }
    }
}