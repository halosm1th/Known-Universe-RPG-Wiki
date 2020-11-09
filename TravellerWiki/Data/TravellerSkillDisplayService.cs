using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellerWiki.Data
{
    public class TravellerSkillDisplayService
    {
        public List<TravellerSkillDisplay> TravellerSkillLists { get; set; } = new List<TravellerSkillDisplay>
        {
            new TravellerSkillDisplay("Admin","This skill covers bureaucracies and administration of all sorts, including the navigation of bureaucratic obstacles or disasters. It also covers tracking inventories, ship manifests and other records."),
            new TravellerSkillDisplay("Advocate ","Advocate gives a knowledge of common legal codes and practises, especially interstellar law. It also gives the Traveller experience in oratory, debate and public speaking, making it an excellent skill for lawyers and politicians."),
            new TravellerSkillDisplay("Animals(Handling)","The Traveller knows how to handle an animal and ride those trained to bear a rider. Unusual animals raise the difficulty of the check.Riding a Horse into Battle: Difficult (10+) Animals (handling) check (1D seconds, DEX). If successful, the Traveller can control the horse for a number of minutes equal to the Effect before needing to make another check."),
            new TravellerSkillDisplay("Animals(Veterinary)","The Traveller is trained in veterinary medicine and animal care.Applying Medical Care: See the Medic skill on page 67, but use the Animals (veterinary) skill."),
            new TravellerSkillDisplay("Animals(Training)","The Traveller knows how to tame and train animals.Taming a Strange Alien Creature: Formidable (14+) Animals (training) check (1D days, INT)."),
            new TravellerSkillDisplay("Art(Performer)","The Traveller is a trained actor, dancer or singer at home on the stage, screen or holo. Performing a Play: Average (8+) Art (performer) check (1D hours, EDU).Convincing a Person you are Actually Someone Else:Art (performer) check (INT) opposed by Recon check (INT)."),
            new TravellerSkillDisplay("Art(Holography)","Recording and producing aesthetically pleasing and clear holographic images.Surreptitiously Switching on Your Recorder While in a Secret Meeting: Formidable (14+) Art (holography) check (1D seconds, DEX)."),
            new TravellerSkillDisplay("Art(Instrument)","Playing a particular musical instrument, such a flute, piano or organ.Playing a Concerto: Difficult (10+) Art (instrument) check (1D x 10 minutes, EDU)."),
            new TravellerSkillDisplay("Art(Visual Media)","Making artistic or abstract paintings or sculptures in a variety of media.Making a Statue of Someone: Difficult (10+) Art (visual media) check (1D days, INT)."),
            new TravellerSkillDisplay("Art(Write)","Composing inspiring or interesting pieces of text.Rousing the People of a Planet by Exposing Their Government’s Corruption: Difficult (10+) Art (write) check (1D hours, INT or EDU).Writing the New Edition of Traveller: Formidable (14+) Art (write) check (1D months, INT)."),
            new TravellerSkillDisplay("Astrogation","This skill is for plotting the courses of starships and calculating accurate jumps. See Spacecraft Operations chapter.Plotting Course to a Target World Using a Gas Giant for a Gravity Slingshot: Difficult (10+) Astrogation check (1D x 10 minutes, EDU).Plotting a Standard Jump: Easy (4+) Astrogation check (1D x 10 minutes, EDU), with DM- equal to the Jump distance."),
            new TravellerSkillDisplay("Athletics(Dexterity)","Climbing, Juggling, Throwing. For alien races with wings, this also includes flying.      Climbing: Difficulty varies. Athletics (dexterity) check (1D x 10 seconds, DEX). So long as he succeeds, the Traveller’s Effect is usually irrelevant unless he is trying to do something while climbing, in which case the climbing is part of a task chain or multiple action.      Sprinting: Average (8+) Athletics (dexterity) check (1D seconds, DEX). If the Traveller does nothing but sprint flat out he can cover 24 + Effect metres with every check. Avoiding obstacles while sprinting requires another Athletics (dexterity) check (Difficult, because he is performing a multiple action).High Jumping: Average (8+) Athletics (dexterity) check (1D seconds, DEX). The Traveller jumps a number of metres straight up equal to the Effect halved.Long Jumping: Average (8+) Athletics (dexterity) check (1D seconds, DEX). The Traveller jumps a number of metres forward equal to the Effect with a running start.Righting Yourself When Artificial Gravity Suddenly Fails on Board a Ship: Average (8+) Athletics (dexterity) check (1D seconds, DEX)"),
            new TravellerSkillDisplay("Athletics(Endurance)","Long-distance running, hiking Long-distance Running: Average (8+) Athletics (endurance) check (1D x 10 minutes, END).Long-distance Swimming: Average (8+) Athletics (endurance) check (1D x 10 minutes, END)."),
            new TravellerSkillDisplay("Athletics(Strength)","Feats of strength, weight-lifting.Arm Wrestling: Opposed Athletics (strength) check (1D minutes, STR). Feats of Strength: Average (8+) Athletics (strength) check (1D x 10 seconds, STR). Performing a Complicated Task in a High Gravity Environment: Difficult (10+) Athletics (strength) check (1D seconds, STR)."),
            new TravellerSkillDisplay("Broker","The Broker skill allows a Traveller to negotiate trades and arrange fair deals. It is heavily used when trading (see the Trade chapter).Negotiating a Deal: Average (8+) Broker check (1D hours, INT).Finding a Buyer: Average (8+) Broker check (1D hours, SOC)."),
            new TravellerSkillDisplay("Carouse","Carousing is the art of socialising; having fun, but also ensuring other people have fun, and infectious good humour. It also covers social awareness and subterfuge in such situations. Drinking Someone Under the Table: Opposed Carouse check (1D hours, END). Difficulty varies by liquor.Gathering Rumours at a Party: Average (8+) Carouse check (1D hours, SOC)."),
            new TravellerSkillDisplay("Deception","Deception allows a Traveller to lie fluently, disguise himself, perform sleight of hand and fool onlookers. Most underhanded ways of cheating and lying fall under deception. Convincing a Guard to let you Past Without ID: Very Difficult (12+) Deception check (1D minutes, INT). Alternatively, oppose with a Recon check.Palming a Credit Chit: Average (8+) Deception check (1D seconds, DEX).Disguising Yourself as a Wealthy Noble to Fool a Client:Difficult (10+) Deception check (1D x 10 minutes, INT or SOC). Alternatively, oppose with a Recon check."),
            new TravellerSkillDisplay("Diplomat","The Diplomat skill is for negotiating deals, establishing peaceful contact and smoothing over social faux pas. It includes how to behave in high society and proper ways to address nobles. It is a much more formal skill than Persuade.Greeting the Emperor Properly: Difficult (10+) Diplomat check (1D minutes, SOC).Negotiating a Peace Treaty: Average (8+) Diplomat check (1D days, EDU).Transmitting a Formal Surrender: Average (8+) Diplomat check (1D x 10 seconds, INT)."),
            new TravellerSkillDisplay("Drive(Hovercraft)","Vehicles that rely on a cushion of air and thrusters for motion.Manoeuvring a Hovercraft Through a Tight Canal:Difficult (10+) Drive (hovercraft) check (1D minutes, DEX)."),
            new TravellerSkillDisplay("Drive(Mole)","For controlling vehicles that move through solid matter using drills or other earth-moving technologies, such as plasma torches or cavitation. Surfacing in the Right Place: Average (8+) Drive (mole) check (1D x 10 minutes, INT).Precisely Controlling a Dig to Expose a Vein of Minerals: Difficult (10+) Drive (mole) check (1D x 10 minutes, DEX)."),
            new TravellerSkillDisplay("Drive(Track)","For tanks and other vehicles that move on tracks.Manoeuvring (or Smashing, Depending on the Vehicle) Through a Forest: Difficult (10+) Drive (tracked) check (1D minutes, DEX).Driving a Tank into a Cargo Bay: Average (8+) Drive (tracked) check (1D x 10 seconds, DEX)."),
            new TravellerSkillDisplay("Drive(Walker)","Vehicles that use two or more legs to manoeuvre.Negotiating Rough Terrain: Difficult (10+) Drive (walker) check (1D minutes, DEX)."),
            new TravellerSkillDisplay("Drive(Wheel)","For automobiles and similar groundcars.Driving a Groundcar in a Short Race: Opposed Drive (wheeled) check (1D minutes, DEX). Longer races use END instead of DEX.Avoiding an Unexpected Obstacle on the Road: Average (8+) Drive (wheeled) check (1D seconds, DEX)."),
            new TravellerSkillDisplay("Electronics(Comms)","The use of modern telecommunications; opening communications channels, querying computer networks, jamming signals and so on, as well as the proper protocols for communicating with starports and other spacecraft.Requesting Landing Privileges at a Starport: Routine (6+) Electronic (comms) check (1D minutes, EDU).Accessing Publicly Available but Obscure Data Over Comms: Average (8+) Electronic (comms) check (1D x 10 minutes, EDU).Bouncing a Signal off Orbiting Satellite to Hide Your Transmitter: Difficult (10+) Electronics (comms) check (1D x 10 minutes, INT). Jamming a Comms System: Opposed Electronics (comms) check (1D minutes, INT). Difficult (10+) for radio, Very Difficult (12+) for laser, and Formidable (14+) for masers. A Traveller using a comms system with a higher Technology Level than his opponent gains DM+1 for every TL of difference."),
            new TravellerSkillDisplay("Electronics(Computers)","Using and controlling computer systems, and similar electronics and electrics.Accessing Publicly Available Data: Easy (4+) Electronics (computers) check (1D minutes, INT or EDU).Activating a Computer Program on a Ship’s Computer: Routine (6+) Electronics (computers) check (1D x 10 seconds, INT or EDU).Searching a Corporate Database for Evidence of Illegal Activity: Difficult (10+) Electronics (computers) check (1D hours, INT).Hacking into a Secure Computer Network:Formidable (14+) Electronics (computers) check (1D x 10 hours, INT). Hacking is aided by Intrusion programs and made more difficult by Security programs. The Effect determines the amount of data retrieved; failure means the targeted system may be able to trace the hacking attempt."),
            new TravellerSkillDisplay("Electronics(Remote Ops)","Using telepresence to remotely control drones, missiles, robots and other devices. Using a Mining Drone to Excavate an Asteroid:Routine (6+) Electronics (remote ops) check (1D hours, DEX)."),
            new TravellerSkillDisplay("Electronics(Sensors)","The use and interpretation of data from electronic sensor devices, from observation satellites and remote probes to thermal imaging and densitometers. Making a Detailed Sensor Scan: Routine (6+) Electronics (sensors) check (1D x 10 minutes, INT or EDU).Analysing Sensor Data: Average (8+) Electronics (sensors) check (1D hours, INT)."),
            new TravellerSkillDisplay("Engineer(J-Drive)","Maintaining and operating a spacecraft’s Jump drive.Making a Jump: Easy (4+) Engineer (j-drive) check (1D x 10 minutes, EDU). "),
            new TravellerSkillDisplay("Engineer(M-drive)","Maintaining and operating a spacecraft’s manoeuvre drive, as well as its artificial gravity. Overcharging a Thruster Plate to Increase a Ship’s agility: Difficult (10+) Engineer (m-drive) check (1D minutes, INT).Estimating a Ship’s Tonnage From its Observed Performance: Average (8+) Engineer (m-drive) check (1D x 10 seconds, INT)."),
            new TravellerSkillDisplay("Engineer(Life Support)","Covers oxygen generators, heating and lighting and other necessary life support systems.Safely Reducing Power to Life Support to Prolong a Ship’s Battery Life: Average (8+) Engineer (life support) check (1D minutes, EDU)."),
            new TravellerSkillDisplay("Engineer(Power)","Maintaining and operating a spacecraft’s power plant.Monitoring an Enemy ship's Power Output to Determine its Capabilities: Difficult (10+) Engineer (power) check (1D minutes, INT)."),
            new TravellerSkillDisplay("Explosives","The Explosives skill covers the use of demolition charges and other explosive devices, including assembling or disarming bombs. A failed Explosives check with an Effect of -4 or less can result in a bomb detonating prematurely.Planting Charges to Collapse a Wall in a Building: Average (8+) Explosives check (1D x 10 minutes, EDU).Planting a Breaching Charge:Average (8+) Explosives check (1D x 10 seconds, EDU). The damage from the explosive is multiplied by the Effect. Disarming a Bomb Equipped with Anti-Tamper Trembler Detonators:Formidable (14+) Explosives check (1D minutes, DEX)."),
            new TravellerSkillDisplay("Flyer(Airship)","Used for airships, dirigibles and other powered lighter than air craft."),
            new TravellerSkillDisplay("Flyer(Grav)","This covers air/rafts, grav belts and other vehicles that use gravitic technology."),
            new TravellerSkillDisplay("Flyer(Ornithopter)","For vehicles that fly through the use of flapping wings."),
            new TravellerSkillDisplay("Flyer(Rotor)","For vehicles that fly through the use of flapping wings."),
            new TravellerSkillDisplay("Flyer(Wing)","For jets, vectored thrust aircraft and aeroplanes using a lifting body."),
            new TravellerSkillDisplay("Gambler","The Traveller is familiar with a wide variety of gambling games, such as poker, roulette, blackjack, horse-racing, sports betting and so on, and has an excellent grasp of statistics and probability. Gambler increases the rewards from Benefit Rolls, giving the Traveller DM+1 to his cash rolls if he has Gambler 1 or better. A Casual Game of Poker: Opposed Gambler check (1D hours, INT).Picking the Right Horse to Bet On: Average (8+) Gambler check (1D minutes, INT)."),
            new TravellerSkillDisplay("Gunner(Turret)","Operating turret-mounted weapons on board a ship.Firing a Turret at an Enemy Ship: Average (8+) Gunner (turret) check (1D seconds, DEX)."),
            new TravellerSkillDisplay("Gunner(Ortillery)","A contraction of Orbital Artillery – using a ship’s weapons for planetary bombardment or attacks on stationary targets.Firing Ortillery: Average (8+) Gunner (ortillery) check (1D minutes, INT)."),
            new TravellerSkillDisplay("Gunner(Screen)","Activating and using a ship’s energy screens like Black Globe generators or meson screens.Activating a Screen to Intercept Enemy Fire: Difficult (10+) Gunner (screen) check (1D seconds, DEX)."),
            new TravellerSkillDisplay("Gunner(Capital)","Operating bay or spinal mount weapons on board a ship.Firing a Spinal Mount Weapon: Average (8+) Gunner (capital) check (1D minutes, INT)."),
            new TravellerSkillDisplay("Gun Combat(Archaic)","For primitive weapons that are not thrown, such as bows and blowpipes. "),
            new TravellerSkillDisplay("Gun Combat(Energy)","Using advanced energy weapons like laser pistols or plasma rifles."),
            new TravellerSkillDisplay("Gun Combat(Slug)","Weapons that fire a solid projectile such as the autorifle or gauss rifle."),
            new TravellerSkillDisplay("Heavy Weapons(Artillery)","Fixed guns, mortars and other indirect-fire weapons."),
            new TravellerSkillDisplay("Heavy Weapons(Man Portable)","Missile launchers, flamethrowers and man portable fusion and plasma."),
            new TravellerSkillDisplay("Heavy Weapons(Vehicle)","Large weapons typically mounted on vehicles or strongpoints such as tank guns and autocannon."),
            new TravellerSkillDisplay("Investigate","The Investigate skill incorporates keen observation, forensics, and detailed analysis. Searching a Crime Scene For Clues: Average (8+) Investigate check (1D x 10 minutes, INT).Watching a Bank of Security Monitors in a Starport, Watching for a Specific Criminal: Difficult (10+) Investigate check (1D hours, INT)."),
            new TravellerSkillDisplay("Jack-of-All-Trades","The Jack-of-All-Trades skill works differently to other skills. It reduces the unskilled penalty a Traveller receives for not having the appropriate skill by one for every level of Jack-of-All-Trades. For example, if a Traveller does not have the Pilot skill, he suffers DM-3 to all Pilot checks. If that Traveller has Jack-of-All-Trades 2, then the penalty is reduced by 2 to DM-1. With Jack-of-All-Trades 3, a Traveller can totally negate the penalty for being unskilled.There is no benefit for having Jack-of-All-Trades 0 or Jack-of-All-Trades 4 or more. "),
            
            new TravellerSkillDisplay("Language(Common)",""),
            new TravellerSkillDisplay("Language(Federation Common)",""),
            new TravellerSkillDisplay("Language(Axios Common)",""),
            new TravellerSkillDisplay("Language(Axios Politcal)",""),
            new TravellerSkillDisplay("Language(Xiao-Ming)",""),
            new TravellerSkillDisplay("Language(Traders cant)",""),
            new TravellerSkillDisplay("Language(Utopian)",""),


            new TravellerSkillDisplay("Language(High Versian)",""),
            new TravellerSkillDisplay("Language(Low Versian)",""),
            new TravellerSkillDisplay("Language(Germushian)",""),
            new TravellerSkillDisplay("Language(Sigmarian)",""),
            new TravellerSkillDisplay("Language(Britannian)",""),
            new TravellerSkillDisplay("Language(Tekka)",""),

            new TravellerSkillDisplay("Language(High Imperial)",""),
            new TravellerSkillDisplay("Language(Low Imperial)",""),

            new TravellerSkillDisplay("Language(Elder Tongue)",""),
            new TravellerSkillDisplay("Language(Witcher)",""),
            new TravellerSkillDisplay("Language(Jed-I)",""),

            new TravellerSkillDisplay("Leadership","The Leadership skill is for directing, inspiring and rallying allies and comrades. A Traveller may make a Leadership action in combat, as detailed on page 72.Shouting an Order: Average (8+) Leadership check (1D seconds, SOC).Rallying Shaken Troops: Difficult (10+) Leadership check (1D seconds, SOC)."),
            new TravellerSkillDisplay("Luck","See <a href=\"Rules/HouseRules\">House Rules</a> for more information on luck."),
            new TravellerSkillDisplay("Mechanic","The Mechanic skill allows a Traveller to maintain and repair most equipment – some advanced equipment and spacecraft components require the Engineer skill. Unlike the narrower and more focussed Engineer or Science skills, Mechanic does not allow a Traveller to build new devices or alter existing ones – it is purely for repairs and maintenance but covers all types of equipment.Repairing a Damaged System in the Field: Average (8+) Mechanic check (1D minutes, INT or EDU)."),
            new TravellerSkillDisplay("Medic","The Medic skill covers emergency first aid and battlefield triage as well as diagnosis, treatment, surgery and long-term care. See Injury and Recovery on page 47.First Aid: Average (8+) Medic check (1D minutes, EDU). The patient regains lost characteristic points equal to the Effect.Treat Poison or Disease: Average (8+) Medic check (1D hours, EDU).Long-term Care: Average (8+) Medic check (1D hours, EDU)."),
            new TravellerSkillDisplay("Melee(Blade)","Punching, kicking and wrestling; using improvised weapons in a bar brawl."),
            new TravellerSkillDisplay("Melee(Blade)","Attacking with swords, rapiers, blades and other edged weapons."),
            new TravellerSkillDisplay("Melee(Bludgeon)","Attacking with maces, clubs, staves and so on."),
            new TravellerSkillDisplay("Melee(Natural)","Weapons that are part of an alien or creature, such as claws or teeth. "),
            new TravellerSkillDisplay("Melee(Void)","Weapons that utilize pure void energy to create limited sized energy melee weapons that can cut through almost anything."),
            
            new TravellerSkillDisplay("Navigation","Navigation is the planetside counterpart of astrogation, covering plotting courses and finding directions on the ground.Plotting a Course Using an Orbiting Satellite Beacon:Average (8+) Navigation check (1D x 10 minutes, INT or EDU).Avoiding Getting Lost in Thick Jungle: Difficult (10+) Navigation check (1D hours, INT)."),
            new TravellerSkillDisplay("Persuade","Persuade is a more casual, informal version of Diplomat. It covers fast talking, bargaining, wheedling and bluffing. It also covers bribery or intimidation. Bluffing Your Way Past a Guard: Opposed Persuade check (1D minutes, INT or SOC).Haggling in a Bazaar: Opposed Persuade check (1D minutes, INT or SOC).Intimidating a Thug: Opposed Persuade check (1D minutes, STR or SOC).Asking the Alien Space Princess to Marry You: Formidable (14+) Persuade check (1D x 10 minutes, SOC)."),
            
            new TravellerSkillDisplay("Pilot(Small Craft)","Shuttles and other craft under 100 tons."),
            new TravellerSkillDisplay("Pilot(Spacecraft)","Trade ships and other vessels between 100 and 5,000 tons."),
            new TravellerSkillDisplay("Pilot(Capital Ships)","Battleships and other ships over 5,000 tons."),
            
            new TravellerSkillDisplay("Profession(Belter)","Mining asteroids for valuable ores and minerals"),
            new TravellerSkillDisplay("Profession(Biologicals)","Engineering and managing artificial organisms"),
            new TravellerSkillDisplay("Profession(Civil Engineering)","Designing structures and buildings."),
            new TravellerSkillDisplay("Profession(Construction)","Building orbital habitats and megastructures."),
            new TravellerSkillDisplay("Profession(Hydroponics)","Growing crops in hostile environments"),
            new TravellerSkillDisplay("Profession(Polymers)","Designing and using polymers."),

            new TravellerSkillDisplay("Recon","A Traveller trained in Recon is able to scout out dangers and spot threats, unusual objects or out of place people. Working Out the Routine of a Trio of Guard Patrols:Average (8+) Recon check (1D x 10 minutes, INT).Spotting the Sniper Before he Shoots You: Recon check (1D x 10 seconds, INT) opposed by Stealth (DEX) check."),
            
            new TravellerSkillDisplay("Science(Archaeology)","The study of ancient civilisations, including the previous Imperiums and Ancients. It also covers techniques of investigation and excavations."),
            new TravellerSkillDisplay("Science(Astronomy)","The study of stars and celestial pheonomena."),
            new TravellerSkillDisplay("Science(Biology)","The study of living organisms."),
            new TravellerSkillDisplay("Science(Chemistry)","The study of matter at the atomic, molecular, and macromolecular levels."),
            new TravellerSkillDisplay("Science(Cosmology)","The study of universe and its creation."),
            new TravellerSkillDisplay("Science(Cybernetics)","The study of blending living and synthetic life."),
            new TravellerSkillDisplay("Science(Economics)","The study of trade and markets."),
            new TravellerSkillDisplay("Science(Genetics)","The study of genetic codes and engineering."),
            new TravellerSkillDisplay("Science(History)","The study of the past, as seen through documents and records as opposed to physical artefacts."),
            new TravellerSkillDisplay("Science(Linguistics)","The study of languages."),
            new TravellerSkillDisplay("Science(Philosophy)","The study of beliefs and religions."),
            new TravellerSkillDisplay("Science(Physics)","The study of the fundamental forces."),
            new TravellerSkillDisplay("Science(Planetology)","The study of planet formation and evolution."),
            new TravellerSkillDisplay("Science(Psychology)","The study of thought and society."),
            new TravellerSkillDisplay("Science(Robotics)","The study of robot construction and use."),
            new TravellerSkillDisplay("Science(Sophontology)","The study of intelligent living creatures."),
            new TravellerSkillDisplay("Science(Voidolgy)","The study of the void, its powers and phenomena."),
            new TravellerSkillDisplay("Science(Xenology)","The study of alien life forms."),

            new TravellerSkillDisplay("Seafarer(Ocean Ships)","For motorised sea-going vessels. "),
            new TravellerSkillDisplay("Seafarer(Personal)","Used for very small waterborne craft such as canoes and rowboats."),
            new TravellerSkillDisplay("Seafarer(Sail)","This skill is for wind-driven watercraft."),
            new TravellerSkillDisplay("Seafarer(Submarine)","For vehicles that travel underwater."),
            
            new TravellerSkillDisplay("Stealth","A Traveller trained in the Stealth skill is adept at staying unseen, unheard, and unnoticed.Sneaking Past a Guard: Stealth check (1D x 10 seconds, DEX) opposed by Recon (INT) check.Avoiding Detection by a Security Patrol: Stealth check (1D minutes, DEX) opposed by Recon (INT) check."),
            new TravellerSkillDisplay("Steward","The Steward skill allows the Traveller to serve and care for nobles and high-class passengers. It covers everything from proper address and behaviour to cooking and tailoring, as well as basic management skills. A Traveller with the Steward skill is necessary on any ship offering High Passage. See Spacecraft Operations chapter for more details.Cooking a Fine Meal: Average (8+) Steward check (1D hours, EDU).Calming Down an Angry Duke who has Just Been Told you Will not be Jumping to his Destination on Time:Difficult (10+) Steward check (1D minutes, SOC)."),
            new TravellerSkillDisplay("Streetwise","A Traveller with the Streetwise skill understands the urban environment and the power structures in society. On his homeworld and in related systems, he knows criminal contacts and fixers. On other worlds, he can quickly intuit power structures and can fit into local underworlds.Finding a Dealer in Illegal Materials or Technologies:Average (8+) Streetwise check (1D x 10 hours, INT).Evading a Police Search: Streetwise check (1D x 10 minutes, INT) opposed by Recon (INT) check."),
            new TravellerSkillDisplay("Survival","The Survival skill is the wilderness counterpart of the urban Streetwise skill – the Traveller is trained to survive in the wild, build shelters, hunt or trap animals, avoid exposure and so forth. He can recognise plants and animals of his homeworld and related planets, and can pick up on common clues and traits even on unfamiliar worlds.Gathering Supplies in the Wilderness to Survive for a Week: Average (8+) Survival check (1D days, EDU).Identifying a Poisonous Plant: Average (8+) Survival check (1D x 10 seconds, INT or EDU)."),
            new TravellerSkillDisplay("Tactics(Military)","Co-ordinating the attacks of foot troops or vehicles on the ground."),
            new TravellerSkillDisplay("Tactics(Naval)","Co-ordinating the attacks of a spacecraft or fleet."),
            new TravellerSkillDisplay("Vacc Suit","The Vacc Suit skill allows a Traveller to wear and operate spacesuits and environmental suits. A Traveller will rarely need to make Vacc Suit checks under ordinary circumstances – merely possessing the skill is enough. If the Traveller does not have the requisite Vacc Suit skill for the suit he is wearing, he suffers DM-2 to all skill checks made while wearing a suit for each missing level. This skill also permits the character to operate advanced battle armour. Performing a Systems Check on Battle Dress: Average (8+) Vacc Suit check (1D minutes, EDU)."),
        };

        public List<TravellerSkillDisplay> GetTravellerSkills() => TravellerSkillLists;
    }
}
