using System.Collections.Generic;

namespace TravellerWikiInfomationArticles
{
    public class InformationSection
    {
        public string TopicTitle { get; }
        public List<string> TopicParagraphsInMarkdown { get; }

        /// <summary>
        /// A section of the body of an information article
        /// </summary>
        /// <param name="topicTitle">The topic of this topic/section</param>
        /// <param name="topicParagraphsInMarkdown">The action paragraphs for this topic, in markdown</param>
        public InformationSection(string topicTitle, List<string> topicParagraphsInMarkdown)
        {
            TopicTitle = topicTitle;
            TopicParagraphsInMarkdown = topicParagraphsInMarkdown;
        }
    }
}