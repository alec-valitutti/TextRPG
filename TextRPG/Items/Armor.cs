namespace TextRPG.Items
{
    public class Armor : Item
    {
        public int ArmorValue { get; set; }
        public ArmorType ArmorPiece { get; set; }
        public Armor() {}
        public Armor(string name, int armorRating,ArmorType armorPiece, Rarity rarity) : base($"{name} {armorPiece}", rarity)
        {
            ArmorValue = armorRating;
            ArmorPiece = armorPiece;
            if (name != "nothing")
            {
                Quantity = 1;
            }
        }
    }
}