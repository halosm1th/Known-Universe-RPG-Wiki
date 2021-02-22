using System.Collections.Generic;
using System.Linq;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerCharacterCreationSkillReward : TravellerCharacterCreationReward
    {
        public List<TravellerSkill> Skilllist { get; }

        public TravellerCharacterCreationSkillReward(List<TravellerSkill> skilllist)
        {
            Skilllist = skilllist;
        }

        public override string ToString()
        {
            return $"{Skilllist.Aggregate("",(skills,next) => $"{skills} {next}")}";
        }
    }
}