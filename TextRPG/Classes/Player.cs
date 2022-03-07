using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Interfaces;
using TextRPG.Abilities;
using TextRPG.Classes;
using TextRPG.Items;
using TextRPG.Utilities;

namespace TextRPG
{
    [System.Serializable]
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public string _PlayerClass { get; set; } = "Human";
        public int Hitpoints { get; set; }
        public int Level { get; set; } = 0;
        public float Experience { get; set; } = 0;
        public int LevelPoints { get; set; } = 0;
        public Weapon CurrentWeapon { get; set; } = new Weapon("Nothing", 1, Rarity.Common);
        public Armor CurrentHelmet { get; set; } = new Armor() { Name = "Nothing" };
        public Armor CurrentBody { get; set; } = new Armor() { Name = "Nothing" };
        public Armor CurrentLegs { get; set; } = new Armor() { Name = "Nothing" };
        public Armor CurrentBoots { get; set; } = new Armor() { Name = "Nothing" };
        public Jewlery CurrentAmulet { get; set; } = new Jewlery() { Name = "Nothing" };
        public Jewlery CurrentRing { get; set; } = new Jewlery() { Name = "Nothing" };
        public List<Ability> Abilities { get; set; } = new List<Ability>();
        public List<Item> Inventory { get; set; } = new List<Item>();
        public List<Projectile> Ammunition { get; set; } = new List<Projectile>();
        public int Gold { get; set; } = 0;
        public Dictionary<string, int> Attributes { get; set; } = new Dictionary<string, int>()
        {
            {"Vigor", 0},
            {"Endurance", 0},
            {"Strength", 0},
            {"Agility", 0},
            {"Cold Resistance", 0},
            {"Fire Resistance", 0},
            {"Lightning Resistance", 0}
        };
        public Player()
        {

        }
        public Player(string name)
        {
            Name = name;
            Hitpoints = 10;
            CharacterUtility characterUtility = new CharacterUtility();
            _PlayerClass = characterUtility.ChooseClass(this);
        }
        public void Attack(Enemy enemy)
        {
            throw new NotImplementedException();
        }
        public void PrintPlayerInformation()
        {
            CharacterUtility characterUtility = new CharacterUtility();
            Utility utility = new Utility();
            characterUtility.PrintPlayerStatistics(this);
            utility.MessageEnder();
            characterUtility.PrintPlayerEquipment(this);
            utility.MessageEnder();
            characterUtility.PrintPlayerAttributes(this);
            utility.MessageEnder();
            characterUtility.PrintPlayerAbilities(this);
            utility.MessageEnder();
            characterUtility.PrintPlayerInventory(this);
            utility.MessageEnder();
            characterUtility.PrintPlayerAmmunition(this);
            utility.MessageEnder();
        }
        public void LevelUp()
        {
            Utility utility = new Utility();
            //print out level up points
            Console.WriteLine($"Level Points: {LevelPoints}");
            //print out dictionary
            Console.WriteLine("What would you like to level up:");
            Console.WriteLine("_________________________");
            var count = 1;
            foreach (var item in Attributes)
            {
                utility.Options.Add($"{item.Key}");
                Console.WriteLine($"{count}: {item.Key} : {item.Value}");
                count++;
            }
            //1-7
            var input = utility.GetInput();
            Attributes[input]++;
            LevelPoints -= 1;
            Console.WriteLine($"You've leveled {input} to {Attributes[input]}!");
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
            utility.SaveObject(this);
            Console.Clear();
            //input
        }
    }
}
