using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Interfaces;

namespace TextRPG.States
{
    public abstract class BaseState: IGameState
    {
        public string State { get; set; }
        public abstract void EnterState();
        public abstract List<string> AddOptions();
    }
}
