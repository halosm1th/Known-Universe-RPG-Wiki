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

        public List<TravellerLocation> WorldsHeldByFactions()
        {
            var worldNames = new List<TravellerLocation>();
            var factionWorldNames = _factions.Select(x => {
                    var ret = new List<TravellerLocation>();
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
                              
                              new TravellerCompany("Voices From the Void", new TravellerLocation("Somewhere in the black",1,1,5,5),
                                  None,Media,Universalis_Confederation,"The Collective",
                                  null,new TravellerDateTime(01,01,83,390-50)),
                              
                                      new TravellerCompany("Dominate Missiles", new TravellerLocation("Reedsville",1,2,3,2), Dominate_Supremius,Large_Arms_Manufacturing,First_Order),
                                      new TravellerCompany("Rushforth for money!", new TravellerLocation("Rushford",1,2,1,7), Dominate_Supremius,Privateers,First_Order),
                                      new TravellerCompany("Hunnelwell Hunters", new TravellerLocation("Hunnelwell",1,1,1,9), Dominate_Supremius,Privateers,The_Kingdom_of_Britannia),
                                      new TravellerCompany("Tip Top Imperial Tailor", new TravellerLocation("Hazelcrest",1,2,3,6), Dominate_Supremius,Armour_Manufacturing,The_Kingdom_of_Britannia),
                                      new TravellerCompany("Dominate Foreign Construction", new TravellerLocation("Ronks",1,1,2,8), Dominate_Supremius,Construction,The_Kingdom_of_Britannia),
                                      new TravellerCompany("Dominate Local Construction", new TravellerLocation("Bunkie",1,1,2,9), Dominate_Supremius,Construction,First_Order),
                                      new TravellerCompany("Imperial Pharmaceuticals", new TravellerLocation("Bandera",1,2,4,7), Dominate_Supremius,Pharamesuiticals,Trans_Galactic_Empire),
                                      new TravellerCompany("The Imperial Standard", new TravellerLocation("Weskan",1,2,8,5), Dominate_Supremius,Media,Trans_Galactic_Empire),
                                      new TravellerCompany("Tokeland Imperial Hopsital", new TravellerLocation("Tokeland",1,3,7,3), Dominate_Supremius,Healthcare,First_Order),
                                      new TravellerCompany("Imperial Droids", new TravellerLocation("Rangeley",1,2,7,8), Dominate_Supremius,Robot_Production,Trans_Galactic_Empire),
                                      new TravellerCompany("Britannian Automatons", new TravellerLocation("Dongeal",1,2,5,10), Dominate_Supremius,Robot_Production,The_Kingdom_of_Britannia),
                                      new TravellerCompany("Imperial Minerals", new TravellerLocation("Oran",1,2,7,2), Dominate_Supremius,Commodities,Trans_Galactic_Empire),
                                      new TravellerCompany("Pickin for Plumtree", new TravellerLocation("Plumtree",1,2,7,7), Dominate_Supremius,Scavengers,First_Order),
                                      new TravellerCompany("Imperial Communications", new TravellerLocation("Kayenta",1,2,7,3), Dominate_Supremius,Communications,The_Kingdom_of_Britannia),
                                      new TravellerCompany("First Standard Electronics", new TravellerLocation("Barinsvil",1,2,2,1), Dominate_Supremius,Eletronics_Production,First_Order),
                                      new TravellerCompany("Imperial Electronics", new TravellerLocation("Norwell",1,2,4,1), Dominate_Supremius,Eletronics_Production,The_Kingdom_of_Britannia),
                                      new TravellerCompany("Imperial-Owned Stores", new TravellerLocation("Goldbar",1,3,6,1), Dominate_Supremius,Retail,Trans_Galactic_Empire),

                                      new TravellerCompany("Moncut Turrets", new TravellerLocation("Moncut",3,2,1,7), Independent_Baronies ,Large_Arms_Manufacturing,First_Order),
                                      new TravellerCompany("Bro I've made some Ammo", new TravellerLocation("Bronaugh",1,3,8,8), Independent_Baronies,Ammunition_Manufacturing,The_Kingdom_of_Britannia),
                                      new TravellerCompany("Sustone Robotics", new TravellerLocation("Sustone",3,2,2,1), Independent_Baronies,Robot_Production,Germushian_Free_Republic),
                                      new TravellerCompany("Trevor Comms Devices", new TravellerLocation("Trevor",4,2,1,6), Independent_Baronies,Communications,Xiao_Ming_Mega_Corporation),
                                      new TravellerCompany("Princes Peridoical", new TravellerLocation("Worland",3,4,6,1), Independent_Baronies,Media, Fifth_Vers_Empire),
                                      new TravellerCompany("Etty Agricultural Ltd", new TravellerLocation("Etty",2,4,7,4), Independent_Baronies,Food,United_Reverse_Lords),
                                      new TravellerCompany("Bro I've got some food", new TravellerLocation("Bronaugh",1,3,8,8), Independent_Baronies,Food, TravellerNationalities.Artekkan_Guilds),
                                      new TravellerCompany("Fruid of the Fields of Thippe", new TravellerLocation("Thippe464",2,2,7,9), Independent_Baronies,Food,Axion_Alliance),
                                      new TravellerCompany("Moko Emergency Supplies", new TravellerLocation("Moko",3,1,7,7), Independent_Baronies,Emergency_Gear,Xiao_Ming_Mega_Corporation),
                                      new TravellerCompany("Garrisonville Privateers", new TravellerLocation("Garrisonville",1,1,6,7), Independent_Baronies,Privateers,Communist_Empire_of_the_Deutschland),
                                      new TravellerCompany("Scavs from Sansterre", new TravellerLocation("Sansterre",3,3,7,2), Independent_Defense_Federation,Scavengers,Communist_Empire_of_the_Deutschland),
                                      new TravellerCompany("Rebecca's Friends", new TravellerLocation("Terrell",4,2,3,2), Independent_Baronies,Lobbying,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars,"Rebecca"),
                                      new TravellerCompany("Ron's Law Firm", new TravellerLocation("Charenton",2,4,4,4), Independent_Baronies,Law_Firms,Polandskia_Peoples_Union),
                                      new TravellerCompany("Hutt Capital", new TravellerLocation("Hutto",2,1,4,3), Independent_Baronies,Venture_Capital_Firms,Universalis_Confederation),
                                      new TravellerCompany("Kenduskeag Stock Market", new TravellerLocation("Kenduskeag",3,1,7,9), Independent_Baronies,Financial_Instituions,Universalis_Confederation),
                                      new TravellerCompany("Vandiver Industrial Manufacturing", new TravellerLocation("Vandiver",3,4,1,4), Independent_Baronies,Manufacturing,Imperial_Versian_Federated_Territories),
                                      new TravellerCompany("Coda Metal Sellars Alliance", new TravellerLocation("Coda",3,2,7,8), Independent_Baronies,Retail,Fifth_Vers_Empire),

                                      new TravellerCompany("Kings Tailor", new TravellerLocation("Bremerton",4,1,2,3), Rex_Van_Der_Sever,Armour_Manufacturing,Fifth_Vers_Empire),
                                      new TravellerCompany("Royal Garbs", new TravellerLocation("Quichotte",3,3,1,9), Rex_Van_Der_Ostrovski,Armour_Manufacturing,Fifth_Vers_Empire),
                                      new TravellerCompany("Acadie Clothing Imporium", new TravellerLocation("Acadie",3,3,6,5), Rex_Van_Der_Ostrovski,Armour_Manufacturing,Fifth_Vers_Empire),
                                      new TravellerCompany("His Magesties Construction", new TravellerLocation("Twining",2,1,6,10), Rex_Van_Der_Sever,TravellerIndustries.Construction,Fifth_Vers_Empire),
                                      new TravellerCompany("Royal Construction", new TravellerLocation("Sumpter",4,4,3,2), Rex_Van_Der_Ostrovski,Construction,Fifth_Vers_Empire),
                                      new TravellerCompany("King's Quality Construction", new TravellerLocation("Lattimore",3,4,8,6), Rex_Van_Der_Ostrovski,Construction,Fifth_Vers_Empire),
                                      new TravellerCompany("Royal Investments", new TravellerLocation("Levant",4,4,2,5), Rex_Van_Der_Ostrovski,Venture_Capital_Firms,Fifth_Vers_Empire),
                                      new TravellerCompany("His Magesties Shoppes", new TravellerLocation("Collbran",3,4,2,1), Rex_Van_Der_Ostrovski,Retail,Fifth_Vers_Empire),
                                      new TravellerCompany("Royal Surplus", new TravellerLocation("Wahpeton",4,4,3,5), Rex_Van_Der_Ostrovski,Wholesellears,Fifth_Vers_Empire),
                                      new TravellerCompany("Royal Electronics", new TravellerLocation("Rison",4,4,4,1), Rex_Van_Der_Ostrovski,Eletronics_Production,Fifth_Vers_Empire),
                                      new TravellerCompany("Lordly Components", new TravellerLocation("Cadyville",4,4,4,5), Rex_Van_Der_Ostrovski,Eletronics_Production,Fifth_Vers_Empire),
                                      new TravellerCompany("Princes Playthings", new TravellerLocation("Collbran",3,4,2,1), Rex_Van_Der_Ostrovski,Toys_And_Trinkets,Fifth_Vers_Empire),
                                      new TravellerCompany("The Royal Medicine Chest", new TravellerLocation("Jeffers",4,3,2,9), Rex_Van_Der_Ostrovski,Pharamesuiticals,Fifth_Vers_Empire),
                                      new TravellerCompany("His Highness's  Aid", new TravellerLocation("Graytown",4,4,8,2), Rex_Van_Der_Ostrovski,Pharamesuiticals,Fifth_Vers_Empire),
                                      new TravellerCompany("Royal Fields", new TravellerLocation("Hazelhurst",3,4,4,9), Rex_Van_Der_Ostrovski,Food,Fifth_Vers_Empire),
                                      new TravellerCompany("His Majesties Dinner Supplier", new TravellerLocation("Cawood",4,4,7,5), Rex_Van_Der_Ostrovski,Food,Fifth_Vers_Empire),
                                      new TravellerCompany("Joyuse Joy-toys", new TravellerLocation("Joyuse",2,3,8,8), Rex_Van_Der_Ostrovski,Robot_Production,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Kosse's Kings Kommandments", new TravellerLocation("Kosse",4,3,4,9), Rex_Van_Der_Ostrovski,Media,Xiao_Ming_Mega_Corporation),
                                      new TravellerCompany("Regents Retail", new TravellerLocation("Langford",4,4,6,5), Rex_Van_Der_Ostrovski,Retail,Fifth_Vers_Empire),
                                      new TravellerCompany("Northern Kings Retail Guild", new TravellerLocation("Mamyria",2,2,4,2), Rex_Van_Der_Sever,Retail,Communist_Empire_of_the_Deutschland),
                                      
                                      new TravellerCompany("Spiritwood Bay Weapons", new TravellerLocation("Lahaina",1,4,7,8), Spiritwood_Senate,Large_Arms_Manufacturing,Axion_Alliance),
                                      new TravellerCompany("Spiritwood Soldiers", new TravellerLocation("Spiritwood",1,4,7,9), Spiritwood_Senate,Privateers,Communist_Empire_of_the_Deutschland),
                                      new TravellerCompany("Pitts Consultants Ltd.", new TravellerLocation("Pitts",1,4,7,7), Spiritwood_Senate,Lobbying,Xiao_Ming_Mega_Corporation),
                                      new TravellerCompany("Spiritwood Extractions", new TravellerLocation("Spiritwood",1,4,7,9), Spiritwood_Senate,Commodities,Artekkan_Guilds),
                                      new TravellerCompany("Spirit of Defense", new TravellerLocation("Immokalee",2,4,1,7), Spiritwood_Senate,Armour_Manufacturing,Axion_Alliance),
                                      new TravellerCompany("Senatatoral Suits", new TravellerLocation("Pitts",1,4,7,7), Spiritwood_Senate,Armour_Manufacturing,Axion_Alliance),
                                      new TravellerCompany("Lahaina Agricultural Supplies", new TravellerLocation("Lahaina",1,4,7,8), Spiritwood_Senate,Food,Axion_Alliance),
                                      
                                      new TravellerCompany("Ionia Spinal Weapons",  new TravellerLocation("Ionia",2,4,4,9), Ionia_Waskish_Trade_Pact,Large_Arms_Manufacturing,Xiao_Ming_Mega_Corporation),
                                      new TravellerCompany("Arima Agriculture",  new TravellerLocation("Waskish",2,4,5,8), Ionia_Waskish_Trade_Pact,Food,Xiao_Ming_Mega_Corporation,"Gihei Arima"),
                                      
                                      new TravellerCompany("Harwich Energy Weapons", new TravellerLocation("Harwichport",3,4,4,2), Harwichport_Simla_Parcol_Trade_Pact,Large_Arms_Manufacturing,Xiao_Ming_Mega_Corporation),
                                      new TravellerCompany("Favocation Industries", new TravellerLocation("Harwichport",3,4,4,2), Harwichport_Simla_Parcol_Trade_Pact,Manufacturing,Xiao_Ming_Mega_Corporation),

                                      new TravellerCompany("Rise Son, We've got Ammo!", new TravellerLocation("Rison",4,4,4,1), Jeffers_Kosse_Trade_Pact,Ammunition_Manufacturing,Xiao_Ming_Mega_Corporation),
                                      new TravellerCompany("Sum Up 'ur Rounds", new TravellerLocation("Sumpter",4,4,3,2), Jeffers_Kosse_Trade_Pact,Ammunition_Manufacturing,Xiao_Ming_Mega_Corporation),
                                      
                                      new TravellerCompany("Xiao-Will Suits and Stuff", new TravellerLocation("Willesvil",3,4,7,3), WillsVille_Trade_Pact,Armour_Manufacturing, Xiao_Ming_Mega_Corporation),
                                      
                                      new TravellerCompany("Imperial Torpedoes", new TravellerLocation("Struchia",2,2,6,5),Gunipped_Stellar_Empire ,Large_Arms_Manufacturing,Fifth_Vers_Empire),
                                      new TravellerCompany("Gun Equipped Ammunition ", new TravellerLocation("Gunripped",2,2,7,5), Gunipped_Stellar_Empire,Ammunition_Manufacturing,Fifth_Vers_Empire),

                                      new TravellerCompany("Evotis Point Defense Systems", new TravellerLocation("Evotis",2,2,4,9), Tilova_Pact,Large_Arms_Manufacturing,Axion_Alliance),
                                      new TravellerCompany("Sons of Drilions", new TravellerLocation("Drilion8JA",2,2,4,8), Tilova_Pact,Privateers,Axion_Alliance),
                                      
                                      new TravellerCompany("D-Liver Some Lead", new TravellerLocation("Delray",2,1,1,2), Kotlik_Tribunal,Ammunition_Manufacturing,Germushian_Free_Republic),
                                      new TravellerCompany("Tribunal Tailor", new TravellerLocation("Winnemucca",1,1,6,3), Kotlik_Tribunal,Armour_Manufacturing,Fifth_Vers_Empire),
                                      new TravellerCompany("Tribunal Food Supplies", new TravellerLocation("Cayey",1,1,8,3), Kotlik_Tribunal,Food,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Tribunal Toys", new TravellerLocation("Rheems",1,1,6,1), Kotlik_Tribunal,Toys_And_Trinkets,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Tribunal Central Supply", new TravellerLocation("Brill",2,1,1,1), Kotlik_Tribunal,Wholesellears,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Tribunal Resources", new TravellerLocation("Kotlik",1,1,5,3), Kotlik_Tribunal,Commodities,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("The Kotlik Exchange ", new TravellerLocation("Kotlik",1,1,5,3), Kotlik_Tribunal,Financial_Instituions,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Tribunal Capital", new TravellerLocation("Stryker",1,1,5,2), Kotlik_Tribunal,Venture_Capital_Firms,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),

                                      new TravellerCompany("Bellport Ammo", new TravellerLocation("Bellport",4,3,3,6), Western_Islands_Trade_Federation,Ammunition_Manufacturing, Germushian_Free_Republic),
                                      new TravellerCompany("Hume Hunting Rounds Industries", new TravellerLocation("Hume",4,2,4,5), Western_Islands_Trade_Federation,Ammunition_Manufacturing, Germushian_Free_Republic),
                                      new TravellerCompany("Safe and Singer Sound Armour", new TravellerLocation("Singer",1,1,1,1), Western_Islands_Trade_Federation,Armour_Manufacturing, Germushian_Free_Republic),
                                      new TravellerCompany("Our Protective layer", new TravellerLocation("Ouray",4,3,7,4), Western_Islands_Trade_Federation,Armour_Manufacturing, Germushian_Free_Republic),
                                      new TravellerCompany("Hard Hat's from Hume", new TravellerLocation("Hume",4,2,4,5), Western_Islands_Trade_Federation,Construction, Germushian_Free_Republic),
                                      new TravellerCompany("Nuremberg Construction", new TravellerLocation("Nuremberg",3,1,3,10), Western_Islands_Trade_Federation,Construction, Germushian_Free_Republic),
                                      new TravellerCompany("Niwot Food Industries", new TravellerLocation("Niwot",4,2,6,7), Western_Islands_Trade_Federation,Food, Germushian_Free_Republic),
                                      new TravellerCompany("Kahului Apples & Other Edible Options", new TravellerLocation("Kahului",4,2,5,9), Western_Islands_Trade_Federation,Food, Germushian_Free_Republic),
                                      new TravellerCompany("Blissful banking by Blissflied", new TravellerLocation("Blissfield",4,2,5,4), Western_Islands_Trade_Federation,Banking, Germushian_Free_Republic),
                                      new TravellerCompany("Janeson and Janeson", new TravellerLocation("Hitterdal",4,2,4,9), Western_Islands_Trade_Federation,Pharamesuiticals, Germushian_Free_Republic),
                                      new TravellerCompany("Pharma-Corp", new TravellerLocation("Kerkhoven",4,3,3,4), Western_Islands_Trade_Federation,Pharamesuiticals, Germushian_Free_Republic),
                                      new TravellerCompany("Nuremberg Pharmesuiticals Inc.", new TravellerLocation("Nuremberg",3,1,3,10), Western_Islands_Trade_Federation,Pharamesuiticals, Germushian_Free_Republic),
                                      new TravellerCompany("Mabton Pharmaceuticals Ltd.", new TravellerLocation("Mabton",4,1,6,10), Western_Islands_Trade_Federation,Pharamesuiticals, Germushian_Free_Republic),
                                      new TravellerCompany("Our Way to Help", new TravellerLocation("Ouray",4,3,7,4), Western_Islands_Trade_Federation,Pharamesuiticals, Germushian_Free_Republic),
                                      new TravellerCompany("Freedom Drugs", new TravellerLocation("Trevor",4,2,1,6), Western_Islands_Trade_Federation,Pharamesuiticals, Polandskia_Peoples_Union),
                                      new TravellerCompany("Kerkhoven Legal CPP", new TravellerLocation("Kerkhoven",4,3,3,4), Western_Islands_Trade_Federation,Law_Firms, Germushian_Free_Republic),
                                      new TravellerCompany("Quik-E-Out", new TravellerLocation("Jonancy",1,1,2,3), Western_Islands_Trade_Federation,Retail, Germushian_Free_Republic),
                                      new TravellerCompany("Barnwell Electric Comments Industries.", new TravellerLocation("Belchertow",4,2,6,3), Western_Islands_Trade_Federation,Eletronics_Production, Germushian_Free_Republic),
                                      new TravellerCompany("Thippe Electronics", new TravellerLocation("Thippe464",2,2,7,9), Western_Islands_Trade_Federation,Eletronics_Production, Germushian_Free_Republic),
                                      new TravellerCompany("Busters Baby-Tainment Toys", new TravellerLocation("Blissfield",4,2,5,9), Western_Islands_Trade_Federation,Toys_And_Trinkets, Germushian_Free_Republic),
                                      new TravellerCompany("Whipp the Truth", new TravellerLocation("Whippleville",4,1,6,1), Western_Islands_Trade_Federation,Media, Germushian_Free_Republic),
                                      new TravellerCompany("Lickup the Facts", new TravellerLocation("Knoblick",4,3,4,3), Western_Islands_Trade_Federation,Media, Germushian_Free_Republic),
                                      new TravellerCompany("Consortium News Network", new TravellerLocation("Whippleville",4,1,6,1), Western_Islands_Trade_Federation,Media, Germushian_Free_Republic),
                                      new TravellerCompany("Honest Hume's Humans", new TravellerLocation("Hume",4,2,4,5), Western_Islands_Trade_Federation ,Lobbying, Germushian_Free_Republic),
                                      new TravellerCompany("Gurnee Consulting Ltd.", new TravellerLocation("Gurnee",4,3,3,7), Western_Islands_Trade_Federation,Lobbying, Germushian_Free_Republic),
                                      new TravellerCompany("Hume Wholesellers Inc.", new TravellerLocation("Hume",4,2,4,5), Western_Islands_Trade_Federation,Wholesellears,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Tonto's Totally Tatical Gear", new TravellerLocation("Tontogany",4,1,5,1), Western_Islands_Trade_Federation,Retail,Germushian_Free_Republic),
                                      new TravellerCompany("Chain-O-Maniacs", new TravellerLocation("Belchertow",4,2,6,3), Western_Islands_Trade_Federation,Retail,Germushian_Free_Republic),
                                      
                                      new TravellerCompany("Consortium Ammunition", new TravellerLocation("Thendara",1,4,4,7), Intercourse_Subsector_Trade_Consortium,Ammunition_Manufacturing,Germushian_Free_Republic),
                                      new TravellerCompany("Thendara Trade Bank", new TravellerLocation("Thendara",1,4,4,7), Intercourse_Subsector_Trade_Consortium,Banking,Germushian_Free_Republic),
                                      new TravellerCompany("Pulciferian Pasta", new TravellerLocation("Pulcifer"), Intercourse_Subsector_Trade_Consortium,Food,Germushian_Free_Republic),
                                      new TravellerCompany("Bakersville Venture Capital", new TravellerLocation("Bakersville",1,4,2,4), Intercourse_Subsector_Trade_Consortium,Venture_Capital_Firms,Germushian_Free_Republic),
                                      new TravellerCompany("Bakers Law & Legal Experts", new TravellerLocation("Bakersville",1,4,2,4), Intercourse_Subsector_Trade_Consortium,Law_Firms,Germushian_Free_Republic),
                                      new TravellerCompany("Hoopeston Hoppers", new TravellerLocation("Hoopeston",1,4,2,2), Intercourse_Subsector_Trade_Consortium, Privateers,Germushian_Free_Republic),
                                      
                                      new TravellerCompany("Preventium Pulverziatorium",  new TravellerLocation("Pulcifer",1,4,4,5), Southern_Islands_Trade_Consortium,Armour_Manufacturing,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("I own Armour", new TravellerLocation("Ionia",2,4,4,9), Southern_Islands_Trade_Consortium,Armour_Manufacturing,Xiao_Ming_Mega_Corporation),
                                      new TravellerCompany("Chaska Construction",  new TravellerLocation("Chaska",2,4,5,3), Southern_Islands_Trade_Consortium,Construction,Germushian_Free_Republic),
                                      new TravellerCompany("Cirta Electronics Ind.",  new TravellerLocation("Charenton",2,4,4,4), Southern_Islands_Trade_Consortium,Eletronics_Production,Germushian_Free_Republic),
                                      new TravellerCompany("Protect ur Selfie", new TravellerLocation("Ionia",2,4,4,9), Southern_Islands_Trade_Consortium,Armour_Manufacturing,Xiao_Ming_Mega_Corporation),
                                      new TravellerCompany("Southern Defensive Emporium",  new TravellerLocation("Charenton",2,4,4,4), Southern_Islands_Trade_Consortium,Armour_Manufacturing,United_Reverse_Lords),

                                      new TravellerCompany("Grabbin from Bladin", new TravellerLocation("Bladin",2,4,4,5), Citra_Subsector_Trade_Constortium,Scavengers,Polandskia_Peoples_Union),                                      
                                      
                                      new TravellerCompany("Ricos Rough Rockers", new TravellerLocation("Esperanza",2,3,1,6), Western_Islands_Alliance,Armour_Manufacturing,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Keldron Armour", new TravellerLocation("Keldron",1,3,2,4), Western_Islands_Alliance,Armour_Manufacturing,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Devin's Defensive Dusters", new TravellerLocation("Camuy",1,3,5,7), Western_Islands_Alliance,Armour_Manufacturing,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Schallere Toys", new TravellerLocation("Schallere",1,3,2,4), Western_Islands_Alliance,Toys_And_Trinkets,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Tales from the Tree", new TravellerLocation("Kingstree",1,3,6,10), Western_Islands_Alliance,Media,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Quanah Electronics", new TravellerLocation("Quanah",1,3,5,8), Western_Islands_Alliance,Eletronics_Production,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Browerville Servent-Bots", new TravellerLocation("Browerville",1,3,3,7), Western_Islands_Alliance,Robot_Production,The_Kingdom_of_Britannia),
                                      new TravellerCompany("Keldron ", new TravellerLocation("Keldron",1,3,2,4), Western_Islands_Alliance,Robot_Production,Germushian_Free_Republic),
                                      new TravellerCompany("Super-Chains", new TravellerLocation("Keldron",1,3,2,4), Western_Islands_Alliance,Retail,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Allaince Small Stores COOP", new TravellerLocation("Quanah",1,3,5,8), Western_Islands_Alliance,Retail,United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                                      new TravellerCompany("Republican Retailers", new TravellerLocation("Chatfield",1,3,4,10), Western_Islands_Alliance,Retail,Germushian_Free_Republic),
                                      new TravellerCompany("Kingly Retailers", new TravellerLocation("Daggett",1,3,8,5), Western_Islands_Alliance,Retail,Fifth_Vers_Empire),
                                      
                                      new TravellerCompany("New Colchis Construction", new TravellerLocation("Besancon",2,3,7,6), New_Colchis_Business_Board,Construction,Germushian_Free_Republic),
                                      new TravellerCompany("Nebelwelt Manufacturing", new TravellerLocation("Nebelwelt",2,3,2,10), New_Colchis_Business_Board,Manufacturing,Germushian_Free_Republic),
                                      new TravellerCompany("Business Board Investment Capital", new TravellerLocation("Elysee",2,3,7,5), New_Colchis_Business_Board,Venture_Capital_Firms,Germushian_Free_Republic),
                                      
                                      new TravellerCompany("Dominate State Construction", new TravellerLocation("ReeDu",3,2,6,10), Venhut_Dominate_States,Construction,Trans_Galactic_Empire),
                                      new TravellerCompany("BodeyWak Boys", new TravellerLocation("BodeyWak",3,2,4,9), Venhut_Dominate_States,Privateers,Trans_Galactic_Empire),
                                      new TravellerCompany("Venhut-Dominate Resource Extraction Ltd.", new TravellerLocation("ReeDu",3,2,6,10), Venhut_Dominate_States,Commodities,Trans_Galactic_Empire),
                                      
                                      new TravellerCompany("Esperenza Meats & Wheats", new TravellerLocation("Esperanza",2,3,1,6), Esperenza,Food,Fifth_Vers_Empire),
                                      new TravellerCompany("Bank of Esperanza", new TravellerLocation("Esperanza",2,3,1,6), Esperenza,Banking,Fifth_Vers_Empire),
                                      
                                      new TravellerCompany("Nuken Home", new TravellerLocation("New Home",3,3,3,5), Old_Islands_Defense_League,Privateers),
                                      
                                      new TravellerCompany("The Strategist", new TravellerLocation("KneelDead",3,2,5,8), Mainhair_Military_Republic,Media,Germushian_Free_Republic),
                                      new TravellerCompany("Mainhair Military Manufacturing Ind.", new TravellerLocation("Garbreeze",3,2,5,7), Mainhair_Military_Republic,Manufacturing,Germushian_Free_Republic),
                                      
                                      new TravellerCompany("Essig Hunters", new TravellerLocation("Essig",1,4,2,9), Essia_Kitarchy,Privateers,United_Reverse_Lords),
                                      new TravellerCompany("Essig Healer", new TravellerLocation("Essig",1,4,2,9), Essia_Kitarchy,Healthcare,United_Reverse_Lords),
                                      
                                      new TravellerCompany("Trotskites Opinion Inc.", new TravellerLocation("Topas",2,3,7,2), Neubayern_Topas_Alliance,Lobbying,Communist_Empire_of_the_Deutschland),
                                      new TravellerCompany("Stalinksy Sound & Communication", new TravellerLocation("Neubayern",3,3,2,2), Neubayern_Topas_Alliance,Communications,Communist_Empire_of_the_Deutschland),
                                      new TravellerCompany("Communist Belters Retail", new TravellerLocation("Schlesien Belt",3,3,3,3), Neubayern_Topas_Alliance,Retail,Communist_Empire_of_the_Deutschland),
                                      new TravellerCompany("Sturgeons Stores", new TravellerLocation("Sturgeons Law",3,3,1,4), Neubayern_Topas_Alliance,Retail,Communist_Empire_of_the_Deutschland),
                                      
                                      new TravellerCompany("Protectorate Electronics", new TravellerLocation("Olitar",3,2,7,3), Olitar_Protectorate,Eletronics_Production,Communist_Empire_of_the_Deutschland),
                                      
                                      new TravellerCompany("General Space Electronics", new TravellerLocation("GenSpace",3,2,7,5), Sar_Tan_Confederacy,Eletronics_Production,United_Reverse_Lords),
                                      
                                      new TravellerCompany("Gregs Pills n Stuff", new TravellerLocation("Griggsvil",2,1,7,10), No_God_Land,Pharamesuiticals,Communist_Empire_of_the_Deutschland),
                                      new TravellerCompany("Doting Pharmasuiticales", new TravellerLocation("Doty",2,1,3,10), No_God_Land,Pharamesuiticals,Communist_Empire_of_the_Deutschland),
                                      new TravellerCompany("Post-Commune Electronics", new TravellerLocation("Lacamp",3,1,8,5), No_God_Land,Eletronics_Production,Communist_Empire_of_the_Deutschland),
                                      
                                      new TravellerCompany("Commune Cabbage", new TravellerLocation("Lithia",2,1,7,6), Western_Islands_Commune,Food),
                                      new TravellerCompany("Commune Emergency Surivival Gear", new TravellerLocation("Millport",2,1,2,5), Western_Islands_Commune,Emergency_Gear),
                                      new TravellerCompany("Commune Kids Toys", new TravellerLocation("Twining",2,1,6,8), Western_Islands_Commune,Toys_And_Trinkets),
                                      new TravellerCompany("Commune Wholesellars", new TravellerLocation("Griggsvil",2,1,7,10), Western_Islands_Commune,Wholesellears),
                                      new TravellerCompany("Western Commune Manufacturing", new TravellerLocation("Lithia",2,1,7,6), Western_Islands_Commune,Manufacturing),
                                      new TravellerCompany("South-Eastern Commune Manufacturing", new TravellerLocation("Uphitera",2,2,3,2), Western_Islands_Commune,Manufacturing),
                                      new TravellerCompany("Commune Law", new TravellerLocation("Knoxboro",2,1,4,8), Western_Islands_Commune,Law_Firms),
                                      new TravellerCompany("Commune Convinces", new TravellerLocation("Ittabena",3,1,8,3), Western_Islands_Commune,Lobbying),
                                      
                          };

        private static List<TravellerFaction> _factions = GetFactions();

    }
}