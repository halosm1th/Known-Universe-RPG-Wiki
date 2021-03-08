using System;
using System.Collections.Generic;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.CreationEvents;
using static TravellerWiki.Data.Charcters.TravellerAttributes;
using static TravellerWiki.Data.Charcters.TravellerSkills;

namespace TravellerWiki.Data.Services.CareerService.VersianCareeres
{
    class TravellerVersianArmy : TravellerVersianCareers
    {
        public static TravellerCareer VersianArmy()
        {
            var army = new TravellerVersianArmy();

            return  army.GetVersianArmy();
        }
        Random random = new Random();

        public TravellerCareer GetVersianArmy()
        {
            return new TravellerCareer(
                careerName: "Versian Army",
                description: "You fight in an army, either for your lord or one of their knights. ",
                nationality: TravellerNationalities.Fifth_Vers_Empire,
                qualifications: new List<TravellerAttributeCheck>
                {
                    new TravellerAttributeCheck(Strength,8),
                    new TravellerAttributeCheck(Dexterity,8),
                    new TravellerAttributeCheck(Endurance,8),
                },
                assignments: new List<TravellerAssignment>
                {
                    new TravellerAssignment(
                        name: "Footman",
                        description: "The sad people who have to open the door, check the rooms, and get shot. Someone has to be the grunts, and that's these guys.",
                        survival: new TravellerAttributeCheck(Endurance,9),
                        advancement: new TravellerAttributeCheck(Dexterity,6),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Recon),
                            GetSkillTableEntry(HeavyWeapons),
                            GetSkillTableEntry(Drive_HoverCraft),
                            GetSkillTableEntry(GunCombat_Slug),
                            GetSkillTableEntry(VaccSuit),
                            GetSkillTableEntry(Melee_Blade),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Infantryman", new TravellerRewardSkill(GunCombat_Slug)),
                            ("Corporal", new TravellerRewardSkill(Melee_Blade)),
                            ("Sargent", new TravellerRewardSkill(Recon)),
                            ("Lieutenant", new TravellerRewardSkill(Stealth)),
                            ("Captain", new TravellerRewardSkill(Tactics_Military)),
                            ("Commander", new TravellerRewardSkill(Leadership)),
                        }),
                    
                    new TravellerAssignment(
                        name: "Strongman",
                        description: "exo-Skeletons or light mech suits allow the Strongmen to carry powerful heavy weapons with ease, and act as heavy support troopers at the upper ranks.",
                        survival: new TravellerAttributeCheck(Endurance,8),
                        advancement: new TravellerAttributeCheck(Strength,6),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Drive_Walker),
                            GetSkillTableEntry(GunCombat_Slug),
                            GetSkillTableEntry(Electronics),
                            GetSkillTableEntry(Gunner),
                            GetSkillTableEntry(Mechanic),
                            GetSkillTableEntry(VaccSuit),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Infantryman", new TravellerRewardSkill(GunCombat_Slug)),
                            ("Corporal", new TravellerRewardSkill(Melee_Blade)),
                            ("Sargent", new TravellerRewardSkill(Recon)),
                            ("Lieutenant", new TravellerRewardSkill(Stealth)),
                            ("Captain", new TravellerRewardSkill(Tactics_Military)),
                            ("Commander", new TravellerRewardSkill(Leadership)),
                        }),

                    new TravellerAssignment(
                        name: "Supplyman",
                        description: "Supplymen, as the name suggests, bring the supplies to the front line. They also drive the tanks and transports for the Army, and provide other forms of mechanized support.",
                        survival: new TravellerAttributeCheck(Endurance,7),
                        advancement: new TravellerAttributeCheck(Intelligence,8),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Drive),
                            GetSkillTableEntry(Gunner),
                            GetSkillTableEntry(Mechanic),
                            GetSkillTableEntry(Flyer),
                            GetSkillTableEntry(Engineer),
                            GetSkillTableEntry(Navigation),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Infantryman", new TravellerRewardSkill(GunCombat_Slug)),
                            ("Corporal", new TravellerRewardSkill(Melee_Blade)),
                            ("Sargent", new TravellerRewardSkill(Recon)),
                            ("Lieutenant", new TravellerRewardSkill(Stealth)),
                            ("Captain", new TravellerRewardSkill(Tactics_Military)),
                            ("Commander", new TravellerRewardSkill(Leadership)),
                        }),

                },
                personalDevelopmentSkillList: new List<TravellerSkillTableEntry>
                {
                    GetSkillTableEntry(Strength),
                    GetSkillTableEntry(Melee),
                    GetSkillTableEntry(Dexterity),
                    GetSkillTableEntry(Medic),
                    GetSkillTableEntry(Endurance),
                    GetSkillTableEntry(Gambler),
                },
                serviceSkillsList: new List<TravellerSkillTableEntry>
                {
                    GetSkillTableEntry(GunCombat_Slug),
                    GetSkillTableEntry(Drive),
                    GetSkillTableEntry(Melee_Blade),
                    GetSkillTableEntry(VaccSuit),
                    GetSkillTableEntry(Recon),
                    GetSkillTableEntry(HeavyWeapons),
                }, musteringOutBenefits: new List<(int Cash, TravellerCharacterCreationReward Benefit)>
                {
                    (2000, new TravellerRewardCombatImplant()), 
                    (5000, new TravellerRewardAttribute(Endurance)),
                    (10000, new TravellerRewardWeapon()),
                    (10000, new TravellerRewardAttribute(Education)),
                    (15000, new TravellerRewardArmour()),
                    (15000, new TravellerRewardCombatImplant()),
                    (15000, new TravellerRewardAttribute(Social)),
                },
                events: new List<TravellerEventCharacterCreation>
                {
                    new TravellerEventMishap("Disaster! Roll on the mishap table, but you are not ejected from the career"),
                    new TravellerEventSkillCheck("You are part of a large scale siege which goes poorly. Trapped on the ground without support, make a check to survive.",
                        yesEvent:new TravellerEventReward("You sneak into the starport and get off the planet",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardSkillChoice(1,new List<TravellerSkills>
                                {
                                    Stealth,Deception,GunCombat_Slug
                                })
                            }), 
                        noEvent:new TravellerEventChangeCareers("You failed to get into the starport, you are captured and taken prisoner.","Versian Prisoner"), 
                        skillChecks:new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(Stealth,8),
                            new TravellerSkillCheck(Deception,8),
                            new TravellerSkillCheck(GunCombat_Slug,8)
                        }),

                    new TravellerEventSkillCheck("You are tasked to join in a black ops mission. Make a Stealth Check",
                        yesEvent:new TravellerEventReward("You are stealthy, the mission goes as planned.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardSkill(Stealth,1),
                                new TravellerRewardBonusBenefit(1)
                            }),
                        noEvent:new TravellerEventReward("You fail to be stealthy and everyone but one other is killed, the sole survivor blames you.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardContact("Black Ops Survivor",TravellerNPCRelationship.Rival)
                            }),
                        skillChecks:new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(Stealth,8),
                        }),

                    new TravellerEventSkillCheck("The planet you are currently on has come under siege and you are called to assist in its defense.",
                        yesEvent:new TravellerEventReward("You are instrumental in pushing the enemies back!",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardAdvancement(2),
                                new TravellerRewardSkillChoice(1, new List<TravellerSkills>
                                {
                                    GunCombat_Slug,Gunner
                                })
                            }), 
                        noEvent:new TravellerEventText("The battle is lost, and after surendering you are transfered to a new lord."), 
                        new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(GunCombat_Slug,1),
                            new TravellerSkillCheck(Gunner,2),
                        }),

                    new TravellerEventChoice("You discover some of your squad mates are gambling and you are invited to join",
                        yesText:"You join the gambling!",
                        yesEvent:new TravellerEventSkillCheck("Joining in the gambling, you take your turn",
                            yesEvent:new TravellerEventReward("You make some winnings gambling!",
                                new List<TravellerCharacterCreationReward>
                                {
                                    new TravellerRewardBonusBenefit(random.Next(1,7)),
                                    new TravellerRewardSkill(Gambler)
                                }), 
                            noEvent:new TravellerEventReward("You fail to make any winnings gambling.",
                                new List<TravellerCharacterCreationReward>
                                {
                                    new TravellerRewardBonusBenefit(random.Next(1,4))
                                }),
                            skillChecks:new List<TravellerSkillCheck>{new TravellerSkillCheck(Gambler,8)}), 
                        noText:"I won't gamble",
                        noEvent:new TravellerEventText("You don't gamble this turn, keeping your benefits for yourself.")),
                    
                    new TravellerEventLife("You have a life event!"),
                    
                    new TravellerEventSkillCheck("While on patrol, you come under fire from an unknown area.",
                        yesEvent:new TravellerEventSkillChoiceReward("You hold your ground against the ambush",new List<TravellerSkills>
                        {
                            GunCombat_Slug,Gunner
                        }), 
                        noEvent:new TravellerEventInjury("You are caught and wounded in the crossjob!"), 
                        skillChecks:new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(Gunner,8),
                            new TravellerSkillCheck(GunCombat_Slug,8)
                        }),

                    new TravellerEventAttributeCheck("One of your supperior officers takes an interest in your career",
                        successText:"You impress the officer",
                        successEvent:new TravellerEventReward("The officer helps you with your work",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardAdvancement(2)
                            }),
                        failText:"The officer decides to take an interest in someone else",
                        failEvent:new TravellerEventReward("You spend the term doing extra work, which pays off in other ways",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardBonusBenefit(1)
                            }),
                        attributeChecks:new List<TravellerAttributeCheck>
                        {
                            new TravellerAttributeCheck(Social,6)
                        }),

                    new TravellerEventSkillCheck("You join your Knight in their siege of another world, you join in the battle.",
                        yesEvent:new TravellerEventReward("You are able to shine in battle, impressing your knight.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardSkillChoice(1,new List<TravellerSkills>
                                {
                                    Gunner,
                                    GunCombat_Slug
                                }),
                                new TravellerRewardAdvancement(2)
                            }), 
                        noEvent:new TravellerEventText("You do nothing of note during the battle."), 
                        skillChecks:new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(GunCombat_Slug,8),
                            new TravellerSkillCheck(Gunner,8)
                        }),
                    
                    new TravellerEventChoice("You discover some of your fellow soldiers have been taking their vehicles out for ‘joyrides’ during their downtime, and invite you along.",
                        yesText:"You join them",
                        yesEvent:new TravellerEventReward("You join them in their joyriding",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardSkillChoice(1,new List<TravellerSkills>
                                {
                                    Drive,Flyer,Seafarer
                                }),
                                new TravellerRewardContact("Military Joyrider",TravellerNPCRelationship.Contact)
                            }), 
                        noText:"You report them.",
                        noEvent:new TravellerEventReward("You decline to join them, reporting them to your superior earning you their anger.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardContact("Military Joyrider",TravellerNPCRelationship.Enemy),
                                new TravellerRewardAdvancement(1)
                            })),
                    
                    new TravellerEventReward("There is no war this term, instead you spend it simply waiting at the starport.", new List<TravellerCharacterCreationReward>
                    {
                        new TravellerRewardSkillChoice(1,new List<TravellerSkills>
                        {
                            Gambler,Carouse,Language,Broker
                        })
                    }),
                },
                mishaps: new List<TravellerEventCharacterCreation>
                {
                    new TravellerEventSeverelyInjured("You are severely injured!"),
                    new TravellerEventReward("You are publicly dishonoured, and for your failure you lose your title as a member of the militorius, demoted back to the Civis",
                        new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardBonusBenefit(-1)
                        }),
                    new TravellerEventSkillCheck("Your Knight embarks on a suicide mission to impress someone further up the chain, and takes his army with him.",
                        yesEvent:new TravellerEventReward("you are able to survive the bloody slaughter,  but you are relieved from your service in your knights army.",new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardBonusBenefit(1)
                        }),
                        noEvent:new TravellerEventInjury("You are wounded in combat"), new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(GunCombat,8)
                        }),
                    new TravellerEventChangeCareers("You Encounter a psychopath in the army, and during battle they ask you to help them with an ambush. After success in the ambush, you go to investigate the corpses of your newly fallen foes, and discover to your horror that they are Versians as well. You are blamed for the issue. Change careers to Versian Prisoner for your crimes.","Versian Prisoner"),
                    new TravellerEventText("You are chosen for a black ops mission, the job goes south and everyone else is killed. You are left abandoned on a hostile world with no support."),
                    new TravellerEventInjury("You are injured!"),
                }
            );
        }
    }
}