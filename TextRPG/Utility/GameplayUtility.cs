using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Classes;

namespace TextRPG.Utilities
{
    class GameplayUtility
    {
        public void GenerateCombatEncounter()
        {
            Enemy e = new Enemy() { Name="Thor"};
            Console.WriteLine($"you found an enemy named: {e.Name}");
        }
    }
}
