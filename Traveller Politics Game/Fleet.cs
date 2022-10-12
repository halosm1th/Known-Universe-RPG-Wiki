namespace Traveller_Politics_Game
{
    class Fleet
    {
        public int TechLevel { get; private set; }
        public Location Location { get; private set; }

        public Fleet(int techLevel, Location startingLocation)
        {
            TechLevel = techLevel;
            Location = startingLocation;
        }

        public void MoveFleet(Location newLocation)
        {
            Location = newLocation;
        }

        public void ModifyFleet(int changeAmount = 1)
        {
            TechLevel += changeAmount;
        }

        public Capital GetUpkeepCost()
        {
            return TechLevel switch
            {
                2 => new Capital(25,1,1,1,1),
                3 => new Capital(50,2,2,2,2),
                4 => new Capital(75,2,3,2,2),
                5 => new Capital(50,1,2,1,4),
                6 => new Capital(100,2,2,3,4),
                7 => new Capital(125,2,2,3,4),
                8 => new Capital(150,3,3,2,4),
                9 => new Capital(225,6,5,5,8),
                10 => new Capital(175,6,4,4,6),
                11 => new Capital(200,6,5,5,6),
                12 => new Capital(275,7,5,6,8),
                13 => new Capital(350,9,7,8,8),
                14 => new Capital(300,8,7,7,8),
                15 => new Capital(500,14,12,15,10),
                _ => new Capital(10,1,1,0,1),
            };
        }
    }
}