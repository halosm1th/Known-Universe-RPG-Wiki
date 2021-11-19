using System;
using System.Collections.Generic;
using TravellerCharacter.Character_Services.NPC_Services;
using TravellerCharacter.CharacterCreator;
using TravellerCharacter.CharacterCreator.Careers;
using TravellerCharacter.CharacterCreator.Careers.Character_Creation_Reward;
using TravellerCharacter.CharacterCreator.Careers.SkillEntry;
using TravellerCharacter.CharacterCreator.CreationEvents;
using TravellerCharacter.CharacterParts;
using TravellerCharacter.CharcterTypes;
using static TravellerCharacter.CharacterParts.TravellerSkills;
using static TravellerCharacter.CharacterParts.TravellerAttributes;

namespace TravellerCharacter.Character_Services.Career_Service.Versian_Careers
{
    class TravellerVersianAristocractic : TravellerVersianCareers
    {
        public static TravellerCareer AristocracticCareer()
        {
            var career = new TravellerVersianAristocractic();

            return career.GetNationCareer();
        }
        Random random = new Random();

        public TravellerCareer GetNationCareer()
        {
            return new TravellerCareer(
       //Aristocractic
       //Aristocractic
       careerName: "Versian Aristocractic",
       description: "You are one of the minor nobles within the Vers empire. You own land, a space station or asteroid or some other bit of land, enough to be of note, but not enough to hold a proper title.",
       nationality: TravellerNationalities.Fifth_Vers_Empire,
       qualifications: new List<TravellerAttributeCheck>
       {
                    new TravellerAttributeCheck(Social,14),
       },
       assignments: new List<TravellerAssignment>
       {
                    new TravellerAssignment(
                        name: "Patron",
                        description: "You are a patron of the arts and science within the empire. With your great wealth you help to bring about some kind of new innovation to your knight or their people.",
                        survival: new TravellerAttributeCheck(Education,8),
                        advancement: new TravellerAttributeCheck(Social,12),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Art),
                            GetSkillTableEntry(Education),
                            GetSkillTableEntry(Broker),
                            GetSkillTableEntry(Leadership),
                            GetSkillTableEntry(Profession),
                            GetSkillTableEntry(Science),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Gentle(man|woman)", new TravellerRewardSkill(Diplomat)),
                            ("Dvoryanin", new TravellerRewardSkill(Science)),
                            ("Pomeshchiki", new TravellerRewardSkill(Broker)),
                            ("Esquire", new TravellerRewardAttribute(Education)),
                            ("Patrician", new TravellerRewardAttribute(Social,2)),
                            ("Seigneur", new TravellerRewardOther("Versian Lordship")),
                        }),

                    new TravellerAssignment(
                        name: "Involved Noble",
                        description: "A true born noble, your whole life is about the nobility. Playing court politics, and commanding your fief. Your title is your life.",
                        survival: new TravellerAttributeCheck(Intelligence,8),
                        advancement: new TravellerAttributeCheck(Social,12),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Carouse),
                            GetSkillTableEntry(Diplomat),
                            GetSkillTableEntry(Advocate),
                            GetSkillTableEntry(Persuade),
                            GetSkillTableEntry(Deception),
                            GetSkillTableEntry(Investigate),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Gentle(man|woman)", new TravellerRewardSkill(Admin)),
                            ("Dvoryanin", new TravellerRewardSkill(Advocate)),
                            ("Pomeshchiki", new TravellerRewardSkill(Language)),
                            ("Esquire", new TravellerRewardSkill(Leadership)),
                            ("Patrician", new TravellerRewardAttribute(Social,2)),
                            ("Seigneur", new TravellerRewardOther("Versian Lordship")),
                        }),

                    new TravellerAssignment(
                        name: "Absentee Noble",
                        description: "Your lands... exist. Someone far away tends to them while you enjoy the fruits of those lands. You spend your time with other Nobles, wining and dining and enjoying life to the fullest extent.",
                        survival: new TravellerAttributeCheck(Endurance,4),
                        advancement: new TravellerAttributeCheck(Social,12),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Carouse),
                            GetSkillTableEntry(Drive),
                            GetSkillTableEntry(Flyer),
                            GetSkillTableEntry(Deception),
                            GetSkillTableEntry(Seafarer),
                            GetSkillTableEntry(JackLuck),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Gentle(man|woman)", new TravellerRewardSkill(Carouse)),
                            ("Dvoryanin", new TravellerRewardSkill(Deception)),
                            ("Pomeshchiki", new TravellerRewardSkill(Diplomat)),
                            ("Esquire", new TravellerRewardSkill(Persuade)),
                            ("Patrician", new TravellerRewardAttribute(Social,2)),
                            ("Seigneur", new TravellerRewardOther("Versian Lordship")),
                        }),

       },
       personalDevelopmentSkillList: new List<TravellerSkillTableEntry>
       {
                    GetSkillTableEntry(Social),
                    GetSkillTableEntry(JackLuck),
                    GetSkillTableEntry(Education),
                    GetSkillTableEntry(Streetwise),
                    GetSkillTableEntry(Intelligence),
                    GetSkillTableEntry(Language),
       },
       serviceSkillsList: new List<TravellerSkillTableEntry>
       {
                    GetSkillTableEntry(Diplomat),
                    GetSkillTableEntry(Language),
                    GetSkillTableEntry(Admin),
                    GetSkillTableEntry(Deception),
                    GetSkillTableEntry(Advocate),
                    GetSkillTableEntry(Carouse),
       }, musteringOutBenefits: new List<(int Cash, TravellerCharacterCreationReward Benefit)>
       {
                    (33333, new TravellerRewardOther("Favour from a knight")),
                    (77777, new TravellerRewardVehicle()),
                    (100965, new TravellerRewardWeapon()),
                    (256732, new TravellerRewardShip()),
                    (403080, new TravellerRewardAugment()),
                    (1005060, new TravellerRewardArmour()),
                    (15000071, new TravellerRewardOther("Favour from a lord")),
       },
       events: new List<TravellerEventCharacterCreation>
       {
                    new TravellerEventMishap("Disaster! Roll on the mishap table, but you are not ejected from the career"),
                    new TravellerEventChoice("our noble is called to war! You are ‘invited’ to join them. During a major battle, you are given the chance to prove yourself.",
                        yesText:"I'll take the chance to earn glory!",
                        yesEvent:new TravellerEventSkillCheck("You have your moment, try and strike!",
                            yesEvent:new TravellerEventChangeCareers("You kill the enemy, who happened to be essential to the enemies plan. Because of this honour, you are granted the title of Versian Knight.","Versian Knight"), 
                            noEvent:new TravellerEventInjury("You fail in the moment and are wounded"), 
                            skillChecks: new List<TravellerSkillCheck>{ new TravellerSkillCheck(Melee,8),new TravellerSkillCheck(GunCombat,8)}), 
                        noText:"Better safe then sorry",
                        noEvent:new TravellerEventText("You don't take the chance, instead hiding to protect your life.")
                    ),

                    new TravellerEventSkillChoiceReward("You spend the term in the thick of court politics.",new List<TravellerSkills>
                    {
                        Diplomat,Deception,Admin,Advocate
                    }),
                    
                    new TravellerEventSkillChoiceReward("Your noble promotes you to an important position in their inner council for a term.",new List<TravellerSkills>
                    {
                        Electronics,Science,Admin,Advocate,Tactics
                    }),

                    new TravellerEventSkillCheck("Your noble is off to war! You are ‘invited’ along. Fight or hide your way through it.",
                        yesEvent:new TravellerEventReward("you survive the war.",new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardAdvancement(2),
                            new TravellerRewardBenefitIncrease(1),
                            new TravellerRewardSkillChoice(1, new List<TravellerSkills>{GunCombat,Melee,Stealth})
                        }), 
                        noEvent:new TravellerEventSeverelyInjured("You are caught and wounded."), 
                        skillChecks: new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(Melee,8),
                            new TravellerSkillCheck(GunCombat,8),
                            new TravellerSkillCheck(Stealth,8),
                        }),

                    new TravellerEventLife("You have a life event!"),

                    new TravellerEventSkillCheck("You are invited to a feast by your noble",
                        yesEvent:new TravellerEventReward("You are the life of the party!", new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardAdvancement(3),
                            new TravellerRewardBenefitIncrease(1),
                            new TravellerRewardBenefitIncrease(1),
                        }), 
                        noEvent:new TravellerEventReward("You boring and thus sidelined.", new TravellerRewardAttribute(Social,-1)), 
                        skillCheck:new TravellerSkillCheck(Carouse,8)),

                    new TravellerEventReward("You spend the term working on your personal projects and relaxing.",
                        new TravellerRewardSkill(JackLuck)),

                    new TravellerEventAttributeCheck("You spend the term getting closer to your noble",
                        successEvent:new TravellerEventReward("You impress the noble!", new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardContact("Noble Ally",TravellerNPCRelationship.Ally),
                            new TravellerRewardSkill(Leadership),
                            new TravellerRewardAdvancement(2)
                        }), 
                        failEvent:new TravellerEventReward("You anger others at court", 
                            new TravellerRewardContact("Court Rival",TravellerNPCRelationship.Rival)), 
                        attributeCheck:new TravellerAttributeCheck(Social,6)),

                    new TravellerEventChoice("A group of your fellow Aristrocratics invite you into a conspiracy.",
                        yesText:"I'd Love to join!",
                        yesEvent:new TravellerEventSkillCheck("You are accepted into the conspiracy, now though, you must face your fellow nobles.",
                            yesEvent:new TravellerEventMishap("The conspiracy falls apart."), 
                            noEvent:new TravellerEventReward("The plot thickens",new TravellerRewardSkillChoice(1,new List<TravellerSkills>
                            {
                                Deception,Persuade
                            })), 
                            skillChecks: new List<TravellerSkillCheck>
                            {
                                new TravellerSkillCheck(Deception,8),
                                new TravellerSkillCheck(Persuade,8),
                            }), 
                        noText:"I'll Decline",
                        noEvent: new TravellerEventReward("The Conspirators swear you as one of her enemies.", 
                            new TravellerRewardContact("Aristrocratic conspirator",TravellerNPCRelationship.Enemy))),

                    new TravellerEventSkillCheck("Your Noble has fallen ill, and they have chosen you to be their physician.",
                        yesEvent:new TravellerEventReward("You succeed in saving the nobles life! You are rewarded greatly for it",new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardCredits(100000),
                            new TravellerRewardSkill(Medic),
                            new TravellerRewardAdvancement(6)
                        }), 
                        noEvent:new TravellerEventFailout("You are banished from the court and branded a noble killer."), 
                        skillCheck:new TravellerSkillCheck(Medic,8)),
       },

       mishaps: new List<TravellerEventCharacterCreation>
       {
                    new TravellerEventSeverelyInjured("You are severely injured!"),

                    new TravellerEventText("Your noble is killed and an outsider takes the title, throwing you out from the court."),

                    new TravellerEventText("You anger the noble whose court you’re a part of and are expelled for it."),

                    new TravellerEventReward("A rising member in the court throws you under the bus for some failure that is not your fault.",new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                    {
                        {"Court Noble 1",TravellerNPCRelationship.Enemy},
                        { "Court Noble 2",TravellerNPCRelationship.Enemy},
                        { "Court Noble 3",TravellerNPCRelationship.Enemy},
                    })),

                    new TravellerEventChoice("You are caught engaging in unbecoming affairs with the nobles’ significant other.",
                        yesText:"I'll pay you back for the error!",
                        yesEvent:new TravellerEventReward("The noble agrees that you're mistakes can be repayed with enoug money.",
                            new TravellerRewardDebt(random.Next(1,7)* 10000000)), 
                        noText:"You have it wrong!",
                        noEvent:new TravellerEventChangeCareers("The noble doesn't care about your excuses, and sentances you to prison.","Versian Prisoner")),

                    new TravellerEventInjury("You are injured!"),
       }
   );
        }
    }
}