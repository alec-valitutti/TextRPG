using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.States
{
    class CombatGameState : BaseState
    {
        public override List<string> AddOptions()
        {
            return new List<string>() { "Attack", "Cast Ability", "Use Item" };
        }

        public override void EnterState()
        {
            throw new NotImplementedException();
        }
    }
}
