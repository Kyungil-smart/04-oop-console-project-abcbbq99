

public class SampleMonster : Monster, IInteractable
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

    public override void ChangeHealth(int value)
    {
        Health += value;
        if (value > 0)
        {
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
                Debug.LogWarning($"{Name} : 회복량 초과 - 체력 조정");
            }
            else
            {
                Debug.Log($"{Name} : {value} 회복");
            }
        }
        else if(value < 0)
        {
            Debug.Log($"{Name} : {(-1)*value} 피해");
        
            if (Health <= 0)
            {
                Debug.Log($"{Name} : 사망");
            }
        }
    }
    
    public void Interact(PlayerCharacter player)
    {
        player.AddBattleList(this);
        SceneManager.isSceneReset = false;
        Debug.LogWarning("씬 초기화 중지");
        SceneManager.Change("Battle");
    }
    
    public override void Skill()
    {
        MonsterSampleAttackSkill Attack = new MonsterSampleAttackSkill();
        Attack.Effect();
    }
}