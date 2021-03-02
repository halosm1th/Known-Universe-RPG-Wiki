using System.Collections.Generic;
using System.Linq;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data.CreationEvents
{
    public class TravellerEventAttributeCheck : TravellerEventChoice
    {
        public List<TravellerAttributeCheck> AttributeChecks { get; }

        public TravellerEventAttributeCheck(string eventText, TravellerEventCharacterCreation successEvent, TravellerEventCharacterCreation failEvent, List<TravellerAttributeCheck> atributeChecks, string successText = "Yes", string failText = "No") : base(eventText, successEvent, failEvent,successText,failText)
        {
            AttributeChecks = atributeChecks;
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
    }
}