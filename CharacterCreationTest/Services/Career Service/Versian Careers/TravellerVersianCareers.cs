using System.Collections.Generic;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.Services.CareerService.NationsCareeres;
using static TravellerWiki.Data.Charcters.TravellerAttributes;
using static TravellerWiki.Data.Charcters.TravellerSkills;

namespace TravellerWiki.Data.Services.CareerService.VersianCareeres
{
    class TravellerVersianCareers : TravellerMajorPowerCareers
    {

        public static TravellerNationsCharacterInfo VersianNation => new TravellerNationsCharacterInfo(
            "Fifth Vers Empire",
            TravellerNationalities.Fifth_Vers_Empire,
            backgroundText:
            "A regal empire reformed but ashamed, beaten and lost, dejected and defeated but boldly looking to the future for growth. Those from the Vers Empire that are travelling tend to be low members of the Aristocractic class or rich members of the Civis class.",
            statChanges: new List<(TravellerAttributes Stat, int ChangeBy)>
            {
                (Social, 1), (Education, +1), (Strength, +1), (Intelligence, -2)
            },
            perks: new List<TravellerCharacterCreationReward>
            {
                new TravellerRewardtem(new List<TravellerItem>
                {
                    new TravellerItem("Versian Citizenship", 10000, 1, 20),
                }),
                new TravellerRewardSkill(new List<TravellerSkill>
                {
                    new TravellerSkill(Language_HighVersian, 1),
                    new TravellerSkill(Langauge_LowVersian, 1),
                    new TravellerSkill(Religion_Sithism),

                })
            },
            backgroundSkills: new Dictionary<int, TravellerSkill>()
            {
                {0, new TravellerSkill(Admin)},
                {1, new TravellerSkill(Animals)},
                {2, new TravellerSkill(Art)},
                {3, new TravellerSkill(Advocate)},
                {4, new TravellerSkill(Carouse)},
                {5, new TravellerSkill(Diplomat)},
                {6, new TravellerSkill(Deception)},
                {7, new TravellerSkill(Gambler)},
                {8, new TravellerSkill(Language)},
                {9, new TravellerSkill(Investigate)},
                {10, new TravellerSkill(Persuade)},
                {11, new TravellerSkill(Profession)},
                {12, new TravellerSkill(Science)},
                {13, new TravellerSkill(Steward)},
                {14, new TravellerSkill(Streetwise)},
                {15, new TravellerSkill(Melee)},
                {16, new TravellerSkill(VaccSuit)},
            },
            drifter: "Versian Prisoner",
            drafts: new string[]
            {
                "Versian Army",
                "Versian Navy"
            });

    public static void AddVersianCareers(List<TravellerCareer> careers)
        {

            careers.AddRange(new List<TravellerCareer>
            {
                TravellerVersianPrisoner.VersianPrisoner(),
                TravellerVersianArmy.VersianArmy(),
                TravellerVersianKnight.VersianKnight(),
                TravellerEquitesOrdinisDeorum.EquitesOrdinisDeorum(),
                TravellerVersianAristocractic.AristocracticCareer(),
            });

        }
    }
}