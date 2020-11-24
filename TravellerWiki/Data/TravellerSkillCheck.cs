namespace TravellerWiki.Data
{
    public class TravellerSkillCheck
    {
        public string SkillName { get; set; }
        public int BeatValue { get; set; }

        public bool PassedCheck(int testValue)
        {
            return testValue >= BeatValue;
        }

        public TravellerSkillCheck(string skillName, int beatValue)
        {
            SkillName = skillName;
            BeatValue = beatValue;
        }

        public override string ToString()
        {
            return $"{SkillName}: {BeatValue}+";
        }
    }
}