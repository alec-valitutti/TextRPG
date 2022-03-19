using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Utilities;

namespace TextRPG.States
{
    class MainMenuState : BaseState
    {
        public override List<string> AddOptions()
        {
            Console.WriteLine("Options:");
            return new List<string>() { "New Game", "Load Game", "Quit" };
        }

        public override Player EnterState(Player player)
        {
            Util.PrintInputOptions(AddOptions());
            return Util.GetInput(player);
        }
    }
}
