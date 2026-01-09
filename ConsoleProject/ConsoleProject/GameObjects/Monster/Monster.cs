

public abstract class Monster : GameObject
{
    public PlayerCharacter Player { get; set; }
    
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int AttackValue { get; set; }
    public int DefenceValue { get; set; }
    public int CritValue { get; set; }
    public int CritDefValue { get; set; }
    
    
    public abstract void ChangeHealth(int value);
    public abstract void Skill();
}