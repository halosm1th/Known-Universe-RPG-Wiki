using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellerWiki.Data
{
    public class TravellerSkillDisplay
    {
        public string SkillName { get; set; }
        public string Description { get; set; }

        public TravellerSkillDisplay(string skillName, string description)
        {
            SkillName = skillName;
            Description = description;
        }
    }
}
