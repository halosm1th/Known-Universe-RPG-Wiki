using TravellerCharacter.CharacterParts;

namespace TravellerCharacter.CharacterCreator
{
    public class TravellerAttributeCheck
    {
        public TravellerAttributeCheck(TravellerAttributes attributeName, int beatValue)
        {
            UnderlingAttribute = new TravellerAttribute(attributeName, beatValue);
        }

        public TravellerAttributeCheck(TravellerAttribute attribute)
        {
            UnderlingAttribute = attribute;
        }

        public TravellerAttributeCheck()
        {
        }

        public TravellerAttribute UnderlingAttribute { get; }

        public TravellerAttributes AttributeToCheck => UnderlingAttribute.AttributeName;


        public bool PassedCheck(int testValue)
        {
            return testValue >= UnderlingAttribute.AttributableValue;
        }


        public override string ToString()
        {
            return $"{UnderlingAttribute.AttributeName}({UnderlingAttribute.AttributableValue}+)";
        }
    }
}