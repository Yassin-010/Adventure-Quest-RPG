using System;

namespace AdventureQuestRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name? ");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 20, 10);
            Monster goblin = new Goblin("Goblin", 50, 15, 5);
            Monster bossMonster = new BossMonster("Dragon", 200, 50, 20);

            Adventure adventure = new Adventure(player);
            adventure.Start();

            Console.WriteLine("\nAdventure complete!");
        }
    }
}
