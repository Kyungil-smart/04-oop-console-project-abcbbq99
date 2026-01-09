

public class BattleManager
{
    public PlayerCharacter player { get; set; }
    public Monster monster { get; set; }
    
    public MonsterList _MonsterList = new MonsterList();
    public int _damage = 0;

    public void AddMonster(Monster monster)
    {
        _MonsterList.Add(monster, monster.TakeDamage());
    }
}