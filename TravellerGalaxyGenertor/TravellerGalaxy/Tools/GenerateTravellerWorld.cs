using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TravellerFactionSystem;
using TravellerGalaxyGenertor.TravellerGalaxy.Interfaces;
using TravellerMapSystem.Worlds;

namespace TravellerMapSystem.Tools
{
    class GenerateTravellerWorld : IWorldGenerator
    {
        
        private static Random die = new Random();
        private int Roll2D6(int modifier = 0, int bottom = 2, int top = 13)
        {
            return die.Next(bottom, top) - modifier;
        }

        /// <summary>
        /// Does not work
        /// </summary>
        /// <param name="world"></param>
        /// <param name="uwp"></param>
        public void GenerateWorldFromText(TravellerWorld world, string uwp)
        {/*
            //Example:Longleaf 1:2 a36b3f4 - e YNY
            var parts = uwp.Split(' ');
            if (parts.Length < 4)
            {
                throw new ArgumentException("not enough args");
            }

            var name = parts[0];
            var code = parts[2];
            var stations = parts[3];

            world.Name = name;

            if (stations[0] == 'Y') world.GasGiant = true;
            if (stations[1] == 'Y') world.MilitaryBase = true;
            if (stations[2] == 'Y') world.OtherBase = true;

            for (int i = 0; i < code.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        if (code[i] == 'x' || code[i] == 'X')
                        {
                            world.StarportQuality = 15;
                        }

                        else
                        {
                            world.StarportQuality = int.Parse(code[i].ToString(), NumberStyles.HexNumber);
                        }
                        break;
                    case 1:
                        world.WorldSize = int.Parse(code[i].ToString(), NumberStyles.HexNumber);
                        break;
                    case 2:
                        world.WorldAtmosphere= int.Parse(code[i].ToString(), NumberStyles.HexNumber);
                        break;
                    case 3:
                        world.WorldHydrographics = int.Parse(code[i].ToString(), NumberStyles.HexNumber);
                        break;
                    case 4:
                        world.Popuation = int.Parse(code[i].ToString(), NumberStyles.HexNumber);
                        break;
                    case 5:
                        world.GovernmentType = int.Parse(code[i].ToString(), NumberStyles.HexNumber);
                        break;
                    case 6:
                        world.LawLevel = int.Parse(code[i].ToString(), NumberStyles.HexNumber);
                        break;
                    case 8:
                        var letter = code[i].ToString();
                        world.TechLevel = int.Parse(letter, NumberStyles.HexNumber);
                        break;
                }

            }
            */
        }

        private StarportQuality CalculateStarport(TravellerWorld world)
        {
            int modifier = 0;

            if (world.PopulationStat >= 8)
            {
                modifier += 1;
            }
            else if (world.PopulationStat >= 10)
            {
                modifier += 2;
            }
            else if (world.PopulationStat <= 4)
            {
                modifier -= 1;
            }
            else if (world.PopulationStat <= 2)
            {
                modifier -= 2;
            }

            var rVal = 0;
            var result = Roll2D6(modifier);
            if (result <= 2) rVal = 15;
            else if (result == 3 || result == 4) rVal = 14;
            else if (result == 5 || result == 4) rVal = 13;
            else if (result == 7 || result == 4) rVal = 12;
            else if (result == 9 || result == 4) rVal = 11;
            else rVal = 10;

            return (StarportQuality)rVal;
        }
        private int GetTechModifiers(TravellerWorld world)
        {
            int modifier;
            switch (world.StarportQuality)
            {
                case StarportQuality.A:
                    modifier = 6;
                    break;
                case StarportQuality.B:
                    modifier = 4;
                    break;
                case StarportQuality.C:
                    modifier = 2;
                    break;
                case StarportQuality.D:
                    modifier = -4;
                    break;
                default:
                    modifier = 0;
                    break;
            }

            switch (world.WorldSize)
            {
                case 0:
                case WorldSize.Tiny_Moon:
                    modifier = 2;
                    break;
                case WorldSize.Tiny_World:
                case WorldSize.Small_World:
                    modifier = 1;
                    break;
                default:
                    modifier = 0;
                    break;
            }

            switch ((int)world.WorldAtmosphere)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    modifier = 1;
                    break;
                default:
                    modifier = 0;
                    break;
            }

            switch (world.WorldHydrographics)
            {
                case 0:
                case 9:
                    modifier = 1;
                    break;
                case 10:
                    modifier = 2;
                    break;
                default:
                    modifier = 0;
                    break;
            }

            switch (world.PopulationStat)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 8:
                    modifier = 1;
                    break;
                case 9:
                    modifier = 2;
                    break;
                case 10:
                    modifier = 4;
                    break;
                default:
                    modifier = 0;
                    break;
            }

            switch (world.GovernmentType)
            {
                case 0:
                case 5:
                case 7:
                    modifier = 1;
                    break;
                case 13:
                case 14:
                    modifier = -2;
                    break;
                default:
                    modifier = 0;
                    break;
            }

            return 0 - modifier;
        }
        
         private Quirks GenerateQuirk()
        {
            var quirks = Enum.GetValues(typeof(Quirks));
            return (Quirks)die.Next(0, quirks.Length);
        }

        private Temperatures GenerateTemperature(TravellerWorld world)
        {
            var roll = Roll2D6();
            GetWorldTemperatureModifier(world,ref roll);

            switch (roll)
            {
                case 0:
                case 1:
                case 2:
                    return Temperatures.Frozen;
                case 3:
                case 4:
                    return Temperatures.Cold;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return Temperatures.Temperate;
                case 10:
                case 11:
                    return
                        Temperatures.Hot;
                case 12:
                    return Temperatures.Boiling;
            }

            return Temperatures.Error;
        }

        
        private int _factionCount = 0;
        private void GenerateInitialFactionCount(TravellerWorld world)
        {
            var rand = die;
            _factionCount = rand.Next(1, 4);
            if (world.GovernmentType == 0 || world.GovernmentType == 7) _factionCount++;
            else if (world.GovernmentType == 10) _factionCount--;
        }

        private List<(int, FactionSize, string)> GenerateFactions(TravellerWorld world)
        {
            var factions = new List<(int, FactionSize, string)>();
            GenerateInitialFactionCount(world);
            for (int i = 0; i < _factionCount; i++)
            {
                var travFac = new TravellerFactionService();
                var faction =  travFac.Factions[Roll2D6(0, 0, travFac.Factions.Count)] ?? null;
                factions.Add((Roll2D6(0,0,16), GetFactionStrengthFromNumber(die.Next(0, 6)), faction?.FactionName ?? "unknown"));
            }

            return factions;
        }

        private FactionSize GetFactionStrengthFromNumber(int number)
        {
            switch (number)
            {
                case 0: return FactionSize.Obscure_Group;
                case 1: return FactionSize.Fringe_Group;
                case 2: return FactionSize.Minor_Group;
                case 3: return FactionSize.Notable_Group;
                case 4: return FactionSize.Significant_Group;
                case 5: return FactionSize.Overwhealming_Popular_Support;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void GetWorldTemperatureModifier(TravellerWorld world,ref int numb)
        {
            switch ((int)world.WorldAtmosphere)
            {
                case 2:
                case 3:
                    numb -= 2;
                    break;
                case 4:
                case 5:
                case 14:
                    numb -= 1;
                    break;
                case 6:
                case 7:
                    numb += 0;
                    break;
                case 8:
                case 9:
                    numb += 1;
                    break;
                case 10:
                case 13:
                case 15:
                    numb += 2;
                    break;
                case 11:
                case 12:
                    numb += 6;
                    break;
            }
        }

        public void GenerateWorld(IWorld worldToGenerate)
        {
            if (worldToGenerate.GetType() != typeof(TravellerWorld))
                throw new TypeAccessException("Error expects traveller world!");

            if (worldToGenerate == null) throw new NullReferenceException("Expects non null world!");
            
            var world = worldToGenerate as TravellerWorld;
            
            world.WorldSize = (WorldSize)Math.Max(0, Roll2D6(2));
            world.WorldAtmosphere = (WorldAtmosphere)Math.Max(0, world.WorldSize <= 0 ? 0 : Roll2D6((int)world.WorldSize - 7));
            world.WorldHydrographics = Math.Max(0, world.WorldAtmosphere <= 0 ? 0 : Roll2D6((int)world.WorldAtmosphere - 7));

            world.PopulationStat = Math.Max(0, Roll2D6(2));
            world.GovernmentType = Math.Max(0, Roll2D6(world.PopulationStat - 7));
            world.LawLevel = Math.Max(0, Roll2D6(world.GovernmentType - 7));

            world.StarportQuality = CalculateStarport(world);
            world.TechLevel = Math.Max(0, Roll2D6(GetTechModifiers(world), 1, 7));

            world.GasGiant = Roll2D6() <= 10;
            world.MilitaryBase = Roll2D6() >= 8;
            world.OtherBase = Roll2D6() >= 8;
            world.Quirk = GenerateQuirk();
            world.Temperature = GenerateTemperature(world);
            world.Factions = GenerateFactions(world);
            
            var r = new Random(world.Name.Aggregate(0, (h,t) => h+t));
            var size = "";
            size += r.Next(0, 10);
            for (int i = 0; i < world.PopulationStat-1; i++)
            {
                size += r.Next(0,9);
            }

            world.Population = size;
        }
    }
}