namespace BasicFantasyRPCharacterCreator
{
    public class BasicFantasyMoney
    {
        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Bronze { get; set; }

        public BasicFantasyMoney(int gold, int silver, int bronze)
        {
            Gold = gold;
            Silver = silver;
            Bronze = bronze;
        }

        public override string ToString()
        {
            return $"Gold: {Gold} Silver: {Silver} Bronze: {Bronze}";
        }
    }
}