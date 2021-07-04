using System.Collections.Generic;
using System.Linq;

namespace TravellerWiki.Data
{
    public class TravellerRewardMulti : TravellerCharacterCreationReward
    {
        public List<TravellerCharacterCreationReward> Rewards { get; }

        public TravellerRewardMulti(List<TravellerCharacterCreationReward> rewards)
        {
            Rewards = rewards;
        }

        public override string ToString()
        {
            return $"{Rewards.Aggregate("", (rewards, next) => $"{rewards} | {next}")} ";
        }
    }
}