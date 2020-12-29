namespace TravellerWiki.Data.Charcters
{
    public class TravellerSkill
    {
        public string SkillName { get; set; }
        public int SkillValue { get; set; }

        public TravellerSkill(string name, int baseValue = 0)
        {
            SkillName = name;
            SkillValue = baseValue;
        }
    }
}