using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Interfaces;
using TextRPG.States;
using TextRPG.Utilities;

namespace TextRPG
{
    public class Game
    {
        public Dictionary<string, IGameState> GameStates { get; set; } = new Dictionary<string, IGameState>()
        {
            {"Main Menu", new MainMenuState() },{ "Idle", new IdleGameState()},{ "Combat", new CombatGameState()}
        };
        public Player Player { get; set; } = new Player();
        internal IGameState CurrentGameState { get; set; }
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
            CurrentGameState = GameStates["Main Menu"];
            CurrentGameState.EnterState();
            utility.PrintInputOptions(CurrentGameState.AddOptions());
            var input = utility.GetInput(Player);
        }
        public void Gameplay()
        {
            Utility utility = new Utility();
            CurrentGameState = GameStates["Idle"];
            utility.PrintInputOptions(CurrentGameState.AddOptions());
            utility.GetInput(Player);

        }
    }
}
