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
        public void Gameplay()
        {
            CurrentGameState = GameStates["Main Menu"];
            Player = CurrentGameState.EnterState(Player);
        }
    }
}
