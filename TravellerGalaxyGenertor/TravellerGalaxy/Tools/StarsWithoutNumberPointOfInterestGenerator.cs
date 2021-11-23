using System;
using System.Linq;
using TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds;
using TravellerGalaxyGenertor.TravellerGalaxy.Interfaces;

namespace TravellerMapSystem.Tools
{
    public class StarsWithoutNumberPointOfInterestGenerator
    {
        public void GeneratePointOfInterest(IWorld worldToGenerate)
        {
            if (worldToGenerate == null) throw new NullReferenceException("Error the world was null!");
            if (worldToGenerate.GetType() != typeof(StarsWithoutNumberPointOfInterest))
                throw new TypeAccessException("Error, wrong type of world for this generator!");

            var world = worldToGenerate as StarsWithoutNumberPointOfInterest;
            var rand = new Random(world.Name.Aggregate(0, (h, t) => h + t));

            world.ContactPoint = GenerateContactPoint(rand);
            world.CurrentRelationship = GenerateRelationship(rand);
            world.OriginOfWorld = GenerateOriginOfWorld(rand);
            world.Population = GeneratePopulation(rand);

            world.LocationType = GenerateLocation(rand);
            world.OccupiedBy = GenerateOccupiedLocation(world.LocationType, rand);
            world.Situation = GenerateSituation(world.LocationType, rand);
            
            world.TechLevel = rand.Next(1, 16);
        }

        private string GenerateSituation(StarsWithoutNumberPoint worldLocationType, Random rand)
        {return worldLocationType switch
            {
                StarsWithoutNumberPoint.Deep_Space_station => rand.Next(1,6) switch{
                    1 => "Systems breaking down",
                    2 => "Foreign sabotage attempt",
                    3 => "Black market for the elite",
                    4 => "Vault for dangerous pretech",
                    5 => "Supply base for pirates",
                    _ => "Error"
                },
                StarsWithoutNumberPoint.Asteroid_Base => rand.Next(1,6) switch{
                    1 => "Life support is threatened",
                    2 => "Base needs a new asteroid",
                    3 => "Dug out something nasty",
                    4 => "Fighting another asteroid",
                    5 => "Hit a priceless vein of ore",
                    _ => "Error"
                },
                StarsWithoutNumberPoint.Remote_Moon_Base => rand.Next(1,6) switch{
                    1 => "Something dark has awoken",
                    2 => "Criminals trying to take over",
                    3 => "Moon plague breaking out",
                    4 => "Desperate for vital supplies",
                    5 => "Rich but badly-protected",
                    _ => "Error"
                },
                StarsWithoutNumberPoint.Ancient_Orbital_Ruin => rand.Next(1,6) switch{
                    1 => "Trying to stop it awakening",
                    2 => "Meddling with strange tech",
                    3 => "Impending tech calamity",
                    4 => "A terrible secret is unearthed",
                    5 => "Fighting outside interlopers",
                    _ => "Error"
                },
                StarsWithoutNumberPoint.Research_Base => rand.Next(1,6) switch{
                    1 => "Perilous research underway",
                    2 => "Hideously immoral research",
                    3 => "Held hostage by outsiders",
                    4 => "Science monsters run amok",
                    5 => "Selling black-market tech",
                    _ => "Error"
                },
                StarsWithoutNumberPoint.Asteroid_Belt => rand.Next(1,6) switch{
                    1 => "Ruptured rock released a peril",
                    2 => "Foreign spy ships hide there",
                    3 => "Gold rush for new minerals",
                    4 => "Ancient ruins dot the rocks",
                    5 => "War between rival rocks",
                    _ => "Error"
                },
                StarsWithoutNumberPoint.Gas_Giant_Mine => rand.Next(1,6) switch{
                    1 => "Things are emerging below",
                    2 => "They need vital supplies",
                    3 => "The workers are in revolt",
                    4 => "Pirates secretly fuel there",
                    5 => "Alien remnants were found",
                    _ => "Error"
                },
                StarsWithoutNumberPoint.Refueling_Station => rand.Next(1,6) switch{
                    1 => "A ship is in severe distress",
                    2 => "Pirates have taken over",
                    3 => "Has corrupt customs agents",
                    4 => "Foreign saboteurs are active",
                    5 => "Deep-space alien signal",
                    _ => "Error"
                },
                _ => "Error"
            };
        }

        private string GenerateOccupiedLocation(StarsWithoutNumberPoint worldLocationType, Random rand)
        {
            return worldLocationType switch
            {
                StarsWithoutNumberPoint.Deep_Space_station => rand.Next(1,6) switch{
                    1 => "Dangerously odd transhumans",
                    2 => "Freeze-dried ancient corpses",
                    3 => "Secretive military observers",
                    4 => "Eccentric oligarch and minions",
                    5 => "Deranged but brilliant scientist",
                    _ => "Error"
                },
                StarsWithoutNumberPoint.Asteroid_Base => rand.Next(1,6) switch{
                    1 => "Zealous religious sectarians",
                    2 => "Failed rebels from another world",
                    3 => "Wage-slave corporate miners",
                    4 => "Independent asteroid prospectors",
                    5 => "Pirates masquerading as otherwise",
                    _ => "Error"
                },
                StarsWithoutNumberPoint.Remote_Moon_Base => rand.Next(1,6) switch{
                    1 => "Unlucky corporate researchers",
                    2 => "Reclusive hermit genius",
                    3 => "Remnants of a failed colony",
                    4 => "Military listening post",
                    5 => "Lonely overseers and robot miners",
                    _ => "Error"
                },
                StarsWithoutNumberPoint.Ancient_Orbital_Ruin => rand.Next(1,6) switch{
                    1 => "Robots of dubious sentience",
                    2 => "Trigger-happy scavengers",
                    3 => "Government researchers",
                    4 => "Military quarantine enforcers",
                    5 => "Heirs of the original alien builders",
                    _ => "Error"
                },
                StarsWithoutNumberPoint.Research_Base => rand.Next(1,6) switch{
                    1 => "Experiments that have gotten loose",
                    2 => "Scientists from a major local corp",
                    3 => "Black-ops governmental researchers",
                    4 => "Secret employees of a foreign power",
                    5 => "Aliens studying the human locals",
                    _ => "Error"
                },
                StarsWithoutNumberPoint.Asteroid_Belt => rand.Next(1,6) switch{
                    1 => "Grizzled belter mine laborers",
                    2 => "Ancient automated guardian drones",
                    3 => "Survivors of destroyed asteroid base",
                    4 => "Pirates hiding out among the rocks",
                    5 => "Lonely military patrol base staff",
                    _ => "Error"
                },
                StarsWithoutNumberPoint.Gas_Giant_Mine => rand.Next(1,6) switch{
                    1 => "Miserable gas-miner slaves or serfs",
                    2 => "Strange robots and their overseers",
                    3 => "Scientists studying the alien life",
                    4 => "Scrappers in the ruined old mine",
                    5 => "Impoverished separatist group",
                    _ => "Error"
                },
                StarsWithoutNumberPoint.Refueling_Station => rand.Next(1,6) switch{
                    1 => "Half-crazed hermit caretaker",
                    2 => "Sordid purveyors of decadent fun",
                    3 => "Extortionate corporate minions",
                    4 => "Religious missionaries to travelers",
                    5 => "Brainless automated vendors",
                    _ => "Error"
                },
                _ => "Error"
            };
        }

        private StarsWithoutNumberPoint GenerateLocation(Random rand)
            => rand.Next(1, 9) switch{
                1 => StarsWithoutNumberPoint.Deep_Space_station,
                2 => StarsWithoutNumberPoint.Asteroid_Base,
                3 => StarsWithoutNumberPoint.Asteroid_Belt,
                4 => StarsWithoutNumberPoint.Ancient_Orbital_Ruin,
                5 => StarsWithoutNumberPoint.Research_Base,
                6 => StarsWithoutNumberPoint.Asteroid_Belt,
                7 => StarsWithoutNumberPoint.Gas_Giant_Mine,
                8 => StarsWithoutNumberPoint.Refueling_Station,
            _ => StarsWithoutNumberPoint.Refueling_Station
            };



        private string GeneratePopulation(Random rand)
        {
            return rand.Next(2, 13) switch
            {
                2 => rand.Next(0,11).ToString(),
                3 => rand.Next(1,101).ToString(),
                4 => rand.Next(100,500001).ToString(),
                5 => rand.Next(500000,1000000).ToString(),
                6 => rand.Next(1000000,9000000).ToString(),
                7 => rand.Next(10000000,50000000).ToString(),
                8 => rand.Next(50000000,100000000).ToString(),
                9 => rand.Next(100000000,500000000).ToString(),
                10 => rand.Next(500000000,1000000000).ToString(),
                11 => rand.Next(1000000000, 2139999999).ToString(),
                12 => rand.Next(1,100000001).ToString(),
                _ => rand.Next(1,101).ToString()
            };
        }
        
        private StarsWithoutNumberCurrentRelationship GenerateRelationship(Random rand)
        {
            return rand.Next(1, 9) switch
            {
                1 => StarsWithoutNumberCurrentRelationship.Confirmed_hatred_of_each_other,
                2 => StarsWithoutNumberCurrentRelationship.Active_cold_war_between_them,
                3 => StarsWithoutNumberCurrentRelationship.Old_grudges_or_resentments,
                4 => StarsWithoutNumberCurrentRelationship.Cultural_disgust_and_avoidance,
                5 => StarsWithoutNumberCurrentRelationship.Polite_interchange_and_trade,
                6 => StarsWithoutNumberCurrentRelationship.Cultural_admiration_for_primary,
                7 => StarsWithoutNumberCurrentRelationship.Long_standing_friendship,
                8 => StarsWithoutNumberCurrentRelationship.Unflinching_mutual_loyalty,
                _ => StarsWithoutNumberCurrentRelationship.Long_standing_friendship
            };
        }

        private StarsWithoutNumberContactPoint GenerateContactPoint(Random rand)
        {
            return rand.Next(1, 9) switch
            {
                1 => StarsWithoutNumberContactPoint.Trade_in_vital_goods,
                2 => StarsWithoutNumberContactPoint.Shared_religion,
                3 => StarsWithoutNumberContactPoint.Mutual_language,
                4 => StarsWithoutNumberContactPoint.Entertainment_content,
                5 => StarsWithoutNumberContactPoint.Shared_research,
                6 => StarsWithoutNumberContactPoint.Threat_to_both_of_them,
                7 => StarsWithoutNumberContactPoint.Shared_elite_families,
                8 => StarsWithoutNumberContactPoint.Exploiting_shared_resource,
                _ => StarsWithoutNumberContactPoint.Shared_elite_families
            };
        }
        
        
        private StarsWithoutNumberOriginOfWorld GenerateOriginOfWorld(Random rand)
        {
            return rand.Next(1, 9) switch
            {
                1 => StarsWithoutNumberOriginOfWorld.Recent_Colony_From_Primary_World,
                2 => StarsWithoutNumberOriginOfWorld.Refuge_For_Exiles_From_Primary,
                3 => StarsWithoutNumberOriginOfWorld.Founded_Ages_Ago_By_Different_Group,
                4 => StarsWithoutNumberOriginOfWorld.Founded_Long_Before_The_Primary_World,
                5 => StarsWithoutNumberOriginOfWorld.Lost_Ancient_Colony_Of_The_Primary,
                6 => StarsWithoutNumberOriginOfWorld.Colony_Recently_Torn_Free_Of_The_Primary,
                7 => StarsWithoutNumberOriginOfWorld.Long_Standing_Cooperative_Colony_World,
                8 => StarsWithoutNumberOriginOfWorld.Recent_Interstellar_Colony_From_Elsewhere,
                _ => StarsWithoutNumberOriginOfWorld.Founded_Long_Before_The_Primary_World
            };
        }
    }
}