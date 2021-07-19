using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TravellerWiki.Data.Factions;
using TravellerWiki.Data.Services.CareerService;
using static TravellerWiki.Data.Services.CareerService.TravellerNationalities;
using static TravellerWiki.Data.Factions.TravellerIndustries;
using static TravellerWiki.Data.Factions.TravellerIslandsNations;
using TravellerWiki.Data.SimpleWikiClasses;
using TravellerWiki.Data.VoicesFromTheVoidArticles;
using TravellerWiki.Pages.Wiki_Pages;

namespace TravellerWiki.Data.Services.DataServices
{
    public class TravellerFactionService
    {
        public List<TravellerFaction> Factions => _factions;

        public TravellerFaction GetTravellerFaction(int factionID) => _factions.First(x => x.FactionID == factionID);

        public List<string> WorldsHeldByFactions()
        {
            var worldNames = new List<string>();
            var factionWorldNames = _factions.Select(x => {
                    var ret = new List<string>();
                    ret.Add(x.HeadquatersLocation);

                    if (x.HasOtherLocation)
                    {
                        foreach (var world in x.OtherOwnedLocations)
                        {
                            ret.Add(world);
                        }
                    }

                    return ret; });
            
            foreach (var factionLists  in factionWorldNames)
            {
                foreach (var world in factionLists)
                {
                    if (!worldNames.Contains(world))
                    {
                     worldNames.Add(world);   
                    }   
                }
            }
            
            return worldNames;
        }

        public void AddFaction(TravellerFaction faction)
        {
            _factions.Add(faction);
        }

        private static List<TravellerFaction> GetFactionFromJson()
        {
            
            var companyPath = Directory.GetCurrentDirectory() + "/Factions/Companies.json";
            var religionPath = Directory.GetCurrentDirectory() + "/Factions/Religions.json";
            var crimePath = Directory.GetCurrentDirectory() + "/Factions/Criminals.json";
            var legalPath = Directory.GetCurrentDirectory() + "/Factions/Legals.json";
            var politicalPath = Directory.GetCurrentDirectory() + "/Factions/Politicals.json";
            
            var classPath = Directory.GetCurrentDirectory() + "/Factions/Classes.json";
            var otherPath = Directory.GetCurrentDirectory() + "/Factions/Others.json";
            var socialPath = Directory.GetCurrentDirectory() + "/Factions/Socials.json";
            var majorGovPath = Directory.GetCurrentDirectory() + "/Factions/Majors.json";
            var islandGodPath = Directory.GetCurrentDirectory() + "/Factions/Islands.json";

            var factions = new List<TravellerFaction>();
           AddToFactionList<TravellerCompany>(factions, companyPath);
           AddToFactionList<TravellerSocialGroup>(factions, socialPath);
           AddToFactionList<TravellerPoliticalGroup>(factions, politicalPath);
           AddToFactionList<TravellerReligion>(factions, religionPath);
           AddToFactionList<TravellerOtherGroup>(factions,otherPath);
           AddToFactionList<TravellerCrimeGroup>(factions,crimePath);
           AddToFactionList<TravellerProfessionalGroup>(factions,legalPath);
           AddToFactionList<TravellerClassGroup>(factions,classPath);
           AddToFactionList<TravellerMajorNationGroup>(factions,majorGovPath);
           AddToFactionList<TravellerNationGroup>(factions,islandGodPath);

           return factions;
        }
        
        private static void AddToFactionList<T>(List<TravellerFaction> factions, string path)
        {
            var travellerCompaniesJson = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));

            foreach (var result in travellerCompaniesJson ?? new List<T>())
            {
                if (result is TravellerFaction)
                {
                    var r = result as TravellerFaction;
                    factions.Add(r);
                    TravellerFaction.GetNextID();
                }
            }
        }

        private static List<TravellerFaction> GetFactions()
        {
            if (_factions == null || _factions.Count == 0)
            {

                var factions = new List<TravellerFaction>();
                var codeFactions = GetCodeFactions();
                foreach (var fac in codeFactions)
                {
                    factions.Add(fac);
                }

                var jsonFactions = GetFactionFromJson();
                foreach (var fac in jsonFactions)
                {
                    factions.Add(fac);
                }

                return factions;
            }
            else
            {
                return _factions;
            }
        }
        
        private static List<TravellerFaction> GetCodeFactions() 
            =>new List<TravellerFaction>()
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
                                      new TravellerCompany("Imperial-Owned Stores", "Goldbar", Dominate_Supremius,Retail,Trans_Galactic_Empire),

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
                                      new TravellerCompany("Coda Metal Sellars Alliance", "Coda", Independent_Baronies,Retail,Fifth_Vers_Empire),

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
                                      new TravellerCompany("Royal Fields", "Hazelhurst", Rex_Van_Der_Ostrovski,Food,Fifth_Vers_Empire),
                                      new TravellerCompany("His Majesties Dinner Supplier", "Cawood", Rex_Van_Der_Ostrovski,Food,Fifth_Vers_Empire),
                                      new TravellerCompany("Joyuse Joy-toys", "Joyuse", Rex_Van_Der_Ostrovski,Robot_Production,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Kosse's Kings Kommandments", "Kosse", Rex_Van_Der_Ostrovski,Media,Xiao_Ming_Mega_Corporation),
                                      new TravellerCompany("Regents Retail", "Langford", Rex_Van_Der_Ostrovski,Retail,Fifth_Vers_Empire),
                                      new TravellerCompany("Northern Kings Retail Guild", "Mamyria", Rex_Van_Der_Sever,Retail,Communist_Empire_of_the_Deutschland),
                                      
                                      new TravellerCompany("Spiritwood Bay Weapons", "Lahaina", Spiritwood_Senate,Large_Arms_Manufacturing,Axion_Alliance),
                                      new TravellerCompany("Spiritwood Soldiers", "Spiritwood", Spiritwood_Senate,Privateers,Communist_Empire_of_the_Deutschland),
                                      new TravellerCompany("Pitts Consultants Ltd.", "Pitts", Spiritwood_Senate,Lobbying,Xiao_Ming_Mega_Corporation),
                                      new TravellerCompany("Spiritwood Extractions", "Spiritwood", Spiritwood_Senate,Commodities,Artekkan_Guilds),
                                      new TravellerCompany("Spirit of Defense", "Immokalee", Spiritwood_Senate,Armour_Manufacturing,Axion_Alliance),
                                      new TravellerCompany("Senatatoral Suits", "Pitts", Spiritwood_Senate,Armour_Manufacturing,Axion_Alliance),
                                      new TravellerCompany("Lahaina Agricultural Supplies", "Lahaina", Spiritwood_Senate,Food,Axion_Alliance),
                                      
                                      new TravellerCompany("Ionia Spinal Weapons", "Ionia", Ionia_Waskish_Trade_Pact,Large_Arms_Manufacturing,Xiao_Ming_Mega_Corporation),
                                      new TravellerCompany("Arima Agriculture", "Waskish", Ionia_Waskish_Trade_Pact,Food,Xiao_Ming_Mega_Corporation,"Gihei Arima"),
                                      
                                      new TravellerCompany("Harwich Energy Weapons", "Harwichport", Harwichport_Simla_Parcol_Trade_Pact,Large_Arms_Manufacturing,Xiao_Ming_Mega_Corporation),
                                      new TravellerCompany("Favocation Industries", "Harwichport", Harwichport_Simla_Parcol_Trade_Pact,Manufacturing,Xiao_Ming_Mega_Corporation),

                                      new TravellerCompany("Rise Son, We've got Ammo!", "Rison", Jeffers_Kosse_Trade_Pact,Ammunition_Manufacturing,Xiao_Ming_Mega_Corporation),
                                      new TravellerCompany("Sum Up 'ur Rounds", "Sumpter", Jeffers_Kosse_Trade_Pact,Ammunition_Manufacturing,Xiao_Ming_Mega_Corporation),
                                      
                                      new TravellerCompany("Xiao-Will Suits and Stuff", "Willesvil", WillsVille_Trade_Pact,Armour_Manufacturing, Xiao_Ming_Mega_Corporation),
                                      
                                      new TravellerCompany("Imperial Torpedoes", "Struchia",Gunipped_Stellar_Empire ,Large_Arms_Manufacturing,Fifth_Vers_Empire),
                                      new TravellerCompany("Gun Equipped Ammunition ", "Gunripped", Gunipped_Stellar_Empire,Ammunition_Manufacturing,Fifth_Vers_Empire),

                                      new TravellerCompany("Evotis Point Defense Systems", "Evotis", Tilova_Pact,Large_Arms_Manufacturing,Axion_Alliance),
                                      new TravellerCompany("Sons of Drilions", "Drilion8JA", Tilova_Pact,Privateers,Axion_Alliance),
                                      
                                      new TravellerCompany("D-Liver Some Lead", "Delray", Kotlik_Tribunal,Ammunition_Manufacturing,Germushian_Free_Republic),
                                      new TravellerCompany("Tribunal Tailor", "Winnemucca", Kotlik_Tribunal,Armour_Manufacturing,Fifth_Vers_Empire),
                                      new TravellerCompany("Tribunal Food Supplies", "Cayey", Kotlik_Tribunal,Food,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Tribunal Toys", "Rheems", Kotlik_Tribunal,Toys_And_Trinkets,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Tribunal Central Supply", "Brill", Kotlik_Tribunal,Wholesellears,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Tribunal Resources", "Kotlik", Kotlik_Tribunal,Commodities,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("The Kotlik Exchange ", "Kotlik", Kotlik_Tribunal,Financial_Instituions,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Tribunal Capital", "Stryker", Kotlik_Tribunal,Venture_Capital_Firms,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),

                                      new TravellerCompany("Bellport Ammo", "Bellport", Western_Islands_Trade_Federation,Ammunition_Manufacturing, Germushian_Free_Republic),
                                      new TravellerCompany("Hume Hunting Rounds Industries", "Hume", Western_Islands_Trade_Federation,Ammunition_Manufacturing, Germushian_Free_Republic),
                                      new TravellerCompany("Safe and Singer Sound Armour", "Singer", Western_Islands_Trade_Federation,Armour_Manufacturing, Germushian_Free_Republic),
                                      new TravellerCompany("Our Protective layer", "Ouray", Western_Islands_Trade_Federation,Armour_Manufacturing, Germushian_Free_Republic),
                                      new TravellerCompany("Hard Hat's from Hume", "Hume", Western_Islands_Trade_Federation,Construction, Germushian_Free_Republic),
                                      new TravellerCompany("Nuremberg Construction", "Nuremberg", Western_Islands_Trade_Federation,Construction, Germushian_Free_Republic),
                                      new TravellerCompany("Niwot Food Industries", "Niwot", Western_Islands_Trade_Federation,Food, Germushian_Free_Republic),
                                      new TravellerCompany("Kahului Apples & Other Edible Options", "Kahului", Western_Islands_Trade_Federation,Food, Germushian_Free_Republic),
                                      new TravellerCompany("Blissful banking by Blissflied", "Blissfield", Western_Islands_Trade_Federation,Banking, Germushian_Free_Republic),
                                      new TravellerCompany("Janeson and Janeson", "Hitterdal", Western_Islands_Trade_Federation,Pharamesuiticals, Germushian_Free_Republic),
                                      new TravellerCompany("Pharma-Corp", "Kerkhoven", Western_Islands_Trade_Federation,Pharamesuiticals, Germushian_Free_Republic),
                                      new TravellerCompany("Nuremberg Pharmesuiticals Inc.", "Nuremberg", Western_Islands_Trade_Federation,Pharamesuiticals, Germushian_Free_Republic),
                                      new TravellerCompany("Mabton Pharmaceuticals Ltd.", "Mabton", Western_Islands_Trade_Federation,Pharamesuiticals, Germushian_Free_Republic),
                                      new TravellerCompany("Our Way to Help", "Ouray", Western_Islands_Trade_Federation,Pharamesuiticals, Germushian_Free_Republic),
                                      new TravellerCompany("Freedom Drugs", "Trevor", Western_Islands_Trade_Federation,Pharamesuiticals, Polandskia_Peoples_Union),
                                      new TravellerCompany("Kerkhoven Legal CPP", "Kerkhoven", Western_Islands_Trade_Federation,Law_Firms, Germushian_Free_Republic),
                                      new TravellerCompany("Quik-E-Out", "Jonancy", Western_Islands_Trade_Federation,Retail, Germushian_Free_Republic),
                                      new TravellerCompany("Barnwell Electric Comments Industries.", "Barnwell", Western_Islands_Trade_Federation,Eletronics_Production, Germushian_Free_Republic),
                                      new TravellerCompany("Thippe Electronics", "Thippe464", Western_Islands_Trade_Federation,Eletronics_Production, Germushian_Free_Republic),
                                      new TravellerCompany("Busters Baby-Tainment Toys", "Blissfield", Western_Islands_Trade_Federation,Toys_And_Trinkets, Germushian_Free_Republic),
                                      new TravellerCompany("Whipp the Truth", "Whippleville", Western_Islands_Trade_Federation,Media, Germushian_Free_Republic),
                                      new TravellerCompany("Lickup the Facts", "Knoblick", Western_Islands_Trade_Federation,Media, Germushian_Free_Republic),
                                      new TravellerCompany("Consortium News Network", "Whippleville", Western_Islands_Trade_Federation,Media, Germushian_Free_Republic),
                                      new TravellerCompany("Honest Hume's Humans", "Hume", Western_Islands_Trade_Federation ,Lobbying, Germushian_Free_Republic),
                                      new TravellerCompany("Gurnee Consulting Ltd.", "Gurnee", Western_Islands_Trade_Federation,Lobbying, Germushian_Free_Republic),
                                      new TravellerCompany("Hume Wholesellers Inc.", "Hume", Western_Islands_Trade_Federation,Wholesellears,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Tonto's Totally Tatical Gear", "Tontogany", Western_Islands_Trade_Federation,Retail,Germushian_Free_Republic),
                                      new TravellerCompany("Chain-O-Maniacs", "Belchertow", Western_Islands_Trade_Federation,Retail,Germushian_Free_Republic),
                                      
                                      new TravellerCompany("Consortium Ammunition", "Thendara", Intercourse_Subsector_Trade_Consortium,Ammunition_Manufacturing,Germushian_Free_Republic),
                                      new TravellerCompany("Thendara Trade Bank", "Thendara", Intercourse_Subsector_Trade_Consortium,Banking,Germushian_Free_Republic),
                                      new TravellerCompany("Pulciferian Pasta", "Pulcifer", Intercourse_Subsector_Trade_Consortium,Food,Germushian_Free_Republic),
                                      new TravellerCompany("Bakersville Venture Capital", "Bakersville", Intercourse_Subsector_Trade_Consortium,Venture_Capital_Firms,Germushian_Free_Republic),
                                      new TravellerCompany("Bakers Law & Legal Experts", "Bakersville", Intercourse_Subsector_Trade_Consortium,Law_Firms,Germushian_Free_Republic),
                                      new TravellerCompany("Hoopeston Hoppers", "Hoopeston", Intercourse_Subsector_Trade_Consortium, Privateers,Germushian_Free_Republic),
                                      
                                      new TravellerCompany("Preventium Pulverziatorium", "Pulcifer", Southern_Islands_Trade_Consortium,Armour_Manufacturing,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("I own Armour", "Ionia", Southern_Islands_Trade_Consortium,Armour_Manufacturing,Xiao_Ming_Mega_Corporation),
                                      new TravellerCompany("Chaska Construction", "Chaska", Southern_Islands_Trade_Consortium,Construction,Germushian_Free_Republic),
                                      new TravellerCompany("Cirta Electronics Ind.", "Charenton", Southern_Islands_Trade_Consortium,Eletronics_Production,Germushian_Free_Republic),
                                      new TravellerCompany("Protect ur Selfie", "Ionia", Southern_Islands_Trade_Consortium,Armour_Manufacturing,Xiao_Ming_Mega_Corporation),
                                      new TravellerCompany("Southern Defensive Emporium", "Charenton", Southern_Islands_Trade_Consortium,Armour_Manufacturing,United_Reverse_Lords),

                                      new TravellerCompany("Grabbin from Bladin", "Bladin", Citra_Subsector_Trade_Constortium,Scavengers,Polandskia_Peoples_Union),                                      
                                      
                                      new TravellerCompany("Ricos Rough Rockers", "Esperanza", Western_Islands_Alliance,Armour_Manufacturing,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Keldron Armour", "Keldron", Western_Islands_Alliance,Armour_Manufacturing,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Devin's Defensive Dusters", "Camuy", Western_Islands_Alliance,Armour_Manufacturing,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Schallere Toys", "Schallere", Western_Islands_Alliance,Toys_And_Trinkets,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Tales from the Tree", "Kingstree", Western_Islands_Alliance,Media,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Quanah Electronics", "Quanah", Western_Islands_Alliance,Eletronics_Production,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Browerville Servent-Bots", "Browerville", Western_Islands_Alliance,Robot_Production,The_Kingdom_of_Britannia),
                                      new TravellerCompany("Keldron ", "Keldron", Western_Islands_Alliance,Robot_Production,Germushian_Free_Republic),
                                      new TravellerCompany("Super-Chains", "Keldron", Western_Islands_Alliance,Retail,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Allaince Small Stores COOP", "Quanah", Western_Islands_Alliance,Retail,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Republican Retailers", "Chatfield", Western_Islands_Alliance,Retail,Germushian_Free_Republic),
                                      new TravellerCompany("Kingly Retailers", "Daggett", Western_Islands_Alliance,Retail,Fifth_Vers_Empire),
                                      
                                      new TravellerCompany("New Colchis Construction", "Besancon", New_Colchis_Business_Board,Construction,Germushian_Free_Republic),
                                      new TravellerCompany("Nebelwelt Manufacturing", "Nebelwelt", New_Colchis_Business_Board,Manufacturing,Germushian_Free_Republic),
                                      new TravellerCompany("Business Board Investment Capital", "Elysee", New_Colchis_Business_Board,Venture_Capital_Firms,Germushian_Free_Republic),
                                      
                                      new TravellerCompany("Dominate State Construction", "ReeDu", Venhut_Dominate_States,Construction,Trans_Galactic_Empire),
                                      new TravellerCompany("BodeyWak Boys", "BodeyWak", Venhut_Dominate_States,Privateers,Trans_Galactic_Empire),
                                      new TravellerCompany("Venhut-Dominate Resource Extraction Ltd.", "ReeDu", Venhut_Dominate_States,Commodities,Trans_Galactic_Empire),
                                      
                                      new TravellerCompany("Esperenza Meats & Wheats", "Esperanza", Esperenza,Food,Fifth_Vers_Empire),
                                      new TravellerCompany("Bank of Esperanza", "Esperanza", Esperenza,Banking,Fifth_Vers_Empire),
                                      
                                      new TravellerCompany("Nuken Home", "New Home", Old_Islands_Defense_League,Privateers),
                                      
                                      new TravellerCompany("The Strategist", "KneelDead", Mainhair_Military_Republic,Media,Germushian_Free_Republic),
                                      new TravellerCompany("Mainhair Military Manufacturing Ind.", "Garbreeze", Mainhair_Military_Republic,Manufacturing,Germushian_Free_Republic),
                                      
                                      new TravellerCompany("Essig Hunters", "Essig", Essia_Kitarchy,Privateers,United_Reverse_Lords),
                                      new TravellerCompany("Essig Healer", "Essig", Essia_Kitarchy,Healthcare,United_Reverse_Lords),
                                      
                                      new TravellerCompany("Trotskites Opinion Inc.", "Topas", Neubayern_Topas_Alliance,Lobbying,Communist_Empire_of_the_Deutschland),
                                      new TravellerCompany("Stalinksy Sound & Communication", "Neubayern", Neubayern_Topas_Alliance,Communications,Communist_Empire_of_the_Deutschland),
                                      new TravellerCompany("Communist Belters Retail", "Schlesien Belt", Neubayern_Topas_Alliance,Retail,Communist_Empire_of_the_Deutschland),
                                      new TravellerCompany("Sturgeons Stores", "Sturgeons Law", Neubayern_Topas_Alliance,Retail,Communist_Empire_of_the_Deutschland),
                                      
                                      new TravellerCompany("Protectorate Electronics", "Olitar", Olitar_Protectorate,Eletronics_Production,Communist_Empire_of_the_Deutschland),
                                      
                                      new TravellerCompany("General Space Electronics", "GenSpace", Sar_Tan_Confederacy,Eletronics_Production,United_Reverse_Lords),
                                      
                                      new TravellerCompany("Gregs Pills n Stuff", "Griggsville", No_God_Land,Pharamesuiticals,Communist_Empire_of_the_Deutschland),
                                      new TravellerCompany("Doting Pharmasuiticales", "Doty", No_God_Land,Pharamesuiticals,Communist_Empire_of_the_Deutschland),
                                      new TravellerCompany("Post-Commune Electronics", "Lacamp", No_God_Land,Eletronics_Production,Communist_Empire_of_the_Deutschland),
                                      
                                      new TravellerCompany("Commune Cabbage", "Lithia", Western_Islands_Commune,Food),
                                      new TravellerCompany("Commune Emergency Surivival Gear", "Millport", Western_Islands_Commune,Emergency_Gear),
                                      new TravellerCompany("Commune Kids Toys", "Twining", Western_Islands_Commune,Toys_And_Trinkets),
                                      new TravellerCompany("Commune Wholesellars", "Griggsvil", Western_Islands_Commune,Wholesellears),
                                      new TravellerCompany("Western Commune Manufacturing", "Lithia", Western_Islands_Commune,Manufacturing),
                                      new TravellerCompany("South-Eastern Commune Manufacturing", "Uphitera", Western_Islands_Commune,Manufacturing),
                                      new TravellerCompany("Commune Law", "Knoxboro", Western_Islands_Commune,Law_Firms),
                                      new TravellerCompany("Commune Convinces", "Ittabena", Western_Islands_Commune,Lobbying),
                                      
                          };

        private static List<TravellerFaction> _factions = GetFactions();

    }
}