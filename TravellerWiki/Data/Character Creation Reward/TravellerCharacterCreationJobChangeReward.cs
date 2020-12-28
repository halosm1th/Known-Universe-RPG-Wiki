namespace TravellerWiki.Data
{
    public class TravellerCharacterCreationJobChangeReward : TravellerCharacterCreationReward
    {
        public string NewCareerName { get; }

        public TravellerCharacterCreationJobChangeReward(string newCareerName)
        {
            NewCareerName = newCareerName;
        }

        public override string ToString()
        {
            return $"Change Career to: {NewCareerName}";
        }
    }
}