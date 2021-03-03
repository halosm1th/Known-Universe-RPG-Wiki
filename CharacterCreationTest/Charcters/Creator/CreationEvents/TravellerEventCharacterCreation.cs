using System;
using System.Collections.Generic;

namespace TravellerWiki.Data.CreationEvents
{
    public abstract class TravellerEventCharacterCreation
    {
        public string EventText { get; set; }

        public TravellerEventCharacterCreation(string eventText)
        {
            EventText = eventText;
        }

        public override string ToString()
        {
            return EventText;
        }
    }
}