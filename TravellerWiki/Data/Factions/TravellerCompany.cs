using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerWiki.Data.Services.CareerService;
using TravellerWiki.Data.SimpleWikiClasses;

namespace TravellerWiki.Data
{
    public class TravellerCompany : TravellerFaction
    {
        public string CeoName => FactionHeadName;
        public uint CurrentSharesOnMarket { get; }
        public uint MarketCap => CurrentSharePrice * CurrentSharesOnMarket;
        public uint CurrentSharePrice { get; }
        public uint MaxSharePrice { get; }
        public uint MinSharePrice { get; }
        public uint Revenues { get; }
        public double DividentPercent { get; }
        
        public TravellerIndustries Industry { get; }
        
        

        public TravellerCompany(string factionName = "", string headquatersLocation = "unkown", 
            TravellerIslandsNations islandsNation = TravellerIslandsNations.Western_Islands_Trade_Federation, 
            TravellerIndustries industry = default, 
            TravellerNationalities supportingNationality = default,
            string factionHeadName = "",
            List<string> otherOwnedLocations = null, 
            TravellerDateTime foundedYear = null,
            uint currentSharesOnMarket = 1, uint currentSharePrice = 1,uint maxSharePrice = 1, uint minSharePrice = 1, uint revenues = 1, double dividentPercent = 1) 
            : base(factionName,  headquatersLocation,islandsNation, supportingNationality, factionHeadName, otherOwnedLocations, foundedYear)
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
                CurrentSharesOnMarket = (uint) _randomGenerator.Next(1000, 100000000);
                MaxSharePrice =(uint)_randomGenerator.Next(10, 100001);
                MinSharePrice = (uint)_randomGenerator.Next(1, Math.Min((int)MaxSharePrice,100));
                CurrentSharePrice = (uint)_randomGenerator.Next((int)MinSharePrice, (int)MaxSharePrice);
                Revenues = (uint)_randomGenerator.Next(10000, 225000000);
                DividentPercent = Math.Round(_randomGenerator.NextDouble()*10,2);
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
                   $"The Companies current Share Price is [Cr: {CurrentSharePrice} Min: {MinSharePrice} Max: {MaxSharePrice}], it makes Cr {Revenues}/Year, pays a dividend of {DividentPercent}%, and has a market cap of {MarketCap}. " +
                   $"{(HasOtherLocations()? $"{FactionName} also operates facilities on: {GetOtherLocationName()}." : "")}";
        }
    }
}
