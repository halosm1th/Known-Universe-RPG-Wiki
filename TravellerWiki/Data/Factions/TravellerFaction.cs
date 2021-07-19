using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.Services.CareerService;
using TravellerWiki.Data.SimpleWikiClasses;

namespace TravellerWiki.Data.Factions
{
    
    public class TravellerFaction
    {
        private static int _factionID = 10000;

        public static int GetNextID()
        {
            var id = _factionID;
            _factionID++;
            return id;
        }
        public int FactionID { get; set; }
        public string FactionName { get; set; }

        [JsonIgnore] public string FactionNameLink => $"[{FactionName}](/Factions/IslandsFaction/{FactionID})";
        
        [JsonIgnore]
        public string FactionHeadName => FactionHead.Name;
        public string HeadquatersLocation { get; set; }
        
        [JsonIgnore]
        public bool HasOtherLocation => OtherOwnedLocations != null && OtherOwnedLocations.Count > 0;
        public List<string> OtherOwnedLocations { get; set; }
        public TravellerDateTime FoundedYear { get; set; }
        public TravellerIslandsNations IslandsNation { get; set; }
        public TravellerNationalities SupportingNationality { get; set; }
        public TravellerFactionPoliticalSway PoliticalSway { get; set; }
        public TravellerFactionSocialSway SocialSway { get; set; }
        public TravellerFactionEconomicSway EconomicSway { get; set; }

        public TravellerNPC FactionHead { get; set; }
        public List<TravellerNPC> FactionMembers { get; set; }
        
        [JsonIgnore]
        protected Random _randomGenerator { get; }

        public TravellerFaction(string factionName, string headquatersLocation, TravellerIslandsNations islandsNation, TravellerNationalities supportingNationality, 
            string factionHeadName, List<string> otherOwnedLocations, TravellerDateTime foundedYear,
            TravellerFactionPoliticalSway politicalSway, TravellerFactionSocialSway socialSway, TravellerFactionEconomicSway economicSway,
            TravellerNPC factionHead = null, List<TravellerNPC> factionMembers = null)
        {
            FactionName = factionName;
            HeadquatersLocation = headquatersLocation;
            OtherOwnedLocations = otherOwnedLocations;
            FoundedYear = foundedYear;
            IslandsNation = islandsNation;
            SupportingNationality = supportingNationality;
            FactionHead = factionHead;
            FactionMembers = factionMembers;
            PoliticalSway = politicalSway;
            SocialSway = socialSway;
            EconomicSway = economicSway;
            FactionID = GenerateFactionID();
            
            var factionSeed = factionName.Aggregate(0, (h, t) => h + t) 
                              + headquatersLocation.Aggregate(0, (h, t) => h + t)
                              + (int) IslandsNation 
                              - ((int) supportingNationality+1);
            
            _randomGenerator = new Random(factionSeed);
            
            if (string.IsNullOrEmpty(factionHeadName))
            {
                factionHeadName = GetNames(1,TravellerNameService.GetNationalitiesNameList(supportingNationality)).First();
            }

            if (foundedYear == null)
            {
                FoundedYear = new TravellerDateTime(_randomGenerator.Next(1, 32), _randomGenerator.Next(1, 13), 83,
                    _randomGenerator.Next(390 - 50, 391));
            }

            if (factionHead == null)
            {
                var npcGenerator = new TravellerNPCService();
                FactionHead = npcGenerator.GenerateNPC(factionHeadName,factionName.Aggregate(0,(h,t) => h+t));
            }

            if (factionMembers == null)
            {
                FactionMembers = new List<TravellerNPC>();
                var npcGenerator = new TravellerNPCService();
                
                int factionMemberCount = _randomGenerator.Next(0, 11);
                for (int i = 0; i < factionMemberCount; i++)
                {
                    var memberName = GetNames(1,TravellerNameService.GetNationalitiesNameList(supportingNationality)).First();
                    
                    FactionMembers.Add(npcGenerator.GenerateNPC(memberName,memberName.Aggregate(0,(h,t) => h+t)));
                }
            }
        }

        public static 
            (TravellerFactionPoliticalSway politicalSway, TravellerFactionSocialSway socialSway, TravellerFactionEconomicSway economicSway) 
            GenerateSwayValues(Random random)
        {
            var max = Enum.GetValues(typeof(TravellerFactionPoliticalSway));
            var pol = (TravellerFactionPoliticalSway) random.Next(0, max.Length - 1);
            var soc = (TravellerFactionSocialSway) random.Next(0, max.Length - 1);
            var econ = (TravellerFactionEconomicSway) random.Next(0, max.Length - 1);

            return (pol, soc, econ);
        }

        private int GenerateFactionID()
        {
            return GetNextID();
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