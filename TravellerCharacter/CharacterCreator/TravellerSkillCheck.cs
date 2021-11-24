﻿using TravellerCharacter.CharacterParts;

namespace TravellerCharacter.CharacterCreator
{
    public class TravellerSkillCheck
    {
        public TravellerSkill SkillToCheck { get; }

        public bool PassedCheck(int testValue)
        {
            return testValue >= SkillToCheck.SkillValue;
        }

        public TravellerSkillCheck(TravellerSkills skillName, int beatValue)
        {
            SkillToCheck = new TravellerSkill(skillName,beatValue);
        }

        public TravellerSkillCheck(TravellerSkill skill)
        {
            SkillToCheck = skill;
        }

        public override string ToString()
        {
            return $"{SkillToCheck.SkillName}({SkillToCheck.SkillValue}+)";
        }
    }
}