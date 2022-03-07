using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using TextRPG.Classes;
using TextRPG.Abilities;
using TextRPG.Items;
using TextRPG.Interfaces;

namespace TextRPG.Utilities
{
    public class CharacterUtility
    {
        public Player CreateCharacter()
        {
            Utility utility = new Utility();
            var input = "";
            var _player = utility.LoadPlayer();
            if (_player != null)
            {
                Console.WriteLine("You already have a character created, do you want to overwrite it?");
                utility.Options = new List<string>() { "Yes", "No" };
                for (int i = 0; i < utility.Options.Count; i++)
                {
                    Console.WriteLine((i + 1).ToString() + ": " + utility.Options[i]);
                }
                //utility.CheckInput(Console.ReadLine(), out input);
                input = utility.GetInput();
                Console.Clear();
                if (input == "No")
                {
                    _player.PrintPlayerInformation();
                    return _player;
                }
            }
            Console.WriteLine("What would you like to name your character?");
            input = Console.ReadLine();
            Player player = new Player(input);
            utility.SaveObject(player);
            player.PrintPlayerInformation();
            return player;
        }
        public string ChooseClass(Player player)
        {
            Utility utility = new Utility();
            Console.WriteLine("What class would you like to be:");
            utility.Options = new List<string>() { "Warrior", "Mage", "Archer", "Custom" };
            utility.PrintInputOptions();
            var input = utility.GetInput();
            switch (input)
            {
                case "Warrior":
                    player.CurrentWeapon = new Weapon("Sword", 3, Rarity.Common);
                    player.CurrentHelmet = new Armor("Helmet", 1, ArmorType.Helmet, Rarity.Common);
                    player.CurrentBody = new Armor("Chainmail", 2, ArmorType.Body, Rarity.Common);
                    player.CurrentLegs = new Armor("Leggings", 1, ArmorType.Legs, Rarity.Common);
                    break;
                case "Mage":
                    player.Abilities.Add(new Ability() { Name = "Fireball", Damage = 2, Cost = 1, _Rarity = Rarity.Uncommon });
                    player.CurrentHelmet = new Armor("Cloth Robe Hat", 1, ArmorType.Helmet, Rarity.Common);
                    player.CurrentBody = new Armor("Cloth Robe Top", 1,ArmorType.Body, Rarity.Common);
                    player.CurrentLegs = new Armor("Cloth Robe Bottom", 1,ArmorType.Legs, Rarity.Common);
                    player.CurrentRing = new Jewlery("Ring", Rarity.Uncommon);
                    break;
                case "Archer":
                    player.CurrentWeapon = new Weapon("Bow", 1, Rarity.Common);
                    player.Ammunition.Add(new Projectile("Arrow", 25, "Wooden", Rarity.Common));
                    player.CurrentBody = new Armor("Leather Body", 1,ArmorType.Body, Rarity.Common);
                    player.CurrentLegs = new Armor("Leather Chaps", 1,ArmorType.Legs, Rarity.Common);
                    break;
                case "Custom":
                    //make a custom character creation
                    player.Inventory.Add(new Item("Potion", 1, Rarity.Common));

                    break;
                default:
                    break;
            }
            return input;
        }
        public void PrintPlayerEquipment(Player player)
        {
            Utility utility = new Utility();
            List<Item> playerItems = new List<Item>();
            playerItems.Add(player.CurrentWeapon);
            playerItems.Add(player.CurrentHelmet);
            playerItems.Add(player.CurrentBody);
            playerItems.Add(player.CurrentLegs);
            playerItems.Add(player.CurrentBoots);
            playerItems.Add(player.CurrentRing);
            playerItems.Add(player.CurrentAmulet);
            //check item rarity
            Console.WriteLine("Here are your currently Equipped Items:");
            utility.TextColorChanger(playerItems);
        }
        public void PrintPlayerAbilities(Player player)
        {
            List<Item> playerAbilities = new List<Item>();
            Utility utility = new Utility();
            foreach (var ability in player.Abilities)
            {
                playerAbilities.Add(ability);
            }
            Console.WriteLine("Here are your abilities:");
            utility.TextColorChanger(playerAbilities);
        }
        public void PrintPlayerStatistics(Player player)
        {
            Console.WriteLine("Here is your character:");
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Level: {player.Level}");
            Console.WriteLine($"Level Points: {player.LevelPoints}");
            Console.WriteLine($"Experience Points: {player.Experience}");
            Console.WriteLine($"Class: {player._PlayerClass}");
        }
        public void PrintPlayerAmmunition(Player player)
        {
            Utility utility = new Utility();
            Console.WriteLine("Here is your Ammunition:");
            utility.TextColorChanger(player.Ammunition);
        }
        public void PrintPlayerAttributes(Player player)
        {
            Utility utility = new Utility();
            //make 
            Console.WriteLine("Here are your attributes:");
            foreach (var stats in player.Attributes)
            {
                Console.WriteLine(stats.Key + " : " + stats.Value.ToString());
            }
        }
        public void PrintPlayerInventory(Player player)
        {
            Console.WriteLine("Here is your inventory:");
            Console.WriteLine($"-Gold: {player.Gold}");
            foreach (var item in player.Inventory)
            {
                Console.WriteLine($"-{item.Name}: {item.Quantity}");
            }
        }
    }
}
