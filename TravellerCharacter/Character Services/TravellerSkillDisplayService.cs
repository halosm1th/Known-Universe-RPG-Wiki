using System;
using System.Collections.Generic;
using System.Linq;
using TravellerCharacter.CharacterParts;

namespace TravellerCharacter.Character_Services
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
