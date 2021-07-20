using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.Services.CareerService;
using TravellerWiki.Data.SimpleWikiClasses;

namespace TravellerWiki.Data.Factions{


public class TravellerCompany : TravellerFaction
    {
        [JsonIgnore]
        public string CeoName => FactionHeadName;
        public uint CurrentSharesOnMarket { get; set; }
        
        [JsonIgnore]
        public uint MarketCap => CurrentSharePrice * CurrentSharesOnMarket;
        public uint CurrentSharePrice { get;  set;}
        public uint MaxSharePrice { get;  set;}
        public uint MinSharePrice { get;  set;}
        public uint Revenues { get;  set;}
        public double DividentPercent { get;  set; }
        
        public TravellerIndustries Industry { get;  set;}
        
        

        public TravellerCompany(string factionName = "", TravellerLocation headquatersLocation = default, 
            TravellerIslandsNations islandsNation = TravellerIslandsNations.Western_Islands_Trade_Federation, 
            TravellerIndustries industry = default, 
            TravellerNationalities supportingNationality = default,
            string factionHeadName = "",
            List<TravellerLocation> otherOwnedLocations = null, 
            TravellerDateTime foundedYear = null,
            TravellerFactionPoliticalSway politicalSway = TravellerFactionPoliticalSway.Some, 
            TravellerFactionSocialSway socialSway = TravellerFactionSocialSway.Average, 
            TravellerFactionEconomicSway economicSway = TravellerFactionEconomicSway.Above_Average,
            uint currentSharesOnMarket = 1, uint currentSharePrice = 1,uint maxSharePrice = 1, uint minSharePrice = 1, uint revenues = 1, double dividentPercent = 1) 
            : base(factionName,  headquatersLocation,islandsNation, supportingNationality, factionHeadName, otherOwnedLocations, foundedYear,politicalSway,socialSway, economicSway)
        {
            CurrentSharesOnMarket = currentSharesOnMarket;
            CurrentSharePrice = currentSharePrice;
            MaxSharePrice = maxSharePrice;
            MinSharePrice = minSharePrice;
            Revenues = revenues;
            DividentPercent = dividentPercent;
            Industry = industry;

            if (currentSharePrice == 1 && maxSharePrice == 1 && minSharePrice == 1)
            {
                var priceInfo = GenerateSharePriceInformation(_randomGenerator);
                var shareInfo = GenerateMarketInfo(_randomGenerator);
                    
                MaxSharePrice = priceInfo.max;
                MinSharePrice = priceInfo.min;
                CurrentSharePrice = priceInfo.current;

                CurrentSharesOnMarket = shareInfo.marketShares;
                Revenues = shareInfo.revenue;
                DividentPercent = shareInfo.dividend;
            }

            if (string.IsNullOrEmpty(FactionName))
            {
                var nameType = _randomGenerator.Next(0, 4);
                FactionName = nameType switch
                {
                    0 => $"{FactionHeadName.Split(" ").First()+"'s"} {Industry} on {HeadquatersLocation} {GetRandomEndTag()}",
                    1 => $"{Industry} on {HeadquatersLocation} {GetRandomEndTag()}",
                    2 => $"{FactionHeadName.Split(" ").First()+"'s"} {HeadquatersLocation} {Industry} {GetRandomEndTag()}",
                    _ => $"{HeadquatersLocation} {Industry} {GetRandomEndTag()}"
                };
            }
        }

        public static (uint marketShares, uint revenue, double dividend) GenerateMarketInfo(Random random)
        {
            var market = (uint) random.Next(1000, 100000000);
            var rev = (uint) random.Next(10000, 225000000);
            var div = Math.Round(random.NextDouble() * 10, 2);

            return (market, rev, div);
        }

        public static (uint min, uint max, uint current) GenerateSharePriceInformation(Random random)
        {
            var max = (uint) random.Next(10, 100001);
            var min = (uint) random.Next(1, Math.Min((int) max, 100));
            var current = (uint) random.Next((int) min, (int) max);

            return (min, max, current);
        }

        private string GetRandomEndTag()
        {
            var endTag = _randomGenerator.Next(1, 6);
            return endTag switch 
            {
                1 => "LLC",
                2 => "Corp",
                3 => "Inc",
                4 => "Industries",
                5 => "Ltd",
                _ => "Co.",
            } ;
        }
        
        public string GetOtherLocationName()
        {
            
            var locationNames = new StringBuilder();
            
            if (HasOtherLocations())
            {
                foreach (var location in OtherOwnedLocations)
                {
                    locationNames.Append($"{location}, ");
                }

                locationNames.Remove(locationNames.Length - 1, 1);
            }

            return locationNames.ToString();
        }

        public bool HasOtherLocations() => OtherOwnedLocations != null && OtherOwnedLocations.Count > 0;

        public override string ToString()
        {
            return $"{FactionName} was founded in {FoundedYear}, and its main industry is {Industry.ToString().Replace("_"," ")}. It is headquartered on {HeadquatersLocation} and its CEO is named {CeoName}. " +
                   $"The company operates under the laws of {IslandsNation.ToString().Replace("_"," ")} but its parent/partner company is in {SupportingNationality.ToString().Replace("_"," ")}. " +
                   $"The Companies current Share Price is [Cr: {CurrentSharePrice} Min: {MinSharePrice} Max: {MaxSharePrice}], it makes Cr {Revenues}/Year, pays a dividend of {DividentPercent}%, and has a market cap of Cr {MarketCap}. " +
                   $"The Company has {PoliticalSway} political sway, {SocialSway} social sway, and {EconomicSway} economic sway. " +
                   $"{(HasOtherLocations()? $"{FactionName} It also operates facilities on: {GetOtherLocationName()}." : "")}";
        }
    }
}
