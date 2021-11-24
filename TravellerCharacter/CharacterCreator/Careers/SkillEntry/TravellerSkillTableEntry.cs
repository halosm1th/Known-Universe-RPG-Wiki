namespace TravellerCharacter.CharacterCreator.Careers.SkillEntry
{
    public abstract class TravellerSkillTableEntry
    {
        public string Name { get; set; }

        public TravellerSkillTableEntry(string name)
        {
            Name = name;
        }
    }
}