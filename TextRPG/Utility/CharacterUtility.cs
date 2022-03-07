using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using TextRPG.Classes;
using TextRPG.Abilities;
using TextRPG.Items;

namespace TextRPG.Utilities
{
    public class CharacterUtility
    {
        public static Player CreateCharacter()
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
        public static string ChooseClass(Player player)
        {
            Utility utility = new Utility();
            Console.WriteLine("What class would you like to be:");
            utility.Options = new List<string>() { "Warrior", "Mage", "Archer", "Custom" };
            utility.PrintInputOptions();
            var input = utility.GetInput();
            switch (input)
            {
                case "Warrior":
                    player.CurrentWeapon = new Weapon("Sword", 3, Rarity.Legendary);
                    player.CurrentBody = new Armor("Chainmail", 3);
                    break;
                case "Mage":
                    player.Abilities.Add(new Ability() { Name = "Fireball", Damage = 2, Cost = 1 });
                    break;
                case "Archer":
                    player.CurrentWeapon = new Weapon("Bow", 1);
                    player.Ammunition.Add(new Projectile("Arrow", 25, "Wooden"));
                    player.CurrentBody = new Armor("Leather Body", 2);
                    break;
                case "Custom":
                    player.Inventory.Add(new Item("Potion", 1));

                    break;
                default:
                    break;
            }
            return input;
        }
        public void PrintPlayerItems(Player player)
        {
            List<Item> playerItems = new List<Item>();
            playerItems.Add(player.CurrentWeapon);
            playerItems.Add(player.CurrentHelmet);
            playerItems.Add(player.CurrentBody);
            playerItems.Add(player.CurrentLegs);
            playerItems.Add(player.CurrentBoots);
            playerItems.Add(player.CurrentRing);
            playerItems.Add(player.CurrentAmulet);
            //check item rarity
            foreach (var item in playerItems)
            {
                // change conosole color to that color
                switch (item.GetRarity())
                {
                    case "Common":
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "Uncommon":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "Rare":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case "Unique":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case "Legendary":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    default:
                        break;
                }
                //write item
                Console.WriteLine($"{item.Name}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
