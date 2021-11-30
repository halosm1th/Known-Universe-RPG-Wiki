namespace TravellerCharacter.CharacterCreator.Items
{
    public enum TravellerGenericItemTypes
    {
        Other,
        SurvivialGear,
        Electronics,
        ComputersAndSoftware,
        Robots,
        ToolsAndEngineering,
        MedicalSupplies,
        HomeComforts,
        SpecialAmmo,
        SightsAndAids
    }

    public class TravellerGenericItem : TravellerItem
    {
        public TravellerGenericItem(string name, int cost, int kg, int tl, string description = "",
            TravellerGenericItemTypes subType = TravellerGenericItemTypes.Other) :
            base(name, cost, kg, tl, description)
        {
            ItemSubtype = subType;
        }

        public TravellerGenericItemTypes ItemSubtype { get; set; }
    }
}