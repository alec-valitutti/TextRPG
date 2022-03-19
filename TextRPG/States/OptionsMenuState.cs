using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Utilities;

namespace TextRPG.States
{
    class OptionsMenuState : BaseState
    {
        public override List<string> AddOptions()
        {
            Console.WriteLine("Options:");
            return new List<string>() { "Save Game", "Main Menu", "Return" };
        }

        public override Player EnterState(Player player)
        {
            Util.PrintInputOptions(AddOptions());
            return Util.GetInput(player);
        }
    }
}
