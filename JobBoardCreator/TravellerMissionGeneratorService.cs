using System;
using System.Collections.Generic;
using System.Text;

namespace JobBoardCreator
{
    public class TravellerMissionGeneratorService
    {
        public TravellerMission GenerateTravellerMission()
        {
            var ally = AllyOrEnemy(GetRandomNumber());
            var enemy = AllyOrEnemy(GetRandomNumber());
            var patron = RandomPatron(GetRandomNumber());
            var patronQuirk = CharcterQuirks(GetRandomNumber());
            var target = RandomTarget(GetRandomNumber());
            var targetQuirk = CharcterQuirks(GetRandomNumber());
            var opposition = RandomOpposition(GetRandomNumber());
            var mission = RandomMission(GetRandomNumber());

            return new TravellerMission(ally,enemy,patron,patronQuirk,target,targetQuirk,opposition,mission);
        }

        public string AllyOrEnemy(int number)
            => number switch
            {
                11 => "Naval Officer",
                12 => "Imperial Diplomat",
                13 => "Crooked Trader",
                14 => "Medical Doctor",
                15 => "Eccentric Scientist",
                16 => "Mercenary",
                21 => "Famous Performer",
                22 => "Alien Thief",
                23 => "Free Trader",
                24 => "Explorer",
                25 => "Marine Captain",
                26 => "Corporate Executive",
                31 => "Researcher",
                32 => "Cultural Attaché",
                33 => "Religious Leader",
                34 => "Conspirator",
                35 => "Rich Noble",
                36 => "Artificial Intelligence",
                41 => "Bored Noble",
                42 => "Planetary Governor",
                43 => "Inveterate Gambler",
                44 => "Crusading Journalist",
                45 => "Doomsday Cultist",
                46 => "Corporate Agent",
                51 => "Criminal Syndicate",
                52 => "Military Governor ",
                53 => "Army Quartermaster",
                54 => "Private Investigator",
                55 => "Starport Administrator",
                56 => "Retired Admiral",
                61 => "Alien Ambassador",
                62 => "Smuggler",
                63 => "Weapons Inspector",
                64 => "Elder Statesman",
                65 => "Planetary Warlord",
                66 => "Imperial Agent",
                _ => ""
            };
        public string CharcterQuirks(int number)
            => number switch
            {
                11 => "Loyal",
                12 => "Distracted by other worries",
                13 => "In debt to criminals",
                14 => "Makes very bad jokes",
                15 => "Will betray characters",
                16 => "Aggressive",
                21 => "Has secret allies",
                22 => "Secret anagathic user",
                23 => "Looking for something",
                24 => "Helpful",
                25 => "Forgetful",
                26 => "Wants to hire the Travellers",
                31 => "Has useful contacts",
                32 => "Artistic",
                33 => "Easily confused",
                34 => "Unusually ugly",
                35 => "Worried about current situation",
                36 => "Shows pictures of his children",
                41 => "Rumour-monger",
                42 => "Unusually provincial",
                43 => "Drunkard or drug addict",
                44 => "Government informant",
                45 => "Mistakes a Traveller for someone else",
                46 => "Possesses unusually advanced technology",
                51 => "Unusually handsome or beautiful",
                52 => "Spying on the Travellers",
                53 => "Possesses TAS membership",
                54 => "Is secretly hostile towards the Travellers",
                55 => "Wants to borrow money",
                56 => "Is convinced the Travellers are dangerous",
                61 => "Involved in political intrigue",
                62 => "Has a dangerous secret",
                63 => "Wants to get off planet as soon as possible",
                64 => "Attracted to a Traveller ",
                65 => "From offworld",
                66 => "Possesses telepathy or other unusual quality",
                _ => ""
            };
        public string RandomOpposition(int number)
            => number switch
            {
                11 => "Animals",
                12 => "Large animal",
                13 => "Bandits & thieves",
                14 => "Fearful peasants",
                15 => "Local authorities",
                16 => "Local lord",
                21 => "Criminals – thugs or corsairs",
                22 => "Criminals – thieves or saboteurs",
                23 => "Police – ordinary security forces",
                24 => "Police – inspectors & detectives",
                25 => "Corporate - agents",
                26 => "Corporate – legal",
                31 => "Starport security",
                32 => "Imperial marines",
                33 => "Interstellar corporation",
                34 => "Alien – private citizen or corporation",
                35 => "Alien – government ",
                36 => "Space travellers or rival ship ",
                41 => "Target is in deep space",
                42 => "Target is in orbit",
                43 => "Hostile weather conditions",
                44 => "Dangerous organisms or radiation",
                45 => "Target is in a dangerous region",
                46 => "Target is in a restricted area",
                51 => "Target is under electronic observation",
                52 => "Hostile guard robots or ships",
                53 => "Biometric identification required",
                54 => "Mechanical failure or computer hacking",
                55 => "Travellers are under surveillance",
                56 => "Out of fuel or ammunition",
                61 => "Police investigation",
                62 => "Legal barriers",
                63 => "Nobility",
                64 => "Government officials ",
                65 => "Target is protected by a third party",
                66 => "Hostages",
                _ => ""
            };
        public string RandomPatron(int number)
            => number switch
            {
                11 => "Assassin",
                12 => "Smuggler",
                13 => "Terrorist",
                14 => "Embezzler",
                15 => "Thief",
                16 => "Revolutionary",
                21 => "Clerk",
                22 => "Administrator",
                23 => "Mayor",
                24 => "Minor Noble",
                25 => "Physician",
                26 => "Tribal Leader",
                31 => "Diplomat",
                32 => "Courier",
                33 => "Spy",
                34 => "Ambassador",
                35 => "Noble",
                36 => "Police Officer",
                41 => "Merchant",
                42 => "Free Trader",
                43 => "Broker",
                44 => "Corporate Executive",
                45 => "Corporate Agent",
                46 => "Financier",
                51 => "Belter",
                52 => "Researcher",
                53 => "Naval Officer",
                54 => "Pilot",
                55 => "Starport Administrator",
                56 => "Scout",
                61 => "Alien",
                62 => "Playboy",
                63 => "Stowaway",
                64 => "Family Relative",
                65 => "Agent of a Foreign Power",
                66 => "Imperial Agent",
                _ => ""
            };
        public string RandomTarget(int number)
            => number switch
            {
                11 => "Common Trade Goods",
                12 => "Common Trade Goods",
                13 => "Random Trade Goods",
                14 => "Random Trade Goods",
                15 => "Illegal Trade Goods",
                16 => "Illegal Trade Goods",
                21 => "Computer Data",
                22 => "Alien Artefact",
                23 => "Personal Effects",
                24 => "Work of Art",
                25 => "Historical Artefact",
                26 => "Weapon",
                31 => "Starport",
                32 => "Asteroid Base",
                33 => "City",
                34 => "Research station ",
                35 => "Bar or Nightclub",
                36 => "Medical Facility",
                41 => RandomPatron(GetRandomNumber()),
                42 => RandomPatron(GetRandomNumber()),
                43 => RandomPatron(GetRandomNumber()),
                44 => AllyOrEnemy(GetRandomNumber()),
                45 => AllyOrEnemy(GetRandomNumber()),
                46 => AllyOrEnemy(GetRandomNumber()),
                51 => "Local Government",
                52 => "Planetary Government",
                53 => "Corporation",
                54 => "Imperial Intelligence",
                55 => "Criminal Syndicate",
                56 => "Criminal Gang",
                61 => "Free Trader",
                62 => "Yacht",
                63 => "Cargo Hauler",
                64 => "Police Cutter",
                65 => "Space Station ",
                66 => "Warship",
                _ => ""
            };

        private static Random rand = new Random();
        public int GetRandomNumber()
        {
            var tens = rand.Next(1, 7) * 10;
            var ones = rand.Next(1, 7);
            return tens + ones;
        }
        public string RandomMission(int number)
            => number switch
            {
                11 => "Assassinate a target",
                12 => "Frame a target",
                13 => "Destroy a target ",
                14 => "Steal from a target",
                15 => "Aid in a burglary",
                16 => "Stop a burglary",
                21 => "Retrieve data or an object from a secure facility",
                22 => "Discredit a target",
                23 => "Find a lost cargo",
                24 => "Find a lost person",
                25 => "Deceive a target",
                26 => "Sabotage a target",
                31 => "Transport goods",
                32 => "Transport a person ",
                33 => "Transport data",
                34 => "Transport goods secretly",
                35 => "Transport goods quickly",
                36 => "Transport dangerous goods",
                41 => "Investigate a crime",
                42 => "Investigate a theft",
                43 => "Investigate a murder",
                44 => "Investigate a mystery",
                45 => "Investigate a target",
                46 => "Investigate an event",
                51 => "Join an expedition",
                52 => "Survey a planet",
                53 => "Explore a new system",
                54 => "Explore a ruin",
                55 => "Salvage a ship",
                56 => "Capture a creature ",
                61 => "Hijack a ship",
                62 => "Entertain a noble",
                63 => "Protect a target",
                64 => "Save a target",
                65 => "Aid a target",
                66 => "It is a trap – the Patron intends to betray the Traveller",
                _ => "Error!"
            };
    }
}
