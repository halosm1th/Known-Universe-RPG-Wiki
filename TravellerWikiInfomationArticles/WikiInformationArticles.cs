using System.Collections.Generic;

namespace TravellerWikiInfomationArticles
{
    public class WikiInformationArticles
    {
        public static List<InformationArticle> Articles = new ()
        {
            TravellerWikiInfomationArticles.Articles.EquitesOridinsDeorum.GetArticle()
        };
    }
}