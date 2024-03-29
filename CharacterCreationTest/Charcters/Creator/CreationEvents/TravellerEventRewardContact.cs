﻿using System.Collections.Generic;

namespace TravellerWiki.Data.CreationEvents
{
    public class TravellerEventRewardContact : TravellerEventReward
    {
        public TravellerEventRewardContact(string text, TravellerRewardContact contact) : base(text,new List<TravellerCharacterCreationReward>())
        {
            Reward.Add(contact);
        }

        public TravellerEventRewardContact(string text, List<TravellerRewardContact> contacts) : base(text, new List<TravellerCharacterCreationReward>())
        {
            Reward.AddRange(contacts);
        }

        public TravellerEventRewardContact(string text, string contactName, TravellerNPCRelationship relationship) : base(text, new List<TravellerCharacterCreationReward>())
        {
            Reward.Add(new TravellerRewardContact(contactName,relationship));
        }
    }
}