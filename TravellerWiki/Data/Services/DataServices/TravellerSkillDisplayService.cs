using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerWiki.Data.Charcters;
using static TravellerWiki.Data.Charcters.TravellerSkills;

namespace TravellerWiki.Data
{
    public class TravellerSkillDisplayService
    {
        public List<TravellerSkill> TravellerSkillLists { get; set; } = new List<TravellerSkill>(GetSkills());

        private static List<TravellerSkill> GetSkills()
        {
            var values = new List<TravellerSkill>();
            foreach (var skill in Enum.GetValues(typeof(TravellerSkills)))
            {
                values.Add(new TravellerSkill((TravellerSkills) skill));
            }

            return values;
        }

        public List<TravellerSkill> GetTravellerSkills() => TravellerSkillLists.OrderBy(skill => skill.SkillName).ToList();
    }
}
