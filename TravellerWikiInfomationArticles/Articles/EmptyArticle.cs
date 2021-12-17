using System.Collections.Generic;

namespace TravellerWikiInfomationArticles.Articles
{
    class EmptyArticle
    {
        public static InformationArticle GetArticle() =>
            new InformationArticle(
                "",
                "",
                new List<InformationSection>()
                {
                    new InformationSection("", new List<string>()
                    {}),
                    
                });
    }
}