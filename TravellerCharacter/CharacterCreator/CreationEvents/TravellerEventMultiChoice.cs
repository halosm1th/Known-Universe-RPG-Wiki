using System;
using System.Collections.Generic;
using System.Text;

namespace TravellerCharacter.CharacterCreator.CreationEvents
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

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(EventText);
            sb.Append(": ");

            foreach (var ccEvent in Events)
            {
                sb.Append("[");
                sb.Append(ccEvent.ToString());
                sb.Append("] ");
            }

            return sb.ToString();
        }
    }
}