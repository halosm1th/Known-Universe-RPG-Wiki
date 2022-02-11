using TravellerCharacter.CharcterTypes;
using TravellerFactionSystem.Location;

namespace TravellerFactionSystem.Faction_Assets
{
    public class TravellerFactionPersonAsset : TravellerFactionAsset
    {
        public TravellerFactionPersonAsset(string assetTitle, TravellerNPC npcAsset,
            string description = "A Traveller", int locationID = 0,
            TravellerFactionAssetValue economicValue = default, TravellerFactionAssetValue socialValue = default,
            TravellerFactionAssetValue politicalValue = default)
            : base(assetTitle, description, locationID, economicValue, socialValue, politicalValue)
        {
            NPCAsset = npcAsset;
        }

        public TravellerNPC NPCAsset { get; set; }

        public override string ToString()
        {
            return
                $"(Person) {NPCAsset.Name} [{NPCAsset.PatronText}]: {NPCAsset.ShortUPP()} ({NPCAsset.Background}, {NPCAsset.Career}) [{CurrentLocationID}]";
        }
    }
}