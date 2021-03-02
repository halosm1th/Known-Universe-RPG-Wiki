namespace TravellerWiki.Data
{
    public class TravellerRewardCharacterCreationJobChange : TravellerCharacterCreationReward
    {
        public string NewCareerName { get; }

        public TravellerRewardCharacterCreationJobChange(string newCareerName)
        {
            NewCareerName = newCareerName;
        }

        public override string ToString()
        {
            return $"Change Career to: {NewCareerName}";
        }
    }
}