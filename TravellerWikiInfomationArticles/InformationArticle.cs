using System.Collections.Generic;
using System.Linq;

namespace TravellerWikiInfomationArticles
{
    public class InformationArticle
    {
        private static int BASE_ID = 1000;
        
        public string Title { get; } = "Information Articles";
        public string Summery { get; } = "A general information article.";
        public List<InformationSection> Body { get; }
        public List<string> Headings => Body.Select(x => x.TopicTitle).ToList();
        public string ID { get; }
        

        /// <summary>
        /// Craete a new Infomration Article
        /// </summary>
        /// <param name="title">The Articles Title</param>
        /// <param name="summery">A short summery of the Article</param>
        /// <param name="body">The body of the article</param>
        public InformationArticle(string title, string summery, List<InformationSection> body)
        {
            Title = title;
            Summery = summery;
            Body = body;
            ID = (BASE_ID++).ToString();
        }
    }
}