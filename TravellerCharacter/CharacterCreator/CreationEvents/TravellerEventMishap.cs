namespace TravellerCharacter.CharacterCreator.CreationEvents
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