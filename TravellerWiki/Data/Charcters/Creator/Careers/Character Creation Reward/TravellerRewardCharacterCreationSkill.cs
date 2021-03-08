using System.Collections.Generic;
using System.Linq;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerRewardCharacterCreationSkill : TravellerCharacterCreationReward
    {
        public List<TravellerSkill> Skilllist { get; }
        public TravellerRewardCharacterCreationSkill(TravellerSkill skill)
        {
            Skilllist = new List<TravellerSkill> { skill };
        }

        public TravellerRewardCharacterCreationSkill(TravellerSkills skill)
        {
            Skilllist = new List<TravellerSkill> { new TravellerSkill(skill, 0) };
        }

        public TravellerRewardCharacterCreationSkill(TravellerSkills skill, int value = 0)
        {
            Skilllist = new List<TravellerSkill> {new TravellerSkill(skill, value)};
        }

        public TravellerRewardCharacterCreationSkill(List<TravellerSkills> skilllist)
        {
            Skilllist = new List<TravellerSkill>();
            foreach (var skill in skilllist)
            {
                Skilllist.Add(new TravellerSkill(skill));
            }
        }

        public TravellerRewardCharacterCreationSkill(List<TravellerSkill> skilllist)
        {
            Skilllist = skilllist;
        }

        public override string ToString()
        {
            return $"{Skilllist.Aggregate("",(skills,next) => $"{skills} | {next}")}";
        }
    }
}