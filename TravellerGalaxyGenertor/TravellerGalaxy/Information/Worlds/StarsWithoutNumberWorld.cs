using Newtonsoft.Json;
using TravellerGalaxyGenertor.TravellerGalaxy.Interfaces;
using TravellerMapSystem.Tools;

namespace TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds
{
    public enum OriginOfWorld
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
    
    public enum CurrentRelationship
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

    public enum ContactPoint
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

    public enum Atmosphere
    {
        Corrosive,
        Inert,
        Airless_Or_Thin,
        Breathable,
        Thick,
        Invasive,
        Both_Corrosive_And_Invasive
    }

    public enum Temperature
    {
        Frozen,
        Cold,
        Variable_Cold,
        Temperate,
        Variable_Warm,
        Warm,
        Burning
    }
    
    public enum Biosphere {
        Remnant,
        Microbiol,
        No,
        Human_Miscible,
        Immiscible,
        Hybrid,
        Engineered
    }

    public enum Population
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
        public string Name { get; }
        [JsonProperty("WorldNumber")] public int WorldNumber { get; }
        //public StarsWithoutNumberWorldTag WorldTag { get; set; }
        public OriginOfWorld OriginOfWorld { get; set; }
        public CurrentRelationship CurrentRelationship { get; set; }
        public ContactPoint ContactPoint { get; set; }
        
        public Atmosphere Atmosphere { get; set; }
        
        public Temperature Temperature { get; set; }
        
        public Biosphere Biosphere { get; set; }
        public Population Population { get; set; }
        
        public int TechLevel { get; set; }

        public StarsWithoutNumberWorld(string name, int number)
        {
            Name = $"{name}.{number.ToString()}";
            WorldNumber = number;
            var generator = new GenerateStarsWithoutNumberWorld();
            generator.GenerateWorld(this);
        }
        
        public string WorldData()
        {
            return ($"Name: {Name}\n" +
                   //$"World Tag: {WorldTag}\n" +
                   $"------------------------\n" +
                   $"Atmosphere: {Atmosphere} ({GetAtmoSphereDescription()})\n" +
                   $"Temperature: {Temperature}\n" +
                   $"Biosphere: {Biosphere}\n" +
                   $"Population: {Population}\n" +
                   $"Tech Level:  {TechLevel}\n" +
                   $"------------------------\n" +
                   $"Origin of World: {OriginOfWorld}\n" +
                   $"Current Relationship: {CurrentRelationship}\n" +
                   $"Contact Point: {ContactPoint}\n").Replace("_"," ");
        }
        
        
        public string ShortDescription()
        {
            return ($"{Name} came from {OriginOfWorld}, to whom its current relationship is {CurrentRelationship} and the two are in contact because of: {ContactPoint}. " +
                   $"{Name}'s biosphere is {Biosphere}, and its atmosphere is {Atmosphere}. The temperature is usually {Temperature}. " +
                   $"Its population is {Population} and its tech level is {TechLevel}").Replace("_", " ");
        }

        private string GetAtmoSphereDescription()
            => Atmosphere switch
            {
                _ => "Mix"
            };

        public override string ToString()
        {
            return WorldData();
        }
    }
}