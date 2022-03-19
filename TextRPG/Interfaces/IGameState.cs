using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.Interfaces
{
    public interface IGameState
    {
        public void EnterState();
        public List<string> AddOptions();
    }
}
