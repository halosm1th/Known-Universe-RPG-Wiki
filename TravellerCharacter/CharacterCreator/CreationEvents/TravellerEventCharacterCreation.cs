namespace TravellerCharacter.CharacterCreator.CreationEvents
{
    public abstract class TravellerEventCharacterCreation
    {
        public TravellerEventCharacterCreation(string eventText)
        {
            EventText = eventText;
        }

        public string EventText { get; set; }

        public override string ToString()
        {
            return EventText;
        }
    }
}