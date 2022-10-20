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

        public Capital GetBuildCosts()
        {
            return TechLevel switch
            {
                2 => new Capital(30,2,2,2,1),
                3 => new Capital(40,4,5,3,2),
                4 => new Capital(45,4,6,3,2),
                5 => new Capital(50,4,5,3,4),
                6 => new Capital(55,5,6,4,4),
                7 => new Capital(65,5,5,4,4),
                8 => new Capital(75,6,6,5,4),
                9 => new Capital(100,10,8,8,8),
                10 => new Capital(250,8,7,6,6),
                11 => new Capital(275,9,8,7,6),
                12 => new Capital(350,10,8,8,8),
                13 => new Capital(425,12,10,10,8),
                14 => new Capital(375,11,10,9,8),
                15 => new Capital(500,14,15,12,10),
                _ => new Capital(25,2,1,1,1),
            };
        }

        public Capital GetUpkeepCost()
        {
            return TechLevel switch
            {
                2 => new Capital(15,2,1,2,1),
                3 => new Capital(20,3,2,2,2),
                4 => new Capital(30,4,3,3,2),
                5 => new Capital(40,2,2,2,4),
                6 => new Capital(50,3,3,3,4),
                7 => new Capital(75,3,2,3,4),
                8 => new Capital(100,4,3,2,4),
                9 => new Capital(125,7,5,5,8),
                10 => new Capital(225,6,4,4,6),
                11 => new Capital(200,7,5,5,6),
                12 => new Capital(275,8,5,6,8),
                13 => new Capital(350,10,7,8,8),
                14 => new Capital(300,9,7,7,8),
                15 => new Capital(425,11,10,10,10),
                _ => new Capital(10,1,1,1,1),
            };
        }
    }
}