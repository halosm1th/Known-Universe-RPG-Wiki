namespace TravellerCharacter.CharacterCreator.CreationEvents
{
    public class TravellerEventChoice : TravellerEventCharacterCreation
    {
        public bool HasYesEvent => YesEvent != null;
        public bool HasNoEvent => NoEvent != null;

        public string YesText { get; }
        public string NoText { get; }

        public TravellerEventCharacterCreation YesEvent { get; }
        public TravellerEventCharacterCreation NoEvent { get; }

        public TravellerEventChoice(string eventText, TravellerEventCharacterCreation yesEvent, TravellerEventCharacterCreation noEvent, string yesText = "Yes", string noText = "No") : base(eventText)
        {
            YesEvent = yesEvent;
            NoEvent = noEvent;
            YesText = yesText;
            NoText = noText;
        }

        public override string ToString()
        {
            return $"{EventText}\n({YesText}: {YesEvent})\n({NoText}: {NoEvent})";
        }
    }
}