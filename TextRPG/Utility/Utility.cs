using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using TextRPG.Items;

namespace TextRPG.Utilities
{
    public class Utility
    {
        public List<string> Options { get; set; } = new List<string>();
        public static string Path = "..\\..\\..\\";

        public bool CheckInput(string input, out string val)
        {
            try
            {
                if (input == null || input.Contains(" "))
                {
                    throw new Exception();
                }
                if (Options == null || Options.Count == 0)
                {
                    throw new Exception();
                }
                int.TryParse(input, out int inputNum);
                if (inputNum <= Options.Count && inputNum != 0)
                {
                    val = Options[inputNum - 1];
                    return true;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Could not verify the input", e);
            }
        }
        public void PrintInputOptions()
        {
            try
            {
                if (Options.Count == 0 || Options == null)
                {
                    throw new Exception();
                }
                for (int i = 0; i < Options.Count; i++)
                {
                    Console.WriteLine((i + 1).ToString() + ": " + Options[i]);
                }
            }
            catch (Exception e)
            {

                throw new Exception("Could not write out options!", e);
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
        public string GetInput()
        {
            bool isTrue = false;
            var output = "";
            while (!isTrue)
            {
                try
                {
                    isTrue = CheckInput(Console.ReadLine(), out string input);
                    output = input;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid input:");
                    PrintInputOptions();
                }
            }
            Console.Clear();
            return output;
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
