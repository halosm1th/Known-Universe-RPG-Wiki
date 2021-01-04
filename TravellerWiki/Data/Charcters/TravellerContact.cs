namespace TravellerWiki.Data.Charcters
{
    public class TravellerContact
    {
        public TravellerCharacter Contact { get; set; }
        
        public string Info { get; set; }

        public TravellerSpecialNPC.NPCRelationship Relationship { get; set; }
    }
}