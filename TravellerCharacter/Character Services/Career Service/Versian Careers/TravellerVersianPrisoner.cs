using System.Collections.Generic;
using TravellerCharacter.Character_Services.NPC_Services;
using TravellerCharacter.CharacterCreator;
using TravellerCharacter.CharacterCreator.Careers;
using TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward;
using TravellerCharacter.CharacterCreator.Careers.SkillEntry;
using TravellerCharacter.CharacterCreator.CreationEvents;
using TravellerCharacter.CharacterParts;
using TravellerCharacter.CharcterTypes;

namespace TravellerCharacter.Character_Services.Career_Service.Versian_Careers
{
    internal class TravellerVersianPrisoner : TravellerVersianCareers
    {
        public static TravellerCareer VersianPrisoner()
        {
            return new TravellerCareer(
                "Versian Prisoner",
                "You are a prisoner within the Vers empire. Whatever your crime, your life now consists of hard labour and serving your lord and whatever happens to be on his mind today.",
                TravellerNationalities.Fifth_Vers_Empire,
                new List<TravellerAttributeCheck>
                {
                    new(TravellerAttributes.Strength, 2),
                    new(TravellerAttributes.Dexterity, 2),
                    new(TravellerAttributes.Endurance, 2)
                },
                new List<TravellerAssignment>
                {
                    new(
                        "Military Prisoner",
                        "You committed crimes while in the military, or while you were part of the Militorius class",
                        new TravellerAttributeCheck(TravellerAttributes.Dexterity, 6),
                        new TravellerAttributeCheck(TravellerAttributes.Education, 10),
                        new List<TravellerSkillTableEntry>
                        {
                            new TravellerSkillTableEntrySkill(TravellerSkills.Athletics_Dexterity),
                            new TravellerSkillTableEntrySkill(TravellerSkills.GunCombat_Slug),
                            new TravellerSkillTableEntrySkill(TravellerSkills.Athletics_Strength),
                            new TravellerSkillTableEntrySkill(TravellerSkills.Melee_Unarmed),
                            new TravellerSkillTableEntrySkill(TravellerSkills.Deception),
                            new TravellerSkillTableEntrySkill(TravellerSkills.Melee_Bludgeon)
                        },
                        new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("New Guy", new TravellerRewardSkill(TravellerSkills.Recon)),
                            ("Thug", new TravellerRewardSkill(TravellerSkills.Melee_Unarmed)),
                            ("Proper Member", new TravellerRewardSkill(TravellerSkills.Melee_Unarmed)),
                            ("Inner Circle", new TravellerRewardSkill(TravellerSkills.Persuade)),
                            ("Right Hand", new TravellerRewardSkill(TravellerSkills.Tactics_Military)),
                            ("Boss", new TravellerRewardSkill(TravellerSkills.Leadership))
                        }),

                    new(
                        "Work Prisoner",
                        "You are a normal prisoner, sentenced to labour till death or end of punishment cycle.",
                        new TravellerAttributeCheck(TravellerAttributes.Strength, 6),
                        new TravellerAttributeCheck(TravellerAttributes.Intelligence, 10),
                        new List<TravellerSkillTableEntry>
                        {
                            new TravellerSkillTableEntrySkill(TravellerSkills.Profession),
                            new TravellerSkillTableEntrySkill(TravellerSkills.Athletics),
                            new TravellerSkillTableEntrySkill(TravellerSkills.Admin),
                            new TravellerSkillTableEntryAttribute(TravellerAttributes.Education),
                            new TravellerSkillTableEntrySkill(TravellerSkills.Steward),
                            new TravellerSkillTableEntrySkill(TravellerSkills.Electronics)
                        },
                        new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("New Guy", new TravellerRewardSkill(TravellerSkills.Recon)),
                            ("Thug", new TravellerRewardSkill(TravellerSkills.Investigate)),
                            ("Proper Member", new TravellerRewardSkill(TravellerSkills.Stealth)),
                            ("Inner Circle", new TravellerRewardSkill(TravellerSkills.Persuade)),
                            ("Right Hand", new TravellerRewardSkill(TravellerSkills.Carouse)),
                            ("Boss", new TravellerRewardSkill(TravellerSkills.Leadership, 2))
                        }),

                    new(
                        "Political Prisoner",
                        "You have been arrested for some political misstep, but you’re still valuable to be kept alive for your political knowledge.",
                        new TravellerAttributeCheck(TravellerAttributes.Social, 8),
                        new TravellerAttributeCheck(TravellerAttributes.Social, 10),
                        new List<TravellerSkillTableEntry>
                        {
                            new TravellerSkillTableEntrySkill(TravellerSkills.Persuade),
                            new TravellerSkillTableEntrySkill(TravellerSkills.Diplomat),
                            new TravellerSkillTableEntrySkill(TravellerSkills.Deception),
                            new TravellerSkillTableEntrySkill(TravellerSkills.Carouse),
                            new TravellerSkillTableEntrySkill(TravellerSkills.Stealth),
                            new TravellerSkillTableEntrySkill(TravellerSkills.Investigate)
                        },
                        new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Know Nothing", new TravellerRewardSkill(TravellerSkills.Investigate)),
                            ("Baby Snitch", new TravellerRewardSkill(TravellerSkills.Persuade)),
                            ("Snitch", new TravellerRewardSkill(TravellerSkills.Broker)),
                            ("Master Snitch", new TravellerRewardSkill(TravellerSkills.Leadership, 1)),
                            ("Knowledge Holder", new TravellerRewardEmpty()),
                            ("Webmaster", new TravellerRewardSkill(TravellerSkills.Deception, 3))
                        })
                },
                new List<(int Cash, TravellerCharacterCreationReward Benefit)>
                {
                    (5, new TravellerRewardContact("Prison Friend", TravellerNPCRelationship.Contact)),
                    (10, new TravellerRewardWeapon()),
                    (100,
                        new TravellerRewardSkillChoice(1,
                            new List<TravellerSkills> { TravellerSkills.Stealth, TravellerSkills.Leadership })),
                    (200,
                        new TravellerRewardSkillChoice(1,
                            new List<TravellerSkills> { TravellerSkills.Deception, TravellerSkills.Diplomat })),
                    (500,
                        new TravellerRewardSkillChoice(1,
                            new List<TravellerSkills> { TravellerSkills.GunCombat, TravellerSkills.Melee })),
                    (1000,
                        new TravellerRewardSkillChoice(1,
                            new List<TravellerSkills> { TravellerSkills.Science, TravellerSkills.Profession })),
                    (2500, new TravellerRewardSkill(TravellerSkills.JackLuck))
                },
                new List<TravellerSkillTableEntry>
                {
                    new TravellerSkillTableEntryAttribute(TravellerAttributes.Strength),
                    new TravellerSkillTableEntrySkill(TravellerSkills.Athletics),
                    new TravellerSkillTableEntrySkill(TravellerSkills.Profession),
                    new TravellerSkillTableEntryAttribute(TravellerAttributes.Education),
                    new TravellerSkillTableEntryAttribute(TravellerAttributes.Intelligence),
                    new TravellerSkillTableEntryAttribute(TravellerAttributes.Dexterity)
                },
                new List<TravellerSkillTableEntry>
                {
                    new TravellerSkillTableEntrySkill(TravellerSkills.Melee_Unarmed),
                    new TravellerSkillTableEntrySkill(TravellerSkills.Gambler),
                    new TravellerSkillTableEntrySkill(TravellerSkills.Broker),
                    new TravellerSkillTableEntrySkill(TravellerSkills.JackLuck),
                    new TravellerSkillTableEntrySkill(TravellerSkills.Stealth),
                    new TravellerSkillTableEntrySkill(TravellerSkills.Melee_Blade)
                },
                new List<TravellerEventCharacterCreation>
                {
                    new TravellerEventMishap(
                        "Disaster! Roll on the mishap table, but you are not ejected from the career"),
                    new TravellerEventText("You spend the term keeping your head down and not getting into any shit."),
                    new TravellerEventSkillCheck(
                        "You are accused of stealing while on work detail. Make a check to avoid getting locked in solitary confinement.",
                        new TravellerEventText("You avoid being locked in solitary confinement."),
                        new TravellerEventReward("You are locked in solitary confinement, driven a little more mad.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardAttribute(TravellerAttributes.Intelligence, -1)
                            }), new List<TravellerSkillCheck>
                        {
                            new(TravellerSkills.Deception, 8),
                            new(TravellerSkills.Persuade, 8)
                        }),
                    new TravellerEventAttributeCheck(
                        "The Knight who owns your prison has returned from a bender which has resulted in a shortfall of cash. To solve this issue, your prison has been sold to another knight. Your new keeper has come for an inspection, giving you a possible chance to show off.",
                        successText: "You succeed in impressing your new master",
                        successEvent: new TravellerEventReward(
                            "Because you impressed your new master you gain an extra benefit.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardBonusBenefit()
                            }),
                        failText: "You fail to impress your new master, allowing others to advance more quickly.",
                        failEvent: new TravellerEventReward(
                            "You fail to impress your new master, allowing others to advance more quickly.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardAdvancement(-1)
                            }),
                        attributeChecks: new List<TravellerAttributeCheck>
                        {
                            new(TravellerAttributes.Social, 10)
                        }
                    ),
                    new TravellerEventChoice(
                        "You are transfered to another prison, during the transfer, the ship is attacked and you are given a chance to join the pirates, do you?",
                        yesText: "Yes",
                        yesEvent: new TravellerEventSkillCheck(
                            "Stepping into the fray, you are tossed a melee weapon and told to help.",
                            new TravellerEventReward("Having helped the pirates, you are kindly forced to join them",
                                new List<TravellerCharacterCreationReward>
                                {
                                    new TravellerRewardJobChange("Polandskia Pirate"),
                                    new TravellerRewardSkill(TravellerSkills.Melee)
                                }),
                            new TravellerEventInjury("The pirates are stopped and you are hurt in the fighting."),
                            new List<TravellerSkillCheck>
                            {
                                new(TravellerSkills.Melee, 8)
                            }),
                        noText: "No",
                        noEvent: new TravellerEventText(
                            "You stay in your cell as the pirates are quickly put down by security forces.")),
                    new TravellerEventLife("You have a life event!"),
                    new TravellerEventReward("You spend the term getting to know your cellmates",
                        new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardContact("Cellmate 1", TravellerNPCRelationship.Ally),
                            new TravellerRewardContact("Cellmate 2", TravellerNPCRelationship.Contact),
                            new TravellerRewardContact("Cellmate 3", TravellerNPCRelationship.Rival)
                        }),
                    new TravellerEventReward(
                        "You spend the term working in either the library or administration offices.",
                        new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardSkillChoice(1, new List<TravellerSkills>
                            {
                                TravellerSkills.Admin, TravellerSkills.Science
                            })
                        }),
                    new TravellerEventChangeCareerWithAssignment(
                        "You are drafted by your knight into military service.", "Versian Army", "Footman"),
                    new TravellerEventChoice("A riot breaks out.",
                        yesText: "I join the riot",
                        yesEvent: new TravellerEventSkillCheck("Joining into the wild violence, you attack the guards!",
                            new TravellerEventReward(
                                "You are able to fight for your freedom!",
                                new List<TravellerCharacterCreationReward>
                                {
                                    new TravellerRewardJobChange("Versian Free Man")
                                }),
                            new TravellerEventMishap("You fail in the riot, suffer a mishap."),
                            new List<TravellerSkillCheck>
                            {
                                new(TravellerSkills.Melee, 8)
                            }
                        ),
                        noText: "I keep my head down in my cell",
                        noEvent: new TravellerEventText(
                            "You keep your head down in your cell. Sparing yourself from harm.")
                    ),
                    new TravellerEventSkillCheck("You dragged into a territory dispute between two rivaling gangs.",
                        new TravellerEventReward("You are on the winning side of the dispute.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardContact("Gang Member", TravellerNPCRelationship.Ally),
                                new TravellerRewardSkill(TravellerSkills.Melee)
                            }),
                        new TravellerEventInjury("You are on the losing side and beat soundly for it."),
                        new List<TravellerSkillCheck>
                        {
                            new(TravellerSkills.Melee, 8)
                        }
                    )
                },
                new List<TravellerEventCharacterCreation>
                {
                    new TravellerEventSeverelyInjured("You are severely injured!"),
                    new TravellerEventReward("Made a deal with the wrong person, someone snitched, etc.",
                        new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardBenefitIncrease(-2),
                            new TravellerRewardContact("Prison snitch", TravellerNPCRelationship.Enemy),
                            new TravellerRewardJobChange("Versian Prisoner")
                        }),
                    new TravellerEventChangeCareers("Word of your crime reaches your homeworld, possibly your family.",
                        "Versian Prisoner"),
                    new TravellerEventReward("A guard has taken a particular liking to ensuring your sufffering.",
                        new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardContact("Prison Guard", TravellerNPCRelationship.Enemy),
                            new TravellerRewardJobChange("Versian Prisoner")
                        }),
                    new TravellerEventChoice(
                        "You make friends with the wrong person, when they're accused of doing something wrong, you're dragged in with them.",
                        yesText: "Sell out your friend, keep a benefit roll for this term, but gain a rival",
                        yesEvent: new TravellerEventReward("You sell your friend out. They are beat thoroughly.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardContact("Prison 'Friend'", TravellerNPCRelationship.Rival),
                                new TravellerRewardBonusBenefit(),
                                new TravellerRewardJobChange("Versian Prisoner")
                            }),
                        noText: "Refuse to sell your friend out, gaining them as a contact.",
                        noEvent: new TravellerEventReward("You keep your friend, gaining them as an ally",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardContact("Prison Friend", TravellerNPCRelationship.Ally),
                                new TravellerRewardJobChange("Versian Prisoner")
                            })
                    ),
                    new TravellerEventInjury("You are injured!")
                }
            );
        }
    }
}