﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerWiki.Data.SimpleWikiClasses;
using TravellerWiki.Data.VoicesFromTheVoidArticles;

namespace TravellerWiki.Data.Services.DataServices
{
    public class TravellerVoicesFromTheVoidService
    {

        private static int currentArticleID { get; set; } = GetBaseID;

        public int CurrentArticleID => currentArticleID;
        public int BaseArticleID => GetBaseID;

        public static int GetNextID()
        {
            currentArticleID += 1;
            return currentArticleID;
        }

        public static int GetBaseID => 999;
        
        private static List<VoicesFromTheVoidIssue> _VoicesFromTheVoidIssues = new List<VoicesFromTheVoidIssue>();

        private List<VoicesFromTheVoidIssue> GetIssues()
        {
            if (_VoicesFromTheVoidIssues.Count == 0)
            {
                _VoicesFromTheVoidIssues.Add(VoicesIssue1.AddIssue1());
                _VoicesFromTheVoidIssues.Add(VoicesIssue2.AddIssue2());
                _VoicesFromTheVoidIssues.Add(VoicesIssue3.AddIssue3());
                _VoicesFromTheVoidIssues.Add(VoicesIssue4.AddIssue4());
                _VoicesFromTheVoidIssues.Add(VoicesIssue5.AddIssue5());
                _VoicesFromTheVoidIssues.Add(VoicesIssue6.AddIssue6());
            }


            return _VoicesFromTheVoidIssues;

        }
        public List<VoicesFromTheVoidIssue> VoicesFromTheVoidIssues => GetIssues();

        public VoicesFromTheVoidArticle GetArticle(int articleID)
        {
                return VoicesFromTheVoidIssues.First(x => x.HasArticle(articleID)).GetArticle(articleID);
        }

        /*
                    new VoicesFromTheVoidArticle(
                    articleAuthor:"",
                    articleName:"",
                    publisher: IslandsSectorPublishers.Voices_From_The_Void,
                    publicationDate:new TravellerDateTime(),
                    paragraphs:new List<string>
                    {

                    }),                
         */


    }
}
