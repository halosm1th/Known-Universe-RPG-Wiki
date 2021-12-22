using System.Collections.Generic;
using System.Linq;
using TravellerWikiInfomationArticles.Articles;

namespace TravellerWikiInfomationArticles
{
    public class WikiInformationArticles
    {
        public static List<InformationArticle> Articles = new ()
        {
            TravellerWikiInfomationArticles.Articles.EquitesOridinsDeorum.GetArticle(),
            VersianGender.GetArticle(),
            EarthStandardTime.GetArticle(),
        };

        public static string GetArticleIDByName(string name)
        {
            if(Articles != null) return Articles.First(x => x.Title == name).ID;
            return $"/Error/{name.Replace(" ", "_")}";
        }
        
        
        public static string GetArticleLinkIDByName(string name)
        {
            return $"/WikiArticle/{GetArticleIDByName(name)}";
        }
    }
}