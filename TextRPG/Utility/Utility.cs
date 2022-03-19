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
    public class Utility : IUserInput
    {
        public static string Path = "..\\..\\..\\";
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
                    c.CreateCharacter();
                }
                return result; }},
            { "Quit", (p)=> {Utility u = new Utility();u.Quit(p); return null;}},
            {"Warrior",(p)=>
                {   p._PlayerClass = "Warrior";
                    p.CurrentWeapon = new Weapon("Sword", 3, Rarity.Common);
                    p.CurrentHelmet = new Armor("Helmet", 1, ArmorType.Helmet, Rarity.Common);
                    p.CurrentBody = new Armor("Chainmail", 2, ArmorType.Body, Rarity.Common);
                    p.CurrentLegs = new Armor("Leggings", 1, ArmorType.Legs, Rarity.Common);
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
                    return p;
                }
            },
            { "TestOption", (p)=>{Console.WriteLine("test"); return p; }},
            { "Check Stats", (p)=>
            { p.PrintPlayerInformation(); return p; } },
            { "Explore",(p)=>{ Console.WriteLine("You explore..."); return p; } },
            {"Use Item",(p)=>{ CharacterUtility characterUtility = new CharacterUtility(); characterUtility.PrintPlayerInventory(p); return p; } },
            { "Main Menu", (p)=>{ var x =new MainMenuState();x.EnterState(p); return p; } }
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
                if (result > Options.Count)
                {
                    isTrue = false;
                }
                if (result < 0 || result == 0)
                {
                    isTrue = false;
                }
                if (!isTrue)
                {
                    Console.WriteLine("Please enter a valid input");
                }
            } while (!isTrue);
            player = Functionality[Options[result - 1]].Invoke(player);
            return player;
        }
        public bool GetConditional()
        {
            bool isTrue;
            int result;
            do
            {
                isTrue = int.TryParse(Console.ReadLine(), out result);
                if (result > Options.Count)
                {
                    isTrue = false;
                }
                if (result < 0 || result == 0)
                {
                    isTrue = false;
                }
                if (!isTrue)
                {
                    Console.WriteLine("Please enter a valid input");
                }

            } while (!isTrue);

            return Conditionals[Options[result - 1]].Invoke();
        }
        public void Quit(Player player)
        {
            try
            {
                if (player == null)
                {
                    throw new Exception("Player was null");
                }
                //SaveObject(player); // dependency
            }
            catch (Exception e)
            {

                throw new Exception("Could not save", e);
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
            var _path = Path + "Player.json";
            try
            {
                var json = "";
                using (StreamReader sr = new StreamReader(_path))
                {
                    json = sr.ReadToEnd();
                }
                var player = JsonSerializer.Deserialize<Player>(json);
                return player;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public void SaveObject(object obj)
        {
            if (obj == null)
            {
                return;
            }
            var _path = Path + obj.GetType().Name.ToString() + ".json";
            using (StreamWriter sw = new StreamWriter(_path))
            {
                string json = JsonSerializer.Serialize(obj);
                sw.Write(json);
            }
        }
        public void MessageEnder()
        {
            Console.WriteLine("_______________________");
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
            Console.Clear();
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
                print = $"{item.GetType().Name}: {item.Name} x {item.Quantity}";
            }
            else
            {
                print = $"{item.GetType().Name}: {item.Name}";
            }
            Console.WriteLine(print);
        }
    }
}
