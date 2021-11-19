using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TravellerFactionSystem.Faction_Assets
{
    public class TravellerPopulatedFactionAsset : TravellerFactionAsset
    {
        
        public List<TravellerFactionPersonAsset> AssetPopulation { get; set; }
        
        public int MaxNumberOfPeopleWithAsset { get; set; }
        public int MinNumberOfPeopleWithAsset { get; set; } 
        [JsonIgnore] public int CurrentNumberOfPeopleWithAsset => AssetPopulation.Count;

        public TravellerPopulatedFactionAsset(string name = "", string description = "", TravellerLocation currentLocation = default, 
            TravellerFactionAssetValue economicValue = default, TravellerFactionAssetValue socialValue = default, TravellerFactionAssetValue politicalValue = default, 
            List<TravellerFactionPersonAsset> assetPopulation = null, int maxNumberOfPeopleWithAsset = 1, int minNumberOfPeopleWithAsset = 1) 
            : base(name, description, currentLocation, economicValue, socialValue, politicalValue)
        {
            AssetPopulation = assetPopulation;
            MaxNumberOfPeopleWithAsset = maxNumberOfPeopleWithAsset;
            MinNumberOfPeopleWithAsset = minNumberOfPeopleWithAsset;

            if (AssetPopulation == null || AssetPopulation.Count <= 0)
            {
                AssetPopulation = new List<TravellerFactionPersonAsset>();
                var population = _random.Next(MinNumberOfPeopleWithAsset, MaxNumberOfPeopleWithAsset);
                var npcGenerator = new TravellerNPCService();
                for (int i = 0; i < population; i++)
                {
                    var npc = npcGenerator.GenerateNPC(name.Aggregate(0, (h, t) => h + t) + AssetPopulation.Count);
                    AssetPopulation.Add(new TravellerFactionPersonAsset(npc.PatronText,npc,$"Employee at: {name}",CurrentLocation));
                }
            }
        }
    }
}