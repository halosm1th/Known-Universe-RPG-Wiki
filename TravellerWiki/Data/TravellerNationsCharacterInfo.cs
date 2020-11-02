using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellerWiki.Data
{
    public class TravellerNationsCharacterInfo
    {
        public string BackgroundText { get; set; }
        public List<(string Stat,int ChangeBy)> StatChanges { get; set; } 
        public List<string> Perks { get; set; }
        public List<string> BackgroundSkills { get; set; }
        public List<string> EntryRequirements { get; set; }

        public TravellerNationsCharacterInfo(string backgroundText, List<(string Stat, int ChangeBy)> statChanges, List<string> perks, List<string> backgroundSkills)
        {
            BackgroundText = backgroundText;
            StatChanges = statChanges;
            Perks = perks;
            BackgroundSkills = backgroundSkills;
            EntryRequirements = new List<string>{"None"};
        }

        public TravellerNationsCharacterInfo(string backgroundText, List<(string Stat, int ChangeBy)> statChanges, List<string> perks, List<string> backgroundSkills, List<string> entryRequirements)
        {
            BackgroundText = backgroundText;
            StatChanges = statChanges;
            Perks = perks;
            BackgroundSkills = backgroundSkills;
            EntryRequirements = entryRequirements;
        }

        public TravellerNationsCharacterInfo()
        {
            BackgroundText = "Error";
            StatChanges = new List<(string Stat, int ChangeBy)>{("Error",0)};
            Perks = new List<string> {"Error"};
            BackgroundSkills = new List<string>{"Error"};
            EntryRequirements = new List<string> {"Error"};
        }
    }
}
