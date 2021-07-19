using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data.Factions.Faction_Assets
{
    public class TravellerFactionPersonAsset : TravellerFactionAsset
    {
        public TravellerNPC NPCAsset { get; set; }

        public TravellerFactionPersonAsset(string assetTitle, TravellerNPC npcAsset , 
            string description = "A Traveller", TravellerLocation currentLocation = null, 
            TravellerFactionAssetValue economicValue = default, TravellerFactionAssetValue socialValue = default,
            TravellerFactionAssetValue politicalValue = default) 
            : base(assetTitle, description, currentLocation, economicValue, socialValue, politicalValue)
        {
            NPCAsset = npcAsset;
        }
    }
}