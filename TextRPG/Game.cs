using System.Collections.Generic;
using TextRPG.Interfaces;
using TextRPG.States;

namespace TextRPG
{
    public class Game
    {
        public Dictionary<states, IGameState> GameStates { get; set; } = new Dictionary<states, IGameState>()
        {
            {states.MainMenu, new MainMenuState() },{states.Idle, new IdleGameState()},{ states.Combat, new CombatGameState()}
        };
        public Player Player { get; set; } = new Player();
        internal IGameState CurrentGameState { get; set; }
        public void Gameplay()
        {
            CurrentGameState = GameStates[states.MainMenu];
            Player = CurrentGameState.EnterState(Player);
            while (true)
            {

                CurrentGameState = GameStates[states.Idle];
                Player = CurrentGameState.EnterState(Player);
            }
        }
    }
    public enum states
    {
        MainMenu,
        Idle,
        Combat
    }
}
