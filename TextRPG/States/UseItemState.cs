using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.States
{
    class UseItemState : BaseState
    {
        internal Player Player;
        public override List<string> AddOptions()
        {
            Console.WriteLine("Options:");
            var options = new List<string>();
            foreach (var item in Player.Inventory)
            {
                options.Add(item.Name);
            }
            options.Add("Return");
            return options;
        }
        public override Player EnterState(Player player)
        {
            Player = player;
            Util.PrintInputOptions(AddOptions());
            player = Util.GetInputForItemUse(player);
            return player;
        }
    }
}
