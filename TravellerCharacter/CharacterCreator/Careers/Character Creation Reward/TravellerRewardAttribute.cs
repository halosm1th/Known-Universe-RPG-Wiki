using TravellerCharacter.CharacterParts;

namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardAttribute : TravellerCharacterCreationReward
    {
        public TravellerAttribute AttributeChange { get; }

        public TravellerRewardAttribute(TravellerAttributes attribute, int changeAmount = 1)
        {
            AttributeChange = new TravellerAttribute(attribute,changeAmount);
        }

        public TravellerRewardAttribute(TravellerAttribute attributeChange)
        {
            AttributeChange = attributeChange;
        }

        public override string ToString()
        {
            return $"{AttributeChange.AttributeName}+{AttributeChange.AttributableValue}";
        }
    }
}