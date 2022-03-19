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
            return new List<string>() { "Explore", "Check Stats", "Use Item", "Main Menu" };
        }
        public override Player EnterState(Player player)
        {
            Utility utility = new Utility();
            utility.PrintInputOptions(AddOptions());
            return utility.GetInput(player);
        }
    }
}
