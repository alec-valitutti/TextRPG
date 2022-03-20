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
        public Item() {}
        public Item(string name, Rarity rarity) { Name = name; _Rarity = rarity; }
        public Item(string name, int quantity, Rarity rarity)
        { Quantity = quantity; Name = name; _Rarity = rarity; }
        public virtual Player UseItem(Player player)
        {
            Console.WriteLine($"You used {Name}");
            player.Inventory.Remove(this);
            return player;
        }
        public string GetName()
        {
            return Name;
        }
        public int GetQuantity()
        {
            return Quantity;
        }
        public int IncrementQuantity(int number)
        {
            Quantity += number;
            return Quantity;
        }
        public Item GetItem()
        {
            return this;
        }
        //How do I let items have unique functionality without having to write an action for each item?
    }
}
