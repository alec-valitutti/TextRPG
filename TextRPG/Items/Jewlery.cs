namespace TextRPG.Items
{
    public class Jewlery : Item
    {
        public Jewlery() { }
        public Jewlery(string name)
        {
            Name = name;
        }
        public Jewlery(string name, Rarity rarity) { Name = name;_Rarity = rarity; }
    }
}