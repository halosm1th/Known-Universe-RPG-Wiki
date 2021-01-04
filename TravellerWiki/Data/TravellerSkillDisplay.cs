using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerSkillDisplay
    {
        public string SkillName { get; set; }
        public TravellerSkill.TravellerSkills TravellerSkill { get; set; }

        public string Description {
        get;set;}

        public TravellerSkillDisplay(string skillName, TravellerSkill.TravellerSkills travellerSkill, string description)
        {
            SkillName = skillName;
            Description = description;
            TravellerSkill = travellerSkill;
        }
    }
}
