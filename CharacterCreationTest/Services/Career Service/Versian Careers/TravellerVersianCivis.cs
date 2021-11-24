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
    class TravellerVersianCivis : TravellerVersianCareers
    {
        public static TravellerCareer VersianCivis()
        {
            var career = new TravellerVersianCivis();

            return career.GetNationCareer();
        }
        Random random = new Random();

        public TravellerCareer GetNationCareer()
        {
            return new TravellerCareer(
       careerName: "Versian Civis",
       description: "The normal people within the Versian Empire. Those who make up the majority of the population, but also have the least overall rights, political power, etc. For many within the Civis class, life is a dull experience of working, spending time with friends, and perhaps pursuing some passions in your off hours. It is a calm and peaceful life for the most part.",
       nationality: TravellerNationalities.Fifth_Vers_Empire,
       qualifications: new List<TravellerAttributeCheck>
       {
                    new TravellerAttributeCheck(Education,6),
                    new TravellerAttributeCheck(Intelligence,6),
                    new TravellerAttributeCheck(Social,6),
       },
       assignments: new List<TravellerAssignment>
       {
                    new TravellerAssignment(
                        name: "Officer Worker",
                        description: "You work in an office, your days are long, but your work keeps the whole system flowing, even if you don’t fully understand exactly what it is that you actually do.",
                        survival: new TravellerAttributeCheck(Education,4),
                        advancement: new TravellerAttributeCheck(Social,6),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Electronics),
                            GetSkillTableEntry(Admin),
                            GetSkillTableEntry(Profession),
                            GetSkillTableEntry(Language),
                            GetSkillTableEntry(Diplomat),
                            GetSkillTableEntry(Gambler),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Intern", new TravellerRewardSkill(Profession)),
                            ("Drone", new TravellerRewardSkill(Stealth)),
                            ("Assistant to the Manager", new TravellerRewardSkill(Investigate)),
                            ("Assistant Manager", new TravellerRewardSkill(Persuade)),
                            ("Jr. Manager", new TravellerRewardAttribute(Social)),
                            ("Sr. Manager", new TravellerRewardSkill(Deception)),
                        }),

                    new TravellerAssignment(
                        name: "Business Starter",
                        description: "You are the starter of small businesses. You create value where none has been found yet. You socialize with people to gather funds and are able to work out the right kinds of deals for your goods.",
                        survival: new TravellerAttributeCheck(Intelligence,8),
                        advancement: new TravellerAttributeCheck(Social,8),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Broker),
                            GetSkillTableEntry(Carouse),
                            GetSkillTableEntry(Steward),
                            GetSkillTableEntry(Persuade),
                            GetSkillTableEntry(Profession),
                            GetSkillTableEntry(Advocate),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("MBA", new TravellerRewardSkill(Broker, 1)),
                            ("Jr. Executive", new TravellerRewardSkill(Admin, 1)),
                            ("Sr. Executive", new TravellerRewardSkill(Electronics_Computers)),
                            ("Vice-President of _", new TravellerRewardSkill(Advocate)),
                            ("CEO", new TravellerRewardSkill(Carouse)),
                            ("Chairman of the Board", new TravellerRewardSkill(Deception,2 )),
                        }),

                    new TravellerAssignment(
                        name: "Ship Owner",
                        description: "You own a ship. You are the backbone of the Universal economy. You pickup supplies from one planet and drop it off at another, hopefully securing a bit of a profit along the way.",
                        survival: new TravellerAttributeCheck(Dexterity,6),
                        advancement: new TravellerAttributeCheck(Intelligence,8),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Pilot_SmallCraft),
                            GetSkillTableEntry(Engineer),
                            GetSkillTableEntry(Astrogation),
                            GetSkillTableEntry(Mechanic),
                            GetSkillTableEntry(Pilot_SmallCraft),
                            GetSkillTableEntry(VaccSuit),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("New Owner", new TravellerRewardSkill(VaccSuit)),
                            ("Hobbyist Trader", new TravellerRewardSkill(Pilot_Spacecraft)),
                            ("Experienced Trader", new TravellerRewardSkill(Engineer_JDrive)),
                            ("Captain", new TravellerRewardSkill(Astrogation)),
                            ("Multi-Ship Captain", new TravellerRewardSkill(Engineer_MDrive)),
                            ("Fleet Master", new TravellerRewardSkill(Engineer_Power)),
                        }),

       },
       personalDevelopmentSkillList: new List<TravellerSkillTableEntry>
       {
                    GetSkillTableEntry(Education),
                    GetSkillTableEntry(Athletics),
                    GetSkillTableEntry(Gambler),
                    GetSkillTableEntry(Language),
                    GetSkillTableEntry(Profession),
                    GetSkillTableEntry(JackLuck),
       },
       serviceSkillsList: new List<TravellerSkillTableEntry>
       {
                    GetSkillTableEntry(Drive),
                    GetSkillTableEntry(Flyer),
                    GetSkillTableEntry(Seafarer),
                    GetSkillTableEntry(Electronics),
                    GetSkillTableEntry(Science),
                    GetSkillTableEntry(Broker),
       }, musteringOutBenefits: new List<(int Cash, TravellerCharacterCreationReward Benefit)>
       {
                    (100, new TravellerRewardItem(new TravellerItem("TAS Membership",1000000,1,15))),
                    (500, new TravellerRewardAttribute(Social,1)),
                    (1000, new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                    {
                        {"Civis Ally 1", TravellerNPCRelationship.Ally },
                        {"Civis Ally 2", TravellerNPCRelationship.Ally },
                    })),
                    (5000, new TravellerRewardAugment()),
                    (10000, new TravellerRewardItem("5 Ship Share",50000,0,10)),
                    (50000, new TravellerRewardVehicle()),
                    (100000, new TravellerRewardShip()),
       },
       events: new List<TravellerEventCharacterCreation>
       {
                    new TravellerEventMishap("Disaster! Roll on the mishap table, but you are not ejected from the career"),
                    new TravellerEventSkillCheck("You are framed for a crime you (might not have) committed",
                        yesEvent:new TravellerEventReward("You are able to negotiate your way into just paying a fine.",new TravellerRewardDebt(100000)),
                        noEvent:new TravellerEventChangeCareers("You are sent to prison","Versian Prisoner"),
                        skillCheck:new TravellerSkillCheck(Advocate,8)),

                    new TravellerEventReward("Your planet is swept by a wave of patriotism after a visit from your lord during a particularly good year. The high lasts for the term",
                        new TravellerRewardBenefitIncrease(1)),

                    new TravellerEventAttributeCheck("You spend the term pursuing your other hobbies as nothing of note happens.",
                        successEvent:new TravellerEventReward("You peruse your hobbies, improving in the area you're looking at.", 
                            new TravellerRewardSkillAny()),
                        failEvent: new TravellerEventText("You spend the term 'improving your hobbies' by drinking and hanging out with your friends."), 
                        attributeCheck:(Education,6)),

                    new TravellerEventAttributeCheck("Plague sweeps your planet, brought in from a trade ship.",
                        successEvent:new TravellerEventReward("You weather the storm unharmed, and spend the time learning a new skill", 
                            new TravellerRewardSkillAny()), 
                        failEvent:new TravellerEventInjury("The plague takes a toll on you."), 
                        attributeCheck:(Endurance,6)),

                    new TravellerEventLife("You have a life event!"),

                    new TravellerEventAttributeCheck("The local knight has for some reason invited you to their court, to join in a party.",
                        successEvent:new TravellerEventRewardAttribute("You are the talk of the party, everyone seems impressed by you.",new TravellerAttribute(Social,2)),
                        failEvent:new TravellerEventRewardAttribute("You are whispered about the whole party, by the end of it you can tell several nasty rumours will be spread about you.",
                            new TravellerAttribute(Social,-2)),
                        attributeCheck:(Social,8)),

                    new TravellerEventSkillCheck("The politics on your planet this term become very vitriolic, and you can’t seem to avoid discussion about the topic.",
                        yesEvent:new TravellerEventRewardContact("You are able to skate by, keeping your friends.", new List<TravellerRewardContact>
                        {
                            new TravellerRewardContact("Political Friend 1", TravellerNPCRelationship.Contact),
                            new TravellerRewardContact("Political Friend 2", TravellerNPCRelationship.Contact),
                        }), 
                        noEvent:new TravellerEventRewardContact("You are able to piss everyone off, angering your friends.", new List<TravellerRewardContact>
                        {
                            new TravellerRewardContact("Political Friend 1", TravellerNPCRelationship.Enemy),
                            new TravellerRewardContact("Political Friend 2", TravellerNPCRelationship.Enemy),
                        }),
                        skillCheck:(Deception,6)),

                    new TravellerEventChoice("The latest vnet show recently finished with an underwhelming conclusion that has left  fans seriously angered. Do you write to the writers?",
                        yesText:"Of course I let them know how wrong they are!",
                        yesEvent:new TravellerEventSkillCheck("You pen a letter, and with it a draft of how you would have ended the show",
                            yesEvent:new TravellerEventChangeCareerWithAssignment("The producer reads your letter and agrees with it. They invite you to write your own script, which gets greenlit and turned into a series. It's a smash hit and you’re promoted into the network",
                                "Versian Free Man","Writer"), 
                            noEvent:new TravellerEventRewardAttribute("The writer returns a quick witted and harsh reply. You feel like a failure and put down a level.",Education,-1), 
                            skillCheck:(Diplomat,8)),
                        noText:"Naw, I'll just vent on the message boards for a few days.",
                        noEvent:new TravellerEventText("You end up quickly finding a new hit series and falling in love with it, as the previous series quickly falls out of discussion.")),

                    new TravellerEventAttributeCheck("Your planet experiences a dip in trade, hurting the local economy, and you have to prove yourself at work.",
                        successEvent:new TravellerEventReward("You easily show your worth to the company, and rewarded for it when the economy picks up again", new TravellerRewardBonusBenefit()), 
                        failEvent:new TravellerEventReward("You are unable to show your value, and are unforunately let go.", new TravellerRewardBonusBenefit(-1)), 
                        attributeCheck:(Education,6)),

                    new TravellerEventAttributeCheck("War breaks out on your planet, while you are not directly involved in the fighting, your industry is still impacted by this.",
                        successEvent:new TravellerEventReward("The war doesn't impacts your industry, and your job is spared. The war ends up being a born for your industry, earning you some extra cash.",new TravellerRewardBonusBenefit(3)),  
                        failEvent:new TravellerEventReward("The war destroys your industry, your job, and your savings with it. ",new TravellerRewardBonusBenefit(-2)), 
                        attributeChecks:new List<TravellerAttributeCheck>
                        {
                            new TravellerAttributeCheck(Education,4),
                            new TravellerAttributeCheck(Intelligence,8),
                            new TravellerAttributeCheck(Dexterity,6),
                        }),
       },

       mishaps: new List<TravellerEventCharacterCreation>
       {
                    new TravellerEventSeverelyInjured("You are severely injured!"),
                    new TravellerEventChangeCareers("War breaks out on your planet and your Knight drafts you into the army","Versian Army"),
                    new TravellerEventMishap("Through a series of events that are of no fault of your own, your company fails and you lose your job."),
                    new TravellerEventSkillCheck("You are (falsely) accused of a heinous crime.",
                        yesEvent:new TravellerEventText("After finishing character creation you start with A 2D6 million credit bounty on your head."), 
                        noEvent:new TravellerEventChangeCareers("You are taken to prison for your crimes!","Versian Prisoner"), 
                        skillCheck:new TravellerSkillCheck(Stealth,8)),
                    new TravellerEventMishap("You’re made the scapegoat for a simple mistake, the coverup of which was a larger scandal then the mistake itself. As a result you are unable to work in that field anymore."),
                    new TravellerEventInjury("You are injured!"),
       }
   );
        }
    }
}