namespace TravellerCharacter.CharacterCreator.CreationEvents
{
    public class TravellerEventLife : TravellerEventCharacterCreation
    {
        public TravellerEventLife(string eventText) : base(eventText)
        {
        }

        public override string ToString()
        {
            return $"{EventText}. Roll on the Life Events table.";
        }
    }
}