using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerRewardContact : TravellerCharacterCreationReward
    {
        public Dictionary<string,TravellerNPCRelationship> Contacts { get; }

        public TravellerRewardContact(string contactName, TravellerNPCRelationship relationship)
        {
            Contacts = new Dictionary<string,TravellerNPCRelationship>
            {
                {contactName,relationship}
            };
        }

        public TravellerRewardContact(Dictionary<string, TravellerNPCRelationship> contacts)
        {
            Contacts = contacts;
        }

        public override string ToString()
        {
            return Contacts.Aggregate(new StringBuilder(), (npcs, next) => npcs.Append($" {next.Value}: {next.Key} |"),
                sb => sb.ToString().Remove(sb.ToString().Length-1));
        }
    }
}