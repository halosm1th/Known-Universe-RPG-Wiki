using TravellerCharacter.CharcterTypes;

namespace TravellerFactionSystem.Faction_Assets
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

        public override string ToString()
        {
            return $"(Person) {NPCAsset.Name} [{NPCAsset.PatronText}]: {NPCAsset.ShortUPP()} ({NPCAsset.Background}, {NPCAsset.Career}) [{@CurrentLocation}]";
        }
    }
}