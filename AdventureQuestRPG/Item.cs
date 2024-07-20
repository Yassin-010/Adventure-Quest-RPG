namespace AdventureQuestRPG
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    public class Weapon : Item
    {
        public int AttackBoost { get; set; }

        public Weapon(string name, string description, int attackBoost)
            : base(name, description)
        {
            AttackBoost = attackBoost;
        }
    }

    public class Armor : Item
    {
        public int DefenseBoost { get; set; }

        public Armor(string name, string description, int defenseBoost)
            : base(name, description)
        {
            DefenseBoost = defenseBoost;
        }
    }

    public class Potion : Item
    {
        public int HealthRestore { get; set; }

        public Potion(string name, string description, int healthRestore)
            : base(name, description)
        {
            HealthRestore = healthRestore;
        }
    }
}
