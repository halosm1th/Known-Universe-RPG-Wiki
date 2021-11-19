namespace TravellerCharacter.CharacterCreator.CreationEvents
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