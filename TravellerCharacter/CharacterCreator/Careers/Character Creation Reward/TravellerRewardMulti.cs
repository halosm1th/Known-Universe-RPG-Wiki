using System.Collections.Generic;
using System.Linq;
using TravellerWiki.Data;

namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
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