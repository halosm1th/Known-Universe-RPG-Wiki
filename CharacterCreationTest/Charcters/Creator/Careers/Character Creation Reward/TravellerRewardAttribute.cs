using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerRewardAttribute : TravellerCharacterCreationReward
    {
        public TravellerAttribute AttributeChange { get; }

        public TravellerRewardAttribute(TravellerAttributes attribute, int changeAmount)
        {
            AttributeChange = new TravellerAttribute(attribute,changeAmount);
        }

        public TravellerRewardAttribute(TravellerAttribute attributeChange)
        {
            AttributeChange = attributeChange;
        }
    }
}