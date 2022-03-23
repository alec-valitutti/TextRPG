using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Interfaces;
using TextRPG.Utilities;

namespace TextRPG.States
{
    public abstract class BaseState : IGameState
    {
        public string State { get; set; }
        public Utility Util { get; set; } = new Utility();
        public Player Player { get; set; }
        public BaseState() { }
        public BaseState(Player player) { Player = player ?? throw new ArgumentNullException(nameof(player)); }
        public CharacterUtility CharacterUtil { get; set; } = new CharacterUtility();
        public abstract Player EnterState(Player player);
        public abstract List<string> AddOptions();
    }
}
