namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardAdvancement : TravellerCharacterCreationReward
    {
        public TravellerRewardAdvancement(int advancementAmount)
        {
            AdvancementAmount = advancementAmount;
        }

        public int AdvancementAmount { get; }

        public override string ToString()
        {
            return $"Increase to 1 advance roll by {AdvancementAmount}";
        }
    }
}