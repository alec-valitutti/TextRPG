using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Items;

namespace TextRPG.Interfaces
{
    public interface IItem
    {
        Player UseItem(Player player);
        string GetName();
        int GetQuantity();
        int IncrementQuantity(int number);
        Item GetItem();
    }
}
