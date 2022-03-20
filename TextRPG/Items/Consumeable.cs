using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.Items
{
    class Consumeable : Item
    {
        public Consumeable() { }
        public Consumeable(string name, Rarity rarity) : base(name, rarity)
        {
            if (name != "nothing")
            {
                Quantity = 1;
            }
        }
    }
}
