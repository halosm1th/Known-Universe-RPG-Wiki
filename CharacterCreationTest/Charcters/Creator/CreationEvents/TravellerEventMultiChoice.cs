using System;
using System.Collections.Generic;

namespace TravellerWiki.Data.CreationEvents
{
    public class TravellerEventMultiChoice : TravellerEventCharacterCreation
    {
        public List<TravellerEventCharacterCreation> Events { get; }

        public TravellerEventMultiChoice(string eventText, List<TravellerEventCharacterCreation> events) : base(eventText)
        {
            Events = events;
        }

        /// <summary>
        /// Get a specific event
        /// </summary>
        /// <param name="number">The number to retrieve</param>
        /// <returns>The requested Event</returns>
        public TravellerEventCharacterCreation GetEvent(int eventNumber)
        {
            if (eventNumber >= Events.Count) throw new ArgumentOutOfRangeException("eventNumber must be less then Event count");

            return Events[eventNumber];
        }
    }
}