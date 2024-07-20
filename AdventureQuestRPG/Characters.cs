namespace AdventureQuestRPG
{
    public abstract class Character : IBattleStates
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }

        public Character(string name, int health, int attackPower, int defense)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            Defense = defense;
        }
    }

    public class Player : Character
    {
        public Inventory Inventory { get; set; }

        public Player(string name, int health, int attackPower, int defense)
            : base(name, health, attackPower, defense)
        {
            Inventory = new Inventory();
        }
    }

    public abstract class Monster : Character
    {
        public Monster(string name, int health, int attackPower, int defense)
            : base(name, health, attackPower, defense)
        {
        }
    }

    public class Goblin : Monster
    {
        public Goblin(string name, int health, int attackPower, int defense)
            : base(name, health, attackPower, defense)
        {
        }
    }

    public class BossMonster : Monster
    {
        public BossMonster(string name, int health, int attackPower, int defense)
            : base(name, health, attackPower, defense)
        {
        }
    }
}
