using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Utilities;

namespace TextRPG.States
{
    class IdleGameState : BaseState
    {
        public override List<string> AddOptions()
        {
            Console.WriteLine("Options:");
            return new List<string>() { "Explore", "Check Stats", "Items", "Options" };
        }
        public override Player EnterState(Player player)
        {
            Util.PrintInputOptions(AddOptions());
            return Util.GetInput(player);
        }
    }
}
