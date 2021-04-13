using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data.CreationEvents
{
    public class TravellerEventAttributeCheck : TravellerEventChoice
    {
        public List<TravellerAttributeCheck> AttributeChecks { get; }
        public TravellerEventAttributeCheck(string eventText, TravellerEventCharacterCreation successEvent, TravellerEventCharacterCreation failEvent,
            (TravellerAttributes attribute, int value) attributeCheck, string successText = "<<Pass>>", string failText = "<<Fail>>") : base(eventText, successEvent, failEvent, successText, failText)
        {
            AttributeChecks = new List<TravellerAttributeCheck>();
            AttributeChecks.Add(new TravellerAttributeCheck(attributeCheck.attribute,attributeCheck.value)); 
        }
        public TravellerEventAttributeCheck(string eventText, TravellerEventCharacterCreation successEvent, TravellerEventCharacterCreation failEvent,
            TravellerAttributeCheck attributeCheck, string successText = "<<Pass>>", string failText = "<<Fail>>") : base(eventText, successEvent, failEvent, successText, failText)
        {
            AttributeChecks = new List<TravellerAttributeCheck>();
            AttributeChecks.Add(attributeCheck);
        }
        public TravellerEventAttributeCheck(string eventText, TravellerEventCharacterCreation successEvent, TravellerEventCharacterCreation failEvent, 
            List<TravellerAttributeCheck> attributeChecks, string successText = "<<Pass>>", string failText = "<<Fail>>") : base(eventText, successEvent, failEvent,successText,failText)
        {
            AttributeChecks = attributeChecks;
        }

        /// <summary>
        /// Make an Attribute check
        /// </summary>
        /// <param name="roll">The result of the die roll from the traveller, before modifiers</param>
        /// <param name="attributeToCheckAgainst">the Attribute the traveller is using.</param>
        /// <returns>If the check was passed</returns>
        public bool MakeAttributeCheck(int roll, TravellerAttribute attributeToCheckAgainst)
        {
            var skill = AttributeChecks.First(skill => skill.AttributeToCheck == attributeToCheckAgainst.AttributeName);
            return skill.PassedCheck(roll + attributeToCheckAgainst.AttributableValue);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(EventText);
            sb.Append(" Make one of: ");

            foreach (var attribute in AttributeChecks)
            {
                sb.Append(attribute.ToString());
                sb.Append(" ");
            }

            return sb.ToString();
        }
    }
}