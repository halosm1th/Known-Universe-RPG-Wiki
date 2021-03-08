namespace TravellerWiki.Data
{
    public class TravellerRewardGun : TravellerCharacterCreationReward
    {
        public string RewardText =>
            "Select any common or military ranged weapon with a limit of Cr1000 and TL 12. If you roll this benefit again, you may take another weapon or one level in the appropriate Gun Combat skill for a weapon already received as a benefit.";

        public override string ToString() => "Gun";
    }
}