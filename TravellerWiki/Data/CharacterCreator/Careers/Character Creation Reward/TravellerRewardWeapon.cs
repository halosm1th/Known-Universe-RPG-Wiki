namespace TravellerWiki.Data
{
    public class TravellerRewardWeapon : TravellerCharacterCreationReward
    {
        public string RewardText =>
            "You may choose a single weapon of Tech Level 12 or lower with a total value of less then 2000 Credits, applying whatever modifications or specialty ammunition you may wish to purchase with it, so long as the total is less then 2000Cr.";
        public override string ToString() => "Weapon Reward";
    }
}