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
        public Func<string, Player, Player> UseItem = (i, p) => { p.UseItem(i); return p; };
        public Func<Player, Player> Return = (p) => { return p; };
        public List<string> Options { get; set; } = new List<string>();
        public Player CreateCharacter()
        {
            Utility utility = new Utility();
            var _player = utility.LoadPlayer();
            if (_player != null)
            {
                Console.WriteLine("You already have a character created, do you want to overwrite it?");
                utility.PrintInputOptions(new List<string>() { "Yes", "No" });
                var isTrue = utility.GetConditional();
                if (!isTrue)
                {
                    Console.WriteLine("Loading character:");
                    _player.PrintPlayerInformation();
                    return _player;
                }
            }
            Console.WriteLine("What would you like to name your character?");
            string name = "";
            while (!utility.IsValidString(Console.ReadLine(), out name))
            {
                Console.WriteLine("Please enter a valid name:");
            }
            Player player = new Player(name)
            {
                LevelPoints = 1
            };
            ChooseClass(player);
            utility.SavePlayer(player);
            player.PrintPlayerInformation();
            return player;
        }
        public void ChooseClass(Player player)
        {
            Utility utility = new Utility();
            Console.WriteLine("What class would you like to be:");
            utility.PrintInputOptions(new List<string>() { "Warrior", "Mage", "Archer", "TESTCLASS" });
            utility.GetInput(player);

        }
        public void PrintPlayerEquipment(Player player)
        {
            Utility utility = new Utility();
            List<Item> playerItems = new List<Item>
            {
                player.CurrentWeapon,
                player.CurrentHelmet,
                player.CurrentBody,
                player.CurrentLegs,
                player.CurrentBoots,
                player.CurrentRing,
                player.CurrentAmulet
            };
            //check item rarity
            Console.WriteLine("Here are your currently Equipped Items:");
            foreach (var item in playerItems)
            {

                utility.TextColorChanger(item);
            }
            Console.ResetColor();
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
            foreach (var item in playerAbilities)
            {
                utility.TextColorChanger(item);
            }
            Console.ResetColor();
        }
        public void PrintPlayerStatistics(Player player)
        {
            Console.WriteLine("Here is your character:");
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Level: {player.Level}");
            Console.WriteLine($"Health: {player.Hitpoints}");
            Console.WriteLine($"Level Points: {player.LevelPoints}");
            Console.WriteLine($"Experience Points: {player.Experience}");
            Console.WriteLine($"Class: {player._PlayerClass}");
        }
        public void PrintPlayerAmmunition(Player player)
        {
            Utility utility = new Utility();
            List<Item> playerAmmunition = new List<Item>();
            foreach (var item in player.Ammunition)
            {
                playerAmmunition.Add(item);
            }
            Console.WriteLine("Here is your Ammunition:");
            foreach (var item in playerAmmunition)
            {

                utility.TextColorChanger(item);
            }
            Console.ResetColor();
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
            Utility utility = new Utility();
            Console.WriteLine("Here is your inventory:");
            foreach (var item in player.Inventory)
            {
                //Console.WriteLine($"-{item.Name}: {item.Quantity}");
                utility.TextColorChanger(item.GetItem());
            }
            Console.ResetColor();
        }
        public void PrintPlayerGold(Player player)
        {
            Console.WriteLine("Here is your gold:");
            Console.WriteLine($"-Gold: {player.Gold}");
        }
        public Player GetInputForItemUse(Player player)
        {
            bool isTrue;
            int result;
            do
            {
                isTrue = int.TryParse(Console.ReadLine(), out result);
                if (result > Options.Count) isTrue = false;
                if (result < 0 || result == 0) isTrue = false;
                if (!isTrue) Console.WriteLine("Please enter a valid input");
            } while (!isTrue);
            if (Options[result - 1] == "Return")
            {
                player = Return.Invoke(player);
            }
            UseItem(Options[result - 1], player);
            return player;
        }
    }
    public enum CharacterFunctions
    {
        UseItem,
        HealPlayer,
        BoostResistance,
    }
}
