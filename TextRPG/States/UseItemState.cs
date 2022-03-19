using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.States
{
    class UseItemState : BaseState
    {
        public override List<string> AddOptions()
        {
            Console.WriteLine("Options:");
            return new List<string>() { "Return" };
        }
        public override Player EnterState(Player player)
        {
            Util.PrintInputOptions(AddOptions());
            return Util.GetInput(player);
        }
    }
}
