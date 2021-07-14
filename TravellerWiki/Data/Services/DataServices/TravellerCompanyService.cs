using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerWiki.Data.SimpleWikiClasses;
using TravellerWiki.Data.VoicesFromTheVoidArticles;

namespace TravellerWiki.Data.Services.DataServices
{
    public class TravellerCompanyService
    {
        public Dictionary<string, List<TravellerCompany>> Companies => _companies;

        private static Dictionary<string, List<TravellerCompany>> _companies =
            new Dictionary<string, List<TravellerCompany>>()
            {
                {
                    "LargeArms", new List<TravellerCompany>()
                    {
                        new TravellerCompany("Dominate Missiles", "Reedsville", "Dominate Supremius"),
                        new TravellerCompany("Moncut Turrets", "Moncut", "United Baroniest"),
                        new TravellerCompany("Spiritwood Bay Weapons", "Lahaina", "Spiritwood Senate"),
                        new TravellerCompany("Ionia Spinal Weapons", "Ionia", "Ionia-Waskish Trade Pact"),
                        new TravellerCompany("Hardwich Energy Weapons", "Hardwichport",
                            "Harwichport-Simla-Parcol Trade Pact"),
                        new TravellerCompany("Imperial Torpedoes", "Struchia", "Gunipped Stellar Empire"),
                        new TravellerCompany("Evotis Point Defense Systems", "Evotis", "Tilova Pact")
                    }
                },
                {
                    "Ammunition", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Rison", "Jeffers-Kosse Trade Pact"),
                        new TravellerCompany("", "Delray", "Kotlik Tribunal"),
                        new TravellerCompany("", "Bronaugh", "United Baronies"),
                        new TravellerCompany("", "Sumpter", "Jeffers-Kosse Trade Pact"),
                        new TravellerCompany("", "Bellport", "Western Islands Trade Consortium"),
                        new TravellerCompany("", "Gunripped", "Gunripped Stellar Empire"),
                        new TravellerCompany("", "Thendara", "Intercourse Subsector Trade Consortium"),
                        new TravellerCompany("", "Hume", "Western Islands Trade Consortium")
                    }
                },
                {
                    "Armour", new List<TravellerCompany>()
                    {
                        new TravellerCompany("Safe and Singer Sound Armour", "Singer", "Trade Federation"),
                        new TravellerCompany("Preventium Pulverziatorium", "Pulcifer", "Soutern Islands Trade Consortium"),
                        new TravellerCompany("Ricos Rough Rockers", "Esperanza", "Western Islands Allaince"),
                        new TravellerCompany("I own Armour", "Ionia", "Soutern Islands Trade Consortium"),
                        new TravellerCompany("Our Protective layer", "Ouray", "Trade Federation"),
                        new TravellerCompany("Kings Tailor", "Bremerton", "Rex van der Sever"),
                        new TravellerCompany("Protect ur Selfie", "Ionia", "Southern Islands Trade Consortium"),
                        new TravellerCompany("Keldron Armour", "Keldron", "Western Islands Alliance"),
                        new TravellerCompany("Acadie Clothing Imporium", "Acadie", "Independent Baronies"),
                        new TravellerCompany("Devin's Defensive Dusters", "Camuy", "Western Islands Alliance"),
                        new TravellerCompany("Spirit of Defense", "Immokalee", "Spiritwood Senate"),
                        new TravellerCompany("Senatatoral Suits", "Pitts", "Spiritwood Senate"),
                        new TravellerCompany("Southern Defensive Emporium", "Charenton", "Southern Islands Trade Federation"),
                        new TravellerCompany("Royal Garbs", "Quichotte", "Rex van der Ostrovski"),
                        new TravellerCompany("Tribunal Tailor", "Winnemucca", "Kotlik Tribunal"),
                        new TravellerCompany("Tip Top Imperial Tailor", "Hazelcrest", "Dominate Supremius"),
                        new TravellerCompany("Xiao-Will Suits and Stuff", "Willesvil", "Willsvil Trade Pact")
                    }
                },
                {
                    "Construction", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Besancon", "New Colchis Business Board"),
                        new TravellerCompany("", "ReeDu", "Venhut Dominate States"),
                        new TravellerCompany("", "Twining", "Rex van der Sever"),
                        new TravellerCompany("", "Sumpter", "Rex van der Ovstrovski"),
                        new TravellerCompany("", "Hume", "Western Islands Trade Federation"),
                        new TravellerCompany("", "Ronks", "Dominate Supremius"),
                        new TravellerCompany("", "Lattimore", "Rex van der Ostrovski"),
                        new TravellerCompany("", "Nuremberg", "Western Islands Trade Federation"),
                        new TravellerCompany("", "Chaska", "Soutern Islands Trade Federation"),
                        new TravellerCompany("", "Bunkie", "Dominate Supremius")
                    }
                },
                {
                    "Food", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Hazelhurst", "Rex van der Ostrovski"),
                        new TravellerCompany("", "Lithia", "Western Islands Commune"),
                        new TravellerCompany("", "Bronaugh", "United Baronies"),
                        new TravellerCompany("", "Pulcifer", "Intercourse Subsector Trade Consortium"),
                        new TravellerCompany("", "Niwot", "Western Islands Trade Consortium"),
                        new TravellerCompany("", "Kahului", "Western Islands Trade Consortium"),
                        new TravellerCompany("", "Lahaina", "Spiritwood Senate"),
                        new TravellerCompany("", "Etty", "Untied Baronies"),
                        new TravellerCompany("", "Thippe464", "United Baronies"),
                        new TravellerCompany("", "Cayey", "Kotlik Tribunal"),
                        new TravellerCompany("", "Waskish", "Ionia-Waskish Trade Pact"),
                        new TravellerCompany("", "Esperanza", "Esperanza Planetary Government"),
                        new TravellerCompany("", "Cawood", "Rex van der Ostrovski")
                    }
                },
                {
                    "Banks", new List<TravellerCompany>()
                    {
                        new TravellerCompany("Bank of Esperanza", "Esperanza", "Esperanza Planetary Government"),
                        new TravellerCompany("Thendara Trade Bank", "Thendara",
                            "Intercourse Subsector Trade Consortium"),
                        new TravellerCompany("Blissful banking by Blissflied", "Blissfield",
                            "Western Islands Trade Consortium"),
                        new TravellerCompany("", "Struchia", "Gunipped Stellar Empire")
                    }
                },
                {
                    "Pharmesuiticals", new List<TravellerCompany>()
                    {
                        new TravellerCompany("Janeson and Janeson", "Hitterdal", "Trade Federation"),
                        new TravellerCompany("", "Kerkhoven", "Trade Federation"),
                        new TravellerCompany("", "Graytown", "Rex van der Ostrovski"),
                        new TravellerCompany("", "Nuremberg", "Trade Federation"),
                        new TravellerCompany("", "Mabton", "Trade Federation"),
                        new TravellerCompany("", "Griggsville", "No God Land"),
                        new TravellerCompany("", "Bandera", "Dominate Supremius"),
                        new TravellerCompany("", "Ouray", "Trade Federation"),
                        new TravellerCompany("", "Trevor", "Trade Federation"),
                        new TravellerCompany("", "Doty", "No God Land"),
                        new TravellerCompany("", "Jeffers", "Rex van der Ostrovski")
                    }
                },
                {
                    "EmergencyGear", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Millport", "Western Islands Commune"),
                        new TravellerCompany("", "Moko", "United Baronies"),
                    }
                },
                {
                    "Toys", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Schallere", "Western Islands Alliance"),
                        new TravellerCompany("", "Collbran", "Rex van der Ostrovski"),
                        new TravellerCompany("", "Rheems", "Kotlik Tribunal"),
                        new TravellerCompany("", "Blissfield", "Western Islands Trade Consortium"),
                        new TravellerCompany("", "Twining", "Western Islands Commune"),
                    }
                },
                {
                    "Media", new List<TravellerCompany>()
                    {
                        new TravellerCompany("Voices From the Void", "Somewhere in the black",
                            "The nation of your mind"),
                        new TravellerCompany("Whipp the Truth", "Whippleville", "Western Islands Trade Consortium"),
                        new TravellerCompany("Kosse's Kings Kommandments", "Kosse", "Jeffers-Kosse Trade Pact"),
                        new TravellerCompany("Tales from the Tree", "Kingstree", "Western Islands Alliance"),
                        new TravellerCompany("The Imperial Standard", "Weskan", "Dominate Supremius"),
                        new TravellerCompany("Lickup the Facts", "Knoblick", "Western Islands Trade Consortium"),
                        new TravellerCompany("Consortium News Network", "Whippleville",
                            "Western Islands Trade Consortium"),
                        new TravellerCompany("Prices Peridoical", "Worland", "United Baronies"),
                        new TravellerCompany("The Strategist", "KneelDead", "Mainhair Military Republic"),
                    }
                },
                {
                    "Wholesellars", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Brill", "Kotlik Tribunal"),
                        new TravellerCompany("", "Hume", "Western Islands Alliance"),
                        new TravellerCompany("", "Wahpeton", "Rex van der Ostrovski"),
                        new TravellerCompany("", "Griggsvil", "Western Islands Commune"),
                    }
                },
                {
                    "Communications", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Neubayern", "Neubayern-Topas Alliance"),
                        new TravellerCompany("", "Trevor", "United Baronies"),
                        new TravellerCompany("", "Kayenta", "Dominate Supremius"),
                    }
                },
                {
                    "ElectronicsProduction", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Thippe464", "Trade Federation"),
                        new TravellerCompany("", "Rison", "Rex van der Ostrovski"),
                        new TravellerCompany("", "Barinsvil", "Dominate Supremius"),
                        new TravellerCompany("", "Quanah", "Western Islands Alliance"),
                        new TravellerCompany("", "Norwell", "Dominate Supremius"),
                        new TravellerCompany("", "Barnwell", "Trade Federation"),
                        new TravellerCompany("", "Olitar", "Olitar Protectorate"),
                        new TravellerCompany("", "GenSpace", "Sar-Tan Confederacy"),
                        new TravellerCompany("", "Cadyville", "Rex van der Ostrovski"),
                        new TravellerCompany("", "Charenton", "Soutern Islands Trade Federation"),
                        new TravellerCompany("", "Lacamp", "No God Land"),
                    }
                },
                {
                    "RobotProduction", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Browerville", "Western Islands Alliance"),
                        new TravellerCompany("", "Sustone", "United Baronies"),
                        new TravellerCompany("", "Rangeley", "Dominate Supremius"),
                        new TravellerCompany("", "Joyuse", "Western Islands Alliance"),
                        new TravellerCompany("", "Dongeal", "Dominate Supremius"),
                        new TravellerCompany("", "Keldron", "Western Islands Alliance"),
                    }
                },
                {
                    "Commodities", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Spiritwood", "Spiritwood Senate"),
                        new TravellerCompany("", "ReeDu", "Venhut Dominate States"),
                        new TravellerCompany("", "Kotlik", "Kotlik Tribunal"),
                        new TravellerCompany("", "Oran", "Dominate Supremius"),
                    }
                },
                {
                    "Manufacturing", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Lithia", "Western Islands Commune"),
                        new TravellerCompany("", "Harwichport", "Harwichport-Simla-Parcoal Trade Pact"),
                        new TravellerCompany("", "Garbreeze", "Mainhair Military Republic"),
                        new TravellerCompany("", "Nebelwelt", "New Colchis Business Board"),
                        new TravellerCompany("", "Vandiver", "United Baronies"),
                        new TravellerCompany("", "Uphitera", "Western Islands Commune"),
                    }
                },
                {
                    "Healthcare", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Essig", "Essig Kitarchy"),
                        new TravellerCompany("Tokeland Imperial Hopsital", "Tokeland", "Dominate Supremius"),
                    }
                },
                {
                    "Retail", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Collbran", "Rex van der Ostrovski"),
                        new TravellerCompany("", "Jonancy", "Western Islands Trade Federation"),
                        new TravellerCompany("", "", ""),
                        new TravellerCompany("", "", ""),
                        new TravellerCompany("", "", ""),
                        new TravellerCompany("", "", ""),
                        new TravellerCompany("", "", ""),
                        new TravellerCompany("", "", ""),
                        new TravellerCompany("", "", ""),
                        new TravellerCompany("", "", ""),
                        new TravellerCompany("", "", ""),
                        new TravellerCompany("", "", ""),
                        new TravellerCompany("", "", ""),
                        new TravellerCompany("", "", ""),
                    }
                },
                {
                    "FinancialInstitutions", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Kenduskeag", "United Baronies"),
                        new TravellerCompany("", "Kotlik", "Kotlil Tribunal"),
                    }
                },
                {
                    "VentureCapital", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Elysee", "New Colchis Business Board"),
                        new TravellerCompany("", "Stryker", "Kotlik Tribunal"),
                        new TravellerCompany("", "Hutto", "United Baronies"),
                        new TravellerCompany("", "Levant", "Rex van der Ostrovski"),
                        new TravellerCompany("", "Bakersville", "Intercourse Subsector Trade Consortium"),
                    }
                },
                {
                    "LawFirms", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Kerkhoven", "Western Islands Trade Consortium"),
                        new TravellerCompany("", "Charenton", "United Baronies"),
                        new TravellerCompany("", "Bakersville", "Intercourse Subsector Trade Consortium"),
                        new TravellerCompany("", "Knoxboro", "Western Islands Commune"),
                    }
                },
                {
                    "Lobbists", new List<TravellerCompany>()
                    {
                        new TravellerCompany("", "Ittabena", "Western Islands Commune"),
                        new TravellerCompany("", "Hume", "Western Islands Trade Consortium"),
                        new TravellerCompany("", "Terrell", "United Baronies"),
                        new TravellerCompany("", "Pitts", "Spiritwood Senate"),
                        new TravellerCompany("", "Gurnee", "Western Islands Trade Consortium"),
                        new TravellerCompany("", "Topas", "Neubayern-Topas Alliance"),
                    }
                },
                {
                    "Scavengers", new List<TravellerCompany>()
                    {
                        new TravellerCompany("Grabbin from Bladin", "Bladin", "Citra Subsector Trade Constortium"),
                        new TravellerCompany("Pickin for Plumtree", "Plumtree", "Dominate Supremius"),
                        new TravellerCompany("Scavs from Sansterre", "Sansterre", "Indpendent Defense Federation"),
                    }
                },
                {
                    "Privateers", new List<TravellerCompany>()
                    {
                        new TravellerCompany("Essig Hunters", "Essig", "Essig Kitarchy"),
                        new TravellerCompany("Garrisonville Privateers", "Garrisonville", "United Baronies"),
                        new TravellerCompany("Sons of Drilions", "Drilion8JA", "Tilova Pact"),
                        new TravellerCompany("BodeyWak Boys", "BodeyWak", "Venhut Dominate States"),
                        new TravellerCompany("Nuken Home", "New Home", "Old Islands Defense League"),
                        new TravellerCompany("Rushforth for money!", "Rushford", "Dominate Supremius"),
                        new TravellerCompany("Hunnelwell Hunters", "Hunnelwell", "Dominate Supremius"),
                        new TravellerCompany("Spiritwood Soldiers", "Spiritwood", "Spiritwood Senate"),
                        new TravellerCompany("Hoopeston Hoppers", "Hoopeston",
                            "Intercourse Subsector Trade Consortium"),
                    }
                }
            };
    }
}