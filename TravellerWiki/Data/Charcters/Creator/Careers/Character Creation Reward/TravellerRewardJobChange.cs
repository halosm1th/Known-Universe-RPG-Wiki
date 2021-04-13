namespace TravellerWiki.Data
{
    public class TravellerRewardJobChange : TravellerCharacterCreationReward
    {
        public string NewCareerName { get; }

        public TravellerRewardJobChange(string newCareerName)
        {
            NewCareerName = newCareerName;
        }

        public override string ToString()
        {
            return $"Change Career to: {NewCareerName}";
        }
    }
}