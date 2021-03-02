using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.CreationEvents;
using static TravellerWiki.Data.Charcters.TravellerAttributes;
using static TravellerWiki.Data.Charcters.TravellerSkills;

namespace TravellerWiki.Data
{
    class TravellerMajorPowerCareers
    {
        public void AddMajorPowerCareers(List<TravellerCareer> careers)
        {
            //TODO uncomment these as they are added and won't crash shit!
            AddVersianCareers(careers);
            //AddFederationCareers(careers);
            //AddDeutschlandCareers(careers);
            //AddTransGalaticEmpireCareers(careers);
            //AddXiaoMingCareers(careers);
        }

        private static void AddVersianCareers(List<TravellerCareer> careers)
        {
            var prisoner = new TravellerCareer(
                careerName: "Versian Prisoner",
                description: "You are a prisoner within the Vers empire. Whatever your crime, your life now consists of hard labour and serving your lord and whatever happens to be on his mind today.",
                nationality: "Fifth Vers Empire",
                qualifications: new List<TravellerAttributeCheck>
                {
                    new TravellerAttributeCheck(Strength,2),
                    new TravellerAttributeCheck(Dexterity,2),
                    new TravellerAttributeCheck(Endurance,2),
                },
                assignments: new List<TravellerAssignment>
                {
                    new TravellerAssignment(
                        name: "Military Prisoner",
                        description: "You committed crimes while in the military, or while you were part of the Militorius class",
                        survival: new TravellerAttributeCheck(Dexterity,6), 
                        advancement: new TravellerAttributeCheck(Education,10),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            new TravellerSkillTableEntrySkill(Athletics_Dexterity),
                            new TravellerSkillTableEntrySkill(GunCombat_Slug),
                            new TravellerSkillTableEntrySkill(Athletics_Strength),
                            new TravellerSkillTableEntrySkill(Melee_Unarmed),
                            new TravellerSkillTableEntrySkill(Deception),
                            new TravellerSkillTableEntrySkill(Melee_Bludgeon)
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("New Guy", new TravellerRewardCharacterCreationSkill(Recon) ),
                            ("Thug", new TravellerRewardCharacterCreationSkill(Melee_Unarmed)),
                            ("Proper Member", new TravellerRewardCharacterCreationSkill(Melee_Unarmed)),
                            ("Inner Circle", new TravellerRewardCharacterCreationSkill(Persuade)),
                            ("Right Hand", new TravellerRewardCharacterCreationSkill(Tactics_Military)),
                            ("Boss", new TravellerRewardCharacterCreationSkill(Leadership))
                        }),

                    new TravellerAssignment(
                        name: "Work Prisoner",
                        description: "You are a normal prisoner, sentenced to labour till death or end of punishment cycle.",
                        survival: new TravellerAttributeCheck(Strength,6),
                        advancement: new TravellerAttributeCheck(Intelligence,10),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            new TravellerSkillTableEntrySkill(Profession),
                            new TravellerSkillTableEntrySkill(Athletics),
                            new TravellerSkillTableEntrySkill(Admin),
                            new TravellerSkillTableEntryAttribute(Education),
                            new TravellerSkillTableEntrySkill(Steward),
                            new TravellerSkillTableEntrySkill(Electronics),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("New Guy", new TravellerRewardCharacterCreationSkill(Recon) ),
                            ("Thug", new TravellerRewardCharacterCreationSkill(Investigate)),
                            ("Proper Member", new TravellerRewardCharacterCreationSkill(Stealth)),
                            ("Inner Circle", new TravellerRewardCharacterCreationSkill(Persuade)),
                            ("Right Hand", new TravellerRewardCharacterCreationSkill(Carouse)),
                            ("Boss", new TravellerRewardCharacterCreationSkill(Leadership,2))
                        }),

                    new TravellerAssignment(
                        name: "Political Prisoner",
                        description: "You have been arrested for some political misstep, but you’re still valuable to be kept alive for your political knowledge.",
                        survival: new TravellerAttributeCheck(Social,8),
                        advancement: new TravellerAttributeCheck(Social,10),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            new TravellerSkillTableEntrySkill(Persuade),
                            new TravellerSkillTableEntrySkill(Diplomat),
                            new TravellerSkillTableEntrySkill(Deception),
                            new TravellerSkillTableEntrySkill(Carouse),
                            new TravellerSkillTableEntrySkill(Stealth),
                            new TravellerSkillTableEntrySkill(Investigate),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Know Nothing", new TravellerRewardCharacterCreationSkill(Investigate)),
                            ("Baby Snitch", new TravellerRewardCharacterCreationSkill(Persuade)),
                            ("Snitch", new TravellerRewardCharacterCreationSkill(Broker)),
                            ("Master Snitch", new TravellerRewardCharacterCreationSkill(Leadership,1)),
                            ("Knowledge Holder", new TravellerRewardEmpty()),
                            ("Webmaster", new TravellerRewardCharacterCreationSkill(Deception,3)),
                        }),
                },
                musteringOutBenefits: new List<(int Cash, TravellerCharacterCreationReward Benefit)>
                {
                    (5, new TravellerRewardContact("Prison Friend",TravellerNPCRelationship.Contact) ),
                    (10, new TravellerRewardWeapon()),
                    (100, new TravellerRewardSkillChoice(1,new List<TravellerSkills>{Stealth,Leadership})),
                    (200, new TravellerRewardSkillChoice(1, new List<TravellerSkills>{Deception,Diplomat})),
                    (500, new TravellerRewardSkillChoice(1, new List<TravellerSkills>{GunCombat,Melee}) ),
                    (1000,new TravellerRewardSkillChoice(1, new List<TravellerSkills>{Science,Profession})),
                    (2500,new TravellerRewardCharacterCreationSkill(JackLuck)),
                },
                personalDevelopmentSkillList: new List<TravellerSkillTableEntry>
                {
                    new TravellerSkillTableEntryAttribute(Strength),
                    new TravellerSkillTableEntrySkill(Athletics),
                    new TravellerSkillTableEntrySkill(Profession),
                    new TravellerSkillTableEntryAttribute(Education),
                    new TravellerSkillTableEntryAttribute(Intelligence),
                    new TravellerSkillTableEntryAttribute(Dexterity),
                },
                serviceSkillsList: new List<TravellerSkillTableEntry>
                {
                    new TravellerSkillTableEntrySkill(Melee_Unarmed),
                    new TravellerSkillTableEntrySkill(Gambler),
                    new TravellerSkillTableEntrySkill(Broker),
                    new TravellerSkillTableEntrySkill(JackLuck),
                    new TravellerSkillTableEntrySkill(Stealth),
                    new TravellerSkillTableEntrySkill(Melee_Blade),
                },
                events: new List<TravellerEventCharacterCreation>
                {
                    new TravellerEventMishap("Disaster! Roll on the mishap table, but you are not ejected from the career"),
                    new TravellerEventText("You spend the term keeping your head down and not getting into any shit."),
                    new TravellerEventSkillCheck("You are accused of stealing while on work detail.",
                        yesEvent:new TravellerEventText("You avoid being locked in solitary confinement."),
                        noEvent:new TravellerEventReward("You are locked in solitary confinement, driven a little more mad.", new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardAttribute(Intelligence,-1)
                        }),new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(Deception,8),
                            new TravellerSkillCheck(Persuade,8)
                        }),
                    new TravellerEventAttributeCheck("The Knight who owns your prison has returned from a bender which has resulted in a shortfall of cash. To solve this issue, your prison has been sold to another knight. Your new keeper has come for an inspection, giving you a possible chance to show off.",
                        successText:"You succeed in impressing your new master, garnering more benefits.",
                        successEvent: new TravellerEventReward("You succeed in impressing your new master, garnering more benefits.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardBonusBenefit(1)
                            }), 
                        failText:"You fail to impress your new master, allowing others to advance more quickly.",
                        failEvent:new TravellerEventReward("You fail to impress your new master, allowing others to advance more quickly.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardCharacterCreationAdvancement(-1)
                            }),
                        atributeChecks: new List<TravellerAttributeCheck>
                        {
                            new TravellerAttributeCheck(Social,10)
                        }
                        ),
                    new TravellerEventChoice("You are transfered to another prison, during the transfer, the ship is attacked and you are given a chance to join the pirates, do you?",
                        yesText:"Yes",
                        yesEvent:new TravellerEventSkillCheck("Stepping into the fray, you are tossed a melee weapon and told to help.",
                            new TravellerEventReward("Having helped the pirates, you are kindly forced to join them", new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardCharacterCreationJobChange("Polandskia Pirate"), 
                                new TravellerRewardCharacterCreationSkill(Melee)
                            }),
                            new TravellerEventInjury("The pirates are stopped and you are hurt in the fighting."),
                            new List<TravellerSkillCheck>
                            {
                                new TravellerSkillCheck(Melee,8)
                            }),
                        noText:"No",
                        noEvent:new TravellerEventText("You stay in your cell as the pirates are quickly put down by security forces.")),
                    new TravellerEventLife("You have a life event!"),
                    new TravellerEventReward("You spend the term getting to know your cellmates",
                        new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardContact("Cellmate 1", TravellerNPCRelationship.Ally),
                            new TravellerRewardContact("Cellmate 2", TravellerNPCRelationship.Contact),
                            new TravellerRewardContact("Cellmate 3", TravellerNPCRelationship.Rival),
                        }),
                    new TravellerEventReward("You spend the term working in either the library or administration offices.",
                        new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardSkillChoice(1,new List<TravellerSkills>
                            {
                                Admin,Science
                            })
                        }),
                    new TravellerEventChangeCareerWithAssignment("You are drafted by your knight into military service.", "Versian Army", "Footman"),
                    new TravellerEventChoice("A riot breaks out.",
                        yesText:"I join the riot",
                        yesEvent:new TravellerEventSkillCheck("Joining into the wild violence, you attack the guards!",
                            yesEvent: new TravellerEventReward(
                                "You are able to fight for your freedom!",
                                new List<TravellerCharacterCreationReward>
                                {
                                    new TravellerRewardCharacterCreationJobChange("Versian Free Man")
                                }),
                            noEvent: new TravellerEventMishap("You fail in the riot, suffer a mishap."), 
                            skillChecks: new List<TravellerSkillCheck>
                            {
                                new TravellerSkillCheck(Melee,8)
                            }
                        ),
                        noText:"I keep my head down in my cell",
                        noEvent:new TravellerEventText("You keep your head down in your cell. Sparing yourself from harm.")
                        ),
                    new TravellerEventSkillCheck("You dragged into a territory dispute between two rivaling gangs.",
                        yesEvent:new TravellerEventReward("You are on the winning side of the dispute.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardContact("Gang Member",TravellerNPCRelationship.Ally),
                                new TravellerRewardCharacterCreationSkill(Melee)
                            }), 
                        noEvent:new TravellerEventInjury("You are on the losing side and beat soundly for it."), 
                        skillChecks: new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(Melee,8)
                        }
                    ),
                },
                mishaps: new List<TravellerEventCharacterCreation>
                {
                    new TravellerEventSeverelyInjured("You are severely injured!"),
                    new TravellerEventReward("Made a deal with the wrong person, someone snitched, etc.",
                        new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardCharacterCreationBenefitIncrease(-2),
                            new TravellerRewardContact("Prison snitch",TravellerNPCRelationship.Enemy)
                        }),
                    new TravellerEventText("Word of your crime reaches your homeworld, possibly your family."),
                    new TravellerEventReward("A guard has taken a particular liking to ensuring your sufffering.",
                        new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardContact("Prison Guard", TravellerNPCRelationship.Enemy)
                        }),
                    new TravellerEventChoice(
                        eventText:"You make friends with the wrong person, when they're accused of doing something wrong, you're dragged in with them.",
                        yesText:"Sell out your friend, keep a benefit roll for this term, but gain a rival",
                        yesEvent: new TravellerEventReward("You sell your friend out. They are beat thoroughly.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardContact("Prison 'Friend'",TravellerNPCRelationship.Rival),
                                new TravellerRewardBonusBenefit(1)
                            }),
                        noText:"Refuse to sell your friend out, gaining them as a contact.",
                        noEvent: new TravellerEventReward("You keep your friend, gaining them as an ally", new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardContact("Prison Friend", TravellerNPCRelationship.Ally)
                        })
                    ),
                    new TravellerEventInjury("You are injured!"),
                }
            );

            careers.Add(prisoner);

        }

        /*
         *The reference career!
            var career = new TravellerCareer(
                careerName: "",
                description: "",
                nationality: "",
                qualifications: new List<TravellerAttributeCheck>
                {
                    new TravellerAttributeCheck()
                },
                assignments: new List<TravellerAssignment>
                {
                    new TravellerAssignment(
                        name: "",
                        description: "",
                        survival: new TravellerAttributeCheck(),
                        advancement: new TravellerAttributeCheck(),
                        skillList: new List<TravellerSkills>
                        {
                            new TravellerSkillTableEntry(),
                            new TravellerSkillTableEntry(),
                            new TravellerSkillTableEntry(),
                            new TravellerSkillTableEntry(),
                            new TravellerSkillTableEntry(),
                            new TravellerSkillTableEntry(),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("", new TravellerCharacterCreationReward()),
                            ("", new TravellerCharacterCreationReward()),
                            ("", new TravellerCharacterCreationReward()),
                            ("", new TravellerCharacterCreationReward()),
                            ("", new TravellerCharacterCreationReward()),
                            ("", new TravellerCharacterCreationReward()),
                        }),

                    new TravellerAssignment(
                        name: "",
                        description: "",
                        survival: new TravellerAttributeCheck(),
                        advancement: new TravellerAttributeCheck(),
                        skillList: new List<TravellerSkills>
                        {
                            new TravellerSkillTableEntry(),
                            new TravellerSkillTableEntry(),
                            new TravellerSkillTableEntry(),
                            new TravellerSkillTableEntry(),
                            new TravellerSkillTableEntry(),
                            new TravellerSkillTableEntry(),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("", new TravellerCharacterCreationReward()),
                            ("", new TravellerCharacterCreationReward()),
                            ("", new TravellerCharacterCreationReward()),
                            ("", new TravellerCharacterCreationReward()),
                            ("", new TravellerCharacterCreationReward()),
                            ("", new TravellerCharacterCreationReward()),
                        }),

                    new TravellerAssignment(
                        name: "",
                        description: "",
                        survival: new TravellerAttributeCheck(),
                        advancement: new TravellerAttributeCheck(),
                        skillList: new List<TravellerSkills>
                        {
                            new TravellerSkillTableEntry(),
                            new TravellerSkillTableEntry(),
                            new TravellerSkillTableEntry(),
                            new TravellerSkillTableEntry(),
                            new TravellerSkillTableEntry(),
                            new TravellerSkillTableEntry(),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("", new TravellerCharacterCreationReward()),
                            ("", new TravellerCharacterCreationReward()),
                            ("", new TravellerCharacterCreationReward()),
                            ("", new TravellerCharacterCreationReward()),
                            ("", new TravellerCharacterCreationReward()),
                            ("", new TravellerCharacterCreationReward()),
                        }),

                },
                musteringOutBenefits: new List<(int Cash, TravellerCharacterCreationReward Benefit)>
                {
                    (, new TravellerCharacterCreationReward()),
                    (, new TravellerCharacterCreationReward()),
                    (, new TravellerCharacterCreationReward()),
                    (, new TravellerCharacterCreationReward()),
                    (, new TravellerCharacterCreationReward()),
                    (, new TravellerCharacterCreationReward()),
                    (, new TravellerCharacterCreationReward()),
                },
                personalDevelopmentSkillList: new List<TravellerSkillTableEntry>
                {
                    new TravellerSkillTableEntry(),
                    new TravellerSkillTableEntry(),
                    new TravellerSkillTableEntry(),
                    new TravellerSkillTableEntry(),
                    new TravellerSkillTableEntry(),
                    new TravellerSkillTableEntry(),
                },
                serviceSkillsList: new List<TravellerSkillTableEntry>
                {
                    new TravellerSkillTableEntry(),
                    new TravellerSkillTableEntry(),
                    new TravellerSkillTableEntry(),
                    new TravellerSkillTableEntry(),
                    new TravellerSkillTableEntry(),
                    new TravellerSkillTableEntry(),
                },
                events: new List<TravellerCharacterCreationEvent>
                {
                    new TravellerMishapEvent("Disaster! Roll on the mishap table, but you are not ejected from the career"),
                    new TravellerCharacterCreationEvent(),
                    new TravellerCharacterCreationEvent(),
                    new TravellerCharacterCreationEvent(),
                    new TravellerCharacterCreationEvent(),
                    new TravellerLifeEvent("You have a life event!"),
                    new TravellerCharacterCreationEvent(),
                    new TravellerCharacterCreationEvent(),
                    new TravellerCharacterCreationEvent(),
                    new TravellerCharacterCreationEvent(),
                    new TravellerCharacterCreationEvent(),
                },
                mishaps: new List<TravellerCharacterCreationEvent>
                {
                    new TravellerSeverelyInjuredEvent("You are severely injured!"),
                    new TravellerCharacterCreationEvent(),
                    new TravellerCharacterCreationEvent(),
                    new TravellerCharacterCreationEvent(),
                    new TravellerCharacterCreationEvent(),
                    new TravellerInjuryEvent("You are injured!"),
                }
            );
         *
         */

        private static void AddFederationCareers(List<TravellerCareer> careers)
        {
        }

        private static void AddDeutschlandCareers(List<TravellerCareer> careers)
        {
        }

        private static void AddTransGalaticEmpireCareers(List<TravellerCareer> careers)
        {
        }

        private static void AddXiaoMingCareers(List<TravellerCareer> careers)
        {
        }

    }
}