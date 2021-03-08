namespace TravellerWiki.Data.CreationEvents
{
    public class TravellerEventMishap : TravellerEventCharacterCreation
    {
        public TravellerEventMishap(string eventText) : base(eventText)
        {
        }

        public override string ToString()
        {
            return $"Mishap: {EventText}.";
        }
    }
}