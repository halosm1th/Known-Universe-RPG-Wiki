namespace TravellerCharacter.CharacterCreator.CreationEvents
{
    public class TravellerEventChangeCareers : TravellerEventCharacterCreation
    {
        public TravellerEventChangeCareers(string eventText, string newCareerName) : base(eventText)
        {
            NewCareerName = newCareerName;
        }

        public string NewCareerName { get; }

        public override string ToString()
        {
            return $"{EventText}. Change Careers to: {NewCareerName}";
        }
    }
}