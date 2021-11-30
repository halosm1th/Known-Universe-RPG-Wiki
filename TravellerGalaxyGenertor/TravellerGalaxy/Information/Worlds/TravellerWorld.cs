using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using Newtonsoft.Json;
using TravellerFactionSystem.FactionEnums;
using TravellerGalaxyGenertor.TravellerGalaxy.Interfaces;
using TravellerMapSystem.Tools;

namespace TravellerMapSystem.Worlds
{
    #region Enums!

    public enum StarportQuality
    {
        A = 10,
        B = 11,
        C = 12,
        D = 13,
        E = 14,
        X = 15
    }

    public enum WorldSize
    {
        Statation,
        Tiny_Moon,
        Moon,
        Tiny_World,
        Small_World,
        Medium_World,
        Medium_Large_World,
        Large_World,
        Really_Large_World,
        Huge_World,
        Massive_World
    }

    public enum WorldAtmosphere
    {
        None,
        Trace,
        Very_Thin_And_Tainted,
        Very_Thin,
        Thin_and_Tainted,
        Thin,
        Standard,
        Standard_and_Tainted,
        Dense_and_Tainted,
        Dense,
        Exotic,
        Corrosive,
        Insidious,
        Versy_Dense,
        Low,
        Unusual
    }


    public enum Quirks
    {
        Sexist,
        Religous,
        Artistic,
        Ritualised,
        Conservative,
        Xenophobic,

        Taboo,
        Deceptive,
        Liberal,
        Honourable,
        Influenced,
        Fusion,

        Barbaric,
        Remnant,
        Degenerate,
        Progressive,
        Recovering,
        Nexus,

        Tourist_Attraction,
        Violent,
        Peaceful,
        Obsessed,
        Fashion,
        At_War,

        Offworlders,
        Starport,
        Media,
        Technology,
        Lifecycle,
        Social_Standings,

        Trade,
        Nobility,
        Sex,
        Eating,
        Travel,
        Conspiracy
    }

    public enum Temperatures
    {
        Frozen,
        Cold,
        Temperate,
        Hot,
        Boiling,
        Error
    }


    public enum FactionSize
    {
        Obscure_Group,
        Fringe_Group,
        Minor_Group,
        Notable_Group,
        Significant_Group,
        Overwhealming_Popular_Support
    }

    #endregion

    public class TravellerWorld : IWorld
    {
        public string WorldData()
        {
            return $"Name: {Name}\n" +
                   $"UWP: {UWP}\n" +
                   "------------------------\n" +
                   $"Starport: {StarportDescription()}\n" +
                   $"World Size: {WorldSizeDescription()}\n" +
                   $"World atmosphere: {WorldAtmosphereDescrpition()}\n" +
                   $"World hydrographics: {WorldHydrographicsDescription()}\n" +
                   $"Population: {PopulationDescription()} ({PopulationStat})\n" +
                   $"Government Type: {GovernmentTypeDescrption()}\n" +
                   $"Law Level: {LawLevelDescription()}\n" +
                   $"Tech Level: {TechLevelDescription()}\n" +
                   "------------------------\n" +
                   $"Travel Warning: {TravelWarning()}\n" +
                   $@"Trade Codes:
                    {GetTradeCodes().Aggregate("", (h, t) =>
                    {
                        var sb = new StringBuilder(); sb.Append(h);
                        sb.Append(" ");
                        sb.Append(t);
                        sb.Append("\n");
                        return sb.ToString();
                    })}" +
                   "------------------------\n" +
                   $"Temperature: {GetTemperatureDescription()}\n" +
                   $"Quirk: {QuirkDescription()}\n" +
                   "------------------------\n" +
                   $@"Factions: {Factions.Aggregate("", (h, t) =>
                   {
                       var sb = new StringBuilder();
                       sb.Append(h); sb.Append("  "); sb.Append($"{GovernmentTypeDescrption(t.GovernmentType)}: {t.Strength} supported by: {t.Backer}\n"); return sb.ToString();
                   })}\n";
        }

        #region IWorld Requirements

        [JsonProperty("WorldName")] public string Name { get; set; }
        public string WorldType => "Traveller world";
        [JsonProperty("WorldNumber")] public int WorldNumber { get; }

        public override string ToString()
        {
            var gas = GasGiant ? 'Y' : 'N';
            var mil = MilitaryBase ? 'Y' : 'N';
            var oth = OtherBase ? 'Y' : 'N';
            var sq = StarportQuality.ToString("x");
            var ws = WorldSize.ToString("x");
            return $"{Name}: {UWP} " +
                   $"Gas: {gas} Military: {mil} Other: {oth}";
        }

        public string ShortDescription()
        {
            return (
                $"{Name} is a planet with a Class-{StarportQuality} starport. The world is a {WorldSize}, with an atmosphere which is {WorldAtmosphere}. " +
                $"The government is {ShortGovernmentTypeDescrption()}, which rules over {BigInteger.Parse(Population).ToString("N0")} people. " +
                $"The world has Law Level {LawLevel} and Tech Level {TechLevel}. " +
                $"The planets temperature is: {Temperature}, and the people are often {Quirk}.").Replace("_", " ");
        }

        #endregion

        #region Variables

        [JsonProperty("WorldControllingFaction")]
        public TravellerIslandsNations ControllingFaction { get; set; }

        public string UWP
        {
            get
            {
                string retString = "";

                var qal = StarportQuality;
                var size = ((int)WorldSize).ToString("X");
                var atmo = ((int)WorldAtmosphere).ToString("X");
                var hydo = WorldHydrographics.ToString("X");
                var pop = PopulationStat.ToString("X");
                var gov = GovernmentType.ToString("X");
                var law = LawLevel.ToString("X");
                var tech = TechLevel.ToString("X");

                retString = string.Format(new NumberFormatInfo(),
                    "{0}{1:X}{2:X}{3:X}{4:X}{5:X}{6:X}-{7:X}",
                    qal, size, atmo, hydo, pop, gov, law, tech);

                return retString.ToUpper();
            }
        }

        public string Stations
        {
            get
            {
                var military = MilitaryBase ? "+" : " ";
                var other = OtherBase ? "*" : " ";
                var gas = GasGiant ? "O" : " ";

                return $"{other} {gas} {military}";
            }
        }

        #endregion

        #region World Variables

        [JsonProperty("WorldStarportQuality")] public StarportQuality StarportQuality { get; set; }
        [JsonProperty("WorldSize")] public WorldSize WorldSize;
        [JsonProperty("WorldAtmosphere")] public WorldAtmosphere WorldAtmosphere { get; set; }
        [JsonProperty("WorldHydrographics")] public int WorldHydrographics { get; set; }

        [JsonProperty("WorldPopulation")] public int PopulationStat { get; set; }
        [JsonProperty("WorldFactionCount")] public int FactionCount => Factions.Count;

        [JsonProperty("WorldQuirk")] public Quirks Quirk { get; set; }

        [JsonProperty("WorldTemperature")] public Temperatures Temperature { get; set; }

        [JsonProperty("Factions")]
        public List<(int GovernmentType, FactionSize Strength, string Backer)> Factions { get; set; }

        [JsonProperty("Population")] public string Population { get; set; }

        public int GovernmentType { get; set; }
        public int LawLevel { get; set; }
        public int TechLevel { get; set; }
        public bool MilitaryBase { get; set; }
        public bool GasGiant { get; set; }
        public bool OtherBase { get; set; }

        #endregion

        #region Constuctor

        public TravellerWorld(string name, StarportQuality starportQuality, WorldSize worldSize,
            WorldAtmosphere worldAtmosphere,
            int worldHydrographics, int governmentType, int population, int lawLevel, int techLevel, Quirks quirk,
            Temperatures temperature,
            List<(int GovernmentType, FactionSize Strength, string Backer)> factions,
            bool militaryBase, bool gasGiant, bool otherBase, string ExactPop)
        {
            WorldSize = worldSize;
            Name = name;
            StarportQuality = starportQuality;
            WorldAtmosphere = worldAtmosphere;
            WorldHydrographics = worldHydrographics;
            Quirk = quirk;
            Temperature = temperature;
            Factions = factions;
            GovernmentType = governmentType;
            PopulationStat = population;
            LawLevel = lawLevel;
            TechLevel = techLevel;
            MilitaryBase = militaryBase;
            GasGiant = gasGiant;
            OtherBase = otherBase;
            Population = ExactPop;
        }

        public TravellerWorld(string worldText)
        {
            var generator = new GenerateTravellerWorld();
            generator.GenerateWorldFromText(this, worldText);
        }

        public TravellerWorld(string systemName, int worldNumber)
        {
            Name = $"{systemName}.{worldNumber.ToString()}";
            WorldNumber = worldNumber;

            var worldGenerator = new GenerateTravellerWorld();
            worldGenerator.GenerateWorld(this);
        }

        [JsonConstructor]
        public TravellerWorld()
        {
        }

        #endregion

        #region Descriptions

        public string StarportDescription()
        {
            return StarportQuality switch
            {
                StarportQuality.A =>
                    "Excellent Starport. 1D x Cr1000 to Berth. | Refined Fuel. | Shipyard(all) Repair Facilities. Check sheet for bases",
                StarportQuality.B =>
                    "Good Starport. 1D x Cr500 to Berth. | Refined Fuel. | Shipyard(Spacecraft) Repair Facilities. Check sheet for bases",
                StarportQuality.C =>
                    "Routine Starport. 1D x Cr100 to Berth. | Unrefined Fuel. | Shipyard(Small Craft) Repair Facilities. Check sheet for bases",
                StarportQuality.D =>
                    "Poor Starport. 1D x Cr10 to Berth. | Unrefined Fuel. | Limited Repair Facilities. Check sheet for bases",
                StarportQuality.E => "Frontier Starport. 0Cr to Berth. | No Fuel. | No Repair Facilities. No bases.",
                _ => "No Starport. No berthing Cost. | No facilities. | No bases"
            };
        }

        public string WorldSizeDescription()
        {
            return WorldSize switch
            {
                WorldSize.Statation =>
                    "Size of Less then 1000KM. | Examples Asteroid, Orbital Complex. | Negligible Gravity",
                WorldSize.Tiny_Moon => "Size of Roughly 1,600KM. | Example Triton. | 0.05 Gravity",
                WorldSize.Moon => "Size of Roughly 3,200KM. | Examples Luna, Europa. | 0.15 Gravity",
                WorldSize.Tiny_World => "Size of Roughly 4,800KM. | Examples Mercury, Ganymede. | 0.25 Gravity",
                WorldSize.Small_World => "Size of Roughly 6,400KM. | No listed example. | 0.35 Gravity",
                WorldSize.Medium_World => "Size of Roughly 8,000KM. | Example Mars. | 0.45 Gravity",
                WorldSize.Medium_Large_World => "Size of Roughly 9,600KM. | No Listed examples. | 0.7 Gravity",
                WorldSize.Large_World => "Size of Roughly 11,200KM. | Example Earth. 0.9 | Gravity",
                WorldSize.Really_Large_World => "Size of Roughly 12,800KM. | No Listed examples. | 1.0 Gravity",
                WorldSize.Huge_World => "Size of Roughly 14,400KM. | No Listed examples. | 1.25 Gravity",
                WorldSize.Massive_World => "Size of Roughly 16,000KM. | No Listed examples. | 1.4 Gravity",
                _ => "Error"
            };
        }

        public string WorldAtmosphereDescrpition()
        {
            return WorldAtmosphere switch
            {
                WorldAtmosphere.None =>
                    "Compostion: None. | Example Moon. | Pressure 0.00. | Survival Gear Required Vacc Suit.",
                WorldAtmosphere.Trace =>
                    "Compostion: Trace. | Example Mars. | Pressure 0.01 to 0.09. | Survival Gear Required Vacc Suit.",
                WorldAtmosphere.Very_Thin =>
                    "Compostion: Very Thin, Tainted. | Example None. | Pressure 0.1 to 0.42. | Survival Gear Required Respirator, Filter/",
                WorldAtmosphere.Very_Thin_And_Tainted =>
                    "Compostion: Very Thin. | Example None. | Pressure 0.1 to 0.42. | Survival Gear Required Respirator.",
                WorldAtmosphere.Thin_and_Tainted =>
                    "Compostion: Thin, Tainted. | Example None. | Pressure 0.43 to 0.7. | Survival Gear Required Filter.",
                WorldAtmosphere.Thin =>
                    "Compostion: Thin. | Example None. | Pressure 0.43 to 0.7. | Survival Gear Required None.",
                WorldAtmosphere.Standard =>
                    "Compostion: Standard. | Example Earth. | Pressure 0.71-1.49. | Survival Gear Required None.",
                WorldAtmosphere.Standard_and_Tainted =>
                    "Compostion: Standard, Tainted. | Example None. | Pressure 0.71-1.49. | Survival Gear Required Filter.",
                WorldAtmosphere.Dense =>
                    "Compostion: Dense. | Example None. | Pressure 1.5-2.49. | Survival Gear Required None.",
                WorldAtmosphere.Dense_and_Tainted =>
                    "Compostion: Dense, Tainted.  | Example None. | Pressure 1.5-2.49. | Survival Gear Required Filter.",
                WorldAtmosphere.Exotic =>
                    "Compostion: Exotic. | Example None. | Pressure Varies. | Survival Gear Required Air Supply..",
                WorldAtmosphere.Corrosive =>
                    "Compostion: Corrosive. | Example Venus. Pressure Varies. | Survival Gear Required Vacc Suit.",
                WorldAtmosphere.Insidious =>
                    "Compostion: Insidious. | Example None. Pressure Varies. | Survival Gear Required Vacc Suit.",
                WorldAtmosphere.Versy_Dense =>
                    "Compostion: Very Dense. | Example None. | Pressure 2.5+. | Survival Gear Required None",
                WorldAtmosphere.Low =>
                    "Compostion: Low. | Example None. | Pressure 0.5 or less. | Survival Gear Required None.",
                WorldAtmosphere.Unusual =>
                    "Compostion: Unusual. | Example None. | Pressure Varies. | Survival Gear Required Varies",
                _ => "Error"
            };
        }

        public string WorldHydrographicsDescription()
        {
            return WorldHydrographics switch
            {
                0 => "0-5%. | Desert World",
                1 => "5-15%. | Dry World",
                2 => "16-25%. | A few small seas.",
                3 => "25-35%. | Small seas and ocean worlds.",
                4 => "36-45%. | Wet World",
                5 => "46-55%. | Large Oceans.",
                6 => "56-65%. | Fucking Huge Oceans.",
                7 => "66-75%. | Earth-Like world.",
                8 => "76-85%. | Water World",
                9 => "86-95%. | Only a few small Islands and archipelagos.",
                10 => "96-100%. | Almost Entirely Water",
                _ => "0-5%. | Desert World"
            };
        }

        //Give us an actual size stat
        public string PopulationDescription()
        {
            return Population;
        }

        public string ShortGovernmentTypeDescrption()
        {
            return GovernmentType switch
            {
                0 => "None",
                1 => "Company/Corporation",
                2 => "Participating Democracy",
                3 => "Self-Perpetuating Oligarchy",
                4 => "Representative Democracy",
                5 => "Feudal Technocracy",
                6 => "Captive Government",
                7 => "Balkanisation",
                8 => "Civil Service Bureaucracy",
                9 => "Impersonal Bureaucracy",
                10 => "Charismatic Dictator",
                11 => "Non-Charismatic Leader",
                12 => "Charismatic Oligarchy",
                13 => "Religious Dicatorship",
                14 => "Religious Autocracy",
                15 => "Totalitarian Oligarchy",
                _ => "No idea"
            };
        }

        public string GovernmentTypeDescrption()
        {
            return GovernmentType switch
            {
                0 =>
                    "None. | No Government stucture, in many cases family bonds predominate. | Examples: Family, clan, anarchy. | No contraband",
                1 =>
                    "Company/Corporation. | Ruling functions are assumed by a copmany managerial elite, and most citzenry are company employees or dependants. | Examples: Corporate outpost, asteroid mine, feudal domain. | Contraband: Weapons, Drugs, Travellers.",
                2 =>
                    "Participating Democracy. | Ruling function are reach by the advice and consent of the citzenry directly. | Collective, tribval council, commlinked consensus. | Common contraband includes drugs.",
                3 =>
                    "Self-Perpetuating Oligarchy. | Ruling functions are performed by a restricted minority, with little or no input from the mass of citizenry. | Plutocracy, hereditary ruling caste. | Trachnology, weapons, travellers.",
                4 =>
                    "Representative Democracy. | Ruling functions are performed by elected representatives. | Republic, democracy. | Drugs, Weapons, Psiconics.",
                5 =>
                    "Feudal Technocracy. | Ruling functions are performed by specific individuals for persons who agree to be ruled by them. Relationships are based on the performance of technical activities which are mutually beneficial. | Those with accesss to higher technology tend to have higher social status. | Technology, weapons, computers.",
                6 =>
                    "Captive Government. | Ruling functions are performed by an imposed leadership answerable to an outside group. | A colony or conquored area. | Contraband includes weapons, technology, travellers.",
                7 =>
                    "Balkanisation. | No central authority exists; rival governments complete for control. Law level refers to the government nearest the starport. | Multiple governments, civil war. | Various contraband.",
                8 =>
                    "Civil Service Bureaucracy. | Ruling functions are performed by government agencies employing individuals selected for their expertise. | Examples: Technocracy, Communism. | Contraband includes drugs and weapons.",
                9 =>
                    "Impersonal Bureaucracy. | Ruling functions are performed by agencies which have become insulated from the governed citizens. | Entrenched castes of bureacrats. Decaying empire. | Contraband includes Technology, weapons, drugs, travellers, psiconics.",
                10 =>
                    "Charismatic Dictator. | Ruling functions are performed by agencies directed by a single leader who enjoys the overwhelming confidence of the citizens. | Revolutionary leader, messiah, emperor. | No contraband",
                11 =>
                    "Non-Charismatic Leader. | A previous charismatic dictator has been replaced by a leader through normal channels. | Military dictatorship, hereditary kingship. | Contraband: weapons, technology, computers.",
                12 =>
                    "Charismatic Oligarchy. | Ruling functions are performed by a select group of members of an organisation or class which enjoys the overwhelming confidence of the citizenry. | Examples: Junta, revolution council. | Contraband: weapons",
                13 =>
                    "Religious Dicatorship. | Ruling functions are performed by a religious organisation without regard to the specific individual needs of the citizenry. | Examples: Cult, transcendent philosophy, psionic gorup mind. | Contraband varies",
                14 =>
                    "Religious Autocracy. | Government by a single religious leader having absolute power over the citizenry. | Example: Messiah. | Various contraband",
                15 =>
                    "Totalitarian Oligarchy. | Government by an all-powerful minority which maintains absolute control through widespread coercion and oppresion. | Examples: World church, ruthless corporation. | Varies",
                _ => "No idea."
            };
        }

        public string GovernmentTypeDescrption(int governmentType)
        {
            return governmentType switch
            {
                0 =>
                    "None. | No Government stucture, in many cases family bonds predominate. | Examples: Family, clan, anarchy. | No contraband",
                1 =>
                    "Company/Corporation. | Ruling functions are assumed by a copmany managerial elite, and most citzenry are company employees or dependants. | Examples: Corporate outpost, asteroid mine, feudal domain. | Contraband: Weapons, Drugs, Travellers.",
                2 =>
                    "Participating Democracy. | Ruling function are reach by the advice and consent of the citzenry directly. | Collective, tribval council, commlinked consensus. | Common contraband includes drugs.",
                3 =>
                    "Self-Perpetuating Oligarchy. | Ruling functions are performed by a restricted minority, with little or no input from the mass of citizenry. | Plutocracy, hereditary ruling caste. | Trachnology, weapons, travellers.",
                4 =>
                    "Representative Democracy. | Ruling functions are performed by elected representatives. | Republic, democracy. | Drugs, Weapons, Psiconics.",
                5 =>
                    "Feudal Technocracy. | Ruling functions are performed by specific individuals for persons who agree to be ruled by them. Relationships are based on the performance of technical activities which are mutually beneficial. | Those with accesss to higher technology tend to have higher social status. | Technology, weapons, computers.",
                6 =>
                    "Captive Government. | Ruling functions are performed by an imposed leadership answerable to an outside group. | A colony or conquored area. | Contraband includes weapons, technology, travellers.",
                7 =>
                    "Balkanisation. | No central authority exists; rival governments complete for control. Law level refers to the government nearest the starport. | Multiple governments, civil war. | Various contraband.",
                8 =>
                    "Civil Service Bureaucracy. | Ruling functions are performed by government agencies employing individuals selected for their expertise. | Examples: Technocracy, Communism. | Contraband includes drugs and weapons.",
                9 =>
                    "Impersonal Bureaucracy. | Ruling functions are performed by agencies which have become insulated from the governed citizens. | Entrenched castes of bureacrats. Decaying empire. | Contraband includes Technology, weapons, drugs, travellers, psiconics.",
                10 =>
                    "Charismatic Dictator. | Ruling functions are performed by agencies directed by a single leader who enjoys the overwhelming confidence of the citizens. | Revolutionary leader, messiah, emperor. | No contraband",
                11 =>
                    "Non-Charismatic Leader. | A previous charismatic dictator has been replaced by a leader through normal channels. | Military dictatorship, hereditary kingship. | Contraband: weapons, technology, computers.",
                12 =>
                    "Charismatic Oligarchy. | Ruling functions are performed by a select group of members of an organisation or class which enjoys the overwhelming confidence of the citizenry. | Examples: Junta, revolution council. | Contraband: weapons",
                13 =>
                    "Religious Dicatorship. | Ruling functions are performed by a religious organisation without regard to the specific individual needs of the citizenry. | Examples: Cult, transcendent philosophy, psionic gorup mind. | Contraband varies",
                14 =>
                    "Religious Autocracy. | Government by a single religious leader having absolute power over the citizenry. | Example: Messiah. | Various contraband",
                15 =>
                    "Totalitarian Oligarchy. | Government by an all-powerful minority which maintains absolute control through widespread coercion and oppresion. | Examples: World church, ruthless corporation. | Varies",
                _ => "No idea."
            };
        }

        public string LawLevelDescription()
        {
            return LawLevel switch
            {
                0 => "Weapons Banned: No restrictions - Heavy armour and a handy weapon are commended...",
                1 =>
                    "Weapons Banned: Poison gas, explosives, undetectable weapons, WMD. | Armour Banned: Battle dress.",
                2 => "Weapons Banned: Portable energy and laser weapons. | Armour Banned: Combat armour.",
                3 => "Weapons Banned: Military Weapons. | Armour Banned: Flak.",
                4 => "Weapons Banned: Light assault weapons and submachine guns. | Armour Banned: Cloth.",
                5 => "Weapons Banned: Personal concealable weapons. | Armour Banned: Mesh.",
                6 =>
                    "Weapons Banned: All firearms except shotguns & stunners; carrying weapons discouraged. | Armour Banned: No New Items.",
                7 => "Weapons Banned: Shotguns. | Armour Banned: No New Items.",
                8 => "Weapons Banned: All bladed weapons, stunners. | Armour Banned: All visible armour.",
                _ => "Weapons Banned: All Weapons. | Armour Banned: All armour."
            };
        }

        public string TechLevelDescription()
        {
            return TechLevel switch
            {
                0 =>
                    "(Primitive): No technology. TL 0 species have only discovered the simplest tools and principles, and are on a par with Earth’s Stone Age.",
                1 =>
                    "(Primitive): Roughly on a par with Bronze or Iron age technology. TL 1 science is mostly superstition, but they can manufacture weapons and work metals.",
                2 =>
                    "(Primitive): Renaissance technology. TL 2 brings with it a greater understanding of chemistry, physics, biology and astronomy as well as the scientific method. ",
                3 =>
                    "(Primitive): The advances of TL 2 are now applied, bringing the germ of industrial revolution and steam power. Primitive firearms now dominate the battlefield. This is roughly comparable to the early 19th century.",
                4 =>
                    "(Industrial): The transition to industrial revolution is complete, bringing plastics, radio and other such inventions. Roughly comparable to the late 19th/early 20th century.",
                5 =>
                    "(Industrial): TL 5 brings widespread electrification, tele-communications and internal combustion. At the high end of the TL, atomics and primitive computing appear. Roughly on a par with the mid-20th century.",
                6 =>
                    "(Industrial): TL 6 brings the development of fission power and more advanced computing. Advances in materials technology and rocketry bring about the dawn of the space age. ",
                7 =>
                    "(Pre-Stellar): A pre-stellar society can reach orbit reliably and has telecommunications satellites. Computers become common. At the time of writing, humanity is currently somewhere between TL 7 and TL 8.",
                8 =>
                    "(Pre-Stellar): At TL 8, it is possible to reach other worlds in the same system, although terraforming or full colonisation are not within the culture’s capacity. Permanent space habitats become possible. Fusion power becomes commercially viable.",
                9 =>
                    "(Pre-Stellar): The defining element of TL 9 is the development of gravity manipulation, which makes space travel vastly safer and faster. This research leads to development of the jump drive, which occurs near the end of this Tech Level. TL 9 cultures can colonise other worlds, although travelling to a colony is often a one-way trip.",
                10 =>
                    "(Early Stellar): With the advent of commonly available jump drives, nearby systems are opened up. Orbital habitats and factories become common. Interstellar travel and trade lead to an economic boom. Colonies become much more viable.",
                11 =>
                    "(Early Stellar): The first true artificial intelligences become possible, as computers are able to model synaptic networks. Grav-supported structures reach to the heavens. Jump 2 travel becomes possible, allowing easier travel beyond the one jump stellar mains. ",
                12 =>
                    "(Average Stellar): Weather control revolutionises terraforming and agriculture. Man-portable plasma weapons and carrier-mounted fusion guns make the battlefield untenable for unarmoured combatants. Jump 3 travel is developed. ",
                13 =>
                    "(Average Stellar): The battle dress appears on the battlefield in response to the new weapons. Cloning of body parts becomes easy. Advances in hull design and thruster plates means that spacecraft can easily go underwater. Jump 4 travel.",
                14 => "(Average Stellar): Fusion weapons become man-portable. Flying cities appear. Jump 5 travel.",
                15 =>
                    " (High Stellar): Black globe generators suggest a new direction for defensive technologies, while the development of synthetic anagathics means that the human lifespan is now vastly increased. Jump 6 travel.",
                _ => "I didn't code this far"
            };
        }

        public List<string> GetTradeCodes()
        {
            var tradeCodes = new List<Func<string>>
            {
                () =>
                {
                    return (int)WorldAtmosphere > 3 && (int)WorldAtmosphere < 9 && WorldHydrographics > 3 &&
                           WorldHydrographics < 9 && PopulationStat > 4 && PopulationStat < 8
                        ? "(Ag)riculture: Dedicated to farming and food production. Often, they are divided into vast semi-feudal estates."
                        : "";
                },
                () =>
                {
                    return
                        WorldAtmosphere == 0 && WorldAtmosphere == 0 && WorldHydrographics == 0
                            ? "(As)teroids: Usually mining colonies, but can also be orbital factories or colonies."
                            : "";
                },
                () =>
                {
                    return PopulationStat == 0 && GovernmentType == 0 && LawLevel == 0
                        ? "(Ba)rren: Uncolonised and empty."
                        : "";
                },
                () =>
                {
                    return (int)WorldAtmosphere >= 2 && WorldHydrographics == 0
                        ? "(De)sert: Dry and barely habitable"
                        : "";
                },
                () =>
                {
                    return (int)WorldAtmosphere >= 10 && WorldHydrographics >= 1
                        ? "(Fl)uid Oceans: Worlds where the surface liquid is something other than water, and so are incompatible with Earth-derived life"
                        : "";
                },
                () =>
                {
                    return (int)WorldSize > 5 && (int)WorldSize < 9
                                              && ((int)WorldAtmosphere == 5 || (int)WorldAtmosphere == 6 ||
                                                  (int)WorldAtmosphere == 8) && WorldHydrographics >= 5 &&
                                              WorldHydrographics <= 7
                        ? "(Ga)rden: Worlds that are like earth"
                        : "";
                },
                () => { return PopulationStat >= 9 ? "(Hi)gh population: A population in the billions" : ""; },
                () =>
                {
                    return TechLevel >= 12
                        ? "(Ht)High Tech: Among the most technologically advanced in Charted Space"
                        : "";
                },
                () =>
                {
                    return (WorldAtmosphere == 0 || (int)WorldAtmosphere == 1)
                           && WorldHydrographics > 1
                        ? "(Ie)Ice-Capped: Worlds that have most of their surface liquid frozen in polar ice caps, and are cold and dry."
                        : "";
                },
                () =>
                {
                    return PopulationStat >= 9 &&
                           (WorldAtmosphere >= 0 && (int)WorldAtmosphere <= 2
                            || (int)WorldAtmosphere == 4 || (int)WorldAtmosphere == 7 || (int)WorldAtmosphere == 9)
                        ? "(In)dustrial: Dominated by factories and cities."
                        : "";
                },
                () =>
                {
                    return PopulationStat <= 3 ? "(Lo)w population: A population of only a few thousand or less." : "";
                },
                () =>
                {
                    return TechLevel <= 5 ? "(Lt)Low tech: Pre-industrial and cannot produce advanced goods." : "";
                },
                () =>
                {
                    return WorldAtmosphere >= 0 && (int)WorldAtmosphere <= 3 && WorldHydrographics >= 0 &&
                           WorldHydrographics <= 3 && PopulationStat >= 6
                        ? "(Na) Non-Agricultural: Too dry or barren to support their populations using conventional food production."
                        : "";
                },
                () =>
                {
                    return PopulationStat <= 6 && PopulationStat >= 0
                        ? "(Ni) Non-Industrial: Too low in population to maintain an extensive industrial base. "
                        : "";
                },
                () =>
                {
                    return (int)WorldAtmosphere >= 2 && (int)WorldAtmosphere <= 5 && WorldHydrographics >= 0 &&
                           WorldHydrographics <= 3
                        ? "(Po)or: Lacking resources, viable land or sufficient population to be anything other than marginal colonies."
                        : "";
                },
                () =>
                {
                    return ((int)WorldAtmosphere == 6 || (int)WorldAtmosphere == 8) && PopulationStat >= 6 &&
                           PopulationStat <= 8 && GovernmentType >= 4 && GovernmentType <= 9
                        ? "(Ri)ch: Blessed with a stable government and viable."
                        : "";
                },
                () => { return WorldAtmosphere == 0 ? "(Va)cuum: No atmosphere." : ""; },
                () =>
                {
                    return WorldHydrographics >= 10
                        ? "(Wa)ter World: Almost entirely water-ocean across their surface."
                        : "";
                }
            };

            var tradeCode = new List<string>();
            foreach (var trade in tradeCodes)
            {
                var result = trade();
                if (result != "") tradeCode.Add(trade());
            }

            return tradeCode;
        }

        private bool TravelWarning()
        {
            return (int)WorldAtmosphere > 10 || GovernmentType == 0 || GovernmentType == 7 || GovernmentType == 10 ||
                   LawLevel == 0 || LawLevel >= 9;
        }

        public string QuirkDescription()
        {
            return QuirkText(Quirk);
        }

        private string QuirkText(Quirks quirk)
        {
            switch (quirk)
            {
                case Quirks.Sexist:
                    return "Sexist - one gender is considered subservient or inferior to the other.";
                case Quirks.Religous:
                    return
                        "Religious - culture is heavily influenced by a religion or belief systems, possibly one unique to this world.";
                case Quirks.Artistic:
                    return
                        "Artistic - art and culture are highly prized. Aesthetic design is important in all artefacts produced on world.";
                case Quirks.Ritualised:
                    return
                        "Ritualised - social interaction and trade is highly formalised. Politeness and adherence to traditional forms is considered very important.";
                case Quirks.Conservative:
                    return "Conservative - the culture resists change and outside influences. ";
                case Quirks.Xenophobic:
                    return
                        "Xenophobic - the culture distrusts outsiders and alien influences. Offworlders will face considerable prejudice.";

                case Quirks.Taboo:
                    return
                        "Taboo - a particular topic is forbidden and cannot be discussed. Travellers who unwittingly mention this topic will be ostracised.";
                case Quirks.Deceptive:
                    return
                        "Deceptive - trickery and equivocation are considered acceptable. Honesty is a sign of weakness.";
                case Quirks.Liberal:
                    return
                        "Liberal - the culture welcomes change and offworld influence. Travellers who bring new and strange ideas will be welcomed.";
                case Quirks.Honourable:
                    return "Honourable - one’s word is one’s bond in the culture. Lying is both rare and despised.";
                case Quirks.Influenced:
                    return
                        "Influenced - the culture is heavily influenced by another, neighbouring world. Roll again for a cultural quirk that has been inherited from the culture.";
                case Quirks.Fusion:
                    return
                        "Fusion - the culture is a merger of two distinct cultures. Roll again twice to determine the quirks inherited from these cultures. If the quirks are incompatible, then the culture is likely divided.";

                case Quirks.Barbaric:
                    return
                        "Barbaric - physical strength and combat prowess are highly valued in the culture. Travellers may be challenged to a fight, or dismissed if they seem incapable of defending themselves. Sports tend towards the bloody and violent.";
                case Quirks.Remnant:
                    return
                        "Remnant - the culture is a surviving remnant of a once-great and vibrant civilisation, clinging to its former glory. The world is filled with crumbling ruins, and every story revolves around the good old days.";
                case Quirks.Degenerate:
                    return
                        "Degenerate - the culture is falling apart and is on the brink of war or economic collapse. Violent protests are common, and the social order is decaying. ";
                case Quirks.Progressive:
                    return
                        "Progressive - the culture is expanding and vibrant. Fortunes are being made in trade; science is forging bravely ahead.";
                case Quirks.Recovering:
                    return
                        "Recovering - a recent trauma, such as a plague, war, disaster or despotic regime has left scars on the culture.";
                case Quirks.Nexus:
                    return "Nexus - members of many different cultures and species visit here.";

                case Quirks.Tourist_Attraction:
                    return
                        "Tourist Attraction - some aspect of the culture or the planet draws visitors from all over charted space. ";
                case Quirks.Violent:
                    return
                        "Violent - physical conflict is common, taking the form of duels, brawls or other contests. Trial by combat is a part of their judicial system.";
                case Quirks.Peaceful:
                    return
                        "Peaceful - physical conflict is almost unheard-of. The culture produces few soldiers, and diplomacy reigns supreme. Forceful Travellers will be ostracised.";
                case Quirks.Obsessed:
                    return
                        "Obsessed - everyone is obsessed with or addicted to a substance, personality, act or item. This monomania pervades every aspect of the culture.";
                case Quirks.Fashion:
                    return
                        "Fashion - fine clothing and decoration are considered vitally important in the culture. Underdressed Travellers have no standing here.";
                case Quirks.At_War:
                    return
                        "At war - the culture is at war, either with another planet or polity, or is troubled by terrorists or rebels.";

                case Quirks.Offworlders:
                    return
                        "Unusual Custom: Offworlders - space travellers hold a unique position in the culture’s mythology or beliefs, and travellers will be expected to live up to these myths.";
                case Quirks.Starport:
                    return
                        "Unusual Custom:  Starport - the planet’s starport is more than a commercial centre; it might be a religious temple, or be seen as highly controversial and surrounded by protestors.";
                case Quirks.Media:
                    return
                        "Unusual Custom: Media - news agencies and telecommunications channels are especially strange here. Getting accurate information may be difficult.";
                case Quirks.Technology:
                    return
                        "Unusual Customs: Technology - the culture interacts with technology in an unusual way. Telecommunications might be banned, robots might have civil rights, or cyborgs might be property.";
                case Quirks.Lifecycle:
                    return
                        "Unusual Customs: Lifecycle - there might be a mandatory age of termination, or anagathics might be widely used. Family units might be different, with children being raised by the state or banned in favour of cloning.";
                case Quirks.Social_Standings:
                    return
                        "Unusual Customs: Social Standings - the culture has a distinct caste system. Travellers of a low social standing who do not behave appropriately will face punishment.";

                case Quirks.Trade:
                    return
                        "Unusual Customs: Trade - the culture has an odd attitude towards some aspect of commerce, which may interfere with trade at the spaceport. For example, merchants might expect a gift as part of a deal, or some goods may only be handled by certain families.";
                case Quirks.Nobility:
                    return
                        "Unusual Customs: Nobility - those of high social standing have a strange custom associated with them; perhaps nobles are blinded, or must live in gilded cages, or only serve for a single year before being exiled.";
                case Quirks.Sex:
                    return
                        "Unusual Customs: Sex - the culture has an unusual attitude towards intercourse and reproduction. Perhaps cloning is used instead, or sex is used to seal commercial deals.";
                case Quirks.Eating:
                    return
                        "Unusual Customs: Eating - food and drink occupies an unusual place in the culture. Perhaps eating is a private affair, or banquets and formal dinners are seen as the highest form of politeness.";
                case Quirks.Travel:
                    return
                        "Unusual Customs: Travel - travellers may be distrusted or feted, or perhaps the culture frowns on those who leave their homes. ";
                case Quirks.Conspiracy:
                    return
                        "Unusual Custom: Conspiracy - something strange is going on. The government is being subverted by another group or agency.";
            }

            return "";
        }

        public string GetTemperatureDescription()
        {
            return GetTemperatureText(Temperature);
        }

        private string GetTemperatureText(Temperatures temp)
        {
            switch (temp)
            {
                case Temperatures.Frozen:
                    return
                        "Frozen | Average Temperate <-51 | Frozen World. No liquid water, very dry atmosphere";
                case Temperatures.Cold:
                    return
                        "Cold | Average Temperature -51 - 0| Icy World. Little liquid water, extensive ice caps, few clouds";
                case Temperatures.Temperate:
                    return
                        "Temperate | Average Temperature 0-30 | Temperate world. Earth-Like. Liquid & vaporised water are common. Moderate icecaps";
                case Temperatures.Hot:
                    return
                        "Hot | Average Temperature 31-80 | Hot world. Small or no ice caps, little liquid water. most water in hte form of clouds.";
                case Temperatures.Boiling:
                    return "Boiling | Average Temperature 81+ | Boiling world. No ice caps, little liquid water";
                case Temperatures.Error:
                    return
                        "There is an error in the TAS records for this planet. Consult your referee for more information";
            }

            return "Error in temperature code.";
        }

        #endregion
    }
}