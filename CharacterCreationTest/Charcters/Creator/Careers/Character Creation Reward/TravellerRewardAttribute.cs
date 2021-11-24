using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
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