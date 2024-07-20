using System;
using System.Collections.Generic;

namespace AdventureQuestRPG
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
            Console.WriteLine($"{item.Name} has been added to your inventory.");
        }

        public void DisplayItems()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
                return;
            }

            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_items[i].Name} - {_items[i].Description}");
            }
        }

        public void UseItem(int index, Player player)
        {
            if (index < 0 || index >= _items.Count)
            {
                throw new Exception("Invalid item number.");
            }

            Item item = _items[index];
            _items.RemoveAt(index);

            if (item is Weapon weapon)
            {
                player.AttackPower += weapon.AttackBoost;
                Console.WriteLine($"You equipped {weapon.Name}. Attack power increased by {weapon.AttackBoost}.");
            }
            else if (item is Armor armor)
            {
                player.Defense += armor.DefenseBoost;
                Console.WriteLine($"You equipped {armor.Name}. Defense increased by {armor.DefenseBoost}.");
            }
            else if (item is Potion potion)
            {
                player.Health += potion.HealthRestore;
                Console.WriteLine($"You used {potion.Name}. Health restored by {potion.HealthRestore}.");
            }
        }

        public bool IsEmpty()
        {
            return _items.Count == 0;
        }

    }
}
