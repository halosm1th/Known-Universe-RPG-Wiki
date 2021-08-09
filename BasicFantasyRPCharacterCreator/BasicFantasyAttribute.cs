namespace BasicFantasyRPCharacterCreator
{
    public class BasicFantasyAttribute
    {
        public BasicFantasyAttribute(BasicFantasyAttributes attribute, int value)
        {
            Attribute = attribute;
            Value = value;
        }

        public BasicFantasyAttributes Attribute { get; set; }
        public int Value { get; set; }
        public int Mod => Value switch
        {
            3 => -3,
            4 => -2,
            5 => -2,
            6 => -1,
            7 => -1,
            8 => -1,
            9 => 0,
            10 => 0,
            11 => 0,
            12 => 0,
            13 => 1,
            14 => 1,
            15 => 1,
            16 => 2,
            17 => 2,
            18 => 3,
            19 => 3,
            20 => 3,
            21 => 4,
            _ => -4
        };
    }
}