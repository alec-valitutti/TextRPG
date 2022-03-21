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
            var options = new List<string>();
            foreach (var item in Player.Inventory)
            {
                options.Add(item.GetName());
            }
            options.Add("Return");
            return options;
        }
        public override Player EnterState(Player player)
        {
            Player = player;
            if (player.Inventory.Count > 0)
            {
                Util.PrintInputOptions(AddOptions());
                player = Util.GetInputForItemUse(player);
            }
            else
            {
                Console.WriteLine("You have no items:");
                Util.MessageEnder();
            }
            return player;
        }
    }
}
