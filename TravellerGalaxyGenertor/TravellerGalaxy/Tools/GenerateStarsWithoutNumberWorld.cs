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
            world.Population = GeneratePopulation(rand);
            world.TechLevel = GenerateTechLevel(rand,world.Population);
            
            world.ContactPoint = GenerateContactPoint(rand);
            world.CurrentRelationship = GenerateRelationship(rand);
            world.OriginOfWorld = GenerateOriginOfWorld(rand);
        }

        private int GenerateTechLevel(Random rand, Population pop)
        {
            var mod = pop switch
            {
                Population.Failed_Colony => -5,
                Population.Outpost => -2,
                Population.Fewer_Then_A_Million_Inhabitants => 0,
                Population.Several_Million_Inhabitants => +1,
                Population.Billions_Of_Inhabitants => +2,
                Population.Hundreds_Of_Millions_Of_Inhabitants => +3,
                Population.Alien_Inhabitants => +5,
                _ => 0
            };

            var tl = rand.Next(1, 15) + mod;
            return Math.Max(1, tl);
        }

        private Population GeneratePopulation(Random rand)
        {
            return rand.Next(2, 13) switch
            {
                2 => Population.Failed_Colony,
                3 => Population.Outpost,
                4 => Population.Fewer_Then_A_Million_Inhabitants,
                5 => Population.Fewer_Then_A_Million_Inhabitants,
                6 => Population.Several_Million_Inhabitants,
                7 => Population.Several_Million_Inhabitants,
                8 => Population.Several_Million_Inhabitants,
                9 => Population.Hundreds_Of_Millions_Of_Inhabitants,
                10 => Population.Hundreds_Of_Millions_Of_Inhabitants,
                11 => Population.Billions_Of_Inhabitants,
                12 => Population.Alien_Inhabitants,
                _ => Population.Outpost 
            };
        }

        private Biosphere GenerateBiosphere(Random rand)
        {
            return rand.Next(2, 13) switch
            {
                2 => Biosphere.Remnant,
                3 => Biosphere.Microbiol,
                4 => Biosphere.No,
                5 => Biosphere.No,
                6 => Biosphere.Human_Miscible,
                7 => Biosphere.Human_Miscible,
                8 => Biosphere.Human_Miscible,
                9 => Biosphere.Immiscible,
                10 => Biosphere.Immiscible,
                11 => Biosphere.Hybrid,
                12 => Biosphere.Engineered,
                _ => Biosphere.Human_Miscible
            };
        }

        private Temperature GenerateTemperature(Random rand)
        {
            return rand.Next(2, 13) switch
            {
                2 => Temperature.Frozen,
                3 => Temperature.Cold,
                4 => Temperature.Variable_Cold,
                5 => Temperature.Variable_Cold,
                6 => Temperature.Temperate,
                7 => Temperature.Temperate,
                8 => Temperature.Temperate,
                9 => Temperature.Variable_Warm,
                10 => Temperature.Variable_Warm,
                11 => Temperature.Warm,
                12 => Temperature.Burning,
                _ => Temperature.Temperate
            };
        }

        private Atmosphere GenerateAtmosphere(Random rand)
        {
            return rand.Next(2, 13) switch
            {
                 2 => Atmosphere.Corrosive,
                 3 => Atmosphere.Inert,
                 4 => Atmosphere.Airless_Or_Thin,
                 5 => Atmosphere.Breathable,
                 6 => Atmosphere.Breathable,
                 7 => Atmosphere.Breathable,
                 8 => Atmosphere.Breathable,
                 9 => Atmosphere.Breathable,
                 10 => Atmosphere.Thick,
                 11 => Atmosphere.Invasive,
                 12 => Atmosphere.Both_Corrosive_And_Invasive,
                 _ => Atmosphere.Breathable
            };
        }

        private OriginOfWorld GenerateOriginOfWorld(Random rand)
        {
            return rand.Next(1, 9) switch
            {
                1 => OriginOfWorld.Recent_Colony_From_Primary_World,
                2 => OriginOfWorld.Refuge_For_Exiles_From_Primary,
                3 => OriginOfWorld.Founded_Ages_Ago_By_Different_Group,
                4 => OriginOfWorld.Founded_Long_Before_The_Primary_World,
                5 => OriginOfWorld.Lost_Ancient_Colony_Of_The_Primary,
                6 => OriginOfWorld.Colony_Recently_Torn_Free_Of_The_Primary,
                7 => OriginOfWorld.Long_Standing_Cooperative_Colony_World,
                8 => OriginOfWorld.Recent_Interstellar_Colony_From_Elsewhere,
                _ => OriginOfWorld.Founded_Long_Before_The_Primary_World
            };
        }

        private CurrentRelationship GenerateRelationship(Random rand)
        {
            return rand.Next(1, 9) switch
            {
                1 => CurrentRelationship.Confirmed_hatred_of_each_other,
                2 => CurrentRelationship.Active_cold_war_between_them,
                3 => CurrentRelationship.Old_grudges_or_resentments,
                4 => CurrentRelationship.Cultural_disgust_and_avoidance,
                5 => CurrentRelationship.Polite_interchange_and_trade,
                6 => CurrentRelationship.Cultural_admiration_for_primary,
                7 => CurrentRelationship.Long_standing_friendship,
                8 => CurrentRelationship.Unflinching_mutual_loyalty,
                _ => CurrentRelationship.Long_standing_friendship
            };
        }

        private ContactPoint GenerateContactPoint(Random rand)
        {
            return rand.Next(1, 9) switch
            {
                1 => ContactPoint.Trade_in_vital_goods,
                2 => ContactPoint.Shared_religion,
                3 => ContactPoint.Mutual_language,
                4 => ContactPoint.Entertainment_content,
                5 => ContactPoint.Shared_religion,
                6 => ContactPoint.Threat_to_both_of_them,
                7 => ContactPoint.Shared_elite_families,
                8 => ContactPoint.Exploiting_shared_resource,
                _ => ContactPoint.Shared_elite_families
            };
        }
    }
}