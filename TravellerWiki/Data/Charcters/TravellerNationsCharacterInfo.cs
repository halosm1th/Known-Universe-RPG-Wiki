using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellerWiki.Data
{
    public class TravellerNationsCharacterInfo
    {
        public string NationName { get; set; }
        public string BackgroundText { get; set; }
        public List<(string Stat, int ChangeBy)> StatChanges { get; set; }
        public List<string> Perks { get; set; }
        public List<string> BackgroundSkills { get; set; }
        public List<string> EntryRequirements { get; set; }

        public TravellerNationsCharacterInfo(string name, string backgroundText, List<(string Stat, int ChangeBy)> statChanges, List<string> perks, List<string> backgroundSkills)
        {
            NationName = name;
            BackgroundText = backgroundText;
            StatChanges = statChanges;
            Perks = perks;
            BackgroundSkills = backgroundSkills;
            EntryRequirements = new List<string> { "None" };
        }

        public TravellerNationsCharacterInfo(string name, string backgroundText, List<(string Stat, int ChangeBy)> statChanges, List<string> perks, List<string> backgroundSkills, List<string> entryRequirements)
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
            StatChanges = new List<(string Stat, int ChangeBy)> { ("Error", 0) };
            Perks = new List<string> { "Error" };
            BackgroundSkills = new List<string> { "Error" };
            EntryRequirements = new List<string> { "Error" };
        }

        public string GetStatChanges()
        {
            var sb = new StringBuilder();
            foreach (var change in StatChanges)
            {
                sb.Append(change.Stat);
                sb.Append(":");
                sb.Append(change.ChangeBy);

                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }

        public override string ToString()
        {
            return NationName;
        }
    }
}