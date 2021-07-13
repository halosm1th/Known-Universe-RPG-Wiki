using System;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using TravellerWiki.Data.Services.DataServices;

namespace TravellerWiki.Data.SimpleWikiClasses
{
    public enum IslandsSectorPublishers
    {
        Voices_From_The_Void,
        Whipp_The_Truth,
        Kosses_Kings_Kommandments,
        Tales_From_The_Tree,
        The_Imperial_Standard,
        Lickup_The_Facts,
        ConsortiumNewsNetwork,
        PrincePeriodical,
        TheStrategist,
        Univeralis_Confederation_Bulletin,
        Travellers_Aid_Society,
    }

    public class VoicesFromTheVoidArticle
    {
        public string ArticleName { get; protected set; }
        public int ArticleID { get; }
        public List<string> Paragraphs { get; protected set; }

        public string ArticleAuthor { get; protected set; }
        public IslandsSectorPublishers Publisher { get; protected set; }
        public TravellerDateTime PublicationDate { get; set; }

        public string PublishersName => Publisher.ToString().Replace("_", " ");

        public VoicesFromTheVoidArticle(string articleName, List<string> paragraphs, string articleAuthor, IslandsSectorPublishers publisher, TravellerDateTime publicationDate)
        {
            ArticleName = articleName;
            Paragraphs = paragraphs;
            ArticleAuthor = articleAuthor;
            Publisher = publisher;
            PublicationDate = publicationDate;

            ArticleID = TravellerVoicesFromTheVoidService.GetNextID();
        }
    }
}
