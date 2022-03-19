using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Interfaces;

namespace TextRPG.Items
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Rarity _Rarity { get; set; }
        public Item() { }
        public Item(string name, Rarity rarity) { Name = name; _Rarity = rarity; }
        public Item(string name, int quantity, Rarity rarity)
            { Quantity = quantity; Name = name; _Rarity = rarity; }
        public void UseItem()
        {
            Console.WriteLine($"You used {Name}");
        }

    }
}
