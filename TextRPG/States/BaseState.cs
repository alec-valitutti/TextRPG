using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Interfaces;

namespace TextRPG.States
{
    public abstract class BaseState : IGameState
    {
        public string State { get; set; }
        public abstract Player EnterState(Player player);
        public abstract List<string> AddOptions();
    }
}
