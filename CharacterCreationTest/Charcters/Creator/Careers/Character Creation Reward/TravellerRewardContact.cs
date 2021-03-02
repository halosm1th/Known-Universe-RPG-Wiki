using System.Collections.Generic;
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
    }
}