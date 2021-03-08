using System;
using System.Collections.Generic;
using System.ComponentModel;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.CreationEvents;
using TravellerWiki.Data.Services.CareerService.PolandskianCareeres;
using TravellerWiki.Data.Services.CareerService.VersianCareeres;
using static TravellerWiki.Data.Charcters.TravellerAttributes;
using static TravellerWiki.Data.Charcters.TravellerSkills;

namespace TravellerWiki.Data.Services.CareerService.PolandskianCareeres
{
    class TravellerPolandskiaPirate : TravellerPolandskianCareers
    {
        public static TravellerCareer PolandskiaPirate()
        {
            var pirate = new TravellerPolandskiaPirate();

            return pirate.GetPolandskiaPirate();
        }
        Random random = new Random();

        public TravellerCareer GetPolandskiaPirate()
        {
            return new TravellerCareer(
                careerName: "Polandskia Pirate",
                description: "Within the peoples union, it is hard to find work, those who still own ships need a way to feed their crew, and better they eat then you.",
                nationality:TravellerNationalities.Polandskia_Peoples_Union,
                qualifications: new List<TravellerAttributeCheck>
                {
                    new TravellerAttributeCheck(Strength,6),
                },
                assignments: new List<TravellerAssignment>
                {
                    new TravellerAssignment(
                        name: "Pillager",
                        description: "You head down to the planets within the Union to raid and pillage for supplies",
                        survival: new TravellerAttributeCheck(Dexterity,4),
                        advancement: new TravellerAttributeCheck(Strength,8),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(GunCombat_Archaic),
                            GetSkillTableEntry(Survival),
                            GetSkillTableEntry(Persuade),
                            GetSkillTableEntry(Navigation),
                            GetSkillTableEntry(Recon),
                            GetSkillTableEntry(Melee),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Stick Sharpener", new TravellerRewardSkill(Melee)),
                            ("Stick User", new TravellerRewardSkill(Streetwise)),
                            ("People Watcher", new TravellerRewardSkill(Recon)),
                            ("Gun Getter", new TravellerRewardSkill(GunCombat_Archaic)),
                            ("Group Leader", new TravellerRewardSkill(Tactics_Military)),
                            ("Raid Master", new TravellerRewardSkill(Leadership)),
                        }),

                    new TravellerAssignment(
                        name: "Border",
                        description: "You board the other ships within the Union to steal their supplies and crew",
                        survival: new TravellerAttributeCheck(Dexterity,6),
                        advancement: new TravellerAttributeCheck(Endurance,8),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Melee),
                            GetSkillTableEntry(GunCombat_Archaic),
                            GetSkillTableEntry(Deception),
                            GetSkillTableEntry(Gambler),
                            GetSkillTableEntry(Medic),
                            GetSkillTableEntry(Recon),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Stabber", new TravellerRewardSkill(Melee_Bludgeon)),
                            ("Sr. Stabber", new TravellerRewardSkill(Melee_Blade)),
                            ("Gunny", new TravellerRewardSkill(GunCombat_Archaic)),
                            ("Sr. Gunny", new TravellerRewardSkill(HeavyWeapons)),
                            ("Tellguy", new TravellerRewardSkill(Tactics_Military)),
                            ("Bossman", new TravellerRewardSkill(Leadership)),
                        }),

                    new TravellerAssignment(
                        name: "Privateer",
                        description: "You work with one or more of the major governments from outside the union taking on pirate actions for it in secret.",
                        survival: new TravellerAttributeCheck(Education,5),
                        advancement: new TravellerAttributeCheck(Social,10),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Tactics),
                            GetSkillTableEntry(Language),
                            GetSkillTableEntry(Diplomat),
                            GetSkillTableEntry(Advocate),
                            GetSkillTableEntry(Pilot),
                            GetSkillTableEntry(Astrogation),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Shipboy", new TravellerRewardSkill(Engineer)),
                            ("Shipman", new TravellerRewardSkill(Pilot)),
                            ("Runner", new TravellerRewardSkill(Astrogation)),
                            ("Gunner", new TravellerRewardSkill(Gunner)),
                            ("Teller", new TravellerRewardSkill(Tactics_Naval)),
                            ("Cap-E-tan", new TravellerRewardSkill(Leadership)),
                        }),

                },
                personalDevelopmentSkillList: new List<TravellerSkillTableEntry>
                {
                    GetSkillTableEntry(Strength),
                    GetSkillTableEntry(GunCombat_Archaic),
                    GetSkillTableEntry(Dexterity),
                    GetSkillTableEntry(Melee),
                    GetSkillTableEntry(Endurance),
                    GetSkillTableEntry(Pilot),
                },
                serviceSkillsList: new List<TravellerSkillTableEntry>
                {
                    GetSkillTableEntry(Tactics),
                    GetSkillTableEntry(Navigation),
                    GetSkillTableEntry(Survival),
                    GetSkillTableEntry(Streetwise),
                    GetSkillTableEntry(Engineer),
                    GetSkillTableEntry(Mechanic),
                }, musteringOutBenefits: new List<(int Cash, TravellerCharacterCreationReward Benefit)>
                {
                    (5, new TravellerRewardtem(new List<TravellerItem>
                    {
                        new TravellerItem("Fake TAS Membership",500000,1,16)
                    })),
                    (10, new TravellerRewardtem(new List<TravellerItem>
                    {
                        new TravellerItem("TAS Membership",1000000,1,15)
                    })),
                    (100, new TravellerRewardGun()),
                    (250, new TravellerRewardBlade()),
                    (500, new TravellerRewardArmour()),
                    (1000, new TravellerRewardOther($"{random.Next(1,7)} Ship Shares")),
                    (5000, new TravellerRewardOther("A stolen ship")),
                },
                events: new List<TravellerEventCharacterCreation>
                {
                    new TravellerEventMishap("Disaster! Roll on the mishap table, but you are not ejected from the career"),

                    new TravellerEventChoice("During a raid your Bossman tells you to take all the chippers, but you can pocket some for yourself",
                        yesText:"Try and take some",
                        yesEvent:new TravellerEventSkillCheck("You try and toss some credits in your pocket",
                            yesEvent:new TravellerEventReward("You are able to hide some of the credits, and convince the Bossman that another in your group took them.", new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardBenefitIncrease(2),
                                new TravellerRewardContact("Pirate Thrown Under the Bus",TravellerNPCRelationship.Rival)
                            }),
                            noEvent:new TravellerEventReward("The bossman notices you hiding the credits and decides you're not getting paid for this term.", new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardBonusBenefit(-1)
                            }),
                            skillChecks:new List<TravellerSkillCheck>
                            {
                                new TravellerSkillCheck(Deception,6),

                            }),
                        noText:"Put them where they belong.",
                        noEvent:new TravellerEventText("You put all the credits in their proper place.")),

                    new TravellerEventChoice("You can spend your off time this term gambling with your fellow Pirates.",
                        yesText:"Yeah I'll gamble some credits",
                        yesEvent:new TravellerEventSkillCheck("You agree to some gambling, and sit down to play your hand.",
                            yesEvent:new TravellerEventReward("You are victorious! You capture the credits of your fellow pirates with ease.", new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardBonusBenefit(random.Next(1,6))
                            }),
                            noEvent:new TravellerEventReward("Alas, you cannot win every, or in this case, any hand.", new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardBonusBenefit(-random.Next(1,4))
                            }),
                            skillChecks:new List<TravellerSkillCheck>
                            {
                                new TravellerSkillCheck(Gambler,8),

                            }),
                        noText:"I shall keep what is mine!",
                        noEvent:new TravellerEventText("You watch as several of your fellow pirates are quickly stripped of their credits.")),

                    new TravellerEventChoice("During a raid you come across a stash of Statues of Sigmar, do you wish to steal them?",
                        yesText:"Toss em in the sack.",
                        yesEvent:new TravellerEventAttributeCheck("As you're throwing them into your sack, you feel a mystical feeling overcome you.",
                            successText:"You feel the voice of Sigmar echo in your head, as your mind rids itself of fog you didn't realize you had. There is now some strong light gently guiding you it feels",
                            successEvent:new TravellerEventReward("You have been blessed by Sigmar, choose two of his powers to be bestowed upon you",
                                new List<TravellerCharacterCreationReward>
                                {
                                    new TravellerRewardSkillChoice(2,new List<TravellerSkills>
                                    {
                                        SigmarsFreeze,
                                        SigmarsAid,
                                        SigmarsAir,
                                        SigmarsFlame,
                                        SigmarsGuidance,
                                        SigmarsHand,
                                        SigmarsWater,
                                        SigmarsKnowledge,
                                        SigmarsLight
                                    })
                                }),
                            failText:"A few weeks after the raid is over you see your picture circulating as a Denounced heritic of Sigmar",
                            failEvent:new TravellerEventReward("The church has denounced you and assigned some inquisitors to your case",
                                new List<TravellerCharacterCreationReward>
                                {
                                    new TravellerRewardContact("Inquisitor 1",TravellerNPCRelationship.Enemy),
                                    new TravellerRewardContact("Inquisitor 2",TravellerNPCRelationship.Enemy),
                                }), 
                            attributeChecks: new List<TravellerAttributeCheck>
                            {
                                new TravellerAttributeCheck(Psionics,8)
                            }
                            ), 
                        noText:"I'll leave 'em in place. Better to not piss off a God.",
                        noEvent:new TravellerEventText("You leave the statues where they are.")),

                    new TravellerEventSkillCheck("The loot from your last haul wasn’t as good as the Bossman promised, and now the people are looking for someone to take charge, you try and step up to take command",
                        yesEvent:new TravellerEventReward("You stand out among the offers",new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardAdvancement(8)
                        }), 
                        noEvent: new TravellerEventSeverelyInjured("You fail, and the bossman beats you harshly for your actions."), 
                        skillChecks:new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(Leadership,8),
                        }),

                    new TravellerEventLife("You have a life event!"),

                    new TravellerEventReward("You spend the term raiding small time ships in the outer regions.", 
                        new List<TravellerCharacterCreationReward>{new TravellerRewardBonusBenefit()}),

                    new TravellerEventSkillCheck("One of your fellow raiders has been making your life a living hell. You decided to settle this matter in the proper way, violence.",
                        yesEvent:new TravellerEventReward("You beat some sense into them, earning their respect.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardContact("Beaten Pirate",TravellerNPCRelationship.Rival),
                                new TravellerRewardContact(new Dictionary<string,TravellerNPCRelationship>
                                {
                                    {"Impressed Pirate 1", TravellerNPCRelationship.Contact},
                                    {"Impressed Pirate 2", TravellerNPCRelationship.Contact},
                                    {"Impressed Pirate 3", TravellerNPCRelationship.Contact},
                                    {"Impressed Pirate 4", TravellerNPCRelationship.Contact},
                                })
                            }), 
                        noEvent:new TravellerEventReward("The pirates beat some sense into you, and decided to do it more often.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardContact("Leader Pirate",TravellerNPCRelationship.Rival),
                                new TravellerRewardContact(new Dictionary<string,TravellerNPCRelationship>
                                {
                                    {"Asshole Pirate 1", TravellerNPCRelationship.Enemy},
                                    {"Asshole Pirate 2", TravellerNPCRelationship.Enemy},
                                    {"Asshole Pirate 3", TravellerNPCRelationship.Enemy },
                                })
                            }),
                        skillChecks:new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(GunCombat_Archaic,8),
                            new TravellerSkillCheck(Melee,8)
                        }),

                    new TravellerEventSkillCheck("You spend the term illegally raiding Detuschland towns along the neutral zone, roll to see if you get caught.",
                        yesEvent:new TravellerEventReward("You are able to get away with your raids, earning you great money.", new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardCredits(random.Next(1,7)*1000)
                        }),
                        noEvent: new TravellerEventReward("The Communists and their church put a bounty on your head.", new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardOther($"There is a {random.Next(1,7)*1000} bounty on your head for your crimes"),
                            new TravellerRewardContact("Bounty hunter after reward",TravellerNPCRelationship.Enemy)
                        }),
                        skillChecks:new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(Stealth,8)
                        }
                        ),

                    new TravellerEventReward("You spend the term working with your groups weapons-master, sharpening spears and producing ammunition.",new List<TravellerCharacterCreationReward>
                    {
                        new TravellerRewardSkill(Mechanic,1)
                    }),

                    new TravellerEventChoice("During a raid, a family thrusts their child onto you, and beg you to take care of it.",
                        yesText:"You agree to take it.",
                        yesEvent:new TravellerEventReward("You agree to take the wee child and raise it, treating it on as one of your own.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardContact("Pirate Child",TravellerNPCRelationship.Ally)
                            }), 
                        noText:"You take the child, and place it into your bag for later.",
                        noEvent:new TravellerEventReward("After the battle, you and your fellows sit down for a hearty meal, using the meat from your bag.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardAttribute(Endurance,1)
                            })),
                },
                mishaps: new List<TravellerEventCharacterCreation>
                {
                    new TravellerEventSeverelyInjured("You are severely injured!"),
                    new TravellerEventReward("Your target fends you off, for your failure you lose your position among the crew, but are allowed to keep your loot.",
                        new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardBonusBenefit(1)
                        }),
                    new TravellerEventReward("Your ship is attacked by another privateer group, they don’t need anymore hands but agree to drop you off on a planet alive.",
                        new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardBonusBenefit(random.Next(1,4))
                        }),
                    new TravellerEventInjury("A raid goes to the Nether fast, and you’re hit, the people take care of you."),
                    new TravellerEventText("You are stopped by the ‘authorities’ and are arrested, but are able to bribe your way out of it. Your crew has left you behind."),
                    new TravellerEventInjury("You are injured!"),
                }
            );
        }
    }
}