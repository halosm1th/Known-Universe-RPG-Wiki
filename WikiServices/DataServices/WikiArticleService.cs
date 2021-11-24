using System.Collections.Generic;
using System.Linq;
using TravellerWikiInfomationArticles;

namespace WikiServices.DataServices
{
    public class WikiArticleService
    {
        public static List<InformationArticle> Articles => WikiInformationArticles.Articles;

        public InformationArticle GetArticle(string id)
        {
            return Articles.First(x => x.ID == id);
        }

        public List<InformationArticle> AllArticles => Articles;
    }
}