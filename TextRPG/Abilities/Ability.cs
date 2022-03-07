using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.Abilities
{
    [System.Serializable]
    public class Ability
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Damage { get; set; }
        public virtual void UseAbility()
        {
            Console.WriteLine($"You cast a {Name}, dealing {Damage} Damage.");
        }
    }
}
