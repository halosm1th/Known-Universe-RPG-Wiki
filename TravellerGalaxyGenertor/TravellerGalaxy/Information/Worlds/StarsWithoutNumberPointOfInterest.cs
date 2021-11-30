using System.Numerics;
using TravellerGalaxyGenertor.TravellerGalaxy.Interfaces;
using TravellerMapSystem.Tools;

namespace TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds
{
    public class StarsWithoutNumberPointOfInterest : IWorld
    {
        public StarsWithoutNumberPointOfInterest(string name, int number)
        {
            Name = $"{name}.{number}";
            WorldNumber = number;
            var generator = new StarsWithoutNumberPointOfInterestGenerator();
            generator.GeneratePointOfInterest(this);
        }

        public StarsWithoutNumberOriginOfWorld OriginOfWorld { get; set; }
        public StarsWithoutNumberCurrentRelationship CurrentRelationship { get; set; }
        public StarsWithoutNumberContactPoint ContactPoint { get; set; }

        public StarsWithoutNumberPoint LocationType { get; set; }
        public string OccupiedBy { get; set; }
        public string Situation { get; set; }
        public string WorldType => "Point of Interest";
        public string Name { get; }
        public string Population { get; set; }
        public int TechLevel { get; set; }
        public int WorldNumber { get; }

        public string WorldData()
        {
            return ($"Name: {Name}\n" +
                    $"Location Type: {LocationType}\n" +
                    $"Occupied By: {OccupiedBy}\n" +
                    $"Situation: {Situation}\n" +
                    $"Origin: {OriginOfWorld}\n" +
                    $"Relationship to Prime: {CurrentRelationship}\n" +
                    $"Contact Point: {ContactPoint}\n" +
                    $"Population: {BigInteger.Parse(Population).ToString("N0")}\n" +
                    $"Tech Level: {TechLevel}\n")
                .Replace("_", " ");
        }

        public string ShortDescription()
        {
            return (
                    $"{Name} is a {LocationType} which is occupied by {OccupiedBy}, who are dealing with {Situation}. " +
                    $"The origin of this place is {OriginOfWorld}, and it relationship to the prime world {CurrentRelationship}. " +
                    $"The two contact each other regarding {ContactPoint}. " +
                    $"{Name} has a population of {BigInteger.Parse(Population).ToString("N0")} and a tech level of {TechLevel}")
                .Replace("_", " ");
        }
    }

    public enum StarsWithoutNumberPoint
    {
        Deep_Space_station,
        Asteroid_Base,
        Remote_Moon_Base,
        Ancient_Orbital_Ruin,
        Research_Base,
        Asteroid_Belt,
        Gas_Giant_Mine,
        Refueling_Station
    }
}