using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data
{
    public class TravellerNPC : TravellerCharacter
    {
        public TravellerAttribute Strength =>
            AttributeList.FirstOrDefault(attribute => attribute.AttributeName == TravellerAttributes.Strength);
        public TravellerAttribute Dexterity =>
            AttributeList.FirstOrDefault(attribute => attribute.AttributeName == TravellerAttributes.Dexterity);
        public TravellerAttribute Endurance =>
            AttributeList.FirstOrDefault(attribute => attribute.AttributeName == TravellerAttributes.Endurance);
        public TravellerAttribute Intelligence =>
            AttributeList.FirstOrDefault(attribute => attribute.AttributeName == TravellerAttributes.Intelligence);

        public TravellerAttribute Education =>
            AttributeList.FirstOrDefault(attribute => attribute.AttributeName == TravellerAttributes.Intelligence);

        public TravellerAttribute Social =>
            AttributeList.FirstOrDefault(attribute => attribute.AttributeName == TravellerAttributes.Intelligence);

        public string Background { get; set; }
        public string Career { get; set; }

        public string PatronText { get; set; }
        public string QuirkText { get; set; }

    }
}
