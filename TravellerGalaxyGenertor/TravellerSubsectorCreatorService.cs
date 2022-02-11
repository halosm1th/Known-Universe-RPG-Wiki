using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using TravellerMapSystem;
using TravellerMapSystem.Worlds;

namespace TravellerGalaxyGenertor
{
    public class TravellerSubsectorCreatorService
    {
        public TravellerSubsectorCreatorService()
        {
            
        }

        public string CreateSubsectorFromData(string subsectorName, List<(string,string)> Locations, int extraWorldsinSystem, TravellerSubsectorGeneratorService generator)
        {
            KnownUniverseSubsector subsector = new KnownUniverseSubsector(subsectorName, Locations, extraWorldsinSystem);
            return generator.AddSubsector(subsector);
        }
    }
}