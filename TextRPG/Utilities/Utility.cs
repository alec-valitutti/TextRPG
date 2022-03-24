using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using TextRPG.Items;
using TextRPG.Abilities;
using TextRPG.Interfaces;
using TextRPG.States;

namespace TextRPG.Utilities
{
    public class Utility
    {
        public static string Path = "..\\..\\..\\Player\\";
        public List<string> Options { get; set; } = new List<string>();
        public Dictionary<string, Func<Player, Player>> Functionality { get; set; } = new Dictionary<string, Func<Player, Player>>()
        {
            { "New Game", (p)=>
            {CharacterUtility c = new CharacterUtility(); return c.CreateCharacter();}},
            {"Load Game", (p)=>
            {
                Utility u = new Utility();
                CharacterUtility c = new CharacterUtility();
                var result = u.LoadPlayer();
                if (result != null)
                {
                    result.PrintPlayerInformation();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("No save data found, creating new character:");
                    p=c.CreateCharacter();
                }
                return result; }},
            { "Save Game", (p)=> {Utility u = new Utility();u.SavePlayer(p);Console.WriteLine("Character Saved!"); return p;}},
            { "Quit", (p)=> {Utility u = new Utility();u.Quit(p); return p;}},
            {"TESTCLASS",(p)=>
                {   p._PlayerClass="TESTCLASS";
                    p.Inventory.Add(new Consumeable("Potion", Rarity.Legendary){ Quantity=2});
                    p.Inventory.Add(new Weapon("Axe",9, Rarity.Unique));
                    return p; } },
            {"Warrior",(p)=>
                {   p._PlayerClass = "Warrior";
                    p.CurrentWeapon = new Weapon("Sword", 3, Rarity.Common);
                    p.CurrentHelmet = new Armor("Helmet", 1, ArmorType.Helmet, Rarity.Common);
                    p.CurrentBody = new Armor("Chainmail", 2, ArmorType.Body, Rarity.Common);
                    p.CurrentLegs = new Armor("Leggings", 1, ArmorType.Legs, Rarity.Common);
                    p.Inventory.Add(new Consumeable("Potion",Rarity.Legendary));
                return p;
                }
            },
            {"Mage",(p)=>
                {
                    p._PlayerClass = "Mage";
                    p.Abilities.Add(new Ability() { Name = "Fireball", Damage = 2, Cost = 1, _Rarity = Rarity.Uncommon });
                    p.CurrentHelmet = new Armor("Cloth Robe", 1, ArmorType.Hat, Rarity.Common);
                    p.CurrentBody = new Armor("Cloth Robe", 1, ArmorType.Body, Rarity.Common);
                    p.CurrentLegs = new Armor("Cloth Robe", 1, ArmorType.Legs, Rarity.Common);
                    p.CurrentRing = new Jewlery("Ring", Rarity.Uncommon);
                    p.Inventory.Add(new Consumeable("Potion",Rarity.Legendary));

                    return p;
                }
            },
            {"Archer",(p)=>
                {
                    p._PlayerClass = "Archer";
                    p.CurrentWeapon = new Weapon("Bow", 1, Rarity.Common);
                    p.Ammunition.Add(new Projectile("Arrow", 25, "Wooden", Rarity.Common));
                    p.CurrentBody = new Armor("Leather", 1, ArmorType.Body, Rarity.Common);
                    p.CurrentLegs = new Armor("Leather", 1, ArmorType.Legs, Rarity.Common);
                    p.Inventory.Add(new Consumeable("Potion",Rarity.Legendary));
                    return p;
                }
            },
            { "TestOption", (p)=>{Console.WriteLine("test"); return p; }},
            { "Check Stats", (p)=>
            { p.PrintPlayerInformation(); return p; } },
            { "Explore",(p)=>{ Console.WriteLine("You explore..."); return p; } },
            {"Items",(p)=>{ CharacterUtility characterUtility = new CharacterUtility();
                characterUtility.PrintPlayerInventory(p);UseItemState uIS = new UseItemState(); p=uIS.EnterState(p); return p; } },

            { "Main Menu", (p)=>{ var x =new MainMenuState();p=x.EnterState(p); return p; } },
            { "Options", (p)=>{ var x =new OptionsMenuState();p=x.EnterState(p); return p; } },
            { "Level Up", (p)=>{p.LevelUp(); return p; } },
            { "Return", (p)=>{ return p; } }
        };
        public Dictionary<string, Func<bool>> Conditionals { get; set; } = new Dictionary<string, Func<bool>>()
        {
            { "Yes", () =>{ return true; } },
            { "No", () => { return false; } }
        };
        public void PrintInputOptions(List<string> InputType)
        {
            if (InputType == null || InputType.Count == 0)
            {
                throw new Exception("input was null/input list count was 0");
            }
            Options = InputType;
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Options[i]}");
            }
        }
        public Player GetInput(Player player)
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
            if (!Console.IsOutputRedirected) Console.Clear();
            player = Functionality[Options[result - 1]].Invoke(player);
            return player;
        }
        public bool GetInput()
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
            if (!Console.IsOutputRedirected) Console.Clear();
            return Conditionals[Options[result - 1]].Invoke();

        }
        public void Quit(Player player)
        {
            try
            {
                if (player != null)
                {
                    if (LoadPlayer() != player)
                    {
                        SavePlayer(player);
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Could not save player before quitting", e);
            }
            Environment.Exit(0);
        }
        public bool IsValidString(string input, out string output)
        {
            output = null;
            if (!string.IsNullOrEmpty(input))
            {
                if (input != " ")
                {
                    output = input;
                    return true;
                }
            }
            return false;

        }
        public Player LoadPlayer()
        {
            var _pPath = Path + "player.json";
            var json = "";
            try
            {
                using (StreamReader sr = new StreamReader(_pPath))
                {
                    json = sr.ReadToEnd();
                }
                var player = JsonSerializer.Deserialize<Player>(json);
                //These could be rewritten somethwere
                player.Inventory.Clear();
                player.Inventory.AddRange(player.consumeables);
                player.Inventory.AddRange(player.weapons);
                player.Inventory.AddRange(player.armors);
                player.Inventory.AddRange(player.jewleries);
                player.consumeables.Clear();
                player.weapons.Clear();
                player.armors.Clear();
                player.jewleries.Clear();
                return player;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public void SavePlayer(Player p)
        {
            /*Would be nice to figure out how to generically save any object like i had before*/
            if (p == null)
            {
                return;
            }
            //sort out inventory
            foreach (var item in p.Inventory)
            {
                if (item is Consumeable) p.consumeables.Add((Consumeable)item);
                if (item is Weapon) p.weapons.Add((Weapon)item);
                if (item is Armor) p.armors.Add((Armor)item);
                if (item is Jewlery) p.jewleries.Add((Jewlery)item);
            }
            //write player to json
            string player = JsonSerializer.Serialize(p);
            //add to string list
            var _path = Path + $"{nameof(player)}" + ".json";
            using (StreamWriter sw = new StreamWriter(_path))
            {
                sw.Write(player);
            }
        }
        public void MessageEnder()
        {
            /*I may get rid of this method because I don't like that I call this to clear after certain input*/
            Console.WriteLine("_______________________");
            Console.WriteLine("Enter any key to continue:");
            Console.ReadLine();
            if (!Console.IsOutputRedirected) Console.Clear();

        }
        public void TextColorChanger(Item item)
        {
            // change conosole color to that color
            switch (item._Rarity.ToString())
            {
                case "Common":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case "Uncommon":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "Rare":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "Unique":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "Legendary":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
            //write item
            var print = "";
            if (item.Quantity > 1)
            {
                print = $"{item.Name} x {item.Quantity}";
            }
            else
            {
                print = $"{item.Name}";
            }
            Console.WriteLine(print);
        }
    }
}
