using TravellerWiki.Data;

namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardArmour : TravellerCharacterCreationReward
    {
        public string RewardText =>
            "Select any type of armour with a limit of Cr10000 and TL 12. If you roll this benefit again, then you can either select another type of armour with the same limits or trade your original in for armour with a limit of Cr 25000";

        public override string ToString() => "Armour";
    }
}