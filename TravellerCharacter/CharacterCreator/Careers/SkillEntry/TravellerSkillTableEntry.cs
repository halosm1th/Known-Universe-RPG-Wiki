namespace TravellerCharacter.CharacterCreator.Careers.SkillEntry
{
    public abstract class TravellerSkillTableEntry
    {
        public TravellerSkillTableEntry(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}