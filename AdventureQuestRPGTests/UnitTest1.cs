using AdventureQuestRPG;

namespace AdventureQuestRPGTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestAttack_ReduceEnemyHealth()
        {
            // Arrange
            Player hero = new Player("Hero", 100, 20, 10);
            Monster goblin = new Goblin("Goblin", 50, 15, 5);
            BattleSystem battleSystem = new BattleSystem();

            // Act
            battleSystem.Attack(hero, goblin);

            // Assert
            Assert.True(goblin.Health < 50);
        }

        [Fact]
        public void TestAttack_ReducePlayerHealth()
        {
            // Arrange
            Player hero = new Player("Hero", 100, 20, 10);
            Monster goblin = new Goblin("Goblin", 50, 15, 5);
            BattleSystem battleSystem = new BattleSystem();

            // Act
            battleSystem.Attack(goblin, hero);

            // Assert
            Assert.True(hero.Health < 100);
        }

        [Fact]
        public void TestBattle_Result_EnsureWinnerHealthGreaterThanZero()
        {
            // Arrange
            Player hero = new Player("Hero", 100, 20, 10);
            Monster goblin = new Goblin("Goblin", 50, 15, 5);
            BattleSystem battleSystem = new BattleSystem();

            // Act
            ExecuteBattle(hero, goblin);

            // Assert
            Assert.True(hero.Health > 0 || goblin.Health > 0);
        }

        private void ExecuteBattle(Player hero, Monster enemy)
        {
            BattleSystem battleSystem = new BattleSystem();

            while (hero.Health > 0 && enemy.Health > 0)
            {
                battleSystem.Attack(hero, enemy);

                if (enemy.Health <= 0)
                {
                    break;
                }

                battleSystem.Attack(enemy, hero);

                if (hero.Health <= 0)
                {
                    break;
                }
            }
        }


        


        [Fact]
        public void MoveToNewLocationTest()
        {
            Player player = new Player("Hero", 100, 20, 10);
            Adventure adventure = new Adventure(player);

            List<string> locations = new List<string> { "Forest", "Cave", "Town" };
            adventure.SetLocations(locations);

            string initialLocation = adventure.CurrentLocation;
            adventure.MoveToLocation("Cave");

            Assert.NotEqual(initialLocation, adventure.CurrentLocation);
            Assert.Equal("Cave", adventure.CurrentLocation);
        }
    }
}