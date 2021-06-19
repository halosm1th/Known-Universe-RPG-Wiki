using System;
using System.Collections.Generic;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.CreationEvents;
using TravellerWiki.Data.Services.CareerService.PolandskianCareeres;
using TravellerWiki.Data.Services.CareerService.VersianCareeres;
using static TravellerWiki.Data.Charcters.TravellerAttributes;
using static TravellerWiki.Data.Charcters.TravellerSkills;

namespace TravellerWiki.Data.Services.CareerService.NationsCareeres
{
    class TravellerVersianFreeMan : TravellerVersianCareers
    {
        public static TravellerCareer VesianFreeMan()
        {
            var career = new TravellerVersianFreeMan();

            return career.GetVesianFreeMan();
        }
        Random random = new Random();

        public TravellerCareer GetVesianFreeMan()
        {
            return new TravellerCareer(
       careerName: "Versian Free Man",
       description: "You are bound (directly) to no lord, no person above you, and no net to catch you if you fall. You pursue the arts and the expansion of your mind, to educate and entertain others.",
       nationality: TravellerNationalities.Fifth_Vers_Empire,
       qualifications: new List<TravellerAttributeCheck>
       {
                    new TravellerAttributeCheck(Social,8),                
                    new TravellerAttributeCheck(Intelligence,6),
                    new TravellerAttributeCheck(Education,10),
       },
       assignments: new List<TravellerAssignment>
       {
                    new TravellerAssignment(
                        name: "Composer",
                        description: "You compose great music for whoever's court happens to be in at the moment.",
                        survival: new TravellerAttributeCheck(Intelligence,6),
                        advancement: new TravellerAttributeCheck(Dexterity,8),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Art_Instrument),
                            GetSkillTableEntry(Persuade),
                            GetSkillTableEntry(Art_Instrument),
                            GetSkillTableEntry(Language),
                            GetSkillTableEntry(Electronics_Computers),
                            GetSkillTableEntry(Art),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Nobody", new TravellerRewardSkill(Art_Instrument)),
                            ("Online Publisher", new TravellerRewardAttribute(Education)),
                            ("Cult Following", new TravellerRewardAttribute(Dexterity)),
                            ("Dedicated Subculture", new TravellerRewardEmpty()),
                            ("Mainstream", new TravellerRewardSkill(Persuade)),
                            ("Famous", new TravellerRewardAttribute(Social)),
                        }),

                    new TravellerAssignment(
                        name: "Writer",
                        description: "You write the great epics of the History of the people of Vers. It may be the story of the noble whose house you’re sleeping in at the moment, or the story of their most unspoken for servant.",
                        survival: new TravellerAttributeCheck(Education,8),
                        advancement: new TravellerAttributeCheck(Social,6),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Art_Write),
                            GetSkillTableEntry(Streetwise),
                            GetSkillTableEntry(Art),
                            GetSkillTableEntry(Social),
                            GetSkillTableEntry(Advocate),
                            GetSkillTableEntry(Investigate),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Nobody", new TravellerRewardSkill(Art_Write)),
                            ("Online Publisher", new TravellerRewardAttribute(Education)),
                            ("Cult Following", new TravellerRewardAttribute(Intelligence)),
                            ("Dedicated Subculture", new TravellerRewardEmpty()),
                            ("Mainstream", new TravellerRewardSkill(Persuade)),
                            ("Famous", new TravellerRewardAttribute(Social)),
                        }),

                    new TravellerAssignment(
                        name: "Performer",
                        description: "You perform the great works produced, bringing the emotional performances to life with your acting, playing with the viewers heart strings as though they were cords on your instrument.",
                        survival: new TravellerAttributeCheck(Social,10),
                        advancement: new TravellerAttributeCheck(Intelligence,6),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Art),
                            GetSkillTableEntry(Carouse),
                            GetSkillTableEntry(Persuade),
                            GetSkillTableEntry(Steward),
                            GetSkillTableEntry(Art_Preformer),
                            GetSkillTableEntry(Social),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Nobody", new TravellerRewardSkill(Art_Instrument)),
                            ("Online Publisher", new TravellerRewardAttribute(Education)),
                            ("Cult Following", new TravellerRewardAttribute(Dexterity)),
                            ("Dedicated Subculture", new TravellerRewardEmpty()),
                            ("Mainstream", new TravellerRewardSkill(Persuade)),
                            ("Famous", new TravellerRewardAttribute(Social)),
                        }),

       },
       
       personalDevelopmentSkillList: new List<TravellerSkillTableEntry>
       {
                    GetSkillTableEntry(Social),
                    GetSkillTableEntry(Carouse),
                    GetSkillTableEntry(Streetwise),
                    GetSkillTableEntry(Art),
                    GetSkillTableEntry(Intelligence),
                    GetSkillTableEntry(Gambler),
       },
       
       serviceSkillsList: new List<TravellerSkillTableEntry>
       {
                    GetSkillTableEntry(Art),
                    GetSkillTableEntry(Deception),
                    GetSkillTableEntry(Persuade),
                    GetSkillTableEntry(Carouse),
                    GetSkillTableEntry(Art),
                    GetSkillTableEntry(Art),
       }, 
       
       musteringOutBenefits: new List<(int Cash, TravellerCharacterCreationReward Benefit)>
       {
                    (500, new TravellerRewardAttribute(Social)),
                    (1000, new TravellerRewardAttribute(Education)),
                    (2500, new TravellerRewardAttribute(Social)),
                    (2500, new TravellerRewardAttribute(Education)),
                    (5000, new TravellerRewardAttribute(Intelligence)),
                    (10000, new TravellerRewardItem(TravellerItemStoreService.GetItemStatic("2 Ship Shares"))),
                    (20000, new TravellerRewardAttribute(Social)),
       },

       mishaps: new List<TravellerEventCharacterCreation>
       {
           new TravellerEventSeverelyInjured("You are severely injured!"),
           
           new TravellerEventChangeCareers("The noble whose court you’re at decides your talents could be better spent solving the wonders of science, not society.",
               "Versian Idea Creator"),
           
           new TravellerEventChangeCareers("You are caught with the child of a major Aristocratic, in order to hide you, they smuggle you off world.",
               "Versian Production Worker"),
           
           new TravellerEventChangeCareers("You just can’t cut it.",
               "Versian Civis"),
           
           new TravellerEventReward("Your art impresses someone of importance high up and they decide to knight you.",
               new List<TravellerCharacterCreationReward>
               {
                   new TravellerRewardContact("Noble who knighted you",TravellerNPCRelationship.Friend),
                   new TravellerRewardJobChange("Versian Knight")
               }),
           
           new TravellerEventInjury("You are injured!"),
       },

       events: new List<TravellerEventCharacterCreation>
       {
                    new TravellerEventMishap("Disaster! Roll on the mishap table, but you are not ejected from the career"),
                    new TravellerEventRewardContact("Your best friend steals one of your pieces and tries to sell it as their own.",
                        "Ex-Friend who stole work of art",TravellerNPCRelationship.Rival),

                    new TravellerEventSkillCheck("Your masterpiece is stolen! You spend the term in the criminal underworld tracking it down.",
                        yesEvent:new TravellerEventReward("You are able to track the piece down, gaining some allies along the way, but angering someone further up the chain.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardBonusBenefit(1),
                                new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                                {
                                    {"Person who stole art work #1",TravellerNPCRelationship.Enemy },
                                    {"Person who stole art work #2",TravellerNPCRelationship.Enemy },
                                    {"Person who stole art work #3",TravellerNPCRelationship.Enemy },
                                })
                            }), 
                        noEvent:new TravellerEventReward("You are unable to track the piece down.",
                            new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardSkillChoice(1, new List<TravellerSkills>
                                {
                                    Streetwise,Deception,Stealth,Investigate
                                }),
                                new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                                {
                                    {"Person who stole art work #1",TravellerNPCRelationship.Enemy },
                                    {"Person who stole art work #2",TravellerNPCRelationship.Enemy },
                                    {"Person who stole art work #3",TravellerNPCRelationship.Enemy },
                                })
                            }),
                        skillChecks: new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(Streetwise,8),
                            new TravellerSkillCheck(Deception,8),
                            new TravellerSkillCheck(Stealth,8),
                            new TravellerSkillCheck(Investigate,8),
                        }),

                    new TravellerEventChangeCareers("An Aristocratic becomes so interested in your life and you that he pulls you into his society.",
                        "Versian Aristocractic"),

                    new TravellerEventReward("You gain a patron of the arts.",
                        new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardAdvancement(2),
                            new TravellerRewardContact("Patron of the arts",TravellerNPCRelationship.Contact)
                        }),

                    new TravellerEventLife("You have a life event!"),

                    new TravellerEventReward("The person you hired to distribute your works have been illegally reselling them and taking the bonus profits for themselves.",
                        new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardBonusBenefit(-1),
                            new TravellerRewardContact("Art thief",TravellerNPCRelationship.Enemy)
                        }),

                    new TravellerEventChoice("You have the chance to release something that could end a promising young noble's career. Do you?",
                        yesEvent:new TravellerEventSkillCheck("Check to see just how well of a critique you can make.",
                            
                            yesEvent:new TravellerEventReward("Your work ends the nobles career, making them your enemy", 
                                new List<TravellerCharacterCreationReward>
                                {
                                    new TravellerRewardContact("Noble whos career you ended",TravellerNPCRelationship.Enemy),
                                    new TravellerRewardAdvancement(5),
                                    new TravellerRewardSkill(Art),
                                    new TravellerRewardSkill(Art_Instrument),
                                    new TravellerRewardSkill(Art_Holography),
                                    new TravellerRewardSkill(Art_Preformer),
                                    new TravellerRewardSkill(Art_Write),
                                    new TravellerRewardSkill(Art_VisualMedia),
                                }), 

                            noEvent:new TravellerEventChangeCareers("Your work goes unnoticed, but you are arrested.",
                                "Versian Prisoner"), 
                            skillChecks: new List<TravellerSkillCheck>
                            {
                                new TravellerSkillCheck(Art,8),
                                new TravellerSkillCheck(Art_Instrument,8),
                                new TravellerSkillCheck(Art_VisualMedia,8),
                                new TravellerSkillCheck(Art_Holography,8),
                                new TravellerSkillCheck(Art_Preformer,8),
                                new TravellerSkillCheck(Art_Write,8),
                            }), 

                        noEvent:new TravellerEventChoice("The noble instead comes to you and asks if you would write a piece in support of them, do you?",
                            yesEvent:new TravellerEventSkillCheck("See how good of a piece you produce.",
                                yesEvent:new TravellerEventText("Your art is passable to the noble, and goes unnoticed."), 
                                noEvent: new TravellerEventReward("Your art is mocked sector wide for as clear propaganda.",
                                    new TravellerRewardAdvancement(-2)),
                                skillChecks:new List<TravellerSkillCheck>
                                {

                                    new TravellerSkillCheck(Art,6),
                                    new TravellerSkillCheck(Art_Instrument,6),
                                    new TravellerSkillCheck(Art_VisualMedia,6),
                                    new TravellerSkillCheck(Art_Holography,6),
                                    new TravellerSkillCheck(Art_Preformer,6),
                                    new TravellerSkillCheck(Art_Write,6),
                                }), 
                            noEvent:new TravellerEventReward("The Noble sets out to ruin your career.", new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardAdvancement(-5),
                                new TravellerRewardContact("Noble who wants to ruin your career",TravellerNPCRelationship.Rival)
                            }))),

                    new TravellerEventReward("You hit it big and get a smash hit across your Masters Sovereignty, you spend the term on touring, visiting all the important nobles courts to impress them.",
                        new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                            {
                                {"1st Noble whose court you visited",TravellerNPCRelationship.Contact },
                                {"3nd Noble whose court you visited",TravellerNPCRelationship.Contact },
                                {"3rd Noble whose court you visited",TravellerNPCRelationship.Contact },
                                {"4th Noble whose court you visited",TravellerNPCRelationship.Contact },
                                {"5th Noble whose court you visited",TravellerNPCRelationship.Contact },
                                {"6th Noble whose court you visited",TravellerNPCRelationship.Contact },
                            }),
                            new TravellerRewardAdvancement(4),
                            new TravellerRewardSkill(new List<TravellerSkills>
                            {
                                Deception,
                                Carouse,
                                Diplomat,
                                Steward,
                                Persuade,
                            })
                        }),

                    new TravellerEventSkillCheck("You spend the term out on the town.",
                        yesEvent:new TravellerEventReward("Your name becomes a legend among the common folk and those in the scene.", new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardBonusBenefit(2),
                            new TravellerRewardAdvancement(2)
                        }), 
                        noEvent:new TravellerEventReward("You spend the term drinking and stumbling into obscurity.", new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardBonusBenefit(-1),
                            new TravellerRewardAdvancement(-2)
                        }),
                        skillChecks: new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(Carouse,6),
                            new TravellerSkillCheck(Gambler,6)
                        }),

                    new TravellerEventReward("You become a celebrity on your homeworld, a fan club forms around you and its leader introduces themself to you.", new List<TravellerCharacterCreationReward>
                    {
                        new TravellerRewardSkillChoice(1,
                        new List<TravellerSkills>
                            {
                                Carouse,
                                Persuade,
                                Steward,
                                Diplomat,
                            }),
                        new TravellerRewardContact("Homeworld fanclub head",TravellerNPCRelationship.Contact)
                    }),
       }
   );
        }
    }
}