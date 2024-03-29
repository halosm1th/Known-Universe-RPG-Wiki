﻿using System.Collections.Generic;
using TravellerCharacter.CharacterCreator.Careers;
using TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward;
using TravellerCharacter.CharacterCreator.Items;
using TravellerCharacter.CharacterParts;
using TravellerCharacter.CharcterTypes;
using static TravellerCharacter.CharacterParts.TravellerSkills;
using static TravellerCharacter.CharacterParts.TravellerAttributes;

namespace TravellerCharacter.Character_Services.Career_Service.Polandskian_Careers
{
    internal class TravellerPolandskianCareers : TravellerMinorPowerCareers
    {
        public static TravellerNationsCharacterInfo PolandskiaNation =>
            new("Polandskia Peoples Union",
                TravellerNationalities.Polandskia_Peoples_Union,
                "What happens to a place when the government is told they have to leave, and the replacement government is told they aren’t allowed to do anything too similar to their closest neighbor who they now depend on. Piracy has begun to run rampant, as has terrorism and various warlords declaring their own nations within Polandskia, described once as \\“A nation of nations, one which can handle nations within nations. Even if we don’t always agree as nations.\\”",
                new List<(TravellerAttributes Stat, int ChangeBy)>
                {
                    (Strength, +2), (Intelligence, 1), (Education, -1), (Endurance, -2)
                },
                new List<TravellerCharacterCreationReward>
                {
                    new TravellerRewardItem(new List<TravellerItem>
                    {
                        new TravellerGenericItem("Weapon", 2000, 30, 12)
                    }),
                    new TravellerRewardSkill(new List<TravellerSkill>
                    {
                        new(Language_germushian, 1),
                        new(Langauge_Sigmarian, 1),
                        new(Religion_Sigmarism)
                    })
                },
                new Dictionary<int, TravellerSkill>
                {
                    { 0, new TravellerSkill(GunCombat) },
                    { 1, new TravellerSkill(Animals) },
                    { 2, new TravellerSkill(Melee) },
                    { 3, new TravellerSkill(Athletics) },
                    { 4, new TravellerSkill(Carouse) },
                    { 5, new TravellerSkill(Drive) },
                    { 6, new TravellerSkill(Electronics) },
                    { 7, new TravellerSkill(Flyer) },
                    { 8, new TravellerSkill(Language) },
                    { 9, new TravellerSkill(Mechanic) },
                    { 10, new TravellerSkill(Medic) },
                    { 11, new TravellerSkill(Explosives) },
                    { 12, new TravellerSkill(HeavyWeapons) },
                    { 13, new TravellerSkill(Seafarer) },
                    { 14, new TravellerSkill(Streetwise) },
                    { 15, new TravellerSkill(Survival) },
                    { 16, new TravellerSkill(VaccSuit) }
                },
                "Polandskia Pirate",
                new[]
                {
                    "Polandskia Pirate",
                    "Polandskia Military"
                });

        public static void AddPolandskianCareers(List<TravellerCareer> careers)
        {
            var pirate = TravellerPolandskiaPirate.PolandskiaPirate();

            careers.Add(pirate);
        }
    }
}