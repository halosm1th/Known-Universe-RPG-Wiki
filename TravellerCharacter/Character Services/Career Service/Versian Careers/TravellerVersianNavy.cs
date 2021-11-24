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
using TravellerWiki.Data;
using static TravellerCharacter.CharacterParts.TravellerSkills;
using static TravellerCharacter.CharacterParts.TravellerAttributes;

namespace TravellerCharacter.Character_Services.Career_Service.Versian_Careers
{
    class TravellerVersianNavy : TravellerVersianCareers
    {
        public static TravellerCareer VersianNavy()
        {
            var career = new TravellerVersianNavy();

            return career.GetNationCareer();
        }
        Random random = new Random();

        public TravellerCareer GetNationCareer()
        {
            return new TravellerCareer(
       careerName: "Versian Navy",
       description: "The Versian Navy, the backbone of trade and war in the Empire. From its massive Capital Stellar craft like landing Forts and Castles, to the smaller shuttles and fighters, or the group of officers who go ‘Down’ to planets and stations, the Versian Navy is its own complex beast, oftentimes operating almost outside of the purview of their Lord.",
       nationality: TravellerNationalities.Fifth_Vers_Empire,
       qualifications: new List<TravellerAttributeCheck>
       {
                    new TravellerAttributeCheck(Dexterity,6),
                    new TravellerAttributeCheck(Education,8),
                    new TravellerAttributeCheck(Social,10),
       },
       assignments: new List<TravellerAssignment>
       {
                    new TravellerAssignment(
                        name: "Small Craft Pilot",
                        description: "You pilot the various small craft in the Vers Empire, from shuttles and fighters, to intrasystem transports and battleships. If it lacks FTL, you fly it.",
                        survival: new TravellerAttributeCheck(Dexterity,8),
                        advancement: new TravellerAttributeCheck(Endurance,7),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Pilot_SmallCraft),
                            GetSkillTableEntry(Astrogation),
                            GetSkillTableEntry(Gunner),
                            GetSkillTableEntry(Flyer),
                            GetSkillTableEntry(Dexterity),
                            GetSkillTableEntry(Engineer),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Bey", new TravellerRewardSkill(Pilot)),
                            ("Begum", new TravellerRewardSkill(Pilot)),
                            ("Bruninieks", new TravellerRewardSkill(Gunner)),
                            ("Rytsar", new TravellerRewardSkill(Pilot)),
                            ("Dama", new TravellerRewardSkill(Leadership)),
                            ("Ritter", new TravellerRewardSkill(Tactics_Naval)),
                        }),

                    new TravellerAssignment(
                        name: "Capital Stellarcraft Shipmember",
                        description: "You serve aboard one of the Empires Capita Stellarcraft. The massive vessels originally built around their Aldnoah Drive, now though the term refers to any ship which is capable of FTL travel.",
                        survival: new TravellerAttributeCheck(Education,8),
                        advancement: new TravellerAttributeCheck(Social,10),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Pilot_CapitalShips),
                            GetSkillTableEntry(Education),
                            GetSkillTableEntry(Engineer),
                            GetSkillTableEntry(Social),
                            GetSkillTableEntry(Steward),
                            GetSkillTableEntry(Gunner),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Deckchild", new TravellerRewardSkill(Mechanic)),
                            ("Deckman", new TravellerRewardSkill(Engineer)),
                            ("Freechild", new TravellerRewardSkill(Gunner)),
                            ("Freeman", new TravellerRewardAttribute(Social)),
                            ("Watchild", new TravellerRewardSkill(Leadership)),
                            ("Bridgeman", new TravellerRewardSkill(Pilot_CapitalShips)),
                        }),

                    new TravellerAssignment(
                        name: "Down Officer",
                        description: "You are a member of the Navy, but your role tends to focus more on descending to planets or stations, dealing with on ship issues like boarding parties or trade disputes, managing internal personnel, etc.",
                        survival: new TravellerAttributeCheck(Endurance,6),
                        advancement: new TravellerAttributeCheck(Intelligence,10),
                        skillList: new List<TravellerSkillTableEntry>
                        {
                            GetSkillTableEntry(Pilot_Spacecraft),
                            GetSkillTableEntry(VaccSuit),
                            GetSkillTableEntry(Admin),
                            GetSkillTableEntry(Melee),
                            GetSkillTableEntry(Mechanic),
                            GetSkillTableEntry(GunCombat),
                        },
                        ranksAndBonuses:new List<(string title, TravellerCharacterCreationReward perk)>
                        {
                            ("Deckchild", new TravellerRewardSkill(Melee_Blade)),
                            ("Deckman", new TravellerRewardSkill(GunCombat)),
                            ("Freechild", new TravellerRewardSkill(Recon)),
                            ("Freeman", new TravellerRewardSkill(Survival)),
                            ("Watchild", new TravellerRewardSkill(Tactics_Military)),
                            ("Bridgeman", new TravellerRewardSkill(Leadership)),
                        }),

       },
       personalDevelopmentSkillList: new List<TravellerSkillTableEntry>
       {
                    GetSkillTableEntry(Melee),
                    GetSkillTableEntry(Dexterity),
                    GetSkillTableEntry(Education),
                    GetSkillTableEntry(Social),
                    GetSkillTableEntry(Intelligence),
                    GetSkillTableEntry(Pilot),
       },
       serviceSkillsList: new List<TravellerSkillTableEntry>
       {
                    GetSkillTableEntry(Pilot),
                    GetSkillTableEntry(Engineer),
                    GetSkillTableEntry(Astrogation),
                    GetSkillTableEntry(Tactics_Naval),
                    GetSkillTableEntry(Melee),
                    GetSkillTableEntry(Gunner),
       }, musteringOutBenefits: new List<(int Cash, TravellerCharacterCreationReward Benefit)>
       {
                    (1000, new TravellerRewardWeapon()),
                    (6000, new TravellerRewardShip()),
                    (10000, new TravellerRewardVehicle()),
                    (10000, new TravellerRewardAttribute(Social,1)),
                    (11000, new TravellerRewardContact("Noble",TravellerNPCRelationship.Contact)),
                    (12000, new TravellerRewardItem(TravellerItemStoreService.GetItemStatic("TAS Membership"))),
                    (20000, new TravellerRewardAugment()),
       },
       mishaps: new List<TravellerEventCharacterCreation>
       {
           new TravellerEventSeverelyInjured("Your mishap results in you becoming severely injured!"),

           new TravellerEventChangeCareers("During your time on watch, something goes horribly wrong, and several lives are lost. You are blamed for this, and after being court martialed you are sentenced to prison.","Versian Prisoner"),

           new TravellerEventChangeCareers("The master of the ship you’re on decides the correct action is a ground assault; it goes… poorly. After running out of infantrymen, you’re drafted into the military.","Versian Army"),

           new TravellerEventText("You are caught fraternizing with someone well below your rank and are kicked out for it."),

           new TravellerEventText("You finally have enough of the dickwad who has been tormenting you shipside for years, and decided to flee into the night during your next stop at port."),

           new TravellerEventInjury("Your mishap results in an injury!"),
       },

       events: new List<TravellerEventCharacterCreation>
       {
                    new TravellerEventMishap("Disaster! Roll on the mishap table, but you are not ejected from the career"),

                    new TravellerEventSkillCheck("Your ship was able to disable an enemy in an intense space battle, and you’ve been tagged to be part of a boarding party.",
                        yesEvent: new TravellerEventReward("You are able to capture the enemy prize, and take her to a friendly port, giving you a tidy profit.",new TravellerRewardBonusBenefit(1)),
                        noEvent:new TravellerEventInjury("You failed to capture the enemy prize, and were wounded in the process."),
                        skillChecks: new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(Leadership,8),
                            new TravellerSkillCheck(Melee,8),
                            new TravellerSkillCheck(GunCombat,8),
                        }),

                    new TravellerEventChoice("After weeks of travel across the super-sector, you’ve stopped in a system where the sensors are picking up a strange anomaly on the planet below. The Captain has chosen you to be a part of the landing party. When you arrive on the surface, you find a barren wasteland of gray and brown, save for one green plant",
                        yesText:"Steal the planet",
                        yesEvent:new TravellerEventChoice("ou begin to pull on the small green shrub, your ship mates soon joining in on trying to pull it out to no avail. Do you wish to dig it out with an exo-suit?",
                            yesEvent:new TravellerEventSkillCheck("Do you do the digging, or supervising?",
                                yesEvent:new TravellerEventRewardContact("As you begin to dig around the planet, you soon uncover the reason you were unable to pull it out. It isn’t a plant but a tuft of hair from a sleep giant that was napping on this world. The creature politely asks you to leave, threatening to pull your ship out of orbit if it can not resume its nap. You think it best to do so.", "Alien Plant-Creature", TravellerNPCRelationship.Contact),
                                noEvent:new TravellerEventInjury("The digging seems to be making progress, pulling up mountains of dirt and rock. However, the ground begins to shake, an earthquake coming from nowhere, that wasn’t detected on any instruments takes over the region. As you sprint away towards your shuttle, you watch as the ground behind you where the small green plant once was now rises a massive giant, whom you’d guess could easily reach into orbit. You barely escape to your shuttle and leave the planet before the giant is awake enough to stop you."),
                                skillChecks:new List<TravellerSkillCheck>
                                {
                                    new TravellerSkillCheck(VaccSuit,8),
                                    new TravellerSkillCheck(Leadership,8)
                                }),
                            noEvent:new TravellerEventRewardSkill("The plant stays in the ground, as you choose to instead spend several hours walking around the area, taking samples and readings. Whatever happened here, happened so long ago that it may be lost to history. You return to the ship feeling reinvigorated having had a good away mission.",TravellerSkills.Science_History)),
                        noText:"Leave the planet in its place",
                        noEvent:new TravellerEventRewardSkill("You spent several hours walking around the area, taking samples and readings. Whatever happened here, happened so long ago that it may be lost to history. You return to the ship feeling reinvigorated having had a good away mission.",TravellerSkills.Science_History)),

                    new TravellerEventChoice("You have a chance to cause your shipboard tormentor an ‘accident’, do you take it?",
                        yesEvent: new TravellerEventReward("", new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardAttribute(Social,-1),
                            new TravellerRewardContact("Tormentor who suffered an accident",TravellerNPCRelationship.Enemy)
                        }),
                        noEvent:new TravellerEventReward("", new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardAttribute(Intelligence,-1),
                            new TravellerRewardContact("Shipboard Rival",TravellerNPCRelationship.Rival)
                        })),

                    new TravellerEventMultiChoice(" A new era of colonization has been called forth by the Empress in the Collosius, your lord has dispatched your ship to investigate new systems for them to claim. As your ship crosses into the unexplored lands, you come across a never before visited world. While investigating the planet, you discover a village of local aliens. What do you do?",
                        new List<TravellerEventCharacterCreation>
                        {
                            new TravellerEventSkillCheck("Attack the creatures! You get your men ready, putting the creatures in your sights.",
                                yesEvent:new TravellerEventReward("You open fight on the creatures, attacking and slaughtering the village before they have time to raise any kind of defense.", new List<TravellerCharacterCreationReward>
                                {
                                    new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                                    {
                                        {"Alien 1", TravellerNPCRelationship.Enemy },
                                        {"Alien 2", TravellerNPCRelationship.Enemy },
                                        {"Alien 3", TravellerNPCRelationship.Enemy },
                                    }),
                                    new TravellerRewardWeapon()
                                }),
                                noEvent:new TravellerEventReward("You are overrun, you underestimated what looked like primitives, but proved not to be.", new List<TravellerCharacterCreationReward>
                                {
                                    new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                                    {
                                        {"Alien 1", TravellerNPCRelationship.Enemy },
                                        {"Alien 2", TravellerNPCRelationship.Enemy },
                                        {"Alien 3", TravellerNPCRelationship.Enemy },
                                    }),
                                    new TravellerRewardAttribute(Endurance,-1)
                                }),
                                skillChecks: new List<TravellerSkillCheck>
                                {
                                    new TravellerSkillCheck(GunCombat,6),
                                }),

                            new TravellerEventSkillCheck("Try and talk to them: You approach the creatures, universal translator at the ready.",
                                yesEvent: new TravellerEventReward("You’re eventually able to decode their language, and they come to believe you are some kind of deity. Laying the foundation for future translation efforts.", new List<TravellerCharacterCreationReward>
                                {
                                    new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                                    {
                                        {"Alien friend 1", TravellerNPCRelationship.Ally },
                                        {"Alien friend 2", TravellerNPCRelationship.Ally },
                                    }),
                                    new TravellerRewardAdvancement(1)
                                }),
                                noEvent:new TravellerEventReward("", new List<TravellerCharacterCreationReward>
                                {
                                    new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                                    {
                                        {"Alien enemy 1", TravellerNPCRelationship.Enemy },
                                        {"Alien enemy 2", TravellerNPCRelationship.Enemy},
                                    }),
                                    new TravellerRewardAttribute(Endurance,-1)
                                }),
                                skillChecks: new List<TravellerSkillCheck>
                                {
                                    new TravellerSkillCheck(Diplomat,8),
                                    new TravellerSkillCheck(Deception,8),
                                    new TravellerSkillCheck(Language,8),
                                }),

                            new TravellerEventSkillCheck("Watch them for a bit: You spend some time watching the creatures",
                                yesEvent: new TravellerEventReward("After watching them for a while, you discover that while they appear primitive on the ourside, they are actually quiet technologically adept, and would easily be able to overpower you in a fight.",
                                    new List<TravellerCharacterCreationReward>
                                    {
                                        new TravellerRewardAdvancement(2),
                                        new TravellerRewardSkillChoice(1,new List<TravellerSkill>
                                        {
                                            new TravellerSkill(Recon,2),
                                            new TravellerSkill(Stealth,2)
                                        })
                                    }),
                                noEvent:new TravellerEventReward("The creatures spot you watching them. You didn’t notice as their numbers seemed to drop. You didn’t notice as they came up behind you. But you did notice when they opened fire on you, killing everyone in your squad and wounding you.", new List<TravellerCharacterCreationReward>
                                {
                                    new TravellerRewardContact(new Dictionary<string, TravellerNPCRelationship>
                                    {
                                        {"Alien enemy", TravellerNPCRelationship.Enemy },
                                    }),
                                    new TravellerRewardAttribute(Endurance,-2),
                                    new TravellerRewardAttribute(Dexterity,-1),
                                    new TravellerRewardAttribute(Strength,-1),
                                }),
                                skillChecks: new List<TravellerSkillCheck>
                                {
                                    new TravellerSkillCheck(Recon,8),
                                    new TravellerSkillCheck(Stealth,8),
                                }),
                        }),

                    new TravellerEventLife("You have a life event!"),


                    new TravellerEventChoice("The Crew aboard the ship begin to mutiny against the captain in the name of the Traitor Lord Hellsbeck, do you stand with your captain?",
                        yesEvent: new TravellerEventSkillCheck("You stand with your captain, your crew, and the rightful empress.",
                            yesEvent: new TravellerEventReward("You are able to hold the traitors back and regain control of the ship.",new List<TravellerCharacterCreationReward>
                                {
                                    new TravellerRewardAdvancement(2),
                                    new TravellerRewardContact("Shipmate turned Traitor 1",TravellerNPCRelationship.Enemy),
                                    new TravellerRewardContact("Shipmate turned Traitor 2",TravellerNPCRelationship.Enemy),
                                }),
                            noEvent: new TravellerEventReward("The traitors are able to win, however you still served with them and they are people of honour. They choose to leave you at the next planet they stop at.",new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardJobChange("Versian Civis"),
                                new TravellerRewardContact("Ex-Shipmate turned Pirate 1",TravellerNPCRelationship.Contact),
                            }),
                            skillChecks: new List<TravellerSkillCheck>
                            {
                                new TravellerSkillCheck(Leadership,8),
                                new TravellerSkillCheck(GunCombat,8),
                                new TravellerSkillCheck(Melee,8),
                            }),
                        noEvent:new TravellerEventSkillCheck("You stand with those who want a better life, a place in government and to abolish the noble order.",
                            yesEvent: new TravellerEventReward("Your rebellion is successful, you begin a life of piracy aboard your ship. ",new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardJobChange("Polandskia Pirate"),
                                new TravellerRewardContact("Versian Pirate 1",TravellerNPCRelationship.Ally),
                                new TravellerRewardContact("Versian Pirate 2",TravellerNPCRelationship.Ally),
                            }),
                            noEvent: new TravellerEventReward("Your rebellion is put down and you are sentenced to prison.",new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardJobChange("Versian Prisoner"),
                                new TravellerRewardContact("Versian Traitor Shipmate 1",TravellerNPCRelationship.Rival),
                                new TravellerRewardContact("Versian Traitor Shipmate 2",TravellerNPCRelationship.Rival),

                            }),
                            skillChecks: new List<TravellerSkillCheck>
                            {
                                new TravellerSkillCheck(Leadership,8),
                                new TravellerSkillCheck(GunCombat,8),
                                new TravellerSkillCheck(Melee,8),
                            })),

                    new TravellerEventSkillCheck("Your Lord has decided it is time for battle! While at war with a fellow peer of his, your ship comes across an enemy. The battle begins, you head to your battle station.",
                        yesEvent: new TravellerEventReward("Your ship is able to win the battle, it has its losses but it is victory.", new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardSkillChoice(1,new List<TravellerSkills>
                            {
                                Pilot_Spacecraft,Pilot_CapitalShips,Pilot_SmallCraft,
                                Engineer,Engineer_JDrive,Engineer_LifeSupport,Engineer_MDrive,Engineer_Power,
                                Gunner,Gunner_Capital,Gunner_Ortillery,Gunner_Screen,Gunner_Turret
                            }),
                            new TravellerRewardBenefitIncrease(1)
                        }),
                        noEvent: new TravellerEventInjury("Your ship is damaged in the battle and looses, you retreat but suffer many losses."),
                        skillChecks: new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(Pilot,8),
                            new TravellerSkillCheck(Engineer,8),
                            new TravellerSkillCheck(Gunner,8),
                        }),

                    new TravellerEventChoice("A few days after setting off from port with a few Army Units aboard, you enter the Mess to find several of your friends brawling with the troops. Do you join the fighting, or try and stop it.",
                        yesText:"Join the fighting",
                        yesEvent:new TravellerEventSkillCheck("You hop into the fighting, and start to swing your fists about.",
                            yesEvent:new TravellerEventReward("You show the army who is in charge aboard this boat by giving them a good beating.", new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardContact("Brawling Soldier",TravellerNPCRelationship.Rival),
                                new TravellerRewardAdvancement(-1),
                                new TravellerRewardSkill(Melee)
                            }),
                            noEvent:new TravellerEventReward("You are beaten and bruised but it was a good fight,even if someone did end up stopping it before you could finish it.", new List<TravellerCharacterCreationReward>
                            {
                                new TravellerRewardSkill(Melee),
                                new TravellerRewardAttribute(Endurance,-1)
                            }),
                            skillCheck:(Melee,8)),
                        noText:"Try and stop it",
                        noEvent: new TravellerEventReward("You work to pull you friends free from the army-boys, a similar counterpart on the other side gives a curt nod",new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardAdvancement(1),
                            new TravellerRewardContact("Soldier from Brawl",TravellerNPCRelationship.Contact)
                        })),

                    new TravellerEventSkillCheck("While traveling the stars, you discover an awesome alien megastructure. You are sent to investigate.",
                        yesEvent: new TravellerEventReward("Wandinger the immense hallways of the megastructure, you uncover a hidden trove of riches, making yourself a handsome bonus. The facility itself seems long dormant, its purpose forgotten to an empire who was themselves forgotten to everything but this place.", new TravellerRewardBonusBenefit(2)),
                        noEvent:new TravellerEventInjury("While investigating the structure, something goes wrong, you can momentarily feel the world slipping away from you, like you’re being sucked into the vast emptiness just outside your suit. You suffer a minor injury while investigating the ancient structure."),
                        skillChecks:new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(Pilot,8),
                            new TravellerSkillCheck(VaccSuit,8),
                        }),

                    new TravellerEventSkillCheck("During a battle, your ship is disabled and a boarding party has been dispatched to take your vessel. Try and find a way to hold them back.",
                        yesEvent:new TravellerEventReward("You push the enemies back, retaking your ship for Lord and Land. You are quickly marked for a promotion.", new List<TravellerCharacterCreationReward>
                        {
                            new TravellerRewardAdvancement(2),
                            new TravellerRewardSkillChoice(1,new List<TravellerSkills>
                            {
                                GunCombat,Melee,Gunner
                            })
                        }), 
                        noEvent:new TravellerEventChoice("You were unable to hold the enemy invaders back, they pillage your ship and take it as their own prize. They ask if you wish to swear allegiance to their Lord?",
                            yesEvent:new TravellerEventReward("You find it easy to change to your new Lord, however it does seem more difficult to get promoted, as you get used to the different customs of this court", new TravellerRewardAdvancement(-2)), 
                            noEvent:new TravellerEventChangeCareers("The Lord tosses you into one of their prison.","Versian Prisoner")), 
                        skillChecks:new List<TravellerSkillCheck>
                        {
                            new TravellerSkillCheck(GunCombat,8),
                            new TravellerSkillCheck(Melee,8),
                            new TravellerSkillCheck(Gunner,8),
                        }),

       }
       );
        }
    }
}