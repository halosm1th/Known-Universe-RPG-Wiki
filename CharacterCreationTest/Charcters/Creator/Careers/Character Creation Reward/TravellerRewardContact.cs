using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerRewardContact : TravellerCharacterCreationReward
    {
        public Dictionary<TravellerNPCRelationship,string> Contacts { get; }

        public TravellerRewardContact(string contactName, TravellerNPCRelationship relationship)
        {
            Contacts = new Dictionary<TravellerNPCRelationship, string>
            {
                {relationship,contactName}
            };
        }

        public TravellerRewardContact(Dictionary<TravellerNPCRelationship, string> contacts)
        {
            Contacts = contacts;
        }

        public override string ToString()
        {
            return Contacts.Aggregate(new StringBuilder(), (npcs, next) => npcs.Append($"| {next.Value}: {next.Key}"),
                sb => sb.ToString());
        }
    }
}