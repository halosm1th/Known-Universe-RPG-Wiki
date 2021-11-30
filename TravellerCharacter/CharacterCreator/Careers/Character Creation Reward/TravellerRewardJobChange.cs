namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardJobChange : TravellerCharacterCreationReward
    {
        public TravellerRewardJobChange(string newCareerName)
        {
            NewCareerName = newCareerName;
        }

        public string NewCareerName { get; }

        public override string ToString()
        {
            return $"Change Career to: {NewCareerName}";
        }
    }
}