﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerWiki.Data.Charcters;

namespace TravellerWiki.Data.Charcters
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


        public string UPP()
        {
            var sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(" - ");
            sb.Append(Strength.AttributeHex);
            sb.Append(Dexterity.AttributeHex);
            sb.Append(Endurance.AttributeHex);
            sb.Append(Intelligence.AttributeHex);
            sb.Append(Education.AttributeHex);
            sb.Append(Social.AttributeHex);
            return sb.ToString();
        }

        private string NPCBackgroundAndCareer()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Background);
            sb.Append(", ");
            sb.Append(Career);

            return sb.ToString();
        }

        private string NPCTextAndQuirk()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(PatronText);
            sb.Append(", ");
            sb.Append(QuirkText);

            return sb.ToString();
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(UPP());
            sb.Append(" - ");

            sb.Append(NPCBackgroundAndCareer());
            sb.Append(" - ");

            sb.Append(NPCTextAndQuirk());

            return sb.ToString();
        }

    }
}
