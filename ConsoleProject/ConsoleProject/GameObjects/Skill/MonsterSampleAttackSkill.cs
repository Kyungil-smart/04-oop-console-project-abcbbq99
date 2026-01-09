

public class MonsterSampleAttackSkill : Skill
{
    public MonsterSampleAttackSkill() => Init();
    
    private void Init()
    {
        Name = "Attack";
        Power = 1;
    }

    public override void Effect()
    {
        int value = Monster.AttackValue * Power;
        Player.ChangeHealth((-1) * value);
    }
}