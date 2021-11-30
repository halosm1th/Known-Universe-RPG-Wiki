using System.Collections.Generic;
using System.Linq;
using TravellerCharacter.CharacterParts;

namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardSkill : TravellerCharacterCreationReward
    {
        public TravellerRewardSkill(TravellerSkill skill)
        {
            Skilllist = new List<TravellerSkill> { skill };
        }

        public TravellerRewardSkill(TravellerSkills skill)
        {
            Skilllist = new List<TravellerSkill> { new(skill) };
        }

        public TravellerRewardSkill(TravellerSkills skill, int value = 0)
        {
            Skilllist = new List<TravellerSkill> { new(skill, value) };
        }

        public TravellerRewardSkill(List<TravellerSkills> skilllist)
        {
            Skilllist = new List<TravellerSkill>();
            foreach (var skill in skilllist) Skilllist.Add(new TravellerSkill(skill));
        }

        public TravellerRewardSkill(List<TravellerSkill> skilllist)
        {
            Skilllist = skilllist;
        }

        public List<TravellerSkill> Skilllist { get; }

        protected void AddSkills(List<TravellerSkills> skilllist)
        {
            foreach (var skill in skilllist) Skilllist.Add(new TravellerSkill(skill));
        }

        public override string ToString()
        {
            return $"{Skilllist.Aggregate("", (skills, next) => $"{skills} | {next}")}";
        }
    }
}