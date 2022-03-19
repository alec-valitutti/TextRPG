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
        public abstract Player EnterState(Player player);
        public abstract List<string> AddOptions();
    }
}
