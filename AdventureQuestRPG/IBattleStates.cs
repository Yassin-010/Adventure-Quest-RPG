namespace AdventureQuestRPG
{
    public interface IBattleStates
    {
        string Name { get; set; }
        int Health { get; set; }
        int AttackPower { get; set; }
        int Defense { get; set; }
    }
}
