using System;
using System.Collections.Generic;
using TravellerCharacter.Character_Services.Career_Service.Versian_Careers;
using TravellerCharacter.Character_Services.NPC_Services;
using TravellerCharacter.CharacterCreator;
using TravellerCharacter.CharacterCreator.Careers;
using TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward;
using TravellerCharacter.CharacterCreator.Careers.SkillEntry;
using TravellerCharacter.CharacterCreator.CreationEvents;
using TravellerCharacter.CharacterCreator.Items;
using TravellerCharacter.CharacterParts;
using TravellerCharacter.CharcterTypes;
using static TravellerCharacter.CharacterParts.TravellerSkills;
using static TravellerCharacter.CharacterParts.TravellerAttributes;

namespace TravellerCharacter.Character_Services.Career_Service.Federation_Careers
{
    /*
    internal class TravellerLunaKnights : TravellerFederationCareers
    {
        private Random random = new();

        public static TravellerNationsCharacterInfo LunaKnightsNation => new(
            "",
            TravellerNationalities.Luna_Knights,
            "",
            new List<(TravellerAttributes Stat, int ChangeBy)>
            {
            },
            new List<TravellerCharacterCreationReward>
            {
                new TravellerRewardItem(new List<TravellerItem>
                {
                }),
                new TravellerRewardSkill(new List<TravellerSkill>
                {
                })
            },
            new Dictionary<int, TravellerSkill>
            {
            },
            new List<TravellerAttributeCheck>
            {
            },
            drifter: "Luna Knight", drafts: new[] { "Luna Knight" },
            parentNation: TravellerNationalities.United_Federation_of_Earth_and_her_Colonies_Among_the_Stars);

        public static TravellerCareer LunaKnight()
        {
            var career = new TravellerLunaKnights();

            return career.GetLunaKnight();
        }

        public TravellerCareer GetLunaKnight()
        {
            return new TravellerCareer(
                "",
                "",
                TravellerNationalities.Luna_Knights,
                new List<TravellerAttributeCheck>
                {
                },
                new List<TravellerAssignment>
                {
                    new(
                        "",
                        "",
                        new TravellerAttributeCheck(),
                        new TravellerAttributeCheck(),
                        new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry()
                        },
                        new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("", new TravellerRewardMulti(new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardSkill(),
                                new TravellerRewardItem(new List<TravellerItem>
                                {
                                    TravellerItemStoreService.GetItemStatic("")
                                })
                            })),
                            ("", new TravellerRewardSkill()),
                            ("", new TravellerRewardSkill()),
                            ("", new TravellerRewardSkill()),
                            ("", new TravellerRewardSkill()),
                            ("", new TravellerRewardSkill())
                        }),

                    new(
                        "",
                        "",
                        new TravellerAttributeCheck(),
                        new TravellerAttributeCheck(),
                        new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry()
                        },
                        new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("", new TravellerRewardMulti(new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardSkill(),
                                new TravellerRewardItem(new List<TravellerItem>
                                {
                                    TravellerItemStoreService.GetItemStatic("")
                                })
                            })),
                            ("", new TravellerRewardSkill(FreeForm)),
                            ("", new TravellerRewardSkill(FreeForm)),
                            ("", new TravellerRewardSkill(FreeForm)),
                            ("", new TravellerRewardSkill(FreeForm)),
                            ("", new TravellerRewardSkill(FreeForm))
                        }),

                    new(
                        "",
                        "",
                        new TravellerAttributeCheck(),
                        new TravellerAttributeCheck(),
                        new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry(),
                            GetSkillTableEntry()
                        },
                        new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("", new TravellerRewardMulti(new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardSkill(),
                                new TravellerRewardItem(new List<TravellerItem>
                                {
                                    TravellerItemStoreService.GetItemStatic("")
                                })
                            })),
                            ("", new TravellerRewardSkill()),
                            ("", new TravellerRewardSkill()),
                            ("", new TravellerRewardSkill()),
                            ("", new TravellerRewardSkill()),
                            ("", new TravellerRewardSkill())
                        })
                },
                personalDevelopmentSkillList: new List<TravellerSkillTableEntry>
                {
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
                    GetSkillTableEntry()
                },
                serviceSkillsList: new List<TravellerSkillTableEntry>
                {
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
                    GetSkillTableEntry(),
                    GetSkillTableEntry()
                }, musteringOutBenefits: new List<(int Cash, TravellerCharacterCreationReward Benefit)>
                {
                    (, new TravellerRewardItem(new List<TravellerItem>
                    {
                        TravellerItemStoreService.GetItemStatic("")
                    })),
                    (,
                        new TravellerRewardOther(
                            "")),
                    (, new TravellerRewardOther("")),
                    (, new TravellerRewardItem(new List<TravellerItem>
                    {
                        TravellerItemStoreService.GetItemStatic("")
                    })),
                    (, new TravellerRewardItem(new List<TravellerItem>
                    {
                        TravellerItemStoreService.GetItemStatic("")
                    })),
                    (, new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                    {
                        { "", TravellerNPCRelationship.Contact },
                        { "", TravellerNPCRelationship.Contact },
                        { "", TravellerNPCRelationship.Contact },
                        { "", TravellerNPCRelationship.Contact },
                        { "", TravellerNPCRelationship.Contact },
                        { "", TravellerNPCRelationship.Contact }
                    })),
                    ( new TravellerRewardAugment())
                },
                events: new List<TravellerEventCharacterCreation>
                {
                    new TravellerEventMishap(
                        "Disaster! Roll on the mishap table, but you are not ejected from the career"),
                    new TravellerEventLife("You have a life event!"),
                },
                mishaps: new List<TravellerEventCharacterCreation>
                {
                    new TravellerEventSeverelyInjured("You are severely injured!"),
                    new TravellerEventInjury("You are injured!")
                }
            );
        }
    }*/
}