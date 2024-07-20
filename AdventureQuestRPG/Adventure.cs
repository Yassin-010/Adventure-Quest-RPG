using System;
using System.Collections.Generic;

namespace AdventureQuestRPG
{
    public class Adventure
    {
        private Player _player;
        private List<Monster> _monsters;
        private BattleSystem _battleSystem;
        private Random _random;
        private List<string> _locations;
        public string CurrentLocation { get; private set; }

        public Adventure(Player player)
        {
            _player = player;
            _battleSystem = new BattleSystem();
            _random = new Random();
            _locations = new List<string> { "Forest", "Cave", "Town", "Castle" };

            _monsters = new List<Monster>
            {
                new Goblin("Goblin", 50, 15, 5),
                new Goblin("Orc", 70, 20, 10),
                new BossMonster("Dragon", 200, 50, 20)
            };

            if (_locations.Count > 0)
            {
                CurrentLocation = _locations[0];
            }
        }

        public void SetLocations(List<string> locations)
        {
            _locations = locations;
            if (_locations.Count > 0)
            {
                CurrentLocation = _locations[0];
            }
        }

        public void MoveToLocation(string newLocation)
        {
            if (_locations.Contains(newLocation))
            {
                CurrentLocation = newLocation;
                Console.WriteLine($"You have moved to: {CurrentLocation}");
            }
            else
            {
                Console.WriteLine($"Location {newLocation} does not exist.");
            }
        }

        public void Start()
        {
            bool gameRunning = true;
            while (gameRunning)
            {
                DisplayPlayerLocation();
                DisplayMenu();

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        EncounterMonster();
                        break;
                    case "2":
                        ManageInventory();
                        break;
                    case "3":
                        gameRunning = false;
                        break;
                    case "4":
                        DisplayLocations();
                        Console.Write("Enter the location you want to move to: ");
                        string location = Console.ReadLine();
                        MoveToLocation(location);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void DisplayPlayerLocation()
        {
            Console.WriteLine($"\nYou are in {CurrentLocation}.");
        }

        private void DisplayMenu()
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Encounter a monster");
            Console.WriteLine("2. Manage inventory");
            Console.WriteLine("3. End game");
            Console.WriteLine("4. Move to a new location");
            Console.Write("Enter your choice: ");
        }

        private void DisplayLocations()
        {
            Console.WriteLine("\nAvailable locations:");
            foreach (var location in _locations)
            {
                Console.WriteLine(location);
            }
        }

        private void EncounterMonster()
        {
            int monsterIndex = _random.Next(0, _monsters.Count);
            Monster monster = _monsters[monsterIndex];

            Console.WriteLine($"\nA wild {monster.Name} appears!");

            while (_player.Health > 0 && monster.Health > 0)
            {
                // Player's turn
                Console.WriteLine($"\nIt's {_player.Name}'s turn.");
                _battleSystem.Attack(_player, monster);

                if (monster.Health <= 0)
                {
                    Console.WriteLine($"\nYou defeated the {monster.Name}!");
                    break;
                }

                // Monster's turn
                Console.WriteLine($"\nIt's {monster.Name}'s turn.");
                _battleSystem.Attack(monster, _player);

                if (_player.Health <= 0)
                {
                    Console.WriteLine($"\nYou were defeated by the {monster.Name}...");
                    break;
                }
            }
        }

        private void ManageInventory()
        {
            Console.WriteLine("\nYour inventory:");
            _player.Inventory.DisplayItems();

            Console.WriteLine("\nWould you like to use an item? (yes/no)");
            string choice = Console.ReadLine().ToLower();

            if (choice == "yes")
            {
                Console.WriteLine("\nEnter the item number you want to use:");
                if (int.TryParse(Console.ReadLine(), out int itemNumber))
                {
                    try
                    {
                        _player.Inventory.UseItem(itemNumber - 1, _player);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid item number.");
                }
            }
        }
    }
}
