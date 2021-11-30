using System.Collections.Generic;
using TravellerCharacter.CharacterCreator.Careers;
using TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward;
using TravellerCharacter.CharacterCreator.Items;
using TravellerCharacter.CharacterParts;
using TravellerCharacter.CharcterTypes;
using static TravellerCharacter.CharacterParts.TravellerSkills;
using static TravellerCharacter.CharacterParts.TravellerAttributes;

namespace TravellerCharacter.Character_Services.Career_Service.Versian_Careers
{
    internal class TravellerVersianCareers : TravellerMajorPowerCareers
    {
        public static TravellerNationsCharacterInfo VersianNation => new(
            "Fifth Vers Empire",
            TravellerNationalities.Fifth_Vers_Empire,
            "A regal empire reformed but ashamed, beaten and lost, dejected and defeated but boldly looking to the future for growth. Those from the Vers Empire that are travelling tend to be low members of the Aristocractic class or rich members of the Civis class.",
            new List<(TravellerAttributes Stat, int ChangeBy)>
            {
                (Social, 1), (Education, +1), (Strength, +1), (Intelligence, -2)
            },
            new List<TravellerCharacterCreationReward>
            {
                new TravellerRewardItem(new List<TravellerItem>
                {
                    new TravellerGenericItem("Versian Citizenship", 10000, 1, 20)
                }),
                new TravellerRewardSkill(new List<TravellerSkill>
                {
                    new(Language_HighVersian, 1),
                    new(Langauge_LowVersian, 1),
                    new(Religion_Sithism)
                })
            },
            new Dictionary<int, TravellerSkill>
            {
                { 0, new TravellerSkill(Admin) },
                { 1, new TravellerSkill(Animals) },
                { 2, new TravellerSkill(Art) },
                { 3, new TravellerSkill(Advocate) },
                { 4, new TravellerSkill(Carouse) },
                { 5, new TravellerSkill(Diplomat) },
                { 6, new TravellerSkill(Deception) },
                { 7, new TravellerSkill(Gambler) },
                { 8, new TravellerSkill(Language) },
                { 9, new TravellerSkill(Investigate) },
                { 10, new TravellerSkill(Persuade) },
                { 11, new TravellerSkill(Profession) },
                { 12, new TravellerSkill(Science) },
                { 13, new TravellerSkill(Steward) },
                { 14, new TravellerSkill(Streetwise) },
                { 15, new TravellerSkill(Melee) },
                { 16, new TravellerSkill(VaccSuit) }
            },
            "Versian Prisoner",
            new[]
            {
                "Versian Army",
                "Versian Navy"
            });

        public static void AddVersianCareers(List<TravellerCareer> careers)
        {
            careers.AddRange(new List<TravellerCareer>
            {
                TravellerVersianCivis.VersianCivis(),
                TravellerVersianPrisoner.VersianPrisoner(),
                TravellerVersianArmy.VersianArmy(),
                TravellerVersianKnight.VersianKnight(),
                TravellerEquitesOrdinisDeorum.EquitesOrdinisDeorum(),
                TravellerVersianAristocractic.AristocracticCareer(),
                TravellerVersianIdeaCreator.VersianIdeaCreator(),
                TravellerVersianNavy.VersianNavy(),
                TravellerVersianProductionWorker.VersianProductionWorker(),
                TravellerVersianFreeMan.VesianFreeMan()
            });
        }
    }
}