using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Utilities;

namespace TextRPG
{
    public class Game
    {

        public Player Player { get; set; }
        public void Play()
        {
            Console.WriteLine("Welcome to the game");

            MainMenu();
            while (true)
            {
                Gameplay();
            }
        }
        public void MainMenu()
        {
            Utility utility = new Utility();
            CharacterUtility characterUtility = new CharacterUtility();
            Console.WriteLine("Options:");
            //utility.Options = new List<string>() { "New Game", "Load Game", "Quit" };
            utility.PrintInputOptions(new List<string>() { "New Game", "Load Game", "Quit" });
            var input = "";
            input = utility.GetInput();
            switch (input)
            {
                case "New Game":
                    Player = characterUtility.CreateCharacter();
                    break;
                case "Load Game":
                    try
                    {
                        Player = utility.LoadPlayer();
                        if (Player == null) throw new Exception();
                        Player.PrintPlayerInformation();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No save data found, would you like to create a new character?");
                        //utility.Options = new List<string>() { "Yes", "No" };
                        utility.PrintInputOptions(new List<string>() { "Yes", "No" });
                        //utility.CheckInput(Console.ReadLine(), out input);
                        input = utility.GetInput();
                        if (input == "1")
                        {
                            Player = characterUtility.CreateCharacter();
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                case "Quit":
                    utility.Quit(Player);
                    break;
                default:
                    break;
            }
        }
        public void Gameplay()
        {
            Utility utility = new Utility();
            //utility.Options = new List<string>() { "Explore", "Check Stats", "Quit" };
            if (Player.LevelPoints > 0)
            {
                utility.Options.Insert(2, "Level Up");
            }
            if (Player.Inventory.Count > 0)
            {
                utility.Options.Insert(2, "Use Item"
                    );
                
            }
            utility.PrintInputOptions(new List<string>() { "Explore", "Check Stats", "Quit" });
            var input = utility.GetInput();
            switch (input)
            {
                case "Explore":
                    GameplayUtility gameplayUtility = new GameplayUtility();
                    gameplayUtility.GenerateCombatEncounter();
                    break;
                case "Check Stats":
                    Player.PrintPlayerInformation();
                    break;
                case "Quit":
                    utility.Quit(Player);
                    break;
                case "Level Up":
                    Player.LevelUp();
                    break;
                case "Use Item":
                        Player.UseItem();
                    break;
                default:
                    break;
            }
        }
    }
}
