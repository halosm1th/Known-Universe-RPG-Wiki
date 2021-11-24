using TravellerWiki.Data;

namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardBlade : TravellerCharacterCreationReward
    {
        public string RewardText =>
            "Select any blade weapon with a limit of Cr1000 and TL 12. If you roll this benefit again, you may take another blade or one level in the Melee (blades) skill.";

        public override string ToString() => "Blade";
    }
}