﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data.CreationEvents
{
    public class TravellerEventSkillCheck : TravellerEventChoice
    {
        public List<TravellerSkillCheck> SkillChecks { get; }

        public TravellerEventSkillCheck(string eventText, TravellerEventCharacterCreation yesEvent, TravellerEventCharacterCreation noEvent, (TravellerSkills skill, int value) skillCheck) : base(eventText, yesEvent, noEvent)
        {
            SkillChecks = new List<TravellerSkillCheck>();
            SkillChecks.Add(new TravellerSkillCheck(skillCheck.skill,skillCheck.value));
        }

        public TravellerEventSkillCheck(string eventText, TravellerEventCharacterCreation yesEvent, TravellerEventCharacterCreation noEvent, TravellerSkillCheck skillCheck) : base(eventText, yesEvent, noEvent)
        {
            SkillChecks = new List<TravellerSkillCheck>();
            SkillChecks.Add(skillCheck);
        }
        public TravellerEventSkillCheck(string eventText, TravellerEventCharacterCreation yesEvent, TravellerEventCharacterCreation noEvent, List<TravellerSkillCheck> skillChecks) : base(eventText, yesEvent, noEvent)
        {
            SkillChecks = skillChecks;
        }

        /// <summary>
        /// Make a skill check
        /// </summary>
        /// <param name="roll">The result of the die roll from the traveller, before modifiers</param>
        /// <param name="travellersSkill">the skill the traveller is using.</param>
        /// <returns>If the skill check was passed</returns>
        public bool MakeSkillCheck(int roll, TravellerSkill travellersSkill)
        {
            var skill = SkillChecks.First(skill => skill.SkillToCheck.SkillName == travellersSkill.SkillName);
            
            return skill.PassedCheck(roll + travellersSkill.SkillValue);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(EventText);
            sb.Append(" Make one of: ");

            foreach (var skill in SkillChecks)
            {
                sb.Append(skill.ToString());
                sb.Append(" ");
            }

            return sb.ToString();
        }
    }
}