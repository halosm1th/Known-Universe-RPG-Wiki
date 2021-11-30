using System.Collections.Generic;
using System.Linq;

namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardMulti : TravellerCharacterCreationReward
    {
        public TravellerRewardMulti(List<TravellerCharacterCreationReward> rewards)
        {
            Rewards = rewards;
        }

        public List<TravellerCharacterCreationReward> Rewards { get; }

        public override string ToString()
        {
            return $"{Rewards.Aggregate("", (rewards, next) => $"{rewards} | {next}")} ";
        }
    }
}