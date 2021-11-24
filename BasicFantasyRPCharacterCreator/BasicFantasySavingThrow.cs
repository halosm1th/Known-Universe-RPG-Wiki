namespace BasicFantasyRPCharacterCreator
{

    public enum SavingThrows
    {
        DeathRay,
        MagicWands,
        Stone,
        Dragon,
        Spell
    }
    public class BasicFantasySavingThrow
    {
        public SavingThrows SavingThrow { get; set; }
        public int Value { get; set; }

        public BasicFantasySavingThrow(SavingThrows savingThrow, int value)
        {
            SavingThrow = savingThrow;
            Value = value;
        }
    }
}