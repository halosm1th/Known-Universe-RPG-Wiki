using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TravellerCharacter.CharacterCreator.Items;

namespace TravellerCharacter.Character_Services
{
#nullable enable
    public class TravellerItemStoreService
    {
        public static Dictionary<int, TravellerItem> ItemStoreStatic = new();


        private static readonly string Path = Directory.GetCurrentDirectory() + "/Data/Items/";
        private static bool HasNotAddedDefaultItems = true;

        public TravellerItemStoreService()
        {
            AddDefaultItems();
        }

        public Dictionary<int, TravellerItem> ItemStore => ItemStoreStatic;

        public static Dictionary<int, TravellerItem> GenericItemStatic =>
            ItemStoreStatic.Where(x => x.Value.ItemType == TravellerItemTypes.ItemGeneric)
                .ToDictionary(i => i.Key, i => i.Value);

        public Dictionary<int, TravellerItem> GenericItemStore => GenericItemStatic;

        public Dictionary<int, TravellerSpecialAmmo> SpecialAmmoStore => SpecialAmmoStoreStatic;

        public static Dictionary<int, TravellerSpecialAmmo> SpecialAmmoStoreStatic =>
            ItemStoreStatic.Where(x => x.Value is TravellerSpecialAmmo)
                .ToDictionary(i => i.Key, i => (TravellerSpecialAmmo)i.Value);

        public Dictionary<int, TravellerWeapon> WeaponStore => WeaponStoreStatic;

        public static Dictionary<int, TravellerWeapon> WeaponStoreStatic =>
            ItemStoreStatic.Where(x => x.Value is TravellerWeapon)
                .ToDictionary(i => i.Key, i => (TravellerWeapon)i.Value);


        public Dictionary<int, TravellerArmour> ArmourStore => ArmourStoreStatic;

        public static Dictionary<int, TravellerArmour> ArmourStoreStatic =>
            ItemStoreStatic.Where(x => x.Value is TravellerArmour)
                .ToDictionary(i => i.Key, i => (TravellerArmour)i.Value);


        public Dictionary<int, TravellerAugments> AugmentsStore => AugmentsStoreStatic;

        public static Dictionary<int, TravellerAugments> AugmentsStoreStatic =>
            ItemStoreStatic.Where(x => x.Value is TravellerAugments)
                .ToDictionary(i => i.Key, i => (TravellerAugments)i.Value);

        public static TravellerItem GetItemStatic(int ID)
        {
            AddDefaultItems();
            return ItemStoreStatic[ID];
        }


        public TravellerItem? GetItem(string name)
        {
            if (ItemStore.Any(x => x.Value.Name == name))
                return ItemStore.First(x => x.Value.Name == name).Value ?? null;
            return null;
        }

        public static void AddItemStatic(int id, TravellerItem item)
        {
            AddDefaultItems();
            ItemStoreStatic.Add(id, item);
        }


        public TravellerItem GetItem(int ID)
        {
            return ItemStore[ID];
        }

        public void AddItem(int id, TravellerItem item)
        {
            ItemStore.Add(id, item);
        }

        public static void AddDefaultItems()
        {
            if (HasNotAddedDefaultItems)
            {
                //var items = File.ReadAllText(Directory.GetCurrentDirectory() + "/Items.json");
                //ItemStoreStatic = JsonConvert.DeserializeObject<Dictionary<int, TravellerItem>>(items);

                AddArmours();
                AddWeapons();
                AddSpecialAmmo();
                AddAugments();
                AddItems();

                HasNotAddedDefaultItems = false;
            }
        }

        private static void AddAugments()
        {
            var itemsJson = File.ReadAllText(Path + "Augments.json");
            var augments = JsonConvert.DeserializeObject<Dictionary<int, TravellerAugments>>(itemsJson);

            foreach (var aug in augments ?? new Dictionary<int, TravellerAugments>())
                ItemStoreStatic.Add(aug.Key, aug.Value);
        }

        private static void AddItems()
        {
            var itemsJson = File.ReadAllText(Path + "Items.json");
            var items = JsonConvert.DeserializeObject<Dictionary<int, TravellerGenericItem>>(itemsJson);

            foreach (var item in items ?? new Dictionary<int, TravellerGenericItem>())
                ItemStoreStatic.Add(item.Key, item.Value);
        }


        private static void AddWeapons()
        {
            var itemsJson = File.ReadAllText(Path + "Weapons.json");
            var items = JsonConvert.DeserializeObject<Dictionary<int, TravellerWeapon>>(itemsJson);

            foreach (var item in items ?? new Dictionary<int, TravellerWeapon>())
                ItemStoreStatic.Add(item.Key, item.Value);
        }

        private static void AddSpecialAmmo()
        {
            var itemsJson = File.ReadAllText(Path + "SpecialAmmo.json");
            var items = JsonConvert.DeserializeObject<Dictionary<int, TravellerSpecialAmmo>>(itemsJson);

            foreach (var item in items ?? new Dictionary<int, TravellerSpecialAmmo>())
                ItemStoreStatic.Add(item.Key, item.Value);
        }

        private static void AddArmours()
        {
            var itemsJson = File.ReadAllText(Path + "Armours.json");
            var items = JsonConvert.DeserializeObject<Dictionary<int, TravellerArmour>>(itemsJson);

            foreach (var item in items ?? new Dictionary<int, TravellerArmour>())
                ItemStoreStatic.Add(item.Key, item.Value);
        }

        public static TravellerItem? GetItemStatic(string name)
        {
            AddDefaultItems();

            Console.WriteLine($"Looking for: {name}");
            if (ItemStoreStatic.Any(x => x.Value.Name == name))
                return ItemStoreStatic.First(x => x.Value.Name == name).Value;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Attempted to retrieve: {name}");
            Console.ForegroundColor = ConsoleColor.Gray;
            return null;
        }
    }
}