using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravellerCharacter.Character_Services.NPC_Services;

namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardContact : TravellerCharacterCreationReward
    {
        public TravellerRewardContact(string contactName, TravellerNPCRelationship relationship)
        {
            Contacts = new Dictionary<string, TravellerNPCRelationship>
            {
                { contactName, relationship }
            };
        }

        public TravellerRewardContact(Dictionary<string, TravellerNPCRelationship> contacts)
        {
            Contacts = contacts;
        }

        public Dictionary<string, TravellerNPCRelationship> Contacts { get; }

        public override string ToString()
        {
            return Contacts.Aggregate(new StringBuilder(), (npcs, next) => npcs.Append($" {next.Value}: {next.Key} |"),
                sb => sb.ToString().Remove(sb.ToString().Length - 1));
        }
    }
}