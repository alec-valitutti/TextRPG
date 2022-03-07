using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.Classes
{
    public class Enemy
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Damage { get; set; }
        public int Hitpoints { get; set; }
        public Enemy() { }
    }
}
