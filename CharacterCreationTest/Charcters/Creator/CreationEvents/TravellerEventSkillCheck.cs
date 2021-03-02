using System.Collections.Generic;
using System.Linq;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data.CreationEvents
{
    public class TravellerEventSkillCheck : TravellerEventChoice
    {
        public List<TravellerSkillCheck> SkillChecks { get; }

        public TravellerEventSkillCheck(string eventText, TravellerEventCharacterCreation yesEvent, TravellerEventCharacterCreation noEvent, List<TravellerSkillCheck> skillChecks) : base(eventText, yesEvent, noEvent)
        {
            SkillChecks = skillChecks;
        }

        /// <summary>
        /// Make a skill check
        /// </summary>
        /// <param name="roll">The result of the die roll from the traveller, before modifiers</param>
        /// <param name="skillToCheckAgainst">the skill the traveller is using.</param>
        /// <returns>If the skill check was passed</returns>
        public bool MakeSkillCheck(int roll, TravellerSkill skillToCheckAgainst)
        {
            var skill = SkillChecks.First(skill => skill.SkillToCheck.SkillName == skillToCheckAgainst.SkillName);
            return skill.PassedCheck(roll + skillToCheckAgainst.SkillValue);
        }
    }
}