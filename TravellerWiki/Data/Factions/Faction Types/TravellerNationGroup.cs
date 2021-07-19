﻿using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.Services.CareerService;
using TravellerWiki.Data.Services.DataServices;
using TravellerWiki.Data.SimpleWikiClasses;

namespace TravellerWiki.Data.Factions
{
    public class TravellerNationGroup : TravellerFaction
    {
        protected static TravellerFactionService _factionService = new TravellerFactionService();

        [JsonIgnore]
        public List<TravellerFaction> FactionsAlignedWithNation =>
            _factionService.Factions.Where(x => x.IslandsNation == this.IslandsNation).ToList();
        
        public TravellerNationGroup(string headquatersLocation, 
            TravellerIslandsNations islandsNation, TravellerNationalities supportingNationality,
            string factionHeadName, List<string> otherOwnedLocations, TravellerDateTime foundedYear, 
            TravellerFactionPoliticalSway politicalSway, TravellerFactionSocialSway socialSway, 
            TravellerFactionEconomicSway economicSway, TravellerNPC factionHead = null, 
            List<TravellerNPC> factionMembers = null) 
            : base(islandsNation.ToString().Replace("_"," "), headquatersLocation, islandsNation, supportingNationality, factionHeadName, 
                otherOwnedLocations, foundedYear, politicalSway, socialSway, economicSway, factionHead, factionMembers)
        {
        }


        public string GetAlignedFactions()
        {
            var factions = FactionsAlignedWithNation.Select(x => x.FactionNameLink).ToList();
            return string.Join(", ", factions);
        }
        
        public override string ToString()
        {
            string factionType = "Islands Nation";

            return
                $"The {factionType} known as {FactionName} first appeared in the Islands in {FoundedYear} on {HeadquatersLocation}. It is currently headed by {FactionHead.Name}" +
                $"and it functions as a part of the {IslandsNation.ToString().Replace("_", " ")} with help from {SupportingNationality.ToString().Replace("_", " ")}." +
                $"This {factionType} has {PoliticalSway.ToString().Replace("_", " ")} political sway. " +
                $"{EconomicSway.ToString().Replace("_", " ")} economic sway, " +
                $" and {SocialSway.ToString().Replace("_", " ")} social sway within the {IslandsNation.ToString().Replace("_", " ")} and its allies. " +
                $" {(HasOtherLocation ? $"It also has holdings on: {string.Join(", ", OtherOwnedLocations)}" : "")}" +
                $"There are several other groups who rely on this {factionType}, most notably: {GetAlignedFactions()}.";
        }
    }
}