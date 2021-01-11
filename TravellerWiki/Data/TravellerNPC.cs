using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellerWiki.Data
{
    public class TravellerNPC
    {

        public int Strength
        {
            get { return SkillDictionary["Str"]; }
            set { SkillDictionary["Str"] += value; }
        }

        public int Dexterity
        {
            get { return SkillDictionary["Dex"]; }
            set { SkillDictionary["Dex"] += value; }
        }

        public int Endurance
        {
            get { return SkillDictionary["End"]; }
            set { SkillDictionary["End"] += value; }
        }

        public int Intelligence
        {
            get { return SkillDictionary["Int"]; }
            set { SkillDictionary["Int"] += value; }
        }

        public int Education
        {
            get { return SkillDictionary["Edu"]; }
            set { SkillDictionary["Edu"] += value; }
        }

        public int Social
        {
            get { return SkillDictionary["Soc"]; }
            set { SkillDictionary["Soc"] += value; }
        }

        public string Background { get; set; }
        public string Career { get; set; }

        public string PatronText { get; set; }
        public string QuirkText { get; set; }


        public string Name { get; set; }

        public int Modifier(int number)
            => number switch
            {
                0 => -3,
                1 => -2,
                2 => -2,
                3 => -1,
                4 => -1,
                5 => -1,
                6 => 0,
                7 => 0,
                8 => 0,
                9 => 1,
                10 => 1,
                11 => 1,
                12 => 2,
                13 => 2,
                14 => 2,
                15 => 3,
                _ => 3

    };

        //Skill,level
        public Dictionary<string,int> SkillDictionary { get; set; }

        public string UPP()
        {
            var sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(" - ");
            sb.Append(Strength.ToString("X"));
            sb.Append(Dexterity.ToString("X"));
            sb.Append(Endurance.ToString("X"));
            sb.Append(Intelligence.ToString("X"));
            sb.Append(Education.ToString("X"));
            sb.Append(Social.ToString("X"));
            return sb.ToString();
        }

        private string NPCBackgroundAndCareer()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Background);
            sb.Append(", ");
            sb.Append(Career);

            return sb.ToString();
        }

        private string NPCTextAndQuirk()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(PatronText);
            sb.Append(", ");
            sb.Append(QuirkText);

            return sb.ToString();
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(UPP());
            sb.Append(" - ");

            sb.Append(NPCBackgroundAndCareer());
            sb.Append(" - ");

            sb.Append(NPCTextAndQuirk());

            return sb.ToString();
        }
    }
}
