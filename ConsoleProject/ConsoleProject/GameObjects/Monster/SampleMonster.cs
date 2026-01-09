

public class SampleMonster : Monster
{
    public SampleMonster() => Init();
    
    private void Init()
    {
        Symbol = '◇';
        Name = "Temp";
        Health = 100;
        MaxHealth = 100;
        AttackValue = 10;
        DefenceValue = 0;
        CritValue = 10;
        CritDefValue = 10;
    }

    public override void ChangeHealth()
    {
        
    }
    
    
    public override void Skill()
    {
        
    }
}