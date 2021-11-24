using System.Collections.Generic;
using System.Linq;

namespace VoicesFromTheVoidArticles
{
    public class VoicesFromTheVoidIssue
    {
        public TravellerDateTime StartDate { get; }
        public TravellerDateTime EndDate { get; }
        public List<VoicesFromTheVoidArticle> Articles { get; }
        public string IssueName { get; }
        public string IssueDescription { get; }
        public int IssueNumber { get; }

        public VoicesFromTheVoidIssue( string issueName, string issueDescription,  int issueNumber, List<VoicesFromTheVoidArticle> articles)
        {
            Articles = articles;
            IssueName = issueName;
            IssueDescription = issueDescription;
            IssueNumber = issueNumber;
            StartDate = articles.OrderBy(x => x.PublicationDate).First().PublicationDate;
            EndDate = articles.OrderBy(x => x.PublicationDate).Last().PublicationDate;
        }

        public VoicesFromTheVoidArticle GetArticle(int articleID)
        {
            if (HasArticle(articleID)) return Articles.First(x => x.ArticleID == articleID);
            return null;
        }

        public VoicesFromTheVoidArticle GetArticle(string articleName)
        {
            if (HasArticle(articleName)) return Articles.First(x => x.ArticleName.Contains(articleName));
            return null;
        }
        
        public bool HasArticle(int articleID)
        {
            return Articles.Any(x => x.ArticleID == articleID);
        }
        
        public bool HasArticle(string articleName)
        {
            return Articles.Any(x => x.ArticleName.Contains(articleName));
        }
    }
}