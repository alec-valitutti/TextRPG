using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using TextRPG.Items;
using TextRPG.Abilities;

namespace TextRPG.Utilities
{
    public class Utility
    {
        public static string Path = "..\\..\\..\\";
        public List<string> Options { get; set; } = new List<string>();
        public Dictionary<string, Func<Player, CharacterUtility, Utility, Player>> Functionality { get; set; } = new Dictionary<string, Func<Player, CharacterUtility, Utility, Player>>()
        {
            { "New Game", (p,c,u)=>{ return c.CreateCharacter();}},
            {"Load Game", (p,c,u)=>{ var result = u.LoadPlayer();
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
            { "Quit", (p,c,u)=> {u.Quit(p); return null;}},
        };
        public Dictionary<string, Func<bool>> Conditionals { get; set; } = new Dictionary<string, Func<bool>>()
        {
            { "Yes", () =>{ return true; } },
            { "No", () => { return false; } }
        };
        public Dictionary<string, Action<Player>> ClassesDictionary { get; set; } = new Dictionary<string, Action<Player>>()
        {
            {"Warrior",(player)=>
                {
                    player.CurrentWeapon = new Weapon("Sword", 3, Rarity.Common);
                    player.CurrentHelmet = new Armor("Helmet", 1, ArmorType.Helmet, Rarity.Common);
                    player.CurrentBody = new Armor("Chainmail", 2, ArmorType.Body, Rarity.Common);
                    player.CurrentLegs = new Armor("Leggings", 1, ArmorType.Legs, Rarity.Common);
                }
            },
            {"Mage",(player)=>
                {
                    player.Abilities.Add(new Ability() { Name = "Fireball", Damage = 2, Cost = 1, _Rarity = Rarity.Uncommon });
                    player.CurrentHelmet = new Armor("Cloth Robe Hat", 1, ArmorType.Helmet, Rarity.Common);
                    player.CurrentBody = new Armor("Cloth Robe Top", 1, ArmorType.Body, Rarity.Common);
                    player.CurrentLegs = new Armor("Cloth Robe Bottom", 1, ArmorType.Legs, Rarity.Common);
                    player.CurrentRing = new Jewlery("Ring", Rarity.Uncommon);
                }
            },
            {"Archer",(player)=>
                {
                    player.CurrentWeapon = new Weapon("Bow", 1, Rarity.Common);
                    player.Ammunition.Add(new Projectile("Arrow", 25, "Wooden", Rarity.Common));
                    player.CurrentBody = new Armor("Leather Body", 1, ArmorType.Body, Rarity.Common);
                    player.CurrentLegs = new Armor("Leather Chaps", 1, ArmorType.Legs, Rarity.Common);
                }
            },

        };

        public bool CheckInput(string input, string inputType, Player player)
        {
            CharacterUtility characterUtility = new CharacterUtility();
            var result = false;
            try
            {
                if (input == null || input.Contains(" "))
                {
                    throw new Exception();
                }
                int.TryParse(input, out int inputNum);
                if (inputType=="Main Menu")
                {
                    Functionality[Options[inputNum - 1]].Invoke(player, characterUtility, this);

                }
                if (inputType == "Conditional")
                {
                    result = Conditionals[Options[inputNum - 1]].Invoke();
                }
                if (inputType == "Classes")
                {
                    ClassesDictionary[Options[inputNum - 1]].Invoke(player);
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Could not verify the input", e);
            }
        }
        public void PrintInputOptions(string InputType)
        {
            Options.Clear();
            int count = 1;
            if (InputType == "Main Menu")
            {
                foreach (var item in Functionality)
                {
                    Console.WriteLine($"{count}: {item.Key}");
                    Options.Add(item.Key);
                    count++;
                }
            }
            if (InputType == "Conditional")
            {
                foreach (var item in Conditionals)
                {
                    Console.WriteLine($"{count}: {item.Key}");
                    Options.Add(item.Key);
                    count++;
                }
            }
        }
        public void PrintInputOptions(Dictionary<string, Action<Player>> InputType)
        {
            Options.Clear();
            int count = 1;
            List<string> options = new List<string>();
            foreach (var entry in InputType)
            {
                Console.WriteLine($"{count}: {entry.Key}"); ;
                Options.Add(entry.Key);
                count++;
            }
        }
        public void Quit(Player player)
        {
            try
            {
                SaveObject(player);
            }
            catch (Exception e)
            {

                throw new Exception("Could not save", e);
            }
            Environment.Exit(0);
        }
        public void GetInput(Player player)
        {
            CheckInput(Console.ReadLine(),"Main Menu", player);
        }
        public bool GetConditional(Player player)
        {
            return CheckInput(Console.ReadLine(), "Conditional", player);
        }
        public bool GetClasses(Player player)
        {
            return CheckInput(Console.ReadLine(), "Classes", player);
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
        public void TextColorChanger(List<Item> inputList)
        {
            foreach (var item in inputList)
            {
                // change conosole color to that color
                switch (item.GetRarity())
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
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void TextColorChanger(List<Armor> inputList)
        {
            foreach (var item in inputList)
            {
                // change conosole color to that color
                switch (item.GetRarity())
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
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void TextColorChanger(List<Projectile> inputList)
        {
            foreach (var item in inputList)
            {
                // change conosole color to that color
                switch (item.GetRarity())
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
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
