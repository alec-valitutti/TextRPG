using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.States
{
    class IdleGameState : BaseState
    {
        public override List<string> AddOptions()
        {
            return new List<string>() {"Explore","Check Stats","Use Item","Options" };
        }

        public override void EnterState()
        {
            Console.WriteLine("Entered Idle Game State");
        }
    }
}
