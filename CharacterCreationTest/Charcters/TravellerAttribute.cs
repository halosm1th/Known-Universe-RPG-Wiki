using System.Text;

namespace TravellerWiki.Data.Charcters
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

        public TravellerAttributes AttributeName { get; }
        public int AttributableValue { get; set; }

        public string AttributeHex => AttributableValue.ToString("X");

        public int AttributeModifier => AttributableValue switch
        {
            0 => -3,
            1 => -2,
            2 => -2,
            3 => -1,
            4 => -1,
            5 => -1,
            6 => 0,
            7 => 0,
            8 => 0,
            9 => 1,
            10 => 1,
            11 => 1,
            12 => 2,
            13 => 2,
            14 => 2,
            15 => 3,
            16 => 3,
            17 => 3,
            18 => 4,
            19 => 4,
            20 => 4,
            21 => 5,
            22 => 5,
            23 => 5,
            _ => -3
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

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(GetShortName());
            sb.Append(": ");
            sb.Append(AttributableValue);
            sb.Append("[");
            sb.Append(AttributeModifier);
            sb.Append("]");
            return sb.ToString();
        }
    }
}