using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerNationsCharacterInfo
    {
        public string NationName { get; set; }
        public string BackgroundText { get; set; }
        public List<TravellerAttribute> StatChanges { get; set; }
        public List<TravellerItem> Perks { get; set; }
        public List<TravellerSkill> BackgroundSkills { get; set; }
        public List<TravellerAttribute> EntryRequirements { get; set; }

        public TravellerNationsCharacterInfo(string name, string backgroundText, List<TravellerAttribute> statChanges, List<TravellerItem> perks, List<TravellerSkill> backgroundSkills)
        {
            NationName = name;
            BackgroundText = backgroundText;
            StatChanges = statChanges;
            Perks = perks;
            BackgroundSkills = backgroundSkills;
            EntryRequirements = null;
        }

        public TravellerNationsCharacterInfo(string name, string backgroundText, List<TravellerAttribute> statChanges, List<TravellerItem> perks, List<TravellerSkill> backgroundSkills, List<TravellerAttribute> entryRequirements)
        {
            NationName = name;
            BackgroundText = backgroundText;
            StatChanges = statChanges;
            Perks = perks;
            BackgroundSkills = backgroundSkills;
            EntryRequirements = entryRequirements;
        }

        public TravellerNationsCharacterInfo()
        {
            NationName = "Error";
            BackgroundText = "Error";
            StatChanges = new List<TravellerAttribute>();
            Perks = new List<TravellerItem>();
            BackgroundSkills = new List<TravellerSkill>();
            EntryRequirements = new List<TravellerAttribute>();
        }

        public override string ToString()
        {
            return NationName;
        }
    }
}