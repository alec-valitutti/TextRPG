namespace TextRPG.Items
{
    public class Weapon : Item
    {
        public int DamageValue { get; set; }
        public Weapon() { }
        public Weapon(string name, int damage, Rarity rarity) : base(name, rarity)
        {
            DamageValue = damage;
            if (name != "nothing")
            {
                Quantity = 1;
            }
        }
        public override void UseItem()
        {
            System.Console.WriteLine($"You equipped the {Name}");
        }
    }
}