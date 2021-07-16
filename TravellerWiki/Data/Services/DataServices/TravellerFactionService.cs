using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellerWiki.Data.Services.CareerService;
using static TravellerWiki.Data.TravellerIslandsNations;
using static TravellerWiki.Data.TravellerIndustries;
using static TravellerWiki.Data.Services.CareerService.TravellerNationalities;
using TravellerWiki.Data.SimpleWikiClasses;
using TravellerWiki.Data.VoicesFromTheVoidArticles;
using TravellerWiki.Pages.Wiki_Pages;

namespace TravellerWiki.Data.Services.DataServices
{
    public class TravellerFactionService
    {
        public List<TravellerFaction> Factions => _factions;

        private static List<TravellerFaction> _factions =
            new List<TravellerFaction>()
            {
                
                new TravellerCompany("Voices From the Void", "Somewhere in the black",
                    None,Media,Universalis_Confederation,"The Collective",
                    null,new TravellerDateTime(01,01,83,390-50)),
                
                        new TravellerCompany("Dominate Missiles", "Reedsville", Dominate_Supremius,Large_Arms_Manufacturing,First_Order),
                        new TravellerCompany("Rushforth for money!", "Rushford", Dominate_Supremius,Privateers,First_Order),
                        new TravellerCompany("Hunnelwell Hunters", "Hunnelwell", Dominate_Supremius,Privateers,The_Kingdom_of_Britannia),
                        new TravellerCompany("Tip Top Imperial Tailor", "Hazelcrest", Dominate_Supremius,Armour_Manufacturing,The_Kingdom_of_Britannia),
                        new TravellerCompany("Dominate Foreign Construction", "Ronks", Dominate_Supremius,Construction,The_Kingdom_of_Britannia),
                        new TravellerCompany("Dominate Local Construction", "Bunkie", Dominate_Supremius,Construction,First_Order),
                        new TravellerCompany("Imperial Pharmaceuticals", "Bandera", Dominate_Supremius,Pharamesuiticals,Trans_Galactic_Empire),
                        new TravellerCompany("The Imperial Standard", "Weskan", Dominate_Supremius,Media,Trans_Galactic_Empire),
                        new TravellerCompany("Tokeland Imperial Hopsital", "Tokeland", Dominate_Supremius,Healthcare,First_Order),
                        new TravellerCompany("Imperial Droids", "Rangeley", Dominate_Supremius,Robot_Production,Trans_Galactic_Empire),
                        new TravellerCompany("Britannian Automatons", "Dongeal", Dominate_Supremius,Robot_Production,The_Kingdom_of_Britannia),
                        new TravellerCompany("Imperial Minerals", "Oran", Dominate_Supremius,Commodities,Trans_Galactic_Empire),
                        new TravellerCompany("Pickin for Plumtree", "Plumtree", Dominate_Supremius,Scavengers,First_Order),
                        new TravellerCompany("Imperial Communications", "Kayenta", Dominate_Supremius,Communications,The_Kingdom_of_Britannia),
                        new TravellerCompany("First Standard Electronics", "Barinsvil", Dominate_Supremius,Eletronics_Production,First_Order),
                        new TravellerCompany("Imperial Electronics", "Norwell", Dominate_Supremius,Eletronics_Production,The_Kingdom_of_Britannia),

                        new TravellerCompany("Moncut Turrets", "Moncut", Independent_Baronies ,Large_Arms_Manufacturing,First_Order),
                        new TravellerCompany("Bro I've made some Ammo", "Bronaugh", Independent_Baronies,Ammunition_Manufacturing,The_Kingdom_of_Britannia),
                        new TravellerCompany("Sustone Robotics", "Sustone", Independent_Baronies,Robot_Production,Germushian_Free_Republic),
                        new TravellerCompany("Trevor Comms Devices", "Trevor", Independent_Baronies,Communications,Xiao_Ming_Mega_Corporation),
                        new TravellerCompany("Princes Peridoical", "Worland", Independent_Baronies,Media, Fifth_Vers_Empire),
                        new TravellerCompany("Etty Agricultural Ltd", "Etty", Independent_Baronies,Food,United_Reverse_Lords),
                        new TravellerCompany("Bro I've got some food", "Bronaugh", Independent_Baronies,Food, TravellerNationalities.Artekkan_Guilds),
                        new TravellerCompany("Fruid of the Fields of Thippe", "Thippe464", Independent_Baronies,Food,Axion_Alliance),
                        new TravellerCompany("Moko Emergency Supplies", "Moko", Independent_Baronies,Emergency_Gear,Xiao_Ming_Mega_Corporation),
                        new TravellerCompany("Garrisonville Privateers", "Garrisonville", Independent_Baronies,Privateers,Communist_Empire_of_the_Deutschland),
                        new TravellerCompany("Scavs from Sansterre", "Sansterre", Independent_Defense_Federation,Scavengers,Communist_Empire_of_the_Deutschland),
                        new TravellerCompany("Rebecca's Friends", "Terrell", Independent_Baronies,Lobbying,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars,"Rebecca"),
                        new TravellerCompany("Ron's Law Firm", "Charenton", Independent_Baronies,Law_Firms,Polandskia_Peoples_Union),
                        new TravellerCompany("Hutt Capital", "Hutto", Independent_Baronies,Venture_Capital_Firms,Universalis_Confederation),
                        new TravellerCompany("Kenduskeag Stock Market", "Kenduskeag", Independent_Baronies,Financial_Instituions,Universalis_Confederation),
                        new TravellerCompany("Vandiver Industrial Manufacturing", "Vandiver", Independent_Baronies,Manufacturing,Imperial_Versian_Federated_Territories),

                        new TravellerCompany("Kings Tailor", "Bremerton", Rex_Van_Der_Sever,Armour_Manufacturing,Fifth_Vers_Empire),
                        new TravellerCompany("Royal Garbs", "Quichotte", Rex_Van_Der_Ostrovski,Armour_Manufacturing,Fifth_Vers_Empire),
                        new TravellerCompany("Acadie Clothing Imporium", "Acadie", Rex_Van_Der_Ostrovski,Armour_Manufacturing,Fifth_Vers_Empire),
                        new TravellerCompany("His Magesties Construction", "Twining", Rex_Van_Der_Sever,TravellerIndustries.Construction,Fifth_Vers_Empire),
                        new TravellerCompany("Royal Construction", "Sumpter", Rex_Van_Der_Ostrovski,Construction,Fifth_Vers_Empire),
                        new TravellerCompany("King's Quality Construction", "Lattimore", Rex_Van_Der_Ostrovski,Construction,Fifth_Vers_Empire),
                        new TravellerCompany("Royal Investments", "Levant", Rex_Van_Der_Ostrovski,Venture_Capital_Firms,Fifth_Vers_Empire),
                        new TravellerCompany("His Magesties Shoppes", "Collbran", Rex_Van_Der_Ostrovski,Retail,Fifth_Vers_Empire),
                        new TravellerCompany("Royal Surplus", "Wahpeton", Rex_Van_Der_Ostrovski,Wholesellears,Fifth_Vers_Empire),
                        new TravellerCompany("Royal Electronics", "Rison", Rex_Van_Der_Ostrovski,Eletronics_Production,Fifth_Vers_Empire),
                        new TravellerCompany("Lordly Components", "Cadyville", Rex_Van_Der_Ostrovski,Eletronics_Production,Fifth_Vers_Empire),
                        new TravellerCompany("Princes Playthings", "Collbran", Rex_Van_Der_Ostrovski,Toys_And_Trinkets,Fifth_Vers_Empire),
                        new TravellerCompany("The Royal Medicine Chest", "Jeffers", Rex_Van_Der_Ostrovski,Pharamesuiticals,Fifth_Vers_Empire),
                        new TravellerCompany("His Highness's  Aid", "Graytown", Rex_Van_Der_Ostrovski,Pharamesuiticals,Fifth_Vers_Empire),
                        new TravellerCompany("Royal Fields", "Hazelhurst", Rex_Van_Der_Ostrovski,Food),
                        new TravellerCompany("His Majesties Dinner Supplier", "Cawood", Rex_Van_Der_Ostrovski,Food),
                        
                        new TravellerCompany("Spiritwood Bay Weapons", "Lahaina", Spiritwood_Senate,Large_Arms_Manufacturing,Axion_Alliance),
                        new TravellerCompany("Spiritwood Soldiers", "Spiritwood", Spiritwood_Senate,Privateers,Communist_Empire_of_the_Deutschland),
                        new TravellerCompany("Pitts Consultants Ltd.", "Pitts", Spiritwood_Senate,Lobbying,Xiao_Ming_Mega_Corporation),
                        new TravellerCompany("Spiritwood Extractions", "Spiritwood", Spiritwood_Senate,Commodities,Artekkan_Guilds),
                        new TravellerCompany("Spirit of Defense", "Immokalee", Spiritwood_Senate,Armour_Manufacturing,Axion_Alliance),
                        new TravellerCompany("Senatatoral Suits", "Pitts", Spiritwood_Senate,Armour_Manufacturing,Axion_Alliance),
                        new TravellerCompany("Lahaina Agricultural Supplies", "Lahaina", Spiritwood_Senate,Food,Axion_Alliance),
                        
                        new TravellerCompany("Ionia Spinal Weapons", "Ionia", Ionia_Waskish_Trade_Pact,Large_Arms_Manufacturing,Xiao_Ming_Mega_Corporation),
                        new TravellerCompany("Arima Agriculture", "Waskish", Ionia_Waskish_Trade_Pact,Food,Xiao_Ming_Mega_Corporation,"Gihei Arima"),
                        
                        
                        new TravellerCompany("Hardwich Energy Weapons", "Hardwichport", Harwichport_Simla_Parcol_Trade_Pact,Large_Arms_Manufacturing),
                        new TravellerCompany("Imperial Torpedoes", "Struchia",Gunipped_Stellar_Empire ,Large_Arms_Manufacturing),
                        new TravellerCompany("Evotis Point Defense Systems", "Evotis", Tilova_Pact,Large_Arms_Manufacturing),
                        
                        new TravellerCompany("", "Rison", Jeffers_Kosse_Trade_Pact,Ammunition_Manufacturing),
                        new TravellerCompany("", "Delray", Kotlik_Tribunal,Ammunition_Manufacturing),
                        new TravellerCompany("", "Sumpter", Jeffers_Kosse_Trade_Pact,Ammunition_Manufacturing),
                        new TravellerCompany("", "Bellport", Western_Islands_Trade_Federation,Ammunition_Manufacturing),
                        new TravellerCompany("", "Gunripped", Gunipped_Stellar_Empire,Ammunition_Manufacturing),
                        new TravellerCompany("", "Thendara", Intercourse_Subsector_Trade_Consortium,Ammunition_Manufacturing),
                        new TravellerCompany("", "Hume", Western_Islands_Trade_Federation,Ammunition_Manufacturing),
                        
                        new TravellerCompany("Safe and Singer Sound Armour", "Singer", Western_Islands_Trade_Federation,Armour_Manufacturing),
                        new TravellerCompany("Preventium Pulverziatorium", "Pulcifer", Southern_Islands_Trade_Consortium,Armour_Manufacturing),
                        new TravellerCompany("Ricos Rough Rockers", "Esperanza", Western_Islands_Alliance,Armour_Manufacturing),
                        new TravellerCompany("I own Armour", "Ionia", Southern_Islands_Trade_Consortium,Armour_Manufacturing),
                        new TravellerCompany("Our Protective layer", "Ouray", Western_Islands_Trade_Federation,Armour_Manufacturing),
                        new TravellerCompany("Protect ur Selfie", "Ionia", Southern_Islands_Trade_Consortium,Armour_Manufacturing),
                        new TravellerCompany("Keldron Armour", "Keldron", Western_Islands_Alliance,Armour_Manufacturing),
                        new TravellerCompany("Devin's Defensive Dusters", "Camuy", Western_Islands_Alliance,Armour_Manufacturing),
                        new TravellerCompany("Southern Defensive Emporium", "Charenton", Southern_Islands_Trade_Consortium,Armour_Manufacturing),
                        new TravellerCompany("Tribunal Tailor", "Winnemucca", Kotlik_Tribunal,Armour_Manufacturing),
                        new TravellerCompany("Xiao-Will Suits and Stuff", "Willesvil", WillsVille_Trade_Pact,Armour_Manufacturing),
                        new TravellerCompany("", "Besancon", New_Colchis_Business_Board,Construction),
                        new TravellerCompany("", "ReeDu", Venhut_Dominate_States,Construction),
                        new TravellerCompany("", "Hume", Western_Islands_Trade_Federation,Construction),
                        new TravellerCompany("", "Nuremberg", Western_Islands_Trade_Federation,Construction),
                        new TravellerCompany("", "Chaska", Southern_Islands_Trade_Consortium,Construction),
                        
                        new TravellerCompany("", "Lithia", Western_Islands_Commune,Food),
                        new TravellerCompany("", "Pulcifer", Intercourse_Subsector_Trade_Consortium,Food),
                        new TravellerCompany("", "Niwot", Western_Islands_Trade_Federation,Food),
                        new TravellerCompany("", "Kahului", Western_Islands_Trade_Federation,Food),
                        new TravellerCompany("", "Cayey", Kotlik_Tribunal,Food),
                        new TravellerCompany("", "Esperanza", Esperenza,Food),
                        
                        new TravellerCompany("Bank of Esperanza", "Esperanza", Esperenza,Banking),
                        new TravellerCompany("Thendara Trade Bank", "Thendara",
                            Intercourse_Subsector_Trade_Consortium,Banking),
                        new TravellerCompany("Blissful banking by Blissflied", "Blissfield",
                            Western_Islands_Trade_Federation,Banking),
                        new TravellerCompany("Janeson and Janeson", "Hitterdal", Western_Islands_Trade_Federation,Pharamesuiticals),
                        new TravellerCompany("", "Kerkhoven", Western_Islands_Trade_Federation,Pharamesuiticals),
                        new TravellerCompany("", "Nuremberg", Western_Islands_Trade_Federation,Pharamesuiticals),
                        new TravellerCompany("", "Mabton", Western_Islands_Trade_Federation,Pharamesuiticals),
                        new TravellerCompany("", "Griggsville", No_God_Land,Pharamesuiticals),
                        new TravellerCompany("", "Ouray", Western_Islands_Trade_Federation,Pharamesuiticals),
                        new TravellerCompany("", "Trevor", Western_Islands_Trade_Federation,Pharamesuiticals),
                        new TravellerCompany("", "Doty", No_God_Land,Pharamesuiticals),
                        new TravellerCompany("", "Millport", Western_Islands_Commune,Emergency_Gear),
                        
                        
                        
                        new TravellerCompany("", "Schallere", Western_Islands_Alliance,Toys_And_Trinkets),
                        new TravellerCompany("", "Rheems", Kotlik_Tribunal,Toys_And_Trinkets),
                        new TravellerCompany("", "Blissfield", Western_Islands_Trade_Federation,Toys_And_Trinkets),
                        new TravellerCompany("", "Twining", Western_Islands_Commune,Toys_And_Trinkets),
                        new TravellerCompany("Whipp the Truth", "Whippleville", Western_Islands_Trade_Federation,Media),
                        new TravellerCompany("Kosse's Kings Kommandments", "Kosse", Jeffers_Kosse_Trade_Pact,Media),
                        new TravellerCompany("Tales from the Tree", "Kingstree", Western_Islands_Alliance,Media),
                        new TravellerCompany("Lickup the Facts", "Knoblick", Western_Islands_Trade_Federation,Media),
                        new TravellerCompany("Consortium News Network", "Whippleville", Western_Islands_Trade_Federation,Media),
                        new TravellerCompany("The Strategist", "KneelDead", Mainhair_Military_Republic,Media),

                        new TravellerCompany("", "Brill", Kotlik_Tribunal,Wholesellears),
                        new TravellerCompany("", "Hume", Western_Islands_Alliance,Wholesellears),
                        new TravellerCompany("", "Griggsvil", Western_Islands_Commune,Wholesellears),
                        new TravellerCompany("", "Neubayern", Neubayern_Topas_Alliance,Communications),
                        new TravellerCompany("", "Thippe464", Western_Islands_Trade_Federation,Eletronics_Production),
                        new TravellerCompany("", "Quanah", Western_Islands_Alliance,Eletronics_Production),
                        new TravellerCompany("", "Barnwell", Western_Islands_Trade_Federation,Eletronics_Production),
                        new TravellerCompany("", "Olitar", Olitar_Protectorate,Eletronics_Production),
                        new TravellerCompany("", "GenSpace", Sar_Tan_Confederacy,Eletronics_Production),
                        new TravellerCompany("", "Charenton", Southern_Islands_Trade_Consortium,Eletronics_Production),
                        new TravellerCompany("", "Lacamp", No_God_Land,Eletronics_Production),
                        new TravellerCompany("", "Browerville", Western_Islands_Alliance,Robot_Production),
                        new TravellerCompany("", "Joyuse", Western_Islands_Alliance,Robot_Production),
                        new TravellerCompany("", "Keldron", Western_Islands_Alliance,Robot_Production),
                        new TravellerCompany("", "ReeDu", Venhut_Dominate_States,Commodities),
                        new TravellerCompany("", "Kotlik", Kotlik_Tribunal,Commodities),
                        new TravellerCompany("", "Lithia", Western_Islands_Commune,Manufacturing),
                        new TravellerCompany("", "Harwichport", Harwichport_Simla_Parcol_Trade_Pact,Manufacturing),
                        new TravellerCompany("", "Garbreeze", Mainhair_Military_Republic,Manufacturing),
                        new TravellerCompany("", "Nebelwelt", New_Colchis_Business_Board,Manufacturing),
                        new TravellerCompany("", "Uphitera", Western_Islands_Commune,Manufacturing),
                        new TravellerCompany("", "Essig", Essia_Kitarchy,Healthcare),
                        
                        new TravellerCompany("", "Jonancy", Western_Islands_Trade_Federation,Retail),
                        new TravellerCompany("", "", None,Retail),
                        new TravellerCompany("", "", None,Retail),
                        new TravellerCompany("", "", None,Retail),
                        new TravellerCompany("", "", None,Retail),
                        new TravellerCompany("", "", None,Retail),
                        new TravellerCompany("", "", None,Retail),
                        new TravellerCompany("", "", None,Retail),
                        new TravellerCompany("", "", None,Retail),
                        new TravellerCompany("", "", None,Retail),
                        new TravellerCompany("", "", None,Retail),
                        new TravellerCompany("", "", None,Retail),
                        new TravellerCompany("", "", None,Retail),
                        new TravellerCompany("", "Kotlik", Kotlik_Tribunal,Financial_Instituions),
                        new TravellerCompany("", "Elysee", New_Colchis_Business_Board,Venture_Capital_Firms),
                        new TravellerCompany("", "Stryker", Kotlik_Tribunal,Venture_Capital_Firms),
                        new TravellerCompany("", "Bakersville", Intercourse_Subsector_Trade_Consortium,Venture_Capital_Firms),
                        new TravellerCompany("", "Kerkhoven", Western_Islands_Trade_Federation,Law_Firms),
                        new TravellerCompany("", "Bakersville", Intercourse_Subsector_Trade_Consortium,Law_Firms),
                        new TravellerCompany("", "Knoxboro", Western_Islands_Commune,Law_Firms),
                        new TravellerCompany("", "Ittabena", Western_Islands_Commune,Lobbying),
                        
                        new TravellerCompany("", "Hume", Western_Islands_Trade_Federation ,Lobbying),
                        new TravellerCompany("", "Gurnee", Western_Islands_Trade_Federation,Lobbying),
                        new TravellerCompany("", "Topas", Neubayern_Topas_Alliance,Lobbying),
                        new TravellerCompany("Grabbin from Bladin", "Bladin", Citra_Subsector_Trade_Constortium,Scavengers),
                        new TravellerCompany("Essig Hunters", "Essig", Essia_Kitarchy,Privateers),
                        new TravellerCompany("Sons of Drilions", "Drilion8JA", Tilova_Pact,Privateers),
                        new TravellerCompany("BodeyWak Boys", "BodeyWak", Venhut_Dominate_States,Privateers,Trans_Galactic_Empire),
                        new TravellerCompany("Nuken Home", "New Home", Old_Islands_Defense_League,Privateers),
                        new TravellerCompany("Hoopeston Hoppers", "Hoopeston", Intercourse_Subsector_Trade_Consortium, Privateers),
            };
    }
}