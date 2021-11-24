using System;
using System.Linq;
using TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds;
using TravellerGalaxyGenertor.TravellerGalaxy.Interfaces;

namespace TravellerMapSystem.Tools
{
    public class GenerateStarsWithoutNumberWorld  : IWorldGenerator
    {
        public GenerateStarsWithoutNumberWorld()
        {
            
        }

        public void GenerateWorld(IWorld worldToGenerate)
        {
            if (worldToGenerate == null) throw new NullReferenceException("Error, world is null");
            if (worldToGenerate.GetType() != typeof(StarsWithoutNumberWorld))
                throw new TypeAccessException("Error expects Stars without number world");

            var rand = new Random(worldToGenerate.Name.Aggregate(0, (h, t) => h + t));
            var world = worldToGenerate as StarsWithoutNumberWorld;

            //world.WorldTag = GenerateWorldTag(rand);
            
            world.Atmosphere = GenerateAtmosphere(rand);
            world.Temperature = GenerateTemperature(rand);
            world.Biosphere = GenerateBiosphere(rand);
            (world.PopulationOutline,world.Population) = GeneratePopulation(rand);
            world.TechLevel = GenerateTechLevel(rand,world.PopulationOutline);
            
            world.StarsWithoutNumberContactPoint = GenerateContactPoint(rand);
            world.StarsWithoutNumberCurrentRelationship = GenerateRelationship(rand);
            world.StarsWithoutNumberOriginOfWorld = GenerateOriginOfWorld(rand);
        }

        private int GenerateTechLevel(Random rand, StarsWithoutNumberPopulation pop)
        {
            var mod = pop switch
            {
                StarsWithoutNumberPopulation.Failed_Colony => -5,
                StarsWithoutNumberPopulation.Outpost => -2,
                StarsWithoutNumberPopulation.Fewer_Then_A_Million_Inhabitants => 0,
                StarsWithoutNumberPopulation.Several_Million_Inhabitants => +1,
                StarsWithoutNumberPopulation.Billions_Of_Inhabitants => +2,
                StarsWithoutNumberPopulation.Hundreds_Of_Millions_Of_Inhabitants => +3,
                StarsWithoutNumberPopulation.Alien_Inhabitants => +5,
                _ => 0
            };

            var tl = rand.Next(1, 15) + mod;
            return Math.Max(1, tl);
        }

        private (StarsWithoutNumberPopulation,string) GeneratePopulation(Random rand)
        {
            return rand.Next(2, 13) switch
            {
                2 => (StarsWithoutNumberPopulation.Failed_Colony, rand.Next(0,11).ToString()),
                3 => (StarsWithoutNumberPopulation.Outpost, rand.Next(1,101).ToString()),
                4 => (StarsWithoutNumberPopulation.Fewer_Then_A_Million_Inhabitants, rand.Next(100,500001).ToString()),
                5 => (StarsWithoutNumberPopulation.Fewer_Then_A_Million_Inhabitants, rand.Next(500000,1000000).ToString()),
                6 => (StarsWithoutNumberPopulation.Several_Million_Inhabitants, rand.Next(1000000,9000000).ToString()),
                7 => (StarsWithoutNumberPopulation.Several_Million_Inhabitants, rand.Next(10000000,50000000).ToString()),
                8 => (StarsWithoutNumberPopulation.Several_Million_Inhabitants,rand.Next(50000000,100000000).ToString()),
                9 => (StarsWithoutNumberPopulation.Hundreds_Of_Millions_Of_Inhabitants,rand.Next(100000000,500000000).ToString() ),
                10 => (StarsWithoutNumberPopulation.Hundreds_Of_Millions_Of_Inhabitants, rand.Next(500000000,1000000000).ToString()),
                11 => (StarsWithoutNumberPopulation.Billions_Of_Inhabitants, rand.Next(1000000000, 2139999999).ToString()),
                12 => (StarsWithoutNumberPopulation.Alien_Inhabitants, rand.Next(1,100000001).ToString() ),
                _ => (StarsWithoutNumberPopulation.Outpost,rand.Next(1,101).ToString() )
            };
        }

        private StarsWithoutNumberBiosphere GenerateBiosphere(Random rand)
        {
            return rand.Next(2, 13) switch
            {
                2 => StarsWithoutNumberBiosphere.Remnant,
                3 => StarsWithoutNumberBiosphere.Microbiol,
                4 => StarsWithoutNumberBiosphere.No,
                5 => StarsWithoutNumberBiosphere.No,
                6 => StarsWithoutNumberBiosphere.Human_Miscible,
                7 => StarsWithoutNumberBiosphere.Human_Miscible,
                8 => StarsWithoutNumberBiosphere.Human_Miscible,
                9 => StarsWithoutNumberBiosphere.Immiscible,
                10 => StarsWithoutNumberBiosphere.Immiscible,
                11 => StarsWithoutNumberBiosphere.Hybrid,
                12 => StarsWithoutNumberBiosphere.Engineered,
                _ => StarsWithoutNumberBiosphere.Human_Miscible
            };
        }

        private StarsWithoutNumberTemperature GenerateTemperature(Random rand)
        {
            return rand.Next(2, 13) switch
            {
                2 => StarsWithoutNumberTemperature.Frozen,
                3 => StarsWithoutNumberTemperature.Cold,
                4 => StarsWithoutNumberTemperature.Variable_Cold,
                5 => StarsWithoutNumberTemperature.Variable_Cold,
                6 => StarsWithoutNumberTemperature.Temperate,
                7 => StarsWithoutNumberTemperature.Temperate,
                8 => StarsWithoutNumberTemperature.Temperate,
                9 => StarsWithoutNumberTemperature.Variable_Warm,
                10 => StarsWithoutNumberTemperature.Variable_Warm,
                11 => StarsWithoutNumberTemperature.Warm,
                12 => StarsWithoutNumberTemperature.Burning,
                _ => StarsWithoutNumberTemperature.Temperate
            };
        }

        private StarsWithoutNumberAtmosphere GenerateAtmosphere(Random rand)
        {
            return rand.Next(2, 13) switch
            {
                 2 => StarsWithoutNumberAtmosphere.Corrosive,
                 3 => StarsWithoutNumberAtmosphere.Inert,
                 4 => StarsWithoutNumberAtmosphere.Airless_Or_Thin,
                 5 => StarsWithoutNumberAtmosphere.Breathable,
                 6 => StarsWithoutNumberAtmosphere.Breathable,
                 7 => StarsWithoutNumberAtmosphere.Breathable,
                 8 => StarsWithoutNumberAtmosphere.Breathable,
                 9 => StarsWithoutNumberAtmosphere.Breathable,
                 10 => StarsWithoutNumberAtmosphere.Thick,
                 11 => StarsWithoutNumberAtmosphere.Invasive,
                 12 => StarsWithoutNumberAtmosphere.Both_Corrosive_And_Invasive,
                 _ => StarsWithoutNumberAtmosphere.Breathable
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
    }
}