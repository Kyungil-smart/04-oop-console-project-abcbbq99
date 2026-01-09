

public class PlayerSampleAttackSkill : Skill, IInteractable
{
    public PlayerSampleAttackSkill() => Init();
    
    private void Init()
    {
        Name = "Attack";
        Power = 1;
    }

    public void Interact(PlayerCharacter player)
    {
        Player.AddSkill(this);
    }

    public override void Effect()
    {
        Monster.ChangeHealth((-1) * Player.AttackValue * Power);
    }
}