using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellerWiki.Data
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

        private List<string> GetNameList(NationNameList nation)
            => nation switch
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

        private static Random rand = new Random();

        private NationNameList GetRandomNation()
        {
            var listOfNames = Enum.GetValues(typeof(NationNameList)).Length;
            return (NationNameList) rand.Next(0, listOfNames);
        }

        public List<string> GetNames(int numberOfNames, NationNameList nation)
        {

            if (nation == NationNameList.Any) 
                nation = GetRandomNation();

            var nameList = GetNameList(nation);
            var returnList = new List<string>();

            for (int i = 0; i < numberOfNames; i++)
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
