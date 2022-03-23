using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Utilities;

namespace TextRPG.States
{
    class IdleGameState : BaseState
    {
        public IdleGameState() { }
        public IdleGameState(Player player) { Player = player ?? throw new ArgumentNullException(nameof(player)); }
        public override List<string> AddOptions()
        {
            Console.WriteLine("Options:");
            var options = new List<string>() { "Explore", "Check Stats", "Items", "Options" };
            if (Player.LevelPoints >0)
            {
                options.Insert(0, "Level Up");
            }
            return options;
        }
        public override Player EnterState(Player player)
        {
            Player = player;
            Util.PrintInputOptions(AddOptions());
            return Util.GetInput(player);
        }
    }
}
