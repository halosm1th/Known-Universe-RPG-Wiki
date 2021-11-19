using TravellerWiki.Data;

namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardQualification : TravellerCharacterCreationReward
    {
        public int IncreaseAmount { get; }

        public TravellerRewardQualification(int amount)
        {
            IncreaseAmount = amount;
        }

        public override string ToString() => $"Increase your next qualification roll by: {IncreaseAmount}";
    }
}