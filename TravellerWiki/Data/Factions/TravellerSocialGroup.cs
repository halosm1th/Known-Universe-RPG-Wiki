using System.Collections.Generic;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.Services.CareerService;
using TravellerWiki.Data.SimpleWikiClasses;

namespace TravellerWiki.Data.Factions
{
    public class TravellerSocialGroup : TravellerFaction
    {
        public TravellerSocialGroup(string factionName, string headquatersLocation, 
            TravellerIslandsNations islandsNation, TravellerNationalities supportingNationality,
            string factionHeadName, List<string> otherOwnedLocations, TravellerDateTime foundedYear, 
            TravellerFactionPoliticalSway politicalSway, TravellerFactionSocialSway socialSway, 
            TravellerFactionEconomicSway economicSway, TravellerNPC factionHead = null, 
            List<TravellerNPC> factionMembers = null) 
            : base(factionName, headquatersLocation, islandsNation, supportingNationality, factionHeadName, 
                otherOwnedLocations, foundedYear, politicalSway, socialSway, economicSway, factionHead, factionMembers)
        {
        }
        
        
        public override string ToString()
        {
            string factionType = "Social Group";
            
            return
                $"The {factionType} known as {FactionName} first came to prominence in the Islands in {FoundedYear} on {HeadquatersLocation}. It is currently headed by {FactionHead.Name}" +
                $"and it functions as a part of the {IslandsNation.ToString().Replace("_", " ")} with help from {SupportingNationality.ToString().Replace("_"," ")}." +
                $"This {factionType} has {PoliticalSway.ToString().Replace("_", " ")} political sway. " +
                $"{EconomicSway.ToString().Replace("_", " ")} economic sway, " +
                $" and {SocialSway.ToString().Replace("_", " ")} social sway within the {IslandsNation.ToString().Replace("_", " ")} and its allies. " +
                $" {(HasOtherLocation? $"It also has holdings on: {string.Join(", ",OtherOwnedLocations)}" : "")}";
        }
    }
}