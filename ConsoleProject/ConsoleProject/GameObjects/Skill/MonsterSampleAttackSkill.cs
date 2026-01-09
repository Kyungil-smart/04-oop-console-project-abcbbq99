

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
        Player.ChangeHealth((-1) * Monster.AttackValue * Power);
    }
}