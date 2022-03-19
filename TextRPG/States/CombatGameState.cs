using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.States
{
    class CombatGameState : BaseState
    {
        public override List<string> AddOptions()
        {
            Console.WriteLine("Options:");
            return new List<string>() { "Attack", "Cast Ability", "Use Item" };
        }

        public override Player EnterState(Player player)
        {
            Util.PrintInputOptions(AddOptions());
            return Util.GetInput(player);
        }
    }
}
