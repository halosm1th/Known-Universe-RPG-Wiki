using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellerWiki.Data
{
    public class TravellerCompany
    {

        public string Name { get; }
        public string HeadquatersLocation { get; }
        public string InsideNation { get; }

        public TravellerCompany(string name, string headquatersLocation, string insideNation)
        {
            Name = name;
            HeadquatersLocation = headquatersLocation;
            InsideNation = insideNation;
        }
    }
}
