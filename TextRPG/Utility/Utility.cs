using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

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
            if (obj ==null)
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
    }
}
