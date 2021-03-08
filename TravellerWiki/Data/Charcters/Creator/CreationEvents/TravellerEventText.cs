namespace TravellerWiki.Data.CreationEvents
{
    public class TravellerEventText : TravellerEventCharacterCreation
    {
        public TravellerEventText(string eventText) : base(eventText)
        {
        }

        public override string ToString()
        {
            return EventText;
        }
    }
}