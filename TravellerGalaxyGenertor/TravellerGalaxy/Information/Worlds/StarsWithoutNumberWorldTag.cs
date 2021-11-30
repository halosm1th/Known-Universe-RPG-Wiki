using System.Collections.Generic;

namespace TravellerGalaxyGenertor.TravellerGalaxy.Information.Worlds
{
    public enum StarsWithoutNumberWorldTags
    {
    }

    public class StarsWithoutNumberWorldTag
    {
        public StarsWithoutNumberWorldTag(StarsWithoutNumberWorldTags worldTag)
        {
            WorldTag = worldTag;
            Subtags = GetSubtags();
        }

        public StarsWithoutNumberWorldTags WorldTag { get; }
        public List<string> Subtags { get; }

        private List<string> GetSubtags()
        {
            return WorldTag switch
            {
                _ => new List<string>()
            };
        }
    }
}