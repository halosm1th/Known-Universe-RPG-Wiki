using System.Collections.Generic;

namespace BasicFantasyRPCharacterCreator
{
    public class BasicFantasyRace
    {
        public string Name { get; set; }
        public List<string> ClassRestrictions { get; set; }
        public string Description { get; set; }
        public string SpecialAbilities { get; set; }

        public BasicFantasyRace(string name, string description, string specialAbilities, List<string> classRestrictions, 
            BasicFantasyAttribute attributeMin, BasicFantasyAttribute attributeMax)
        {
            Name = name;
            ClassRestrictions = classRestrictions;
            Description = description;
            SpecialAbilities = specialAbilities;
            AttributeMin = attributeMin;
            AttributeMax = attributeMax;
        }

        public BasicFantasyAttribute AttributeMin { get; }
        public BasicFantasyAttribute AttributeMax { get; }

        public bool MeetsAttributeRequirements(BasicFantasyCharacter character)
         => (character.GetAttribute(AttributeMax.Attribute).Value <= AttributeMax.Value) &&
                   (character.GetAttribute(AttributeMin.Attribute).Value >= AttributeMin.Value);
    }
}