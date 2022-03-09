using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Utilities;

namespace TextRPG
{
    public class Game
    {

        public Player Player { get; set; } = new Player();
        public void Play()
        {
            Console.WriteLine("Welcome to the game");

            MainMenu();
        }
        public void MainMenu()
        {
            Utility utility = new Utility();
            Console.WriteLine("Options:");
            utility.PrintInputOptions("Main Menu");
            utility.GetInput(Player);
        }
        public void Gameplay()
        {
            //Player.PrintPlayerInformation();
            //Utility utility = new Utility();
            //utility.Options = new List<string>() { "Explore", "Check Stats", "Quit" };
            //if (Player.LevelPoints > 0)
            //{
            //    utility.Options.Insert(2, "Level Up");
            //}
            //if (Player.Inventory.Count > 0)
            //{
            //    utility.Options.Insert(2, "Use Item"
            //        );

            //}
            //utility.PrintInputOptions("Gameplay");
            //utility.GetInput();
            //switch (input)
            //{
            //    case "Explore":
            //        GameplayUtility gameplayUtility = new GameplayUtility();
            //        gameplayUtility.GenerateCombatEncounter();
            //        break;
            //    case "Check Stats":
            //        Player.PrintPlayerInformation();
            //        break;
            //    case "Quit":
            //        utility.Quit(Player);
            //        break;
            //    case "Level Up":
            //        Player.LevelUp();
            //        break;
            //    case "Use Item":
            //        Player.UseItem();
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
