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
        public Item(string name) { Name = name; }
        public Item(string name, int quantity) { Quantity = quantity; Name = name; }
        public void AddItemToInventory()
        {
        }
        public void UseItem()
        {
        }
        public string GetRarity()
        {
            return _Rarity.ToString();
        }
    }
}
