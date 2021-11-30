namespace TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward
{
    public class TravellerRewardShip : TravellerCharacterCreationReward
    {
        public string RewardText =>
            "You receive a free trader with 25% of the mortgage paid off on it. This free trader is identical to the one on page 168 but you must roll 1D times on the Spacecraft Quirks table on page 164. If you roll this benefit again, an additional 25% of the mortgage has been paid off – if you roll this benefit four times, the free trader will have no mortgage and it will be all yours! Alternatively, you may select a Far Trader (Page 166) instead";

        public override string ToString()
        {
            return "Free Trader Reward";
        }
    }
}