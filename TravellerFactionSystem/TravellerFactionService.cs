using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TravellerFactionSystem.Faction_Types;
using TravellerFactionSystem.FactionEnums;
using VoicesFromTheVoidArticles;
using static TravellerFactionSystem.FactionEnums.TravellerIslandsNations;
using static TravellerFactionSystem.FactionEnums.TravellerIndustries;
using static TravellerCharacter.CharcterTypes.TravellerNationalities;
using TravellerFactionSystem.Location;

namespace TravellerFactionSystem
{
    public class TravellerFactionService
    {
        private static readonly List<TravellerFaction> _factions = GetFactions();
        public List<TravellerFaction> Factions => _factions;

        public TravellerFaction GetTravellerFaction(int factionID)
        {
            return _factions.First(x => x.FactionID == factionID);
        }

        public List<TravellerNationGroup> IslandsNations =>
            Factions.Where(x => x.GetType() == typeof(TravellerNationGroup)).Cast<TravellerNationGroup>().ToList(); 

        public List<TravellerLocation> WorldsHeldByFactions()
        {
            var worldNames = new List<TravellerLocation>();
            var factionWorldNames = _factions.Select(x =>
            {
                var ret = new List<TravellerLocation>();
                ret.Add(x.HeadquatersTextLocation);

                if (x.HasOtherLocation)
                    foreach (var world in x.OtherOwnedLocations)
                        ret.Add(world);

                return ret;
            });

            foreach (var factionLists in factionWorldNames)
            foreach (var world in factionLists)
                if (!worldNames.Contains(world))
                    worldNames.Add(world);

            return worldNames;
        }

        public void AddFaction(TravellerFaction faction)
        {
            _factions.Add(faction);
        }

        private static List<TravellerFaction> GetFactionFromJson()
        {
            var companyPath = Directory.GetCurrentDirectory() + "/Data/Factions/Companies.json";
            var religionPath = Directory.GetCurrentDirectory() + "/Data/Factions/Religions.json";
            var crimePath = Directory.GetCurrentDirectory() + "/Data/Factions/Criminals.json";
            var legalPath = Directory.GetCurrentDirectory() + "/Data/Factions/Legals.json";
            var politicalPath = Directory.GetCurrentDirectory() + "/Data/Factions/Politicals.json";

            var classPath = Directory.GetCurrentDirectory() + "/Data/Factions/Classes.json";
            var otherPath = Directory.GetCurrentDirectory() + "/Data/Factions/Others.json";
            var socialPath = Directory.GetCurrentDirectory() + "/Data/Factions/Socials.json";
            var majorGovPath = Directory.GetCurrentDirectory() + "/Data/Factions/Majors.json";
            var islandGodPath = Directory.GetCurrentDirectory() + "/Data/Factions/Islands.json";

            var factions = new List<TravellerFaction>();

            AddCompany(factions, companyPath);
            AddReligion(factions, religionPath);
            AddPolitical(factions, politicalPath);
            AddSocial(factions, socialPath);
            AddOther(factions, otherPath);
            AddCrime(factions, crimePath);
            AddLegal(factions, legalPath);
            AddClass(factions, classPath);
            AddMajorGov(factions, majorGovPath);
            AddGov(factions, islandGodPath);

            return factions;
        }

        private static void AddGov(List<TravellerFaction> factions, string path)
        {
            var travellerCompaniesJson =
                JsonConvert.DeserializeObject<List<TravellerNationGroup>>(File.ReadAllText(path));

            foreach (var result in travellerCompaniesJson ?? new List<TravellerNationGroup>())
                if (result is { } comp)
                    factions.Add(comp);
        }

        private static void AddMajorGov(List<TravellerFaction> factions, string path)
        {
            var travellerCompaniesJson =
                JsonConvert.DeserializeObject<List<TravellerMajorNationGroup>>(File.ReadAllText(path));

            foreach (var result in travellerCompaniesJson ?? new List<TravellerMajorNationGroup>())
                if (result is { } comp)
                    factions.Add(comp);
        }

        private static void AddClass(List<TravellerFaction> factions, string path)
        {
            var travellerCompaniesJson =
                JsonConvert.DeserializeObject<List<TravellerClassGroup>>(File.ReadAllText(path));

            foreach (var result in travellerCompaniesJson ?? new List<TravellerClassGroup>())
                if (result is { } comp)
                    factions.Add(comp);
        }

        private static void AddLegal(List<TravellerFaction> factions, string path)
        {
            var travellerCompaniesJson =
                JsonConvert.DeserializeObject<List<TravellerProfessionalGroup>>(File.ReadAllText(path));

            foreach (var result in travellerCompaniesJson ?? new List<TravellerProfessionalGroup>())
                if (result is { } comp)
                    factions.Add(comp);
        }

        private static void AddCrime(List<TravellerFaction> factions, string path)
        {
            var travellerCompaniesJson =
                JsonConvert.DeserializeObject<List<TravellerCrimeGroup>>(File.ReadAllText(path));

            foreach (var result in travellerCompaniesJson ?? new List<TravellerCrimeGroup>())
                if (result is { } comp)
                    factions.Add(comp);
        }

        private static void AddOther(List<TravellerFaction> factions, string path)
        {
            var travellerCompaniesJson =
                JsonConvert.DeserializeObject<List<TravellerOtherGroup>>(File.ReadAllText(path));

            foreach (var result in travellerCompaniesJson ?? new List<TravellerOtherGroup>())
                if (result is { } comp)
                    factions.Add(comp);
        }

        private static void AddSocial(List<TravellerFaction> factions, string path)
        {
            var travellerCompaniesJson =
                JsonConvert.DeserializeObject<List<TravellerSocialGroup>>(File.ReadAllText(path));

            foreach (var result in travellerCompaniesJson ?? new List<TravellerSocialGroup>())
                if (result is { } comp)
                    factions.Add(comp);
        }

        private static void AddCompany(List<TravellerFaction> factions, string path)
        {
            var travellerCompaniesJson = JsonConvert.DeserializeObject<List<TravellerCompany>>(File.ReadAllText(path));

            foreach (var result in travellerCompaniesJson ?? new List<TravellerCompany>())
                if (result is { } comp)
                    factions.Add(comp);
        }


        private static void AddReligion(List<TravellerFaction> factions, string path)
        {
            var travellerCompaniesJson = JsonConvert.DeserializeObject<List<TravellerReligion>>(File.ReadAllText(path));

            foreach (var result in travellerCompaniesJson ?? new List<TravellerReligion>())
                if (result is { } comp)
                    factions.Add(comp);
        }


        private static void AddPolitical(List<TravellerFaction> factions, string path)
        {
            var travellerCompaniesJson =
                JsonConvert.DeserializeObject<List<TravellerPoliticalGroup>>(File.ReadAllText(path));

            foreach (var result in travellerCompaniesJson ?? new List<TravellerPoliticalGroup>())
                if (result is { } comp)
                    factions.Add(comp);
        }

        private static List<TravellerFaction> GetFactions()
        {
            if (_factions == null || _factions.Count == 0)
            {
                var factions = new List<TravellerFaction>();
                var codeFactions = GetCodeFactions();
                foreach (var fac in codeFactions) factions.Add(fac);

                var jsonFactions = GetFactionFromJson();
                foreach (var fac in jsonFactions) factions.Add(fac);

                return factions;
            }

            return _factions;
        }

        private static List<TravellerFaction> GetCodeFactions()
        {
            return new List<TravellerFaction>()
            {
                new TravellerCompany("Voices From the Void",
                    new TravellerTextLocation("Somewhere in the black", 1, 1, 5, 5),
                    None, Media, Universalis_Confederation, "The Collective",
                    null, new TravellerDateTime(01, 01, 83, 390 - 50)),

                new TravellerCompany("Dominate Missiles", new TravellerTextLocation("Reedsville", 1, 2, 3, 2),
                    Dominate_Supremius, Large_Arms_Manufacturing, First_Order),
                new TravellerCompany("Rushforth for money!", new TravellerTextLocation("Rushford", 1, 2, 1, 7),
                    Dominate_Supremius, Privateers, First_Order),
                new TravellerCompany("Hunnelwell Hunters", new TravellerTextLocation("Hunnelwell", 1, 1, 1, 9),
                    Dominate_Supremius, Privateers, The_Kingdom_of_Britannia),
                new TravellerCompany("Tip Top Imperial Tailor", new TravellerTextLocation("Hazelcrest", 1, 2, 3, 6),
                    Dominate_Supremius, Armour_Manufacturing, The_Kingdom_of_Britannia),
                new TravellerCompany("Dominate Foreign Construction", new TravellerTextLocation("Ronks", 1, 1, 2, 8),
                    Dominate_Supremius, Construction, The_Kingdom_of_Britannia),
                new TravellerCompany("Dominate Local Construction", new TravellerTextLocation("Bunkie", 1, 1, 2, 9),
                    Dominate_Supremius, Construction, First_Order),
                new TravellerCompany("Imperial Pharmaceuticals", new TravellerTextLocation("Bandera", 1, 2, 4, 7),
                    Dominate_Supremius, Pharamesuiticals, Trans_Galactic_Empire),
                new TravellerCompany("The Imperial Standard", new TravellerTextLocation("Weskan", 1, 2, 8, 5),
                    Dominate_Supremius, Media, Trans_Galactic_Empire),
                new TravellerCompany("Tokeland Imperial Hopsital", new TravellerTextLocation("Tokeland", 1, 3, 7, 3),
                    Dominate_Supremius, Healthcare, First_Order),
                new TravellerCompany("Imperial Droids", new TravellerTextLocation("Rangeley", 1, 2, 7, 8),
                    Dominate_Supremius, Robot_Production, Trans_Galactic_Empire),
                new TravellerCompany("Britannian Automatons", new TravellerTextLocation("Dongeal", 1, 2, 5, 10),
                    Dominate_Supremius, Robot_Production, The_Kingdom_of_Britannia),
                new TravellerCompany("Imperial Minerals", new TravellerTextLocation("Oran", 1, 2, 7, 2), Dominate_Supremius,
                    Commodities, Trans_Galactic_Empire),
                new TravellerCompany("Pickin for Plumtree", new TravellerTextLocation("Plumtree", 1, 2, 7, 7),
                    Dominate_Supremius, Scavengers, First_Order),
                new TravellerCompany("Imperial Communications", new TravellerTextLocation("Kayenta", 1, 2, 7, 3),
                    Dominate_Supremius, Communications, The_Kingdom_of_Britannia),
                new TravellerCompany("First Standard Electronics", new TravellerTextLocation("Barinsvil", 1, 2, 2),
                    Dominate_Supremius, Eletronics_Production, First_Order),
                new TravellerCompany("Imperial Electronics", new TravellerTextLocation("Norwell", 1, 2, 4),
                    Dominate_Supremius, Eletronics_Production, The_Kingdom_of_Britannia),
                new TravellerCompany("Imperial-Owned Stores", new TravellerTextLocation("Goldbar", 1, 3, 6),
                    Dominate_Supremius, Retail, Trans_Galactic_Empire),

                new TravellerCompany("Moncut Turrets", new TravellerTextLocation("Moncut", 3, 2, 1, 7),
                    Independent_Baronies, Large_Arms_Manufacturing, First_Order),
                new TravellerCompany("Bro I've made some Ammo", new TravellerTextLocation("Bronaugh", 1, 3, 8, 8),
                    Independent_Baronies, Ammunition_Manufacturing, The_Kingdom_of_Britannia),
                new TravellerCompany("Sustone Robotics", new TravellerTextLocation("Sustone", 3, 2, 2),
                    Independent_Baronies, Robot_Production, Germushian_Free_Republic),
                new TravellerCompany("Trevor Comms Devices", new TravellerTextLocation("Trevor", 4, 2, 1, 6),
                    Independent_Baronies, Communications, Xiao_Ming_Mega_Corporation),
                new TravellerCompany("Princes Peridoical", new TravellerTextLocation("Worland", 3, 4, 6),
                    Independent_Baronies, Media, Fifth_Vers_Empire),
                new TravellerCompany("Etty Agricultural Ltd", new TravellerTextLocation("Etty", 2, 4, 7, 4),
                    Independent_Baronies, Food, United_Reverse_Lords),
                new TravellerCompany("Bro I've got some food", new TravellerTextLocation("Bronaugh", 1, 3, 8, 8),
                    Independent_Baronies, Food, Artekkan_Guilds),
                new TravellerCompany("Fruid of the Fields of Thippe", new TravellerTextLocation("Thippe464", 2, 2, 7, 9),
                    Independent_Baronies, Food, Axion_Alliance),
                new TravellerCompany("Moko Emergency Supplies", new TravellerTextLocation("Moko", 3, 1, 7, 7),
                    Independent_Baronies, Emergency_Gear, Xiao_Ming_Mega_Corporation),
                new TravellerCompany("Garrisonville Privateers", new TravellerTextLocation("Garrisonville", 1, 1, 6, 7),
                    Independent_Baronies, Privateers, Communist_Empire_of_the_Deutschland),
                new TravellerCompany("Scavs from Sansterre", new TravellerTextLocation("Sansterre", 3, 3, 7, 2),
                    Independent_Defense_Federation, Scavengers, Communist_Empire_of_the_Deutschland),
                new TravellerCompany("Rebecca's Friends", new TravellerTextLocation("Terrell", 4, 2, 3, 2),
                    Independent_Baronies, Lobbying, United_Federation_of_Earth_and_her_Colonies_Among_the_Stars,
                    "Rebecca"),
                new TravellerCompany("Ron's Law Firm", new TravellerTextLocation("Charenton", 2, 4, 4, 4),
                    Independent_Baronies, Law_Firms, Polandskia_Peoples_Union),
                new TravellerCompany("Hutt Capital", new TravellerTextLocation("Hutto", 2, 1, 4, 3), Independent_Baronies,
                    Venture_Capital_Firms),
                new TravellerCompany("Kenduskeag Stock Market", new TravellerTextLocation("Kenduskeag", 3, 1, 7, 9),
                    Independent_Baronies, Financial_Instituions),
                new TravellerCompany("Vandiver Industrial Manufacturing", new TravellerTextLocation("Vandiver", 3, 4, 1, 4),
                    Independent_Baronies, Manufacturing, Imperial_Versian_Federated_Territories),
                new TravellerCompany("Coda Metal Sellars Alliance", new TravellerTextLocation("Coda", 3, 2, 7, 8),
                    Independent_Baronies, Retail, Fifth_Vers_Empire),

                new TravellerCompany("Kings Tailor", new TravellerTextLocation("Bremerton", 4, 1, 2, 3), Rex_Van_Der_Sever,
                    Armour_Manufacturing, Fifth_Vers_Empire),
                new TravellerCompany("Royal Garbs", new TravellerTextLocation("Quichotte", 3, 3, 1, 9),
                    Rex_Van_Der_Ostrovski, Armour_Manufacturing, Fifth_Vers_Empire),
                new TravellerCompany("Acadie Clothing Imporium", new TravellerTextLocation("Acadie", 3, 3, 6, 5),
                    Rex_Van_Der_Ostrovski, Armour_Manufacturing, Fifth_Vers_Empire),
                new TravellerCompany("His Magesties Construction", new TravellerTextLocation("Twining", 2, 1, 6, 10),
                    Rex_Van_Der_Sever, Construction, Fifth_Vers_Empire),
                new TravellerCompany("Royal Construction", new TravellerTextLocation("Sumpter", 4, 4, 3, 2),
                    Rex_Van_Der_Ostrovski, Construction, Fifth_Vers_Empire),
                new TravellerCompany("King's Quality Construction", new TravellerTextLocation("Lattimore", 3, 4, 8, 6),
                    Rex_Van_Der_Ostrovski, Construction, Fifth_Vers_Empire),
                new TravellerCompany("Royal Investments", new TravellerTextLocation("Levant", 4, 4, 2, 5),
                    Rex_Van_Der_Ostrovski, Venture_Capital_Firms, Fifth_Vers_Empire),
                new TravellerCompany("His Magesties Shoppes", new TravellerTextLocation("Collbran", 3, 4, 2),
                    Rex_Van_Der_Ostrovski, Retail, Fifth_Vers_Empire),
                new TravellerCompany("Royal Surplus", new TravellerTextLocation("Wahpeton", 4, 4, 3, 5),
                    Rex_Van_Der_Ostrovski, Wholesellears, Fifth_Vers_Empire),
                new TravellerCompany("Royal Electronics", new TravellerTextLocation("Rison", 4, 4, 4),
                    Rex_Van_Der_Ostrovski, Eletronics_Production, Fifth_Vers_Empire),
                new TravellerCompany("Lordly Components", new TravellerTextLocation("Cadyville", 4, 4, 4, 5),
                    Rex_Van_Der_Ostrovski, Eletronics_Production, Fifth_Vers_Empire),
                new TravellerCompany("Princes Playthings", new TravellerTextLocation("Collbran", 3, 4, 2),
                    Rex_Van_Der_Ostrovski, Toys_And_Trinkets, Fifth_Vers_Empire),
                new TravellerCompany("The Royal Medicine Chest", new TravellerTextLocation("Jeffers", 4, 3, 2, 9),
                    Rex_Van_Der_Ostrovski, Pharamesuiticals, Fifth_Vers_Empire),
                new TravellerCompany("His Highness's  Aid", new TravellerTextLocation("Graytown", 4, 4, 8, 2),
                    Rex_Van_Der_Ostrovski, Pharamesuiticals, Fifth_Vers_Empire),
                new TravellerCompany("Royal Fields", new TravellerTextLocation("Hazelhurst", 3, 4, 4, 9),
                    Rex_Van_Der_Ostrovski, Food, Fifth_Vers_Empire),
                new TravellerCompany("His Majesties Dinner Supplier", new TravellerTextLocation("Cawood", 4, 4, 7, 5),
                    Rex_Van_Der_Ostrovski, Food, Fifth_Vers_Empire),
                new TravellerCompany("Joyuse Joy-toys", new TravellerTextLocation("Joyuse", 2, 3, 8, 8),
                    Rex_Van_Der_Ostrovski, Robot_Production,
                    United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                new TravellerCompany("Kosse's Kings Kommandments", new TravellerTextLocation("Kosse", 4, 3, 4, 9),
                    Rex_Van_Der_Ostrovski, Media, Xiao_Ming_Mega_Corporation),
                new TravellerCompany("Regents Retail", new TravellerTextLocation("Langford", 4, 4, 6, 5),
                    Rex_Van_Der_Ostrovski, Retail, Fifth_Vers_Empire),
                new TravellerCompany("Northern Kings Retail Guild", new TravellerTextLocation("Mamyria", 2, 2, 4, 2),
                    Rex_Van_Der_Sever, Retail, Communist_Empire_of_the_Deutschland),

                new TravellerCompany("Spiritwood Bay Weapons", new TravellerTextLocation("Lahaina", 1, 4, 7, 8),
                    Spiritwood_Senate, Large_Arms_Manufacturing, Axion_Alliance),
                new TravellerCompany("Spiritwood Soldiers", new TravellerTextLocation("Spiritwood", 1, 4, 7, 9),
                    Spiritwood_Senate, Privateers, Communist_Empire_of_the_Deutschland),
                new TravellerCompany("Pitts Consultants Ltd.", new TravellerTextLocation("Pitts", 1, 4, 7, 7),
                    Spiritwood_Senate, Lobbying, Xiao_Ming_Mega_Corporation),
                new TravellerCompany("Spiritwood Extractions", new TravellerTextLocation("Spiritwood", 1, 4, 7, 9),
                    Spiritwood_Senate, Commodities, Artekkan_Guilds),
                new TravellerCompany("Spirit of Defense", new TravellerTextLocation("Immokalee", 2, 4, 1, 7),
                    Spiritwood_Senate, Armour_Manufacturing, Axion_Alliance),
                new TravellerCompany("Senatatoral Suits", new TravellerTextLocation("Pitts", 1, 4, 7, 7), Spiritwood_Senate,
                    Armour_Manufacturing, Axion_Alliance),
                new TravellerCompany("Lahaina Agricultural Supplies", new TravellerTextLocation("Lahaina", 1, 4, 7, 8),
                    Spiritwood_Senate, Food, Axion_Alliance),

                new TravellerCompany("Ionia Spinal Weapons", new TravellerTextLocation("Ionia", 2, 4, 4, 9),
                    Ionia_Waskish_Trade_Pact, Large_Arms_Manufacturing, Xiao_Ming_Mega_Corporation),
                new TravellerCompany("Arima Agriculture", new TravellerTextLocation("Waskish", 2, 4, 5, 8),
                    Ionia_Waskish_Trade_Pact, Food, Xiao_Ming_Mega_Corporation, "Gihei Arima"),

                new TravellerCompany("Harwich Energy Weapons", new TravellerTextLocation("Harwichport", 3, 4, 4, 2),
                    Harwichport_Simla_Parcol_Trade_Pact, Large_Arms_Manufacturing, Xiao_Ming_Mega_Corporation),
                new TravellerCompany("Favocation Industries", new TravellerTextLocation("Harwichport", 3, 4, 4, 2),
                    Harwichport_Simla_Parcol_Trade_Pact, Manufacturing, Xiao_Ming_Mega_Corporation),

                new TravellerCompany("Rise Son, We've got Ammo!", new TravellerTextLocation("Rison", 4, 4, 4),
                    Jeffers_Kosse_Trade_Pact, Ammunition_Manufacturing, Xiao_Ming_Mega_Corporation),
                new TravellerCompany("Sum Up 'ur Rounds", new TravellerTextLocation("Sumpter", 4, 4, 3, 2),
                    Jeffers_Kosse_Trade_Pact, Ammunition_Manufacturing, Xiao_Ming_Mega_Corporation),

                new TravellerCompany("Xiao-Will Suits and Stuff", new TravellerTextLocation("Willesvil", 3, 4, 7, 3),
                    WillsVille_Trade_Pact, Armour_Manufacturing, Xiao_Ming_Mega_Corporation),

                new TravellerCompany("Imperial Torpedoes", new TravellerTextLocation("Struchia", 2, 2, 6, 5),
                    Gunipped_Stellar_Empire, Large_Arms_Manufacturing, Fifth_Vers_Empire),
                new TravellerCompany("Gun Equipped Ammunition ", new TravellerTextLocation("Gunripped", 2, 2, 7, 5),
                    Gunipped_Stellar_Empire, Ammunition_Manufacturing, Fifth_Vers_Empire),

                new TravellerCompany("Evotis Point Defense Systems", new TravellerTextLocation("Evotis", 2, 2, 4, 9),
                    Tilova_Pact, Large_Arms_Manufacturing, Axion_Alliance),
                new TravellerCompany("Sons of Drilions", new TravellerTextLocation("Drilion8JA", 2, 2, 4, 8), Tilova_Pact,
                    Privateers, Axion_Alliance),

                new TravellerCompany("D-Liver Some Lead", new TravellerTextLocation("Delray", 2, 1, 1, 2), Kotlik_Tribunal,
                    Ammunition_Manufacturing, Germushian_Free_Republic),
                new TravellerCompany("Tribunal Tailor", new TravellerTextLocation("Winnemucca", 1, 1, 6, 3),
                    Kotlik_Tribunal, Armour_Manufacturing, Fifth_Vers_Empire),
                new TravellerCompany("Tribunal Food Supplies", new TravellerTextLocation("Cayey", 1, 1, 8, 3),
                    Kotlik_Tribunal, Food, United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                new TravellerCompany("Tribunal Toys", new TravellerTextLocation("Rheems", 1, 1, 6), Kotlik_Tribunal,
                    Toys_And_Trinkets, United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                new TravellerCompany("Tribunal Central Supply", new TravellerTextLocation("Brill", 2), Kotlik_Tribunal,
                    Wholesellears, United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                new TravellerCompany("Tribunal Resources", new TravellerTextLocation("Kotlik", 1, 1, 5, 3), Kotlik_Tribunal,
                    Commodities, United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                new TravellerCompany("The Kotlik Exchange ", new TravellerTextLocation("Kotlik", 1, 1, 5, 3),
                    Kotlik_Tribunal, Financial_Instituions,
                    United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                new TravellerCompany("Tribunal Capital", new TravellerTextLocation("Stryker", 1, 1, 5, 2), Kotlik_Tribunal,
                    Venture_Capital_Firms, United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),

                new TravellerCompany("Bellport Ammo", new TravellerTextLocation("Bellport", 4, 3, 3, 6),
                    Western_Islands_Trade_Federation, Ammunition_Manufacturing, Germushian_Free_Republic),
                new TravellerCompany("Hume Hunting Rounds Industries", new TravellerTextLocation("Hume", 4, 2, 4, 5),
                    Western_Islands_Trade_Federation, Ammunition_Manufacturing, Germushian_Free_Republic),
                new TravellerCompany("Safe and Singer Sound Armour", new TravellerTextLocation("Singer"),
                    Western_Islands_Trade_Federation, Armour_Manufacturing, Germushian_Free_Republic),
                new TravellerCompany("Our Protective layer", new TravellerTextLocation("Ouray", 4, 3, 7, 4),
                    Western_Islands_Trade_Federation, Armour_Manufacturing, Germushian_Free_Republic),
                new TravellerCompany("Hard Hat's from Hume", new TravellerTextLocation("Hume", 4, 2, 4, 5),
                    Western_Islands_Trade_Federation, Construction, Germushian_Free_Republic),
                new TravellerCompany("Nuremberg Construction", new TravellerTextLocation("Nuremberg", 3, 1, 3, 10),
                    Western_Islands_Trade_Federation, Construction, Germushian_Free_Republic),
                new TravellerCompany("Niwot Food Industries", new TravellerTextLocation("Niwot", 4, 2, 6, 7),
                    Western_Islands_Trade_Federation, Food, Germushian_Free_Republic),
                new TravellerCompany("Kahului Apples & Other Edible Options",
                    new TravellerTextLocation("Kahului", 4, 2, 5, 9), Western_Islands_Trade_Federation, Food,
                    Germushian_Free_Republic),
                new TravellerCompany("Blissful banking by Blissflied", new TravellerTextLocation("Blissfield", 4, 2, 5, 4),
                    Western_Islands_Trade_Federation, Banking, Germushian_Free_Republic),
                new TravellerCompany("Janeson and Janeson", new TravellerTextLocation("Hitterdal", 4, 2, 4, 9),
                    Western_Islands_Trade_Federation, Pharamesuiticals, Germushian_Free_Republic),
                new TravellerCompany("Pharma-Corp", new TravellerTextLocation("Kerkhoven", 4, 3, 3, 4),
                    Western_Islands_Trade_Federation, Pharamesuiticals, Germushian_Free_Republic),
                new TravellerCompany("Nuremberg Pharmesuiticals Inc.", new TravellerTextLocation("Nuremberg", 3, 1, 3, 10),
                    Western_Islands_Trade_Federation, Pharamesuiticals, Germushian_Free_Republic),
                new TravellerCompany("Mabton Pharmaceuticals Ltd.", new TravellerTextLocation("Mabton", 4, 1, 6, 10),
                    Western_Islands_Trade_Federation, Pharamesuiticals, Germushian_Free_Republic),
                new TravellerCompany("Our Way to Help", new TravellerTextLocation("Ouray", 4, 3, 7, 4),
                    Western_Islands_Trade_Federation, Pharamesuiticals, Germushian_Free_Republic),
                new TravellerCompany("Freedom Drugs", new TravellerTextLocation("Trevor", 4, 2, 1, 6),
                    Western_Islands_Trade_Federation, Pharamesuiticals, Polandskia_Peoples_Union),
                new TravellerCompany("Kerkhoven Legal CPP", new TravellerTextLocation("Kerkhoven", 4, 3, 3, 4),
                    Western_Islands_Trade_Federation, Law_Firms, Germushian_Free_Republic),
                new TravellerCompany("Quik-E-Out", new TravellerTextLocation("Jonancy", 1, 1, 2, 3),
                    Western_Islands_Trade_Federation, Retail, Germushian_Free_Republic),
                new TravellerCompany("Barnwell Electric Comments Industries.",
                    new TravellerTextLocation("Belchertow", 4, 2, 6, 3), Western_Islands_Trade_Federation,
                    Eletronics_Production, Germushian_Free_Republic),
                new TravellerCompany("Thippe Electronics", new TravellerTextLocation("Thippe464", 2, 2, 7, 9),
                    Western_Islands_Trade_Federation, Eletronics_Production, Germushian_Free_Republic),
                new TravellerCompany("Busters Baby-Tainment Toys", new TravellerTextLocation("Blissfield", 4, 2, 5, 9),
                    Western_Islands_Trade_Federation, Toys_And_Trinkets, Germushian_Free_Republic),
                new TravellerCompany("Whipp the Truth", new TravellerTextLocation("Whippleville", 4, 1, 6),
                    Western_Islands_Trade_Federation, Media, Germushian_Free_Republic),
                new TravellerCompany("Lickup the Facts", new TravellerTextLocation("Knoblick", 4, 3, 4, 3),
                    Western_Islands_Trade_Federation, Media, Germushian_Free_Republic),
                new TravellerCompany("Consortium News Network", new TravellerTextLocation("Whippleville", 4, 1, 6),
                    Western_Islands_Trade_Federation, Media, Germushian_Free_Republic),
                new TravellerCompany("Honest Hume's Humans", new TravellerTextLocation("Hume", 4, 2, 4, 5),
                    Western_Islands_Trade_Federation, Lobbying, Germushian_Free_Republic),
                new TravellerCompany("Gurnee Consulting Ltd.", new TravellerTextLocation("Gurnee", 4, 3, 3, 7),
                    Western_Islands_Trade_Federation, Lobbying, Germushian_Free_Republic),
                new TravellerCompany("Hume Wholesellers Inc.", new TravellerTextLocation("Hume", 4, 2, 4, 5),
                    Western_Islands_Trade_Federation, Wholesellears,
                    United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                new TravellerCompany("Tonto's Totally Tatical Gear", new TravellerTextLocation("Tontogany", 4, 1, 5),
                    Western_Islands_Trade_Federation, Retail, Germushian_Free_Republic),
                new TravellerCompany("Chain-O-Maniacs", new TravellerTextLocation("Belchertow", 4, 2, 6, 3),
                    Western_Islands_Trade_Federation, Retail, Germushian_Free_Republic),

                new TravellerCompany("Consortium Ammunition", new TravellerTextLocation("Thendara", 1, 4, 4, 7),
                    Intercourse_Subsector_Trade_Consortium, Ammunition_Manufacturing, Germushian_Free_Republic),
                new TravellerCompany("Thendara Trade Bank", new TravellerTextLocation("Thendara", 1, 4, 4, 7),
                    Intercourse_Subsector_Trade_Consortium, Banking, Germushian_Free_Republic),
                new TravellerCompany("Pulciferian Pasta", new TravellerTextLocation("Pulcifer"),
                    Intercourse_Subsector_Trade_Consortium, Food, Germushian_Free_Republic),
                new TravellerCompany("Bakersville Venture Capital", new TravellerTextLocation("Bakersville", 1, 4, 2, 4),
                    Intercourse_Subsector_Trade_Consortium, Venture_Capital_Firms, Germushian_Free_Republic),
                new TravellerCompany("Bakers Law & Legal Experts", new TravellerTextLocation("Bakersville", 1, 4, 2, 4),
                    Intercourse_Subsector_Trade_Consortium, Law_Firms, Germushian_Free_Republic),
                new TravellerCompany("Hoopeston Hoppers", new TravellerTextLocation("Hoopeston", 1, 4, 2, 2),
                    Intercourse_Subsector_Trade_Consortium, Privateers, Germushian_Free_Republic),

                new TravellerCompany("Preventium Pulverziatorium", new TravellerTextLocation("Pulcifer", 1, 4, 4, 5),
                    Southern_Islands_Trade_Consortium, Armour_Manufacturing,
                    United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                new TravellerCompany("I own Armour", new TravellerTextLocation("Ionia", 2, 4, 4, 9),
                    Southern_Islands_Trade_Consortium, Armour_Manufacturing, Xiao_Ming_Mega_Corporation),
                new TravellerCompany("Chaska Construction", new TravellerTextLocation("Chaska", 2, 4, 5, 3),
                    Southern_Islands_Trade_Consortium, Construction, Germushian_Free_Republic),
                new TravellerCompany("Cirta Electronics Ind.", new TravellerTextLocation("Charenton", 2, 4, 4, 4),
                    Southern_Islands_Trade_Consortium, Eletronics_Production, Germushian_Free_Republic),
                new TravellerCompany("Protect ur Selfie", new TravellerTextLocation("Ionia", 2, 4, 4, 9),
                    Southern_Islands_Trade_Consortium, Armour_Manufacturing, Xiao_Ming_Mega_Corporation),
                new TravellerCompany("Southern Defensive Emporium", new TravellerTextLocation("Charenton", 2, 4, 4, 4),
                    Southern_Islands_Trade_Consortium, Armour_Manufacturing, United_Reverse_Lords),

                new TravellerCompany("Grabbin from Bladin", new TravellerTextLocation("Bladin", 2, 4, 4, 5),
                    Citra_Subsector_Trade_Constortium, Scavengers, Polandskia_Peoples_Union),

                new TravellerCompany("Ricos Rough Rockers", new TravellerTextLocation("Esperanza", 2, 3, 1, 6),
                    Western_Islands_Alliance, Armour_Manufacturing,
                    United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                new TravellerCompany("Keldron Armour", new TravellerTextLocation("Keldron", 1, 3, 2, 4),
                    Western_Islands_Alliance, Armour_Manufacturing,
                    United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                new TravellerCompany("Devin's Defensive Dusters", new TravellerTextLocation("Camuy", 1, 3, 5, 7),
                    Western_Islands_Alliance, Armour_Manufacturing,
                    United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                new TravellerCompany("Schallere Toys", new TravellerTextLocation("Schallere", 1, 3, 2, 4),
                    Western_Islands_Alliance, Toys_And_Trinkets,
                    United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                new TravellerCompany("Tales from the Tree", new TravellerTextLocation("Kingstree", 1, 3, 6, 10),
                    Western_Islands_Alliance, Media, United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                new TravellerCompany("Quanah Electronics", new TravellerTextLocation("Quanah", 1, 3, 5, 8),
                    Western_Islands_Alliance, Eletronics_Production,
                    United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                new TravellerCompany("Browerville Servent-Bots", new TravellerTextLocation("Browerville", 1, 3, 3, 7),
                    Western_Islands_Alliance, Robot_Production, The_Kingdom_of_Britannia),
                new TravellerCompany("Keldron ", new TravellerTextLocation("Keldron", 1, 3, 2, 4), Western_Islands_Alliance,
                    Robot_Production, Germushian_Free_Republic),
                new TravellerCompany("Super-Chains", new TravellerTextLocation("Keldron", 1, 3, 2, 4),
                    Western_Islands_Alliance, Retail, United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                new TravellerCompany("Allaince Small Stores COOP", new TravellerTextLocation("Quanah", 1, 3, 5, 8),
                    Western_Islands_Alliance, Retail, United_Federation_of_Earth_and_her_Colonies_Among_the_Stars),
                new TravellerCompany("Republican Retailers", new TravellerTextLocation("Chatfield", 1, 3, 4, 10),
                    Western_Islands_Alliance, Retail, Germushian_Free_Republic),
                new TravellerCompany("Kingly Retailers", new TravellerTextLocation("Daggett", 1, 3, 8, 5),
                    Western_Islands_Alliance, Retail, Fifth_Vers_Empire),

                new TravellerCompany("New Colchis Construction", new TravellerTextLocation("Besancon", 2, 3, 7, 6),
                    New_Colchis_Business_Board, Construction, Germushian_Free_Republic),
                new TravellerCompany("Nebelwelt Manufacturing", new TravellerTextLocation("Nebelwelt", 2, 3, 2, 10),
                    New_Colchis_Business_Board, Manufacturing, Germushian_Free_Republic),
                new TravellerCompany("Business Board Investment Capital", new TravellerTextLocation("Elysee", 2, 3, 7, 5),
                    New_Colchis_Business_Board, Venture_Capital_Firms, Germushian_Free_Republic),

                new TravellerCompany("Dominate State Construction", new TravellerTextLocation("ReeDu", 3, 2, 6, 10),
                    Venhut_Dominate_States, Construction, Trans_Galactic_Empire),
                new TravellerCompany("BodeyWak Boys", new TravellerTextLocation("BodeyWak", 3, 2, 4, 9),
                    Venhut_Dominate_States, Privateers, Trans_Galactic_Empire),
                new TravellerCompany("Venhut-Dominate Resource Extraction Ltd.",
                    new TravellerTextLocation("ReeDu", 3, 2, 6, 10), Venhut_Dominate_States, Commodities,
                    Trans_Galactic_Empire),

                new TravellerCompany("Esperenza Meats & Wheats", new TravellerTextLocation("Esperanza", 2, 3, 1, 6),
                    Esperenza, Food, Fifth_Vers_Empire),
                new TravellerCompany("Bank of Esperanza", new TravellerTextLocation("Esperanza", 2, 3, 1, 6), Esperenza,
                    Banking, Fifth_Vers_Empire),

                new TravellerCompany("Nuken Home", new TravellerTextLocation("New Home", 3, 3, 3, 5),
                    Old_Islands_Defense_League, Privateers),

                new TravellerCompany("The Strategist", new TravellerTextLocation("KneelDead", 3, 2, 5, 8),
                    Mainhair_Military_Republic, Media, Germushian_Free_Republic),
                new TravellerCompany("Mainhair Military Manufacturing Ind.",
                    new TravellerTextLocation("Garbreeze", 3, 2, 5, 7), Mainhair_Military_Republic, Manufacturing,
                    Germushian_Free_Republic),

                new TravellerCompany("Essig Hunters", new TravellerTextLocation("Essig", 1, 4, 2, 9), Essia_Kitarchy,
                    Privateers, United_Reverse_Lords),
                new TravellerCompany("Essig Healer", new TravellerTextLocation("Essig", 1, 4, 2, 9), Essia_Kitarchy,
                    Healthcare, United_Reverse_Lords),

                new TravellerCompany("Trotskites Opinion Inc.", new TravellerTextLocation("Topas", 2, 3, 7, 2),
                    Neubayern_Topas_Alliance, Lobbying, Communist_Empire_of_the_Deutschland),
                new TravellerCompany("Stalinksy Sound & Communication", new TravellerTextLocation("Neubayern", 3, 3, 2, 2),
                    Neubayern_Topas_Alliance, Communications, Communist_Empire_of_the_Deutschland),
                new TravellerCompany("Communist Belters Retail", new TravellerTextLocation("Schlesien Belt", 3, 3, 3, 3),
                    Neubayern_Topas_Alliance, Retail, Communist_Empire_of_the_Deutschland),
                new TravellerCompany("Sturgeons Stores", new TravellerTextLocation("Sturgeons Law", 3, 3, 1, 4),
                    Neubayern_Topas_Alliance, Retail, Communist_Empire_of_the_Deutschland),

                new TravellerCompany("Protectorate Electronics", new TravellerTextLocation("Olitar", 3, 2, 7, 3),
                    Olitar_Protectorate, Eletronics_Production, Communist_Empire_of_the_Deutschland),

                new TravellerCompany("General Space Electronics", new TravellerTextLocation("GenSpace", 3, 2, 7, 5),
                    Sar_Tan_Confederacy, Eletronics_Production, United_Reverse_Lords),

                new TravellerCompany("Gregs Pills n Stuff", new TravellerTextLocation("Griggsvil", 2, 1, 7, 10),
                    No_God_Land, Pharamesuiticals, Communist_Empire_of_the_Deutschland),
                new TravellerCompany("Doting Pharmasuiticales", new TravellerTextLocation("Doty", 2, 1, 3, 10), No_God_Land,
                    Pharamesuiticals, Communist_Empire_of_the_Deutschland),
                new TravellerCompany("Post-Commune Electronics", new TravellerTextLocation("Lacamp", 3, 1, 8, 5),
                    No_God_Land, Eletronics_Production, Communist_Empire_of_the_Deutschland),

                new TravellerCompany("Commune Cabbage", new TravellerTextLocation("Lithia", 2, 1, 7, 6),
                    Western_Islands_Commune, Food),
                new TravellerCompany("Commune Emergency Surivival Gear", new TravellerTextLocation("Millport", 2, 1, 2, 5),
                    Western_Islands_Commune, Emergency_Gear),
                new TravellerCompany("Commune Kids Toys", new TravellerTextLocation("Twining", 2, 1, 6, 8),
                    Western_Islands_Commune, Toys_And_Trinkets),
                new TravellerCompany("Commune Wholesellars", new TravellerTextLocation("Griggsvil", 2, 1, 7, 10),
                    Western_Islands_Commune, Wholesellears),
                new TravellerCompany("Western Commune Manufacturing", new TravellerTextLocation("Lithia", 2, 1, 7, 6),
                    Western_Islands_Commune, Manufacturing),
                new TravellerCompany("South-Eastern Commune Manufacturing",
                    new TravellerTextLocation("Uphitera", 2, 2, 3, 2), Western_Islands_Commune, Manufacturing),
                new TravellerCompany("Commune Law", new TravellerTextLocation("Knoxboro", 2, 1, 4, 8),
                    Western_Islands_Commune, Law_Firms),
                new TravellerCompany("Commune Convinces", new TravellerTextLocation("Ittabena", 3, 1, 8, 3),
                    Western_Islands_Commune, Lobbying)
            };
        }
    }
}