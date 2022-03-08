using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.Items
{
    public class Projectile : Item
    {
        public float DamageMultiplier { get; set; }
        public string Type { get; set; }
        public Projectile() { }
        public Projectile(string name, Rarity rarity) : base(name, rarity) { }
        public Projectile(string name, int quantity, string type, Rarity rarity) : base($"{type} {name}", quantity, rarity)
        {
            Quantity = quantity;
            Type = type;
            switch (type)
            {
                case "Wooden":
                    DamageMultiplier = 1.0f;
                    break;
                case "Iron":
                    DamageMultiplier = 1.2f;
                    break;
                case "Steel":
                    DamageMultiplier = 1.4f;
                    break;
                default:
                    break;
            }
        }
    }
}
