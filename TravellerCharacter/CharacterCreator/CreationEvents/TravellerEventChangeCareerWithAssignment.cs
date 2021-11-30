namespace TravellerCharacter.CharacterCreator.CreationEvents
{
    public class TravellerEventChangeCareerWithAssignment : TravellerEventChangeCareers
    {
        public TravellerEventChangeCareerWithAssignment(string eventText, string newCareerName, string assignment) :
            base(eventText, newCareerName)
        {
            Assignment = assignment;
        }

        public string Assignment { get; }

        public override string ToString()
        {
            return $"{EventText}. Change Career to: {NewCareerName} - {Assignment}";
        }
    }
}