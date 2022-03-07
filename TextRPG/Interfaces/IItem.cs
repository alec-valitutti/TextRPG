using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.Interfaces
{
    public interface IItem
    {
        void UseItem();
        void AddItemToInventory();
    }
}
