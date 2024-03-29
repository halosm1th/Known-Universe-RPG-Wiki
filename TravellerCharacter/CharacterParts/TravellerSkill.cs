﻿using System.Text;
using Newtonsoft.Json;

namespace TravellerCharacter.CharacterParts
{
    public enum TravellerSkills
    {
        Admin,
        Advocate,

        AetherSwap,
        AetherTalk,
        AetherWalk,

        Animals,
        Animals_Handling,
        Animals_Training,
        Animals_Veterinary,

        Art,
        Art_Holography,
        Art_Instrument,
        Art_Preformer,
        Art_VisualMedia,
        Art_Write,

        Astrogation,

        Athletics,
        Athletics_Dexterity,
        Athletics_Endurance,
        Athletics_Strength,

        Broker,
        Carouse,

        Circle,
        Circle_Abyss,
        Circle_Aether,
        Circle_Material,
        Circle_Nether,
        Circle_Void,

        Deception,
        Diplomat,

        Drive,
        Drive_HoverCraft,
        Drive_Mole,
        Drive_Track,
        Drive_Walker,
        Drive_Wheel,

        Electronics,
        Electronics_Comms,
        Electronics_Computers,
        Electronics_RemoteOps,
        Electronics_Sensors,

        Engineer,
        Engineer_JDrive,
        Engineer_LifeSupport,
        Engineer_MDrive,
        Engineer_Power,

        Explosives,

        Flyer,
        Flyer_Airship,
        Flyer_Grav,
        Flyer_Ornithopter,
        Flyer_Roter,
        Flyer_Wing,

        FreeForm,
        FreeForm_Abyss,
        FreeForm_Aether,
        FreeForm_Material,
        FreeForm_Nether,
        FreeForm_Void,

        Gambler,

        GunCombat,
        GunCombat_Archaic,
        GunCombat_Energy,
        GunCombat_Slug,

        Gunner,
        Gunner_Capital,
        Gunner_Ortillery,
        Gunner_Screen,
        Gunner_Turret,

        HeavyWeapons,
        HeavyWeapons_Artillery,
        HeavyWeapons_ManPortable,
        HeavyWeapons_Vehicle,

        Investigate,
        JackOfAllTrades,
        JackLuck,

        Language,
        Language_AxiosCommon,
        Language_AxiosPolitical,
        Langauge_Britannian,
        Language_Common,
        Langauge_ElderTongue,
        Language_FederationCommon,
        Language_germushian,
        Langauge_HighImperial,
        Language_HighVersian,
        Langauge_Jedi,
        Langauge_LowImperial,
        Langauge_LowVersian,
        Langauge_Sigmarian,
        Language_Tekka,
        Language_TradersCant,
        Langauge_Utopian,
        Language_Witcher,
        Langauge_XiaoMing,
        Language_Sith,

        Leadership,
        LifeCreate,
        LifeDrain,
        LifeWalk,
        Luck,
        Mechanic,
        Medic,

        Melee,
        Melee_Unarmed,
        Melee_Blade,
        Melee_Bludgeon,
        Melee_Natural,
        Melee_Void,

        Navigation,
        Persuade,

        Pilot,
        Pilot_CapitalShips,
        Pilot_SmallCraft,
        Pilot_Spacecraft,

        Profession,
        Profession_Belter,
        Profession_Biologicals,
        Profession_CivilEngineering,
        Profession_Construction,
        Profession_Hydroponics,
        Profession_Polymers,

        Recon,

        Religion,
        Religion_BritannianSithism,
        Religion_ModernSithism,
        Religion_Deorism,
        Religion_Gatism,
        Religion_Imperialism,
        Religion_JediIsm,
        Religion_Lawgarism,
        Religion_Sigmarism,
        Religion_Sithism,
        Religion_OrthodoxSithism,
        Religion_Witcherism,

        Science,
        Science_Archaeology,
        Science_Astronomy,
        Science_Biology,
        Science_Chemistry,
        Science_Cosmology,
        Science_Cybernetics,
        Science_Economics,
        Science_Genetics,
        Science_History,
        Science_Linguistics,
        Science_Philosophy,
        Science_Physics,
        Science_Planetology,
        Science_Psychology,
        Science_Robotics,
        Science_Sophontology,
        Science_Voidology,
        Science_Xenology,

        Seafarer,
        Seafarer_OceanShips,
        Seafarer_Personal,
        Seafarer_Sail,
        Seafarer_Submarine,

        SigmarsAid,
        SigmarsAir,
        SigmarsFreeze,
        SigmarsFlame,
        SigmarsGuidance,
        SigmarsHand,
        SigmarsKnowledge,
        SigmarsLight,
        SigmarsWater,

        SoulSight,
        SoulLink,
        SoulSwap,

        Stealth,
        Steward,
        Streetwise,
        Survival,

        Tactics,
        Tactics_Military,
        Tactics_Naval,

        VaccSuit
    }

    public class TravellerSkill
    {
        public TravellerSkill(TravellerSkills name, int baseValue = 0)
        {
            SkillName = name;
            SkillValue = baseValue;
        }

        [JsonProperty] public TravellerSkills SkillName { get; set; }


        [JsonProperty] public int SkillValue { get; set; }

        [JsonIgnore]
        public string SkillNameText
        {
            get
            {
                var skill = new StringBuilder(SkillName.ToString());

                if (skill.ToString().Contains("_"))
                {
                    skill = skill.Replace("_", " (");
                    skill.Append(")");
                }

                return skill.ToString();
            }
        }

        [JsonIgnore]
        public string SkillDescriptionText =>
            SkillName switch
            {
                TravellerSkills.Admin =>
                    "This skill covers bureaucracies and administration of all sorts, including the navigation of bureaucratic obstacles or disasters. It also covers tracking inventories, ship manifests and other records.",
                TravellerSkills.Advocate =>
                    "Advocate gives a knowledge of common legal codes and practises, especially interstellar law. It also gives the Traveller experience in oratory, debate and public speaking, making it an excellent skill for lawyers and politicians.",
                TravellerSkills.AetherSwap => "Guild Aether Swap.",
                TravellerSkills.AetherTalk => "Guild Aether Talk.",
                TravellerSkills.AetherWalk => "Guild Aether Walk.",

                TravellerSkills.Animals => "Interact with animals.",
                TravellerSkills.Animals_Handling =>
                    "The Traveller knows how to handle an animal and ride those trained to bear a rider. Unusual animals raise the difficulty of the check.Riding a Horse into Battle: Difficult (10+) Animals (handling) check (1D seconds, DEX). If successful, the Traveller can control the horse for a number of minutes equal to the Effect before needing to make another check.",
                TravellerSkills.Animals_Training =>
                    "The Traveller is trained in veterinary medicine and animal care.Applying Medical Care: See the Medic skill on page 67, but use the Animals (veterinary) skill.",
                TravellerSkills.Animals_Veterinary =>
                    "The Traveller knows how to tame and train animals.Taming a Strange Alien Creature: Formidable (14+) Animals (training) check (1D days, INT).",

                TravellerSkills.Art => "Knowledge of the art world.",
                TravellerSkills.Art_Holography =>
                    "Recording and producing aesthetically pleasing and clear holographic images.Surreptitiously Switching on Your Recorder While in a Secret Meeting: Formidable (14+) Art (holography) check (1D seconds, DEX).",
                TravellerSkills.Art_Instrument =>
                    "Playing a particular musical instrument, such a flute, piano or organ.Playing a Concerto: Difficult (10+) Art (instrument) check (1D x 10 minutes, EDU).",
                TravellerSkills.Art_Preformer =>
                    "The Traveller is a trained actor, dancer or singer at home on the stage, screen or holo. Performing a Play: Average (8+) Art (performer) check (1D hours, EDU).Convincing a Person you are Actually Someone Else:Art (performer) check (INT) opposed by Recon check (INT).",
                TravellerSkills.Art_VisualMedia =>
                    "Making artistic or abstract paintings or sculptures in a variety of media.Making a Statue of Someone: Difficult (10+) Art (visual media) check (1D days, INT).",
                TravellerSkills.Art_Write =>
                    "Composing inspiring or interesting pieces of text.Rousing the People of a Planet by Exposing Their Government’s Corruption: Difficult (10+) Art (write) check (1D hours, INT or EDU).Writing the New Edition of Traveller: Formidable (14+) Art (write) check (1D months, INT).",
                TravellerSkills.Astrogation =>
                    "This skill is for plotting the courses of starships and calculating accurate jumps. See Spacecraft Operations chapter.Plotting Course to a Target World Using a Gas Giant for a Gravity Slingshot: Difficult (10+) Astrogation check (1D x 10 minutes, EDU).Plotting a Standard Jump: Easy (4+) Astrogation check (1D x 10 minutes, EDU), with DM- equal to the Jump distance.",

                TravellerSkills.Athletics => "Using one of your physical stats",
                TravellerSkills.Athletics_Dexterity =>
                    "Climbing, Juggling, Throwing. For alien races with wings, this also includes flying.      Climbing: Difficulty varies. Athletics (dexterity) check (1D x 10 seconds, DEX). So long as he succeeds, the Traveller’s Effect is usually irrelevant unless he is trying to do something while climbing, in which case the climbing is part of a task chain or multiple action.      Sprinting: Average (8+) Athletics (dexterity) check (1D seconds, DEX). If the Traveller does nothing but sprint flat out he can cover 24 + Effect metres with every check. Avoiding obstacles while sprinting requires another Athletics (dexterity) check (Difficult, because he is performing a multiple action).High Jumping: Average (8+) Athletics (dexterity) check (1D seconds, DEX). The Traveller jumps a number of metres straight up equal to the Effect halved.Long Jumping: Average (8+) Athletics (dexterity) check (1D seconds, DEX). The Traveller jumps a number of metres forward equal to the Effect with a running start.Righting Yourself When Artificial Gravity Suddenly Fails on Board a Ship: Average (8+) Athletics (dexterity) check (1D seconds, DEX)",
                TravellerSkills.Athletics_Endurance =>
                    "Long-distance running, hiking Long-distance Running: Average (8+) Athletics (endurance) check (1D x 10 minutes, END).Long-distance Swimming: Average (8+) Athletics (endurance) check (1D x 10 minutes, END).",
                TravellerSkills.Athletics_Strength =>
                    "Feats of strength, weight-lifting.Arm Wrestling: Opposed Athletics (strength) check (1D minutes, STR). Feats of Strength: Average (8+) Athletics (strength) check (1D x 10 seconds, STR). Performing a Complicated Task in a High Gravity Environment: Difficult (10+) Athletics (strength) check (1D seconds, STR).",

                TravellerSkills.Broker =>
                    "The Broker skill allows a Traveller to negotiate trades and arrange fair deals. It is heavily used when trading (see the Trade chapter).Negotiating a Deal: Average (8+) Broker check (1D hours, INT).Finding a Buyer: Average (8+) Broker check (1D hours, SOC).",
                TravellerSkills.Carouse =>
                    "Carousing is the art of socialising; having fun, but also ensuring other people have fun, and infectious good humour. It also covers social awareness and subterfuge in such situations. Drinking Someone Under the Table: Opposed Carouse check (1D hours, END). Difficulty varies by liquor.Gathering Rumours at a Party: Average (8+) Carouse check (1D hours, SOC).",

                TravellerSkills.Circle => "Cast Circle Magic",
                TravellerSkills.Circle_Void => "Cast Circle Magic spells that use Void energy",
                TravellerSkills.Circle_Aether => "Cast Circle Magic spells that use Aether energy",
                TravellerSkills.Circle_Material => "Cast Circle Magic spells that use Material energy",
                TravellerSkills.Circle_Nether => "Cast Circle Magic spells that use Nether energy",
                TravellerSkills.Circle_Abyss => "Cast Circle Magic spells that",

                TravellerSkills.Deception =>
                    "Deception allows a Traveller to lie fluently, disguise himself, perform sleight of hand and fool onlookers. Most underhanded ways of cheating and lying fall under deception. Convincing a Guard to let you Past Without ID: Very Difficult (12+) Deception check (1D minutes, INT). Alternatively, oppose with a Recon check.Palming a Credit Chit: Average (8+) Deception check (1D seconds, DEX).Disguising Yourself as a Wealthy Noble to Fool a Client:Difficult (10+) Deception check (1D x 10 minutes, INT or SOC). Alternatively, oppose with a Recon check.",
                TravellerSkills.Diplomat =>
                    "The Diplomat skill is for negotiating deals, establishing peaceful contact and smoothing over social faux pas. It includes how to behave in high society and proper ways to address nobles. It is a much more formal skill than Persuade.Greeting the Emperor Properly: Difficult (10+) Diplomat check (1D minutes, SOC).Negotiating a Peace Treaty: Average (8+) Diplomat check (1D days, EDU).Transmitting a Formal Surrender: Average (8+) Diplomat check (1D x 10 seconds, INT).",

                TravellerSkills.Drive => "Drive various types of vehicles",
                TravellerSkills.Drive_HoverCraft =>
                    "Vehicles that rely on a cushion of air and thrusters for motion.Manoeuvring a Hovercraft Through a Tight Canal:Difficult (10+) Drive (hovercraft) check (1D minutes, DEX).",
                TravellerSkills.Drive_Mole =>
                    "For controlling vehicles that move through solid matter using drills or other earth-moving technologies, such as plasma torches or cavitation. Surfacing in the Right Place: Average (8+) Drive (mole) check (1D x 10 minutes, INT).Precisely Controlling a Dig to Expose a Vein of Minerals: Difficult (10+) Drive (mole) check (1D x 10 minutes, DEX).",
                TravellerSkills.Drive_Track =>
                    "For tanks and other vehicles that move on tracks.Manoeuvring (or Smashing, Depending on the Vehicle) Through a Forest: Difficult (10+) Drive (tracked) check (1D minutes, DEX).Driving a Tank into a Cargo Bay: Average (8+) Drive (tracked) check (1D x 10 seconds, DEX).",
                TravellerSkills.Drive_Walker =>
                    "Vehicles that use two or more legs to manoeuvre.Negotiating Rough Terrain: Difficult (10+) Drive (walker) check (1D minutes, DEX).",
                TravellerSkills.Drive_Wheel =>
                    "For automobiles and similar groundcars.Driving a Groundcar in a Short Race: Opposed Drive (wheeled) check (1D minutes, DEX). Longer races use END instead of DEX.Avoiding an Unexpected Obstacle on the Road: Average (8+) Drive (wheeled) check (1D seconds, DEX).",

                TravellerSkills.Electronics => "Operate different types of electronics",
                TravellerSkills.Electronics_Comms =>
                    "The use of modern telecommunications; opening communications channels, querying computer networks, jamming signals and so on, as well as the proper protocols for communicating with starports and other spacecraft.Requesting Landing Privileges at a Starport: Routine (6+) Electronic (comms) check (1D minutes, EDU).Accessing Publicly Available but Obscure Data Over Comms: Average (8+) Electronic (comms) check (1D x 10 minutes, EDU).Bouncing a Signal off Orbiting Satellite to Hide Your Transmitter: Difficult (10+) Electronics (comms) check (1D x 10 minutes, INT). Jamming a Comms System: Opposed Electronics (comms) check (1D minutes, INT). Difficult (10+) for radio, Very Difficult (12+) for laser, and Formidable (14+) for masers. A Traveller using a comms system with a higher Technology Level than his opponent gains DM+1 for every TL of difference.",
                TravellerSkills.Electronics_Computers =>
                    "Using and controlling computer systems, and similar electronics and electrics.Accessing Publicly Available Data: Easy (4+) Electronics (computers) check (1D minutes, INT or EDU).Activating a Computer Program on a Ship’s Computer: Routine (6+) Electronics (computers) check (1D x 10 seconds, INT or EDU).Searching a Corporate Database for Evidence of Illegal Activity: Difficult (10+) Electronics (computers) check (1D hours, INT).Hacking into a Secure Computer Network:Formidable (14+) Electronics (computers) check (1D x 10 hours, INT). Hacking is aided by Intrusion programs and made more difficult by Security programs. The Effect determines the amount of data retrieved; failure means the targeted system may be able to trace the hacking attempt.",
                TravellerSkills.Electronics_RemoteOps =>
                    "Using telepresence to remotely control drones, missiles, robots and other devices. Using a Mining Drone to Excavate an Asteroid:Routine (6+) Electronics (remote ops) check (1D hours, DEX).",
                TravellerSkills.Electronics_Sensors =>
                    "The use and interpretation of data from electronic sensor devices, from observation satellites and remote probes to thermal imaging and densitometers. Making a Detailed Sensor Scan: Routine (6+) Electronics (sensors) check (1D x 10 minutes, INT or EDU).Analysing Sensor Data: Average (8+) Electronics (sensors) check (1D hours, INT).",

                TravellerSkills.Engineer_JDrive =>
                    "Maintaining and operating a spacecraft’s Jump drive.Making a Jump: Easy (4+) Engineer (j-drive) check (1D x 10 minutes, EDU). ",
                TravellerSkills.Engineer_MDrive =>
                    "Maintaining and operating a spacecraft’s manoeuvre drive, as well as its artificial gravity. Overcharging a Thruster Plate to Increase a Ship’s agility: Difficult (10+) Engineer (m-drive) check (1D minutes, INT).Estimating a Ship’s Tonnage From its Observed Performance: Average (8+) Engineer (m-drive) check (1D x 10 seconds, INT).",
                TravellerSkills.Engineer_LifeSupport =>
                    "Covers oxygen generators, heating and lighting and other necessary life support systems.Safely Reducing Power to Life Support to Prolong a Ship’s Battery Life: Average (8+) Engineer (life support) check (1D minutes, EDU).",
                TravellerSkills.Engineer_Power =>
                    "Maintaining and operating a spacecraft’s power plant.Monitoring an Enemy ship's Power Output to Determine its Capabilities: Difficult (10+) Engineer (power) check (1D minutes, INT).",

                TravellerSkills.Explosives =>
                    "The Explosives skill covers the use of demolition charges and other explosive devices, including assembling or disarming bombs. A failed Explosives check with an Effect of -4 or less can result in a bomb detonating prematurely.Planting Charges to Collapse a Wall in a Building: Average (8+) Explosives check (1D x 10 minutes, EDU).Planting a Breaching Charge:Average (8+) Explosives check (1D x 10 seconds, EDU). The damage from the explosive is multiplied by the Effect. Disarming a Bomb Equipped with Anti-Tamper Trembler Detonators:Formidable (14+) Explosives check (1D minutes, DEX).",

                TravellerSkills.Flyer_Airship =>
                    "Used for airships, dirigibles and other powered lighter than air craft.",
                TravellerSkills.Flyer_Grav =>
                    "This covers air/rafts, grav belts and other vehicles that use gravitic technology.",
                TravellerSkills.Flyer_Ornithopter => "For vehicles that fly through the use of flapping wings.",
                TravellerSkills.Flyer_Roter => "For vehicles that fly through the use of flapping wings.",
                TravellerSkills.Flyer_Wing => "For jets, vectored thrust aircraft and aeroplanes using a lifting body.",

                TravellerSkills.FreeForm_Void => "Cast free form spell using Void Energy",
                TravellerSkills.FreeForm_Aether => "Cast free form spell using Aetherial Energy",
                TravellerSkills.FreeForm_Material => "Cast free form spell on the Material Plane",
                TravellerSkills.FreeForm_Nether => "Cast free form spell using Netherial Energy",
                TravellerSkills.FreeForm_Abyss => "Cast free form spell using Abyssal Energy",

                TravellerSkills.Gambler =>
                    "The Traveller is familiar with a wide variety of gambling games, such as poker, roulette, blackjack, horse-racing, sports betting and so on, and has an excellent grasp of statistics and probability. Gambler increases the rewards from Benefit Rolls, giving the Traveller DM+1 to his cash rolls if he has Gambler 1 or better. A Casual Game of Poker: Opposed Gambler check (1D hours, INT).Picking the Right Horse to Bet On: Average (8+) Gambler check (1D minutes, INT).",

                TravellerSkills.Gunner => "Operate different types of turrates and other weapons that require a gunner",
                TravellerSkills.Gunner_Turret =>
                    "Operating turret-mounted weapons on board a ship.Firing a Turret at an Enemy Ship: Average (8+) Gunner (turret) check (1D seconds, DEX).",
                TravellerSkills.Gunner_Ortillery =>
                    "A contraction of Orbital Artillery – using a ship’s weapons for planetary bombardment or attacks on stationary targets.Firing Ortillery: Average (8+) Gunner (ortillery) check (1D minutes, INT).",
                TravellerSkills.Gunner_Screen =>
                    "Activating and using a ship’s energy screens like Black Globe generators or meson screens.Activating a Screen to Intercept Enemy Fire: Difficult (10+) Gunner (screen) check (1D seconds, DEX).",
                TravellerSkills.Gunner_Capital =>
                    "Operating bay or spinal mount weapons on board a ship.Firing a Spinal Mount Weapon: Average (8+) Gunner (capital) check (1D minutes, INT).",

                TravellerSkills.GunCombat => "Use different types of guns.",
                TravellerSkills.GunCombat_Archaic =>
                    "For primitive weapons that are not thrown, such as bows and blowpipes. ",
                TravellerSkills.GunCombat_Energy =>
                    "Using advanced energy weapons like laser pistols or plasma rifles.",
                TravellerSkills.GunCombat_Slug =>
                    "Weapons that fire a solid projectile such as the autorifle or gauss rifle.",

                TravellerSkills.HeavyWeapons => "Use various heavy weapons",
                TravellerSkills.HeavyWeapons_Artillery => "Fixed guns, mortars and other indirect-fire weapons.",
                TravellerSkills.HeavyWeapons_ManPortable =>
                    "Missile launchers, flamethrowers and man portable fusion and plasma.",
                TravellerSkills.HeavyWeapons_Vehicle =>
                    "Large weapons typically mounted on vehicles or strongpoints such as tank guns and autocannon.",

                TravellerSkills.Investigate =>
                    "The Investigate skill incorporates keen observation, forensics, and detailed analysis. Searching a Crime Scene For Clues: Average (8+) Investigate check (1D x 10 minutes, INT).Watching a Bank of Security Monitors in a Starport, Watching for a Specific Criminal: Difficult (10+) Investigate check (1D hours, INT).",
                TravellerSkills.JackOfAllTrades =>
                    "The Jack-of-All-Trades skill works differently to other skills. It reduces the unskilled penalty a Traveller receives for not having the appropriate skill by one for every level of Jack-of-All-Trades. For example, if a Traveller does not have the Pilot skill, he suffers DM-3 to all Pilot checks. If that Traveller has Jack-of-All-Trades 2, then the penalty is reduced by 2 to DM-1. With Jack-of-All-Trades 3, a Traveller can totally negate the penalty for being unskilled.There is no benefit for having Jack-of-All-Trades 0 or Jack-of-All-Trades 4 or more.",

                TravellerSkills.Language => "Have a general understanding of Langauges",
                TravellerSkills.Language_Common => "See Langauges page",
                TravellerSkills.Language_FederationCommon => "See Langauges page",
                TravellerSkills.Language_AxiosCommon => "See Langauges page",
                TravellerSkills.Language_AxiosPolitical => "See Langauges page",
                TravellerSkills.Langauge_XiaoMing => "See Langauges page",
                TravellerSkills.Language_TradersCant => "See Langauges page",
                TravellerSkills.Langauge_Utopian => "See Langauges page",
                TravellerSkills.Language_HighVersian => "See Langauges page",
                TravellerSkills.Langauge_LowVersian => "See Langauges page",
                TravellerSkills.Language_germushian => "See Langauges page",
                TravellerSkills.Langauge_Sigmarian => "See Langauges page",
                TravellerSkills.Langauge_Britannian => "See Langauges page",
                TravellerSkills.Language_Tekka => "See Langauges page",
                TravellerSkills.Langauge_HighImperial => "See Langauges page",
                TravellerSkills.Langauge_LowImperial => "See Langauges page",
                TravellerSkills.Langauge_ElderTongue => "See Langauges page",
                TravellerSkills.Language_Witcher => "See Langauges page",
                TravellerSkills.Langauge_Jedi => "See Langauges page",
                TravellerSkills.Language_Sith => "See Language page",

                TravellerSkills.Leadership =>
                    "The Leadership skill is for directing, inspiring and rallying allies and comrades. A Traveller may make a Leadership action in combat, as detailed on page 72.Shouting an Order: Average (8+) Leadership check (1D seconds, SOC).Rallying Shaken Troops: Difficult (10+) Leadership check (1D seconds, SOC).",
                TravellerSkills.Luck => "See House Rules for more information on luck.",
                TravellerSkills.Mechanic =>
                    "The Mechanic skill allows a Traveller to maintain and repair most equipment – some advanced equipment and spacecraft components require the Engineer skill. Unlike the narrower and more focussed Engineer or Science skills, Mechanic does not allow a Traveller to build new devices or alter existing ones – it is purely for repairs and maintenance but covers all types of equipment.Repairing a Damaged System in the Field: Average (8+) Mechanic check (1D minutes, INT or EDU).",
                TravellerSkills.Medic =>
                    "The Medic skill covers emergency first aid and battlefield triage as well as diagnosis, treatment, surgery and long-term care. See Injury and Recovery on page 47.First Aid: Average (8+) Medic check (1D minutes, EDU). The patient regains lost characteristic points equal to the Effect.Treat Poison or Disease: Average (8+) Medic check (1D hours, EDU).Long-term Care: Average (8+) Medic check (1D hours, EDU).",

                TravellerSkills.Melee => "General knowledge of melee combat.",
                TravellerSkills.Melee_Unarmed =>
                    "Punching, kicking and wrestling; using improvised weapons in a bar brawl.",
                TravellerSkills.Melee_Blade => "Attacking with swords, rapiers, blades and other edged weapons.",
                TravellerSkills.Melee_Bludgeon => "Attacking with maces, clubs, staves and so on.",
                TravellerSkills.Melee_Natural =>
                    "Weapons that are part of an alien or creature, such as claws or teeth. ",
                TravellerSkills.Melee_Void =>
                    "Weapons that utilize pure void energy to create limited sized energy melee weapons that can cut through anything",

                TravellerSkills.Navigation =>
                    "Navigation is the planetside counterpart of astrogation, covering plotting courses and finding directions on the ground.Plotting a Course Using an Orbiting Satellite Beacon:Average (8+) Navigation check (1D x 10 minutes, INT or EDU).Avoiding Getting Lost in Thick Jungle: Difficult (10+) Navigation check (1D hours, INT).",
                TravellerSkills.Persuade =>
                    "Persuade is a more casual, informal version of Diplomat. It covers fast talking, bargaining, wheedling and bluffing. It also covers bribery or intimidation. Bluffing Your Way Past a Guard: Opposed Persuade check (1D minutes, INT or SOC).Haggling in a Bazaar: Opposed Persuade check (1D minutes, INT or SOC).Intimidating a Thug: Opposed Persuade check (1D minutes, STR or SOC).Asking the Alien Space Princess to Marry You: Formidable (14+) Persuade check (1D x 10 minutes, SOC)",

                TravellerSkills.Pilot => "General knowledge of piloting spacecraft.",
                TravellerSkills.Pilot_SmallCraft => "Shuttles and other craft under 100 tons.",
                TravellerSkills.Pilot_Spacecraft => "Trade ships and other vessels between 100 and 5,000 tons.",
                TravellerSkills.Pilot_CapitalShips => "Battleships and other ships",

                TravellerSkills.Profession => "General knowledge about working in a white collar job",
                TravellerSkills.Profession_Belter => "Mining asteroids for valuable ores and minerals",
                TravellerSkills.Profession_Biologicals => "Engineering and managing artificial organisms",
                TravellerSkills.Profession_CivilEngineering => "Designing structures and buildings.",
                TravellerSkills.Profession_Construction => "Building orbital habitats and megastructures.",
                TravellerSkills.Profession_Hydroponics => "Growing crops in hostile environments",
                TravellerSkills.Profession_Polymers => "Designing and using polymers.",

                TravellerSkills.Recon =>
                    "A Traveller trained in Recon is able to scout out dangers and spot threats, unusual objects or out of place people. Working Out the Routine of a Trio of Guard Patrols:Average (8+) Recon check (1D x 10 minutes, INT).Spotting the Sniper Before he Shoots You: Recon check (1D x 10 seconds, INT) opposed by Stealth (DEX) Check",

                TravellerSkills.Religion => "Knowledge of various religions in the known universe",
                TravellerSkills.Religion_BritannianSithism => "Knowledge of Britannian Sithism",
                TravellerSkills.Religion_ModernSithism => "Knowledge of Modern Sithism",
                TravellerSkills.Religion_Deorism => "Knowledge of Deorism",
                TravellerSkills.Religion_Gatism => "Knowledge of Gatism",
                TravellerSkills.Religion_Imperialism => "Knowledge of Imperialism",
                TravellerSkills.Religion_JediIsm => "Knowledge of Jed-Iism",
                TravellerSkills.Religion_Lawgarism => "Knowledge of Lawgarism",
                TravellerSkills.Religion_Sigmarism => "Knowledge of Sigmarism",
                TravellerSkills.Religion_Sithism => "Knowledge of Sithism",
                TravellerSkills.Religion_Witcherism => "Knowledge of Witcherism",

                TravellerSkills.Science => "General Knowledge of science",
                TravellerSkills.Science_Archaeology =>
                    "The study of ancient civilisations, including the previous Imperiums and Ancients. It also covers techniques of investigation and excavations.",
                TravellerSkills.Science_Astronomy => "The study of stars and celestial pheonomena.",
                TravellerSkills.Science_Biology => "The study of living organisms.",
                TravellerSkills.Science_Chemistry =>
                    "The study of matter at the atomic, molecular, and macromolecular levels.",
                TravellerSkills.Science_Cosmology => "The study of universe and its creation.",
                TravellerSkills.Science_Cybernetics => "The study of blending living and synthetic life.",
                TravellerSkills.Science_Economics => "The study of trade and markets.",
                TravellerSkills.Science_Genetics => "The study of genetic codes and engineering.",
                TravellerSkills.Science_History =>
                    "The study of the past, as seen through documents and records as opposed to physical artefacts.",
                TravellerSkills.Science_Linguistics => "The study of languages.",
                TravellerSkills.Science_Philosophy => "The study of beliefs and religions.",
                TravellerSkills.Science_Physics => "The study of the fundamental forces.",
                TravellerSkills.Science_Planetology => "The study of planet formation and evolution.",
                TravellerSkills.Science_Psychology => "The study of thought and society.",
                TravellerSkills.Science_Robotics => "The study of robot construction and use.",
                TravellerSkills.Science_Sophontology => "The study of intelligent living creatures.",
                TravellerSkills.Science_Voidology => "The study of the void, its powers and phenomena.",
                TravellerSkills.Science_Xenology => "The study of alien life forms.",

                TravellerSkills.Seafarer => "Knowleding of travelling at sea.",
                TravellerSkills.Seafarer_OceanShips => "For motorised sea-going vessels. ",
                TravellerSkills.Seafarer_Personal =>
                    "Used for very small waterborne craft such as canoes and rowboats.",
                TravellerSkills.Seafarer_Sail => "This skill is for wind-driven watercraft.",
                TravellerSkills.Seafarer_Submarine => "vehicles that travel underwater.",

                TravellerSkills.Stealth =>
                    "A Traveller trained in the Stealth skill is adept at staying unseen, unheard, and unnoticed.Sneaking Past a Guard: Stealth check (1D x 10 seconds, DEX) opposed by Recon (INT) check.Avoiding Detection by a Security Patrol: Stealth check (1D minutes, DEX) opposed by Recon (INT) check.",

                TravellerSkills.SigmarsLight => "Sigmars cleansing holy light is called down by you.",
                TravellerSkills.SigmarsGuidance => "Call upon Sigmars infinite wisdom to guide you",
                TravellerSkills.SigmarsFlame => "Call upon Sigmar to create a Fire/Heat for you",
                TravellerSkills.SigmarsFreeze => "Call upon Sigmar to create Cold for you",
                TravellerSkills.SigmarsWater => "Call upon Sigmar to create Water for you",
                TravellerSkills.SigmarsAir => "Call upon Sigmar to create Air for you",
                TravellerSkills.SigmarsKnowledge => "Call upon Sigmar for knowledge",
                TravellerSkills.SigmarsHand => "Call upon Sigmar for a hand",
                TravellerSkills.SigmarsAid => "Call upon Sigmar for some aid",

                TravellerSkills.Steward =>
                    "The Steward skill allows the Traveller to serve and care for nobles and high-class passengers. It covers everything from proper address and behaviour to cooking and tailoring, as well as basic management skills. A Traveller with the Steward skill is necessary on any ship offering High Passage. See Spacecraft Operations chapter for more details.Cooking a Fine Meal: Average (8+) Steward check (1D hours, EDU).Calming Down an Angry Duke who has Just Been Told you Will not be Jumping to his Destination on Time:Difficult (10+) Steward check (1D minutes, SOC).",
                TravellerSkills.Streetwise =>
                    "A Traveller with the Streetwise skill understands the urban environment and the power structures in society. On his homeworld and in related systems, he knows criminal contacts and fixers. On other worlds, he can quickly intuit power structures and can fit into local underworlds.Finding a Dealer in Illegal Materials or Technologies:Average (8+) Streetwise check (1D x 10 hours, INT).Evading a Police Search: Streetwise check (1D x 10 minutes, INT) opposed by Recon (INT) check.",
                TravellerSkills.Survival =>
                    "The Survival skill is the wilderness counterpart of the urban Streetwise skill – the Traveller is trained to survive in the wild, build shelters, hunt or trap animals, avoid exposure and so forth. He can recognise plants and animals of his homeworld and related planets, and can pick up on common clues and traits even on unfamiliar worlds.Gathering Supplies in the Wilderness to Survive for a Week: Average (8+) Survival check (1D days, EDU).Identifying a Poisonous Plant: Average (8+) Survival check (1D x 10 seconds, INT or EDU).",

                TravellerSkills.Tactics =>
                    "Co-oridnate different types of attacks and a broad general understanding of tactics.",
                TravellerSkills.Tactics_Military =>
                    "Co-ordinating the attacks of foot troops or vehicles on the ground.",
                TravellerSkills.Tactics_Naval => "Co-ordinating the attacks of a spacecraft or fleet.",

                TravellerSkills.VaccSuit =>
                    "The Vacc Suit skill allows a Traveller to wear and operate spacesuits and environmental suits. A Traveller will rarely need to make Vacc Suit checks under ordinary circumstances – merely possessing the skill is enough. If the Traveller does not have the requisite Vacc Suit skill for the suit he is wearing, he suffers DM-2 to all skill checks made while wearing a suit for each missing level. This skill also permits the character to operate advanced battle armour. Performing a Systems Check on Battle Dress: Average (8+) Vacc Suit check (1D minutes, EDU).",
                _ => "Not a valid skill... yet."
            };

        public override string ToString()
        {
            return $"{SkillName}: {SkillValue}";
        }

        public void Increase(int amount)
        {
            SkillValue += amount;
        }

        public bool IsSuperSkill()
        {
            return IsSuperSkill(SkillName);
        }


        public static bool IsSuperSkill(TravellerSkills skill)
        {
            return skill switch
            {
                TravellerSkills.Animals => true,
                TravellerSkills.Art => true,
                TravellerSkills.Athletics => true,
                TravellerSkills.Circle => true,
                TravellerSkills.Drive => true,
                TravellerSkills.Electronics => true,
                TravellerSkills.Engineer => true,
                TravellerSkills.Flyer => true,
                TravellerSkills.FreeForm => true,
                TravellerSkills.GunCombat => true,
                TravellerSkills.Gunner => true,
                TravellerSkills.HeavyWeapons => true,
                TravellerSkills.JackLuck => true,
                TravellerSkills.Language => true,
                TravellerSkills.Melee => true,
                TravellerSkills.Pilot => true,
                TravellerSkills.Profession => true,
                TravellerSkills.Religion => true,
                TravellerSkills.Science => true,
                TravellerSkills.Seafarer => true,
                TravellerSkills.Tactics => true,
                _ => false
            };
        }
    }
}