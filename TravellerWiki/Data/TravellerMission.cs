namespace JobBoardCreator
{
    public class TravellerMission
    {
        public string Ally { get; set; }
        public string Enemy { get; set; }
        public string Patron { get; set; }
        public string PatronQuirk { get; set; }
        public string Target { get; set; }
        public string TargetQuirk { get; set; }
        public string Opposition { get; set; }
        public string Mission { get; set; }
        public int ID { get; set; }

        public TravellerMission(string ally, string enemy, string patron, string patronQuirk, string target, string targetQuirk, string opposition, string mission, int id=0)
        {
            Ally = ally;
            Enemy = enemy;
            Patron = patron;
            PatronQuirk = patronQuirk;
            Target = target;
            TargetQuirk = targetQuirk;
            Opposition = opposition;
            Mission = mission;
            ID = id;
        }

        public TravellerMission()
        {

        }

    }
}