using TravellerWiki.Data;

namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardAugment : TravellerCharacterCreationReward
    {
        public string RewardText =>
            "Gain any augmentations (see page 99) with a limit of Cr50000 and TL 12. If you roll this benefit again, then you may either take a different Augmentation or increase the one you already possess by one level (this may take it above the credit and TL limit).";

        public override string ToString() => "An Augmentation";
    }
}