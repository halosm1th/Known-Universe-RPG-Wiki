using System;
using System.Collections.Generic;
using System.Text;
using TravellerCharacter.Character_Services.NameLists;
using TravellerCharacter.CharcterTypes;

namespace TravellerCharacter.Character_Services
{
    public class TravellerNameService
    {
        public enum NationNameList
        {
            Federation,
            Vers,
            Empire,
            Britannia,
            Germushia,
            Deutschland,
            XiaoMing,
            AxionAlliance,
            Any
        }

        private static readonly Random rand = new();

        public static NationNameList GetNationalitiesNameList(TravellerNationalities nationalities)
        {
            return nationalities switch
            {
                TravellerNationalities.Universalis_Confederation => NationNameList.Any,
                TravellerNationalities.Wicher => NationNameList.Any,
                TravellerNationalities.United_Federation_of_Earth_and_her_Colonies_Among_the_Stars => NationNameList
                    .Federation,
                TravellerNationalities.Luna_Knights => NationNameList.Federation,
                TravellerNationalities.Fifth_Vers_Empire => NationNameList.Vers,
                TravellerNationalities.Equites_Ordinis_deorum => NationNameList.Vers,
                TravellerNationalities.United_Reverse_Lords => NationNameList.Vers,
                TravellerNationalities.Xiao_Ming_Mega_Corporation => NationNameList.XiaoMing,
                TravellerNationalities.Communist_Empire_of_the_Deutschland => NationNameList.Deutschland,
                TravellerNationalities.Church_of_Sigmar => NationNameList.Deutschland,
                TravellerNationalities.Germushian_Free_Republic => NationNameList.Germushia,
                TravellerNationalities.Polandskia_Peoples_Union => NationNameList.Deutschland,
                TravellerNationalities.Trans_Galactic_Empire => NationNameList.Empire,
                TravellerNationalities.Sith => NationNameList.Empire,
                TravellerNationalities.First_Order => NationNameList.Empire,
                TravellerNationalities.The_Kingdom_of_Britannia => NationNameList.Britannia,
                TravellerNationalities.Imperial_Versian_Federated_Territories => NationNameList.Britannia,
                TravellerNationalities.Axion_Alliance => NationNameList.AxionAlliance,
                TravellerNationalities.Artekkan_Guilds => NationNameList.AxionAlliance,
                _ => NationNameList.Any
            };
        }

        private List<string> GetNameList(NationNameList nation)
        {
            return nation switch
            {
                NationNameList.Federation => TravellerNameLists.FederationNameList,
                NationNameList.Britannia => TravellerNameLists.BritanniaNameList,
                NationNameList.Empire => TravellerNameLists.ImperialNameList,
                NationNameList.Vers => TravellerNameLists.VersNameList,
                NationNameList.Germushia => TravellerNameLists.GermushiaNameList,
                NationNameList.Deutschland => TravellerNameLists.DeutschlandNameList,
                NationNameList.XiaoMing => TravellerNameLists.XiaoMingNameList,
                NationNameList.AxionAlliance => TravellerNameLists.AxionAllianceNameList,
                _ => GetNameList(GetRandomNation())
            };
        }

        public NationNameList GetRandomNation()
        {
            var listOfNames = Enum.GetValues(typeof(NationNameList)).Length;
            return (NationNameList)rand.Next(0, listOfNames);
        }

        public List<string> GetNames(int numberOfNames, NationNameList nation)
        {
            if (nation == NationNameList.Any)
                nation = GetRandomNation();

            var nameList = GetNameList(nation);
            var returnList = new List<string>();

            for (var i = 0; i < numberOfNames; i++)
            {
                var sb = new StringBuilder();
                sb.Append(nameList[rand.Next(0, nameList.Count)]);
                sb.Append(" ");
                sb.Append(nameList[rand.Next(0, nameList.Count)]);
                returnList.Add(sb.ToString());
            }

            return returnList;
        }
    }
}