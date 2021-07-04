namespace TravellerWiki.Data
{
    public class TravellerRewardVehicle : TravellerCharacterCreationReward
    {
        public string RewardText =>
            "You receive a personal vehicle, such as a ground car or air/raft. You can choose exactly what type of vehicle this is but it may not be armed and has a limit of Cr300000 and TL 10. If you roll this benefit again, gain a level of Drive or Flyer";
        public override string ToString() => "Vehicle Reward";
    }
}