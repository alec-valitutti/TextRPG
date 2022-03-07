namespace TextRPG.Items
{
    public class Armor : Item
    {
        public int ArmorValue { get; set; }
        public Armor() {
        }
        public Armor(string name, int damage) : base(name)
        {
            ArmorValue = damage;
            if (name != "nothing")
            {
                Quantity = 1;
            }
        }
    }
}