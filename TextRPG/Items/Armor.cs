namespace TextRPG.Items
{
    public class Armor : Item
    {
        public int ArmorValue { get; set; }
        public Armor() {}
        public Armor(string name, int damage, Rarity rarity) : base(name, rarity)
        {
            ArmorValue = damage;
            if (name != "nothing")
            {
                Quantity = 1;
            }
        }
    }
}