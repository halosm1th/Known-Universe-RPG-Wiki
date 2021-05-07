using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
namespace TravellerWiki.Data
{
    public class TravellerNameLists
    {

        public static List<string> FederationNameList =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/NameLists/FederationNameList.txt").ToList();

        public static List<string> BritanniaNameList =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/NameLists/BritanniaNameList.txt").ToList();

        public static List<string> ImperialNameList =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/NameLists/ImperialNameList.txt").ToList();
        
        public static List<string> VersNameList =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/NameLists/VersNameList.txt").ToList();

        public static List<string> GermushiaNameList =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/NameLists/GermushianNameList.txt").ToList();
        
        public static List<string> DeutschlandNameList =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/NameLists/DeutschlandNameList.txt").ToList();

        public static List<string> XiaoMingNameList =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/NameLists/XiaoMingNameList.txt").ToList();
        
        public static List<string> AxionAllianceNameList =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/NameLists/AxionAllianceNameList.txt").ToList();
    }
}
