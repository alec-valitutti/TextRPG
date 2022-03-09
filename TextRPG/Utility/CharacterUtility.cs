﻿using System;
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
            var _player = utility.LoadPlayer();
            if (_player != null)
            {
                Console.WriteLine("You already have a character created, do you want to overwrite it?");
                utility.PrintInputOptions("Conditional");
                var isTrue = utility.GetConditional(_player);
                if (isTrue != true)
                {
                    Console.Clear();
                    Console.WriteLine("Loading character:");
                    _player.PrintPlayerInformation();
                    return _player;
                }
            }
            Console.WriteLine("What would you like to name your character?");
            var input = Console.ReadLine();
            Player player = new Player(input)
            {
                LevelPoints = 1
            };
            ChooseClass(player);
            utility.SaveObject(player);
            player.PrintPlayerInformation();
            return player;
        }
        public void ChooseClass(Player player)
        {
            Utility utility = new Utility();
            Console.WriteLine("What class would you like to be:");
            utility.PrintInputOptions(utility.ClassesDictionary);
            utility.GetClasses(player);
            
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
