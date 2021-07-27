using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.Factions.Faction_Assets;
using TravellerWiki.Data.Services.CareerService;
using TravellerWiki.Data.SimpleWikiClasses;

namespace TravellerWiki.Data.Factions
{
    public class TravellerMajorNationGroup : TravellerNationGroup
    {
        [JsonIgnore]
        public List<TravellerFaction> GetFactionsAlliedWith =>
            _factionService.Factions.Where(x => x.SupportingNationality == SupportingNationality).ToList();
        
        public TravellerMajorNationGroup(
            TravellerLocation headquatersLocation, TravellerIslandsNations islandsNation, 
            TravellerNationalities supportingNationality,
            string factionHeadName, List<TravellerLocation> otherOwnedLocations, 
            TravellerDateTime foundedYear, 
            TravellerFactionPoliticalSway politicalSway, 
            TravellerFactionSocialSway socialSway, 
            TravellerFactionEconomicSway economicSway, 
            TravellerNPC factionHead = null, List<TravellerFactionPersonAsset> factionMembers = null) 
            : base(headquatersLocation, islandsNation, supportingNationality, factionHeadName, 
                otherOwnedLocations, foundedYear, politicalSway, socialSway, economicSway, factionHead, factionMembers)
        {
            FactionName = supportingNationality.ToString().Replace("_", " ");
        }
        
        public override string ToString()
        {
            string factionType = "Major Power";
            
            return
                $"The {factionType} known as {FactionName} first gained allies in the Islands in {FoundedYear} on {HeadquatersLocation} in the {IslandsNation}. It is currently headed by {FactionHead.Name}" +
                $"This {factionType} has {PoliticalSway.ToString().Replace("_", " ")} political sway. " +
                $"{EconomicSway.ToString().Replace("_", " ")} economic sway, " +
                $" and {SocialSway.ToString().Replace("_", " ")} social sway within the {IslandsNation.ToString().Replace("_", " ")} and its allies. " +
                $" {(HasOtherLocation? $"It also has holdings on: {string.Join(", ",OtherOwnedLocations)}" : "")}" +
                $"There are several other groups who rely on this {factionType}, most notably: {GetAlignedFactions()}.";
        }
    }
}