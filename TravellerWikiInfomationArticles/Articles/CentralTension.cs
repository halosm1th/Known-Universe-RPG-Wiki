﻿using System.Collections.Generic;

namespace TravellerWikiInfomationArticles.Articles
{
    class CentralTension
    {
        public static InformationArticle GetArticle() =>
            new InformationArticle(
                "Central Tension",
                "The central tension of the traveller setting currently is between the Federation and the Empire. The federation represents roughly structured freedom, So long as you're tolerant of others, and you live by these very rough rules (give the UFE free barons have near complete autonomy) you can live how you want. VS the empire, wherein the imperial structure may appear to only be bolted on the top, applied generally to all societies, but in reality what comes with it is the demand for conformity to the outside imperial view, the built in class warfare. Yet at the same time, the requirement within the empire for brutal practicality, an ending demand for things to be done for the best of the people and the best of the empire because it is what is best and therefore what is right.",
                new List<InformationSection>()
                {
                    new InformationSection("Summary", new List<string>()
                    {
                        "Looking at the central tension (Federation Vs Empire. The ability to find perfection if you work hard enough, or a good world for everyone but perfect for no one.",
                        "For many living within the setting its the question between which faraway nobody changes hands and to whom they have to pay taxes too. To those in the local know, the question is which far away government is going to toss them even the slightest crumb of support to act as an extension of their power. To those even further up, the vast array of land fades away into a small number of faces, each level up having fewer faces, but the differences between them being much larger.",
                        "Sure for Dave his military academy years get transfered, and Michelle who has to learn a new tax code at worst (assuming the change wouldn't have been made further up the food chain for efficiency of course), the flag waving over them and the people carrying the guns don't matter. But those people didn't live through the great war.",
                        "Today another generation of youth line up, having forgotten the horrors of the last war 50 years EST in the islands ago, beating that same drum their parents died for, not realizing the state the Universe is in."
                    }),
                    
                });
    }
}