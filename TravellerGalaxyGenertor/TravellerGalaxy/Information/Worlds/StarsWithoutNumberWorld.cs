using System.Numerics;
using Newtonsoft.Json;
using TravellerGalaxyGenertor.TravellerGalaxy.Interfaces;
using TravellerMapSystem.Tools;

namespace TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds
{
    public enum StarsWithoutNumberOriginOfWorld
    {
        Recent_Colony_From_Primary_World,
        Refuge_For_Exiles_From_Primary,
        Founded_Ages_Ago_By_Different_Group,
        Founded_Long_Before_The_Primary_World,
        Lost_Ancient_Colony_Of_The_Primary,
        Colony_Recently_Torn_Free_Of_The_Primary,
        Long_Standing_Cooperative_Colony_World,
        Recent_Interstellar_Colony_From_Elsewhere
    }

    public enum StarsWithoutNumberCurrentRelationship
    {
        Confirmed_hatred_of_each_other,
        Active_cold_war_between_them,
        Old_grudges_or_resentments,
        Cultural_disgust_and_avoidance,
        Polite_interchange_and_trade,
        Cultural_admiration_for_primary,
        Long_standing_friendship,
        Unflinching_mutual_loyalty
    }

    public enum StarsWithoutNumberContactPoint
    {
        Trade_in_vital_goods,
        Shared_religion,
        Mutual_language,
        Entertainment_content,
        Shared_research,
        Threat_to_both_of_them,
        Shared_elite_families,
        Exploiting_shared_resource
    }

    public enum StarsWithoutNumberAtmosphere
    {
        Corrosive,
        Inert,
        Airless_Or_Thin,
        Breathable,
        Thick,
        Invasive,
        Both_Corrosive_And_Invasive
    }

    public enum StarsWithoutNumberTemperature
    {
        Frozen,
        Cold,
        Variable_Cold,
        Temperate,
        Variable_Warm,
        Warm,
        Burning
    }

    public enum StarsWithoutNumberBiosphere
    {
        Remnant,
        Microbiol,
        No,
        Human_Miscible,
        Immiscible,
        Hybrid,
        Engineered
    }

    public enum StarsWithoutNumberPopulation
    {
        Failed_Colony,
        Outpost,
        Fewer_Then_A_Million_Inhabitants,
        Several_Million_Inhabitants,
        Hundreds_Of_Millions_Of_Inhabitants,
        Billions_Of_Inhabitants,
        Alien_Inhabitants
    }

    public class StarsWithoutNumberWorld : IWorld
    {
        public StarsWithoutNumberWorld(string name, int number)
        {
            Name = $"{name}.{number.ToString()}";
            WorldNumber = number;
            var generator = new GenerateStarsWithoutNumberWorld();
            generator.GenerateWorld(this);
        }

        //public StarsWithoutNumberWorldTag WorldTag { get; set; }
        public StarsWithoutNumberOriginOfWorld StarsWithoutNumberOriginOfWorld { get; set; }
        public StarsWithoutNumberCurrentRelationship StarsWithoutNumberCurrentRelationship { get; set; }
        public StarsWithoutNumberContactPoint StarsWithoutNumberContactPoint { get; set; }

        public StarsWithoutNumberAtmosphere Atmosphere { get; set; }

        public StarsWithoutNumberTemperature Temperature { get; set; }

        public StarsWithoutNumberBiosphere Biosphere { get; set; }
        public StarsWithoutNumberPopulation PopulationOutline { get; set; }
        public string Name { get; }
        [JsonProperty("WorldNumber")] public int WorldNumber { get; }
        public string WorldType => "SWN World";
        public string Population { get; set; }

        public int TechLevel { get; set; }

        public string WorldData()
        {
            return ($"Name: {Name}\n" +
                    //$"World Tag: {WorldTag}\n" +
                    "------------------------\n" +
                    $"Atmosphere: {Atmosphere} ({GetAtmoSphereDescription()})\n" +
                    $"Temperature: {Temperature} ({GetTemperatureDescription()})\n" +
                    $"Biosphere: {Biosphere}\n" +
                    $"Population: {PopulationOutline} ({Population})\n" +
                    $"Tech Level:  {TechLevel}\n" +
                    "------------------------\n" +
                    $"Origin of World: {StarsWithoutNumberOriginOfWorld}\n" +
                    $"Current Relationship: {StarsWithoutNumberCurrentRelationship}\n" +
                    $"Contact Point: {StarsWithoutNumberContactPoint}\n").Replace("_", " ");
        }


        public string ShortDescription()
        {
            return (
                    $"{Name} came from {StarsWithoutNumberOriginOfWorld}, to whom its current relationship is {StarsWithoutNumberCurrentRelationship} and the two are in contact because of: {StarsWithoutNumberContactPoint}. " +
                    $"{Name}'s biosphere is {Biosphere}, and its atmosphere is {Atmosphere}. The temperature is usually {Temperature}. " +
                    $"Its population is {BigInteger.Parse(Population).ToString("N0")} and its tech level is {TechLevel}")
                .Replace("_", " ");
        }

        public override string ToString()
        {
            return WorldData();
        }

        private string GetTemperatureDescription()
        {
            return Temperature switch
            {
                StarsWithoutNumberTemperature.Frozen => "Locked in perpetual ice",
                StarsWithoutNumberTemperature.Cold => "Dominated by glaciers and tundra",
                StarsWithoutNumberTemperature.Variable_Cold => "Cold with tempermate places",
                StarsWithoutNumberTemperature.Temperate => "Earthlike in its ranges",
                StarsWithoutNumberTemperature.Variable_Warm => "With temperate places",
                StarsWithoutNumberTemperature.Warm => "Tropical and hotter in places",
                StarsWithoutNumberTemperature.Burning => "Intolerably hot on its surface",
                _ => "Earthlike in its ranges"
            };
        }

        private string GetAtmoSphereDescription()
        {
            return Atmosphere switch
            {
                StarsWithoutNumberAtmosphere.Corrosive => "Corrosive, damaging to foreign objects",
                StarsWithoutNumberAtmosphere.Inert => "Inert gas, useless for respiration",
                StarsWithoutNumberAtmosphere.Airless_Or_Thin => "Airless or thin to the point of suffocation",
                StarsWithoutNumberAtmosphere.Breathable => "A breathable mix",
                StarsWithoutNumberAtmosphere.Thick => " Breathable with a pressure mask",
                StarsWithoutNumberAtmosphere.Invasive => "Penetrating suit seals",
                StarsWithoutNumberAtmosphere.Both_Corrosive_And_Invasive =>
                    "Both corrosive and invasive in its effects",
                _ => "Mix"
            };
        }
    }
}