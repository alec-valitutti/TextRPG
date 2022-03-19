using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.Interfaces
{
    public interface IGameState
    {
        public Player EnterState(Player player);
        public List<string> AddOptions();
    }
}
