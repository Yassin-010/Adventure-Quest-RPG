using System;

namespace AdventureQuestRPG
{
    public class BattleSystem
    {
        private Random _random = new Random();

        public void Attack(IBattleStates attacker, IBattleStates target)
        {
            int damage = CalculateDamage(attacker, target);
            target.Health -= damage;

            Console.WriteLine($"{attacker.Name} attacks {target.Name} for {damage} damage.");
            Console.WriteLine($"{target.Name}'s health is now {target.Health}.");

            if (target.Health <= 0)
            {
                Console.WriteLine($"\n{target.Name} has been defeated!");
                if (target is Monster)
                {
                    DropItem(attacker as Player, (Monster)target);
                }
            }
        }

        public int CalculateDamage(IBattleStates attacker, IBattleStates target)
        {
            int damage = attacker.AttackPower - target.Defense;
            if (damage < 0)
                damage = 0;

            return damage;
        }

        public void DropItem(Player player, Monster monster)
        {
            if (_random.Next(0, 100) < 25) 
            {
                Item droppedItem = null;
                int itemType = _random.Next(0, 3);

                switch (itemType)
                {
                    case 0:
                        droppedItem = new Weapon("Sword", "A sharp blade", 10);
                        break;
                    case 1:
                        droppedItem = new Armor("Shield", "A sturdy shield", 5);
                        break;
                    case 2:
                        droppedItem = new Potion("Health Potion", "Restores health", 20);
                        break;
                }

                Console.WriteLine($"{monster.Name} dropped {droppedItem.Name}!");
                player.Inventory.AddItem(droppedItem);
            }
        }
    }
}
