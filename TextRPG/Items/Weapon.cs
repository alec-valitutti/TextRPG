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
        public override Player UseItem(Player player)
        {
            System.Console.WriteLine($"You equipped the {Name}");
            var currentWeapon = player.CurrentWeapon;
            player.CurrentWeapon = this;
            if (currentWeapon.Name != "Nothing")
            {
                player.Inventory.Add(currentWeapon);
            }
            player.Inventory.Remove(this);
            return player;
        }
    }
}