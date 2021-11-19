namespace TravellerCharacter.CharacterCreator.CreationEvents
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