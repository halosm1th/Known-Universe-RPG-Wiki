namespace TravellerCharacter.CharacterCreator.CreationEvents
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