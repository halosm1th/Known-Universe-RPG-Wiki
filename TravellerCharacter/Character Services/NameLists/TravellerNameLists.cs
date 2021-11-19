using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TravellerCharacter.Character_Services.NameLists
{
    public class TravellerNameLists
    {

        public static List<string> FederationNameList =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/Data/NameLists/FederationNameList.txt").ToList();

        public static List<string> BritanniaNameList =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/Data/NameLists/BritanniaNameList.txt").ToList();

        public static List<string> ImperialNameList =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/Data/NameLists/ImperialNameList.txt").ToList();
        
        public static List<string> VersNameList =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/Data/NameLists/VersNameList.txt").ToList();

        public static List<string> GermushiaNameList =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/Data/NameLists/GermushianNameList.txt").ToList();
        
        public static List<string> DeutschlandNameList =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/Data/NameLists/DeutschlandNameList.txt").ToList();

        public static List<string> XiaoMingNameList =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/Data/NameLists/XiaoMingNameList.txt").ToList();
        
        public static List<string> AxionAllianceNameList =
            File.ReadAllLines(Directory.GetCurrentDirectory() + "/Data/NameLists/AxionAllianceNameList.txt").ToList();
    }
}
