using System.Collections.Generic;

namespace TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds
{
    public enum StarsWithoutNumberWorldTags
    {
        
    }
    
    public class StarsWithoutNumberWorldTag
    {
        public StarsWithoutNumberWorldTags WorldTag { get; }
        public List<string> Subtags { get; }

        public StarsWithoutNumberWorldTag(StarsWithoutNumberWorldTags worldTag)
        {
            WorldTag = worldTag;
            Subtags = GetSubtags();
        }
        
        List<string> GetSubtags()
        {
            return WorldTag switch
            {
                
                _ => new List<string>()
            };
        }
    }
}