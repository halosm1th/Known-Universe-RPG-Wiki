using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TravellerCharacter.CharcterTypes;
using TravellerFactionSystem.Faction_Assets;
using TravellerFactionSystem.FactionEnums;
using VoicesFromTheVoidArticles;
using TravellerFactionSystem.Location;

namespace TravellerFactionSystem.Faction_Types
{
    public class TravellerMajorNationGroup : TravellerNationGroup
    {
        public TravellerMajorNationGroup(
            int headquatersTextLocation, TravellerIslandsNations islandsNation,
            TravellerNationalities supportingNationality,
            string factionHeadName, List<int> otherOwnedLocations,
            TravellerDateTime foundedYear,
            TravellerFactionPoliticalSway politicalSway,
            TravellerFactionSocialSway socialSway,
            TravellerFactionEconomicSway economicSway,
            TravellerNPC factionHead = null, List<TravellerFactionPersonAsset> factionMembers = null)
            : base(headquatersTextLocation, islandsNation, supportingNationality, factionHeadName,
                otherOwnedLocations, foundedYear, politicalSway, socialSway, economicSway, factionHead, factionMembers)
        {
            FactionName = supportingNationality.ToString().Replace("_", " ");
        }

        [JsonIgnore]
        public List<TravellerFaction> GetFactionsAlliedWith =>
            _factionService.Factions.Where(x => x.SupportingNationality == SupportingNationality).ToList();

        public override string ToString()
        {
            var factionType = "Major Power";

            return
                $"The {factionType} known as {FactionName} first gained allies in the Islands in {FoundedYear} on {HeadquatersTextLocation} in the {IslandsNation}. It is currently headed by {FactionHead.Name}" +
                $"This {factionType} has {PoliticalSway.ToString().Replace("_", " ")} political sway. " +
                $"{EconomicSway.ToString().Replace("_", " ")} economic sway, " +
                $" and {SocialSway.ToString().Replace("_", " ")} social sway within the {IslandsNation.ToString().Replace("_", " ")} and its allies. " +
                $" {(HasOtherLocation ? $"It also has holdings on: {string.Join(", ", OtherOwnedLocations)}" : "")}" +
                $"There are several other groups who rely on this {factionType}, most notably: {GetAlignedFactions()}.";
        }
    }
}