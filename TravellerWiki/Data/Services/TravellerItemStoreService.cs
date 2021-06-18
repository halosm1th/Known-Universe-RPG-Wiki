using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TravellerWiki.Data.Charcters;
using TravellerWiki.Data.Services.CareerService;

namespace TravellerWiki.Data
{
#nullable enable
    public class TravellerItemStoreService
    {
        public Dictionary<int, TravellerItem> ItemStore => ItemStoreStatic;

        public static Dictionary<int, TravellerItem> GenericItemStatic =>
            ItemStoreStatic.Where(x => x.Value.ItemType == TravellerItemTypes.ItemGeneric)
                .ToDictionary(i => i.Key, i => ((TravellerItem)i.Value));

        public static Dictionary<int, TravellerItem> ItemStoreStatic = new Dictionary<int, TravellerItem>();



        public Dictionary<int, TravellerWeapon> WeaponStore => WeaponStoreStatic;
        public static Dictionary<int, TravellerWeapon> WeaponStoreStatic =>
            ItemStoreStatic.Where(x => x.Value is TravellerWeapon)
                .ToDictionary(i => i.Key, i => ((TravellerWeapon) i.Value));


        public Dictionary<int, TravellerArmour> ArmourStore => ArmourStoreStatic;
        public static Dictionary<int, TravellerArmour> ArmourStoreStatic =>
            ItemStoreStatic.Where(x => x.Value is TravellerArmour)
                .ToDictionary(i => i.Key, i => ((TravellerArmour)i.Value));


        public Dictionary<int, TravellerAugments> AugmentsStore => AugmentsStoreStatic;
        public static Dictionary<int, TravellerAugments> AugmentsStoreStatic =>
            ItemStoreStatic.Where(x => x.Value is TravellerAugments)
                .ToDictionary(i => i.Key, i => ((TravellerAugments)i.Value));

        public static TravellerItem GetItemStatic(int ID)
        {
            return ItemStoreStatic[ID];
        }

        public static void AddItemStatic(int id, TravellerItem item)
        {
            ItemStoreStatic.Add(id,item);
        }

        public static void AddItemJsonStatic(string json)
        {

        }

        public TravellerItem GetItem(int ID)
        {
            return ItemStore[ID];
        }

        public void AddItem(int id, TravellerItem item)
        {
            ItemStore.Add(id, item);
        }


        private static string Path = Directory.GetCurrentDirectory() + "/Items/";
        private static bool HasNotAddedDefaultItems = true;
        public static void AddDefaultItems()
        {
            if (HasNotAddedDefaultItems)
            {
                //var items = File.ReadAllText(Directory.GetCurrentDirectory() + "/Items.json");
                //ItemStoreStatic = JsonConvert.DeserializeObject<Dictionary<int, TravellerItem>>(items);

                AddArmours();
                AddWeapons();
                AddAugments();
                AddItems();

                HasNotAddedDefaultItems = false;
            }
        }

        private static void AddAugments()
        {

            var itemsJson = File.ReadAllText(Path + "Augments.json");
            var augments = JsonConvert.DeserializeObject<Dictionary<int,TravellerAugments>>(itemsJson);
            
            foreach (var aug in augments)
            {
                ItemStoreStatic.Add(aug.Key,aug.Value);
            }
        }

        private static void AddItems()
        {

            var itemsJson = File.ReadAllText(Path + "Items.json");
            var items = JsonConvert.DeserializeObject<Dictionary<int, TravellerItem>>(itemsJson);

            foreach (var item in items)
            {
                ItemStoreStatic.Add(item.Key, item.Value);
            }
        }


        private static void AddWeapons()
        {

            var itemsJson = File.ReadAllText(Path + "Weapons.json");
            var items = JsonConvert.DeserializeObject<Dictionary<int, TravellerWeapon>>(itemsJson);

            foreach (var item in items)
            {
                ItemStoreStatic.Add(item.Key, item.Value);
            }
        }

        private static void AddArmours()
        {
            var itemsJson = File.ReadAllText(Path + "Armours.json");
            var items = JsonConvert.DeserializeObject<Dictionary<int, TravellerArmour>>(itemsJson);

            foreach (var item in items)
            {
                ItemStoreStatic.Add(item.Key, item.Value);
            }
        }

        public static TravellerItem? GetItemStatic(string name)
        {
            Console.WriteLine($"Looking for: {name}");
            if (ItemStoreStatic.Any(x => x.Value.Name == name))
            {
                return ItemStoreStatic.First(x => x.Value.Name == name).Value;
            }

            return null;
        }

        public TravellerItemStoreService()
        {
            AddDefaultItems();
        }
    }

}
