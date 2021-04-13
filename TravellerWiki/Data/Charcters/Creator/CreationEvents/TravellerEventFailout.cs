namespace TravellerWiki.Data.CreationEvents
{
    public class TravellerEventFailout : TravellerEventCharacterCreation
    {
        public TravellerEventFailout(string eventText) : base(eventText)
        {
        }

        public override string ToString()
        {
            return $"Mishap: {EventText}.";
        }
    }
}