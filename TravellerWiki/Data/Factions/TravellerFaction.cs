using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellerWiki.Data.Services.CareerService;
using TravellerWiki.Data.SimpleWikiClasses;

namespace TravellerWiki.Data
{
    public class TravellerFaction
    {
        public string FactionName { get; }
        public string FactionHeadName { get; protected set; }
        public string HeadquatersLocation { get; }
        public List<string> OtherOwnedLocations { get; }
        public TravellerDateTime FoundedYear { get; }
        public TravellerIslandsNations IslandsNation { get; }
        public TravellerNationalities SupportingNationality { get; }

        protected Random _randomGenerator;

        public TravellerFaction(string factionName, string headquatersLocation, TravellerIslandsNations islandsNation, TravellerNationalities supportingNationality, string factionHeadName, List<string> otherOwnedLocations, TravellerDateTime foundedYear)
        {
            FactionName = factionName;
            FactionHeadName = factionHeadName;
            HeadquatersLocation = headquatersLocation;
            OtherOwnedLocations = otherOwnedLocations;
            FoundedYear = foundedYear;
            IslandsNation = islandsNation;
            SupportingNationality = supportingNationality;
            var factionSeed = factionName.Aggregate(0, (h, t) => h + t) 
                              + (int) IslandsNation 
                              - ((int) supportingNationality+1);
            
            _randomGenerator = new Random(factionSeed);
            
            if (string.IsNullOrEmpty(factionHeadName))
            {
                FactionHeadName = GetNames(1,TravellerNameService.GetNationalitiesNameList(supportingNationality)).First();
            }

            if (foundedYear == null)
            {
                FoundedYear = new TravellerDateTime(_randomGenerator.Next(1, 32), _randomGenerator.Next(1, 13), 83,
                    _randomGenerator.Next(390 - 50, 391));
            }
        }
        
        private TravellerNameService.NationNameList GetRandomNation()
        {
            var listOfNames = Enum.GetValues(typeof(TravellerNameService.NationNameList)).Length;
            return (TravellerNameService.NationNameList)_randomGenerator.Next(0, listOfNames);
        }
        
        private List<string> GetNameList(TravellerNameService.NationNameList nation)
            => nation switch
            {
                TravellerNameService.NationNameList.Federation => TravellerNameLists.FederationNameList,
                TravellerNameService.NationNameList.Britannia => TravellerNameLists.BritanniaNameList,
                TravellerNameService.NationNameList.Empire => TravellerNameLists.ImperialNameList,
                TravellerNameService.NationNameList.Vers => TravellerNameLists.VersNameList,
                TravellerNameService.NationNameList.Germushia => TravellerNameLists.GermushiaNameList,
                TravellerNameService.NationNameList.Deutschland => TravellerNameLists.DeutschlandNameList,
                TravellerNameService.NationNameList.XiaoMing => TravellerNameLists.XiaoMingNameList,
                TravellerNameService.NationNameList.AxionAlliance => TravellerNameLists.AxionAllianceNameList,
                _ => GetNameList(GetRandomNation())
            };
        
        public List<string> GetNames(int numberOfNames, TravellerNameService.NationNameList nation)
        {

            if (nation == TravellerNameService.NationNameList.Any)
                nation = GetRandomNation();

            var nameList = GetNameList(nation);
            var returnList = new List<string>();

            for (int i = 0; i < numberOfNames; i++)
            {
                var sb = new StringBuilder();
                sb.Append(nameList[_randomGenerator.Next(0, nameList.Count)]);
                sb.Append(" ");
                sb.Append(nameList[_randomGenerator.Next(0, nameList.Count)]);
                returnList.Add(sb.ToString());
            }

            return returnList;
        }
    }
}