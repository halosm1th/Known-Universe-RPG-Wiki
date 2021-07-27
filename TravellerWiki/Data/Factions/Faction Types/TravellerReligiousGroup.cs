using System.Collections.Generic;
using System.Linq;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.Factions.Faction_Assets;
using TravellerWiki.Data.Services.CareerService;
using TravellerWiki.Data.SimpleWikiClasses;

namespace TravellerWiki.Data.Factions
{
    public class TravellerReligion : TravellerFaction
    {
        public int NumberOfFollowers { get; set; }
        
        
        public TravellerReligion(int numberOfFollowers, string factionName, TravellerLocation headquatersLocation, 
            TravellerIslandsNations islandsNation, TravellerNationalities supportingNationality, string factionHeadName, 
            List<TravellerLocation> otherOwnedLocations, TravellerDateTime foundedYear, TravellerFactionPoliticalSway politicalSway, 
            TravellerFactionSocialSway socialSway, TravellerFactionEconomicSway economicSway, TravellerNPC factionHead = null, 
            List<TravellerFactionPersonAsset> factionMembers = null) :
            base(factionName, headquatersLocation, islandsNation, supportingNationality, factionHeadName, otherOwnedLocations, 
                foundedYear, politicalSway, socialSway, economicSway, factionHead, factionMembers)
        {
            NumberOfFollowers = numberOfFollowers;
        }

        public override string ToString()
        {
            return
                $"The religion of {FactionName} first came to prominence in the Islands in {FoundedYear} on {HeadquatersLocation}. It is currently headed by {FactionHead.Name}" +
                $" and it functions as a part of the {IslandsNation.ToString().Replace("_", " ")} with help from {SupportingNationality.ToString().Replace("_"," ")}." +
                $"It has around {NumberOfFollowers}, of which {FactionMembers.Count} are elite or highly devoted members. This religion has {PoliticalSway.ToString().Replace("_", " ")} political sway. " +
                $"{EconomicSway.ToString().Replace("_", " ")} economic sway, " +
                $"and {SocialSway.ToString().Replace("_", " ")} social sway within the {IslandsNation.ToString().Replace("_", " ")} and its allies. " +
                $" {(HasOtherLocation? $"It also has holdings on: {OtherOwnedLocations.Aggregate("",(h,t) => h + t + ", " )}" : "")}";
        }
    }
}