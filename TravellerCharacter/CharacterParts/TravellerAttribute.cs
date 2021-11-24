using System.Text;
using Newtonsoft.Json;

namespace TravellerCharacter.CharacterParts
{
    public enum TravellerAttributes
    {
        Strength,
        Dexterity,
        Endurance,
        Intelligence,
        Education,
        Social,
        Psionics,
        Sanity
    }

    public class TravellerAttribute
    {

        [JsonProperty]
        public TravellerAttributes AttributeName { get; }
        
        [JsonProperty]
        public int AttributableValue { get; set; }
        
        
        [JsonIgnore]
        public string AttributeHex => AttributableValue.ToString("X");
        
        
        [JsonIgnore]
        public int AttributeModifier => AttributableValue switch
        {
            -3 => -3,
            -2 => -3,
            -1 => -3,
            0 => -3,
            1 => -2,
            2 => -2,
            3 => -1,
            4 => -1,
            5 => -1,
            6 => +0,
            7 => +0,
            8 => +0,
            9 => +1,
            10 => +1,
            11 => +1,
            12 => +2,
            13 => +2,
            14 => +2,
            15 => +3,
            16 => +3,
            17 => +3,
            18 => +4,
            19 => +4,
            20 => +4,
            21 => +5,
            22 => +5,
            23 => +5,
            24 => +6,
            25 => +6,
            26 => +6,
            27 => +7,
            28 => +7,
            29 => +7,
            30 => +8,
            31 => +8,
            32 => +8,
            33 => +9,
            34 => +9,
            35 => +9,
            36 => +10,
            37 => +10,
            38 => +10,
            39 => +11,
            40 => +11,
            41 => +11,
            42 => +12,
            43 => +12,
            44 => +12,
            45 => +13,
            46 => +13,
            47 => +13,
            48 => +14,
            49 => +14,
            50 => +14,
            51 => +15,
            52 => +15,
            53 => +15,
            _ => +16
        };

        public TravellerAttribute(TravellerAttributes attributeName, int attributableValue)
        {
            AttributeName = attributeName;
            AttributableValue = attributableValue;
        }

        public void ModifyStat(int amount)
        {
            AttributableValue += amount;
        }


        public string GetShortName()
            => AttributeName switch
            {
                TravellerAttributes.Strength => "Str",
                TravellerAttributes.Dexterity => "Dex",
                TravellerAttributes.Endurance => "End",
                TravellerAttributes.Intelligence => "Int",
                TravellerAttributes.Education => "Edu",
                TravellerAttributes.Social => "Soc",
                TravellerAttributes.Psionics => "Psi",
                TravellerAttributes.Sanity => "San",
                _ => "Error"
            };

        public bool IsPhysical() =>
            AttributeName switch
            {

                TravellerAttributes.Strength => true,
                TravellerAttributes.Dexterity => true,
                TravellerAttributes.Endurance => true,
                _ => false
            };

        public bool IsMental() =>
            AttributeName switch
            {
                TravellerAttributes.Intelligence => true,
                TravellerAttributes.Education => true,
                TravellerAttributes.Social => true,
                TravellerAttributes.Psionics=> true,
                TravellerAttributes.Sanity => true,
                _ => false
            };


        public string ToStringLongName()
        {
            var sb = new StringBuilder();
            sb.Append(AttributeName);
            sb.Append(": ");
            sb.Append(AttributableValue);
            sb.Append(" [");
            sb.Append(AttributeModifier < 0 ? AttributeModifier.ToString() : $"+{AttributeModifier}");
            sb.Append("]");
            return sb.ToString();
        }

        public string ToNicelyPutAttribute()
        {
            return AttributeModifier switch
            {
                -3 => "Horrible",
                -2 => "Bad",
                -1 => "Not so great",
                0 => "Average",
                1 => "Alright",
                2 => "Pretty good",
                3 => "Good",
                4 => "Great",
                5 => "Amazing",
                _ => "Out of Bounds"
            };
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(GetShortName());
            sb.Append(": ");
            if (AttributableValue >= 10)
            {
                sb.Append(AttributableValue);
            }
            else
            {
                sb.Append(" 0");
                sb.Append(AttributableValue);
            }

            sb.Append(" [");
            sb.Append(AttributeModifier < 0 ? AttributeModifier.ToString() : $"+{AttributeModifier}");
            sb.Append("]");
            return sb.ToString();
        }
    }
}