namespace TravellerWiki.Data.CreationEvents
{
    public class TravellerEventChangeCareers : TravellerEventCharacterCreation
    {
        public string NewCareerName { get; }

        public TravellerEventChangeCareers(string eventText, string newCareerName) : base(eventText)
        {
            NewCareerName = newCareerName;
        }

        public override string ToString()
        {
            return $"{EventText}. Change Careers to: {NewCareerName}";
        }
    }
}