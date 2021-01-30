using System.Collections.Generic;
using System.Linq;

namespace TravellerWiki.Data
{
    public class TravellerCharacterCreationSkillReward : TravellerCharacterCreationReward
    {
        public List<string> Skilllist { get; }

        public TravellerCharacterCreationSkillReward(List<string> skilllist)
        {
            Skilllist = skilllist;
        }

        public override string ToString()
        {
            return $"{Skilllist.Aggregate("",(skills,next) => $"{skills} {next}")}";
        }
    }
}