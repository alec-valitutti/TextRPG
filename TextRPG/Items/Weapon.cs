namespace TextRPG.Items
{
    public class Weapon : Item
    {
        public int DamageValue { get; set; }

        public Weapon() { }
        public Weapon(string name, int damage) : base(name)
        {
            DamageValue = damage;
            if (name != "nothing")
            {
                Quantity = 1;
            }
        }
        public Weapon(string name, int damage, Rarity rarity) : base(name)
        {
            DamageValue = damage;
            if (name != "nothing")
            {
                Quantity = 1;
            }
            _Rarity = rarity;
        }
    }
}